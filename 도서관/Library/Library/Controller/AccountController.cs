using Library.View;
using Library.Model;
using System;
using System.Collections.Generic;

namespace Library.Controller
{
    public class AccountController
    {

        private AccountScreen accountScreen;
        private AccountsDto accounts;

        public AccountController()
        {
            this.accountScreen = new AccountScreen();
            this.accounts = new AccountsDto();
        }

        public void InputLogIn()
        {
            accountScreen.PrintLogInWindow();
            Console.SetCursorPosition(16, 23);
            string temp = Console.ReadLine();
            Console.SetCursorPosition(15, 25);
            string passowrd = Console.ReadLine();
        }

        public void InputSignUp()
        {
            accountScreen.PrintSignUpWindow();

        }


    }
}
