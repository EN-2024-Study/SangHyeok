using Library.Controller.Menu;
using Library.Controller.Task;
using Library.Utility;
using Library.View;
using System;
using System.Collections.Generic;

namespace Library.Controller
{
    public class UserMenuController : MenuController
    {
        private AccountInfoMenuController accountInfoMenuController;
        private BookSearchMenuController bookSearchMenuController;

        public UserMenuController() : base()
        {
            this.accountInfoMenuController = new AccountInfoMenuController((int)Constants.LibraryMode.User);
            this.bookSearchMenuController = new BookSearchMenuController();
            base.menuString = base.DecideMenuType((int)Constants.MenuType.User);
        }

        public override bool Run()
        {
            Console.Clear();
            base.menuValue = 0;
            bool isBack = false;
            bool isMenuSelect = true;

            while (isMenuSelect)
            {
                base.menuScreen.PrintMenu(menuString, menuValue, false);
                isMenuSelect = SelectMenu();
                if (menuValue > 6)
                    menuValue = 6;
            }


            switch (menuValue)
            {
                case (int)Constants.UserMenu.GoBack:
                    return true;
                case (int)Constants.UserMenu.BookSearch:
                    isBack = bookSearchMenuController.Run();
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
                Run();
            return false;
        }
    }
}
