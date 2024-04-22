using Library.Controller.Menu;
using Library.Controller.Task;
using Library.Model;
using Library.Utility;
using Library.View;
using System;
using System.Collections.Generic;
using static Library.Utility.Constants;

namespace Library.Controller
{
    public class ModeMenu : MenuController
    {
        private LogInSignUpMenu logInSignUpMenu;
        private Menu.LogInMenu logInMenu; // 폴더명 Menu
        private YesNoMenu quitMenu;

        public ModeMenu() : base()
        {
            this.logInSignUpMenu = new LogInSignUpMenu(); // 유저 모드로 가면 로그인회원가입 메뉴
            this.logInMenu = new Menu.LogInMenu((int)Constants.LibraryMode.Manager); // 관리자 모드로 가면 로그인 메뉴
            this.quitMenu = new YesNoMenu();
            base.menuString = base.DecideMenuType((int)Constants.MenuType.UserManager);
        }

        public override bool Run()
        {
            Console.Clear();
            base.menuValue = 0;
            bool isMenuSelect = true;
            bool isBack = false;

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
                case (int)Constants.LibraryMode.Quit:
                    isBack = quitMenu.Run();
                    break;
                case (int)Constants.LibraryMode.User:
                    isBack = logInSignUpMenu.Run();
                    break;
                case (int)Constants.LibraryMode.Manager:
                    isBack = logInMenu.Run();
                    break;
            }

            if (isBack)
                Run();
            return false;
        }
    }
}
