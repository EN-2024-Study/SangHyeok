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
        private LogInSignUpMenuController logInSignUpMenu;
        private QuitMenuController quitMenu;
        private AccountTaskController accountTask;

        public ModeMenuController()
        {
            this.logInSignUpMenu = new LogInSignUpMenuController();
            this.quitMenu = new QuitMenuController();
            this.accountTask = new AccountTaskController();
        }

        public override void Run()
        {
            base.menuValue = 0;
            bool isMenuSelect = true;
            bool isNoBack = true;
            string[] menuString = base.DecideMenuType((int)Constants.Type.UserManager);

            while (isMenuSelect)
            {
                base.menuScreen.PrintMenu(menuString, menuValue, coordinate);
                isMenuSelect = base.SelectMenu();
                if (menuValue > 1)
                    menuValue = 1;
            }

            switch (menuValue)
            {
                case (int)Constants.ModeMenu.Quit:
                    quitMenu.Run();
                    Run();
                    break;
                case (int)Constants.ModeMenu.UserMode:
                    logInSignUpMenu.Run();
                    break;
                case (int)Constants.ModeMenu.ManagerMode:
                    isNoBack = accountTask.LogIn((int)Constants.LibraryMode.Manager);
                    break;
            }

            if (!isNoBack)
                Run();
        }
    }
}
