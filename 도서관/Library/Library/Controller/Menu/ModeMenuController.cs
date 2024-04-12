using Library.Controller.Menu;
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
        private LogInMenuController logInMenuController;
        private YesNoMenuController quitMenu;

        public ModeMenuController()
        {
            this.logInSignUpMenu = new LogInSignUpMenuController(); // 유저 모드로 가면 로그인회원가입 메뉴
            this.logInMenuController = new LogInMenuController((int)Constants.LibraryMode.Manager); // 관리자 모드로 가면 로그인 메뉴
            this.quitMenu = new YesNoMenuController();
        }

        public override bool Run()
        {
            Console.Clear();
            base.menuValue = 0;
            bool isMenuSelect = true;
            bool isBack = false;
            string[] menuString = base.DecideMenuType((int)Constants.MenuType.UserManager);

            while (isMenuSelect)
            {
                base.menuScreen.PrintMenu(menuString, menuValue, false);
                ExplainingScreen.PrintQuit();
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
                    isBack = logInMenuController.Run();
                    break;
            }

            if (isBack)
                Run();
            return false;
        }
    }
}
