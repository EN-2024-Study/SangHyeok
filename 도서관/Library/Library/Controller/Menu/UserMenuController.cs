using Library.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Controller
{
    public class UserMenuController : MenuController
    {
        private Tuple<int, int> libraryMenuCoordinate;
        private AccountInfoMenuController accountInfoMenuController;

        public UserMenuController() : base()
        {
            this.libraryMenuCoordinate = new Tuple<int, int>(coordinate.Item1 + 20, coordinate.Item2 - 10);
            this.accountInfoMenuController = new AccountInfoMenuController((int)Constants.LibraryMode.User);
        }

        public override void Run()
        {
            base.menuValue = 0;
            bool isMenuSelect = true;
            string[] menuString = base.DecideMenuType((int)Constants.Type.User);

            while (isMenuSelect)
            {
                base.menuScreen.PrintMenu(menuString, menuValue, libraryMenuCoordinate);
                isMenuSelect = SelectMenu();
                if (menuValue > 5)
                    menuValue = 5;
            }

            switch(menuValue)  // 기능 구현
            {
                case (int)Constants.UserMenu.BookSearch:

                    break;
                case (int)Constants.UserMenu.BookRental:

                    break;
                case (int)Constants.UserMenu.BookRentalHistory:

                    break;
                case (int)Constants.UserMenu.BookReturn:

                    break;
                case (int)Constants.UserMenu.BookReturnHistory:

                    break;
                case (int)Constants.UserMenu.InfoModify:
                    accountInfoMenuController.Run();
                    Run();
                    break;
            }
        }
    }
}
