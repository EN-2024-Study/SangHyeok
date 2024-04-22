using Library.Utility;
using Library.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Controller
{
    public class MenuController
    {
        private MenuScreen menuScreen;
        private MenuSelector menuSelector;
        private AccountController userController;

        public MenuController()
        {
            this.menuScreen = new MenuScreen();
            this.menuSelector = new MenuSelector();
            this.userController = new AccountController();
        }

        public void ControllModeMenu()
        {
            bool isSelected = true;
            menuSelector.menuValue = 0;

            Console.SetWindowSize(30, 5);
            Console.Clear();
            while (isSelected)
            {
                isSelected = menuSelector.IsMenuSelection((int)Constants.MenuType.Mode);
                if (!isSelected)
                    continue;

                switch (menuSelector.menuValue)
                {
                    case (int)Constants.ModeMenu.UserMode:
                        ControllLogInSignUpMenu();
                        break;
                    case (int)Constants.ModeMenu.ManagerMode:
                        ControllLogInMenu((int)Constants.ModeMenu.ManagerMode);
                        break;
                }
            }
        }

        private void ControllLogInSignUpMenu()
        {
            bool isSelected = true;
            menuSelector.menuValue = 0;

            Console.Clear();
            while (isSelected)
            {
                isSelected = menuSelector.IsMenuSelection((int)Constants.MenuType.LogInSignUp);
                if (!isSelected)
                    continue;

                switch (menuSelector.menuValue)
                {
                    case (int)Constants.LogInSignUpMenu.LogIn:
                        ControllLogInMenu((int)Constants.ModeMenu.UserMode);
                        break;
                    case (int)Constants.LogInSignUpMenu.SignUp:

                        break;
                }
            }
        }

        private void ControllLogInMenu(int modeType)
        {
            bool isSelected = true;
            bool isId = false, isPassword = false;
            menuSelector.menuValue = 0;

            Console.SetWindowSize(40, 5);
            Console.Clear();
            while (isSelected)
            {
                isSelected = menuSelector.IsMenuSelection((int)Constants.MenuType.LogIn);
                if (!isSelected)
                    continue;

                switch(menuSelector.menuValue)
                {
                    case (int)Constants.InputType.Id:
                        isId = userController.IsAccountValid((int)Constants.LogInMenu.Id, modeType);
                        break;
                    case (int)Constants.InputType.Password:
                        isPassword = userController.IsAccountValid((int)Constants.LogInMenu.Password, modeType);
                        break;
                }

                if (isId && isPassword) // id와 password가 일치하다면
                {
                    //ControllMainMenu(); // 메인 메뉴로 이동
                    isId = false;
                    isPassword = false;
                }
            }
        }


    }
}
