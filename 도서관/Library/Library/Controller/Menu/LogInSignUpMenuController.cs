using Library.Controller.Menu;
using Library.Controller.Task;
using Library.Utility;
using Library.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Controller
{
    public class LogInSignUpMenuController : MenuController
    {
        private LogInMenuController logInMenu;
        private SignUpMenuController signUpMenu;

        public LogInSignUpMenuController() : base()
        {
            this.logInMenu = new LogInMenuController((int)Constants.LibraryMode.User);
            this.signUpMenu = new SignUpMenuController();
            base.menuString = base.DecideMenuType((int)Constants.MenuType.LogInSignUp);
        }

        public override bool Run()
        {
            base.menuValue = 0;
            bool isMenuSelect = true;
            bool isBack = false;

            base.menuScreen.EraseMenu();
            while (isMenuSelect)
            {
                menuScreen.PrintMenu(menuString, menuValue, false);
                isMenuSelect = SelectMenu();
                if (menuValue > 1)
                    menuValue = 1;
            }

            switch (menuValue)
            {
                case (int)Constants.LogInSigInMenu.GoBack:
                    return true;
                case (int)Constants.LogInSigInMenu.LogIn:
                    isBack = logInMenu.Run();
                    break;
                case (int)Constants.LogInSigInMenu.SignUp:
                    isBack = signUpMenu.Run();
                    break;
            }

            if (isBack)
                return true;
            return false;
        }
    }
}
