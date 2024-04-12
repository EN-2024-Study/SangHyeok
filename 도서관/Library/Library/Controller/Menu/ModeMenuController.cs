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
        private YesNoMenuController quitMenu;
        private AccountTaskController accountTask;

        public ModeMenuController()
        {
            this.logInSignUpMenu = new LogInSignUpMenuController();
            this.quitMenu = new YesNoMenuController();
            this.accountTask = new AccountTaskController();
        }

        public override bool Run()
        {
            base.menuValue = 0;
            bool isMenuSelect = true;
            bool isBack = false;
            string[] menuString = base.DecideMenuType((int)Constants.MenuType.UserManager);

            base.menuScreen.EraseMenu();
            while (isMenuSelect)
            {
                base.menuScreen.PrintMenu(menuString, menuValue);
                isMenuSelect = base.SelectMenu();
                if (menuValue > 1)
                    menuValue = 1;
            }

            switch (menuValue)
            {
                case (int)Constants.ModeMenu.Quit:
                    isBack = quitMenu.Run();
                    break;
                case (int)Constants.ModeMenu.UserMode:
                    isBack = logInSignUpMenu.Run();
                    break;
                case (int)Constants.ModeMenu.ManagerMode:
                    isBack = accountTask.LogIn((int)Constants.LibraryMode.Manager);
                    break;
            }

            if (isBack)
                Run();
            return false;
        }
    }
}
