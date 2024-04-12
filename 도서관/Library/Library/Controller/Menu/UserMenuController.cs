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
        private AccountInfoMenuController accountInfoMenuController;

        public UserMenuController() : base()
        {
            this.accountInfoMenuController = new AccountInfoMenuController((int)Constants.LibraryMode.User);
        }

        public override bool Run()
        {
            base.menuValue = 0;
            bool isMenuSelect = true;
            bool isBack = false;
            string[] menuString = base.DecideMenuType((int)Constants.MenuType.User);

            while (isMenuSelect)
            {
                base.menuScreen.PrintMenu(menuString, menuValue, false);
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
                    isBack = accountInfoMenuController.Run();
                    break;
            }

            if (isBack)
                return true;
            return false;
        }
    }
}
