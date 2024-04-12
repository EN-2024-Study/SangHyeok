using Library.Controller.Task;
using Library.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Controller.Menu
{
    public class SignUpMenuController : MenuController
    {
        public override bool Run()
        {
            base.menuValue = 0;
            bool isMenuSelect = true;
            bool isBack = false;
            string[] menuString = base.DecideMenuType((int)Constants.MenuType.SignUp);

            base.menuScreen.EraseMenu();
            while (isMenuSelect)
            {
                menuScreen.PrintMenu(menuString, menuValue);
                isMenuSelect = SelectMenu();
                if (menuValue > 6)
                    menuValue = 6;
            }

            switch (menuValue)
            {
                case (int)Constants.SignUpMenu.GoBack:
                    return true;
                case (int)Constants.SignUpMenu.Id:
                case (int)Constants.SignUpMenu.Password:
                case (int)Constants.SignUpMenu.PasswordCheck:
                case (int)Constants.SignUpMenu.Name:
                case (int)Constants.SignUpMenu.Age:
                case (int)Constants.SignUpMenu.PhoneNumber:
                case (int)Constants.SignUpMenu.Address:

                    break;
            }

            if (isBack)
                return true;
            return false;
        }
    }
}
