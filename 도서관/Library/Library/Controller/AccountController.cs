using Library.View;
using Library.Model;
using System;
using Library.Utility;
using System.Collections.Generic;

namespace Library.Controller
{
    public class AccountController
    {
        private InputController inputController;
        private AccountScreen accountScreen;
        private ExceptionController exceptionController;
        private AccountsDto accountsDto;

        public AccountController()
        {
            this.inputController = new InputController();
            this.accountScreen = new AccountScreen();
            this.exceptionController = new ExceptionController();
            this.accountsDto = new AccountsDto();
        }

        public void LogIn()    
        {
            accountScreen.PrintLogInWindow();

            string id = inputController.InputLogIn(15, 23, 15, false);
            if (id == null)
                return;
            string password = inputController.InputLogIn(15, 25, 4, true);
            if (password == null)
                return;

            AccountInfo loginInfo = new AccountInfo(id, password);
            //List<AccountInfo> accounts = accountsDto.Accounts;

            //foreach(AccountInfo value in accounts)
            //{
            //    if (value.Id == loginInfo.Id && value.Password == loginInfo.Password)
            //    {
            //        // userModeMenu
            //    }
            //}
            //exceptionController.HandleInputException((int)Constants.Error.Correspond);
            //LogIn();
        }

        public void SignUp(int modeValue)
        {
            if (modeValue == (int)Constants.ModeMenu.ManagerMode)
            {
                exceptionController.HandleSignUpException();
                return;
            }

            Console.CursorVisible = true;
            bool isInput = true;
            int menuValue = 0;
            while (isInput)
            {
                string info = null;
                int coordinateX = 40;
                int coordinateY = 21 + menuValue;
                accountScreen.PrintSignUpWindow(menuValue);
                Console.SetCursorPosition(coordinateX, coordinateY);
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        menuValue--;
                        if (menuValue < 0)
                            menuValue = 0;
                        break;
                    case ConsoleKey.DownArrow:
                        menuValue++;
                        break;
                    case ConsoleKey.Enter:
                        if (menuValue == 6)
                        {
                            // enter일 때
                        }
                        break;
                    default:
                        info = inputController.InputSignUp(coordinateX, coordinateY, menuValue % 7);
                        break;
                }
                if (menuValue > 6)
                    menuValue = 6;

                if (info != null)
                {
                    List<AccountInfo> account = accountsDto.Accounts;
                    foreach(AccountInfo value in account)
                    {

                    }
                }
            }
            Console.CursorVisible = false;
        }


    }
}
