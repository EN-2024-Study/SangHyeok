using Library.Controller.Task;
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
        private BookController bookController;

        public UserMenuController() : base()
        {
            this.accountInfoMenuController = new AccountInfoMenuController((int)Constants.LibraryMode.User);
            this.bookController = new BookController();
            base.menuString = base.DecideMenuType((int)Constants.MenuType.User);
        }

        public override bool Run()
        {
            Console.Clear();
            base.menuValue = 0;
            bool isMenuSelect = true;
            bool isBack = false;

            while (isMenuSelect)
            {
                base.menuScreen.PrintMenu(menuString, menuValue, false);
                isMenuSelect = SelectMenu();
                if (menuValue > 5)
                    menuValue = 5;
            }
           
            switch (menuValue)  
            {
                case (int)Constants.UserMenu.GoBack:
                    return true;
                case (int)Constants.UserMenu.InfoModify:
                    isBack = accountInfoMenuController.Run();
                    break;
                default:
                    isBack = bookController.ControlUserBook(menuValue);
                    break;
            }

            if (isBack)
                return true;
            return false;
        }
    }
}
