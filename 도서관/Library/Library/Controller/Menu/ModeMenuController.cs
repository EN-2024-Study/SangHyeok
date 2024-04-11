using Library.Controller.Task;
using Library.Utility;
using Library.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Library.Utility.Constants;

namespace Library.Controller
{
    public class ModeMenuController : MenuController
    {
        private LogInMenuController logInMenu;
        private YesNoMenuController yesNoMenu;
        private AccountTaskController accountTask;

        public override void Run()
        {
            menuValue = 0;
            bool isMenuSelect = true;
            bool isNoBack = true;

            while (isMenuSelect)
            {
                menuScreen.PrintMenu(menuValue, (int)Constants.ModeMenu.UserMode, coordinate);
                isMenuSelect = SelectMenu();
                if (menuValue > 1)
                    menuValue = 1;
            }

            switch (menuValue)
            {
                case (int)Constants.ModeMenu.Quit:
                    yesNoMenu = new YesNoMenuController();
                    yesNoMenu.Run();
                    break;
                case (int)Constants.ModeMenu.UserMode:
                    logInMenu = new LogInMenuController(menuValue);
                    logInMenu.Run();
                    break;
                case (int)Constants.ModeMenu.ManagerMode:
                    accountTask = new AccountTaskController();
                    isNoBack = accountTask.LogIn((int)Constants.LibraryMode.Manager);
                    break;
            }

            if (!isNoBack)
                Run();
        }
    }
}
