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
        AccountInfoMenuController accountInfoMenu;

        public override void Run()
        {
            menuValue = 0;
            bool isMenuSelect = true;

            while (isMenuSelect)
            {
                menuScreen.PrintLibraryMenu(menuValue, (int)Constants.ModeMenu.ManagerMode);
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
                    accountInfoMenu = new AccountInfoMenuController((int)Constants.LibraryMode.Manager);
                    accountInfoMenu.Run();
                    Run();
                    break;
                case (int)Constants.ManagerMenu.RentalHistory:

                    break;
            }

        }
    }
}
