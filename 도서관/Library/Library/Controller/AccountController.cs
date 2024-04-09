using Library.View;
using Library.Model;
using System;
using Library.Utility;

namespace Library.Controller
{
    public class AccountController
    {
        private InputController inputController;
        private AccountScreen accountScreen;
        private ExceptionController exceptionController;

        public AccountController()
        {
            this.inputController = new InputController();
            this.accountScreen = new AccountScreen();
            this.exceptionController = new ExceptionController();
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



        }

        public void SignUp(int modeValue)
        {
            if (modeValue == (int)Constants.ModeMenu.ManagerMode)
            {
                exceptionController.HandleSignUpException();
                return;
            }

            Console.CursorVisible = true;
            Console.SetCursorPosition(36, 21);
            bool isInput = true;
            int menuValue = 0;
            while (isInput)
            {
                accountScreen.PrintSignUpWindow(menuValue);
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        menuValue--;
                        if (menuValue < 0)
                            menuValue = 6;
                        break;
                    case ConsoleKey.DownArrow:
                        menuValue++;
                        break;
                    case ConsoleKey.Enter:
                        if (menuValue == 6)
                        {
                            // enter일 때
                        }
                        menuValue++;
                        break;
                    default:
                        string info = inputController.InputSignUp(menuValue % 7);
                        break;
                }
                menuValue %= 7;
            }
            Console.CursorVisible = false;
        }


    }
}
