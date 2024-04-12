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
        private AccountInfoMenuController accountInfoMenuController;

        public ManagerMenuController() : base()
        {
            this.accountInfoMenuController = new AccountInfoMenuController((int)Constants.LibraryMode.Manager);
        }

        public override bool Run()
        {
            Console.Clear();
            base.menuValue = 0;
            bool isMenuSelect = true;
            bool isBack = false;
            string[] menuString = base.DecideMenuType((int)Constants.MenuType.Manager);

            while (isMenuSelect)
            {
                menuScreen.PrintMenu(menuString, menuValue, false);
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
                    isBack = accountInfoMenuController.Run();
                    break;
                case (int)Constants.ManagerMenu.RentalHistory:

                    break;
            }

            if (isBack)
                return true;
            return false;
        }
    }
}
