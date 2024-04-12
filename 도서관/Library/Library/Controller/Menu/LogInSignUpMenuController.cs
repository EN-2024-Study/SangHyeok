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

        public override void Run()
        {
            base.menuValue = 0;
            bool isMenuSelect = true;
            bool isNoBack = true;
            string[] menuString = base.DecideMenuType((int)Constants.Type.LogInSignUp);

            while (isMenuSelect)
            {
                menuScreen.PrintMenu(menuString, menuValue, coordinate);
                isMenuSelect = SelectMenu();
                if (menuValue > 1)
                    menuValue = 1;
            }

            switch (menuValue)
            {
                case (int)Constants.LogInMenu.GoBack:
                    ModeMenuController modeMenuController = new ModeMenuController();
                    modeMenuController.Run();
                    break;
                case (int)Constants.LogInMenu.LogIn:
                    isNoBack = accountTask.LogIn((int)Constants.LibraryMode.User);
                    break;
                case (int)Constants.LogInMenu.SignUp:   
                    isNoBack = ((UserAccountTaskController)accountTask).SignUp();
                    break;
            }

            if (!isNoBack)
                Run();
        }
    }
}
