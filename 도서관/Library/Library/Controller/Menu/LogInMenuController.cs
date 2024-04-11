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
    public class LogInMenuController : MenuController
    {
        private int modeValue;
        private ModeMenuController modeMenuController;
        private AccountTaskController accountTask;

        public LogInMenuController(int modeValue) : base()
        {
            this.modeValue = modeValue;
            this.accountTask = new UserAccountTaskController();
        }

        public override void Run()
        {
            menuValue = 0;
            bool isMenuSelect = true;
            bool isNoBack = true;

            while (isMenuSelect)
            {
                menuScreen.PrintMenu(menuValue, (int)Constants.Type.LogInSignUp, coordinate);
                isMenuSelect = SelectMenu();
                if (menuValue > 1)
                    menuValue = 1;
            }

            switch (menuValue)
            {
                case (int)Constants.LogInMenu.GoBack:
                    modeMenuController = new ModeMenuController();
                    modeMenuController.Run();
                    break;
                case (int)Constants.LogInMenu.LogIn:
                    isNoBack = accountTask.LogIn((int)Constants.LibraryMode.User);
                    break;
                case (int)Constants.LogInMenu.SignUp:   
                    ((UserAccountTaskController)accountTask).SignUp();
                    break;
            }

            if (!isNoBack)
                Run();
        }
    }
}
