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

            accountScreen.PrintSignUpWindow();
            for (int i = 0; i < 6; i++)
            {
                string str = inputController.InputSignUp(i);

            }
        }


    }
}
