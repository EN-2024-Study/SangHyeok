using Library.View;
using Library.Model;
using System;
using System.Collections.Generic;

namespace Library.Controller
{
    public class AccountController
    {

        private AccountScreen accountScreen;

        public AccountController()
        {
            this.accountScreen = new AccountScreen();
        }

        public void InputLogIn()
        {
            accountScreen.PrintLogInWindow();

        }

        public void InputSignUp()
        {
            accountScreen.PrintSignUpWindow();

        }
    }
}
