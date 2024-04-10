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
        public override void Run()
        {
            menuValue = 0;
            bool isMenuSelect = true;

            while (isMenuSelect)
            {
                menuScreen.PrintLibraryMenu(menuValue, (int)Constants.Type.UserManager);
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

                    break;
            }
        }
    }
}
