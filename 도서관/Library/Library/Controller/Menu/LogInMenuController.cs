using Library.Controller.Task;
using Library.Utility;
using Library.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Controller.Menu
{
    public class LogInMenuController : MenuController
    {
        private TaskController task;

        public LogInMenuController()
        {
            task = new TaskController();
        }

        public override bool Run()
        {
            base.menuValue = 0;
            bool isMenuSelect = true;
            bool isBack = false;
            string[] menuString = base.DecideMenuType((int)Constants.MenuType.LogIn);

            base.menuScreen.EraseMenu();
            while (isMenuSelect)
            {
                menuScreen.PrintMenu(menuString, menuValue);
                isMenuSelect = SelectMenu();
                if (menuValue > 1)
                    menuValue = 1;
            }

            while(!isBack)
            {
                switch (menuValue)
                {
                    case (int)Constants.LogInMenu.Id:
                        isBack = accountTask.IdPasswordMenu((int)Constants.LibraryMode.User);
                        break;
                    case (int)Constants.LogInMenu.Password:
                        isBack = ((UserAccountTaskController)accountTask).SignUp();
                        break;
                }
            }

            if (isBack)
                return true;
            return false;
        }

        /*
        public bool IdPasswordMenu()
        {
            Tuple<int, int> coordinate = new Tuple<int, int>(20, 25);
            bool isLogIn = true;

            while (isLogIn)     // ID 입력과 Password 입력 중 선택
            {
                accountScreen.PrintScreen(menuController.menuValue, false, true, coordinate);
                isLogIn = menuController.SelectMenu();
                if (menuController.menuValue > 1)
                    menuController.menuValue = 1;
            }

            if (menuController.menuValue == -1) // esc 입력 -> mode 선택 화면
                return false;
            return true;
        }
        */
    }
}
