using Library.View;
using Library.Model;
using System;

namespace Library.Controller
{
    public class AccountController
    {
        private InputController inputController;
        private AccountScreen accountScreen;

        public AccountController()
        {
            this.inputController = new InputController();
            this.accountScreen = new AccountScreen();
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

        public void InputSignUp()
        {
            accountScreen.PrintSignUpWindow();
            
        }


    }
}
