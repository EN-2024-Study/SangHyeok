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
        private AccountController accountController;

        public MenuController()
        {
            this.menuScreen = new MenuScreen();
            this.menuSelector = new MenuSelector();
            this.accountController = new AccountController();
        }

        public void ControllModeMenu()
        {
            bool isSelected = true;
            menuSelector.menuValue = 0;

            while (isSelected)
            {
                Console.SetWindowSize(40, 20);
                Console.Clear();
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

            while (isSelected)
            {
                Console.SetWindowSize(40, 20);
                Console.Clear();
                isSelected = menuSelector.IsMenuSelection((int)Constants.MenuType.LogInSignUp);
                if (!isSelected)
                    continue;

                switch (menuSelector.menuValue)
                {
                    case (int)Constants.LogInSignUpMenu.LogIn:
                        ControllLogInMenu((int)Constants.ModeMenu.UserMode);
                        break;
                    case (int)Constants.LogInSignUpMenu.SignUp:
                        ControllSignUpMenu();
                        break;
                }
            }
        }

        private void ControllLogInMenu(int modeType)
        {
            bool isSelected = true;
            bool isId = false, isPassword = false;
            menuSelector.menuValue = 0;
            Console.SetWindowSize(50, 20);
            Console.Clear();

            while (isSelected)
            {
                isSelected = menuSelector.IsMenuSelection((int)Constants.MenuType.LogIn);
                if (!isSelected)
                    continue;

                switch(menuSelector.menuValue)
                {
                    case (int)Constants.InputType.Id:
                        isId = accountController.IsLogInValid((int)Constants.LogInMenu.Id, modeType);
                        break;
                    case (int)Constants.InputType.Password:
                        isPassword = accountController.IsLogInValid((int)Constants.LogInMenu.Password, modeType);
                        break;
                }

                if (isId && isPassword) // id와 password가 일치하다면
                {
                    isId = false;
                    isPassword = false;
                    ControllModeMenu(modeType);
                    Console.SetWindowSize(50, 20);
                    Console.Clear();
                }
            }
        }

        private void ControllSignUpMenu()
        {
            bool isSelected = true;
            bool[] isInput = new bool[] { false, false, false, false, false };
            menuSelector.menuValue = 0;
            Console.SetWindowSize(50, 20);
            Console.Clear();

            while (isSelected)
            {
                isSelected = menuSelector.IsMenuSelection((int)Constants.MenuType.AccountModify);
                if (!isSelected)
                    continue;

                if (menuSelector.menuValue < 5)
                    isInput[menuSelector.menuValue] = accountController.IsSignUpValid(menuSelector.menuValue);
                else   // 확인 버튼을 눌렀을 때
                {
                    foreach (bool value in isInput)
                    {
                        if (!value) // 모든 정보 기입을 하지 않았다면 
                            continue;
                    }
                        
                    accountController.SetSignUpAccount();   // 회원가입
                    break;
                }
            }
        }

        private void ControllModeMenu(int modeType)
        {
            bool isSelected = true;
            menuSelector.menuValue = 0;

            while (isSelected)
            {
                Console.SetWindowSize(50, 30);
                Console.Clear();

                if (modeType == (int)Constants.ModeMenu.UserMode)
                {
                    isSelected = menuSelector.IsMenuSelection((int)Constants.MenuType.UserMode);
                    if (!isSelected)
                        continue;

                    switch (menuSelector.menuValue)
                    {
                        case (int)Constants.UserMode.BookSearch:

                            break;
                        case (int)Constants.UserMode.BookRental:

                            break;
                        case (int)Constants.UserMode.BookRentalHistory:

                            break;
                        case (int)Constants.UserMode.BookReturn:

                            break;
                        case (int)Constants.UserMode.BookReturnHistory:

                            break;
                        case (int)Constants.UserMode.AccountInfo:

                            break;
                        case (int)Constants.UserMode.AccountDelete:

                            break;
                    }
                }
                else if (modeType == (int)Constants.ModeMenu.ManagerMode)
                {
                    isSelected = menuSelector.IsMenuSelection((int)Constants.MenuType.ManagerMode);
                    if (!isSelected)
                        continue;

                    switch (menuSelector.menuValue)
                    {
                        case (int)Constants.ManagerMode.BookSearch:

                            break;
                        case (int)Constants.ManagerMode.BookAdd:

                            break;
                        case (int)Constants.ManagerMode.BookDelete:

                            break;
                        case (int)Constants.ManagerMode.BookModify:

                            break;
                        case (int)Constants.ManagerMode.AccountModify:

                            break;
                        case (int)Constants.ManagerMode.AccountDelete:

                            break;
                        case (int)Constants.ManagerMode.RentalHistory:

                            break;
                    }
                }
            }
        }

    }
}
