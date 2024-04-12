using Library.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Controller
{
    public class ManagerMenuController : MenuController
    {
        private Tuple<int, int> libraryMenuCoordinate;
        private AccountInfoMenuController accountInfoMenuController;

        public ManagerMenuController() : base()
        {
            this.libraryMenuCoordinate = new Tuple<int, int>(coordinate.Item1 + 20, coordinate.Item2 - 10);
            this.accountInfoMenuController = new AccountInfoMenuController((int)Constants.LibraryMode.Manager);
        }

        public override void Run()
        {
            base.menuValue = 0;
            bool isMenuSelect = true;
            string[] menuString = base.DecideMenuType((int)Constants.Type.Manager);

            while (isMenuSelect)
            {
                menuScreen.PrintMenu(menuString, menuValue, libraryMenuCoordinate);
                isMenuSelect = base.SelectMenu();
                if (menuValue > 5)
                    menuValue = 5;
            }

            switch (menuValue)  // 기능 구현
            {
                case (int)Constants.ManagerMenu.BookSearch:

                    break;
                case (int)Constants.ManagerMenu.BookAdd:

                    break;
                case (int)Constants.ManagerMenu.BookDelete:

                    break;
                case (int)Constants.ManagerMenu.BookModify:

                    break;
                case (int)Constants.ManagerMenu.UserControl:
                    accountInfoMenuController.Run();
                    Run();
                    break;
                case (int)Constants.ManagerMenu.RentalHistory:

                    break;
            }

        }
    }
}
