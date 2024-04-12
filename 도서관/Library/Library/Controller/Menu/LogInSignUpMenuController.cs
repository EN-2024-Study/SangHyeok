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
        private AccountTaskController accountTask;
        public LogInSignUpMenuController() : base()
        {
            this.accountTask = new UserAccountTaskController();
        }

        public override bool Run()
        {
            base.menuValue = 0;
            bool isMenuSelect = true;
            bool isBack = false;
            string[] menuString = base.DecideMenuType((int)Constants.Type.LogInSignUp);

            base.menuScreen.EraseMenu();
            while (isMenuSelect)
            {
                menuScreen.PrintMenu(menuString, menuValue);
                isMenuSelect = SelectMenu();
                if (menuValue > 1)
                    menuValue = 1;
            }

            switch (menuValue)
            {
                case (int)Constants.LogInMenu.GoBack:
                    return true;
                case (int)Constants.LogInMenu.LogIn:
                    isBack = accountTask.LogIn((int)Constants.LibraryMode.User);
                    break;
                case (int)Constants.LogInMenu.SignUp:
                    isBack = ((UserAccountTaskController)accountTask).SignUp();
                    break;
            }

            if (isBack)
                return true;
            return false;
        }
    }
}
