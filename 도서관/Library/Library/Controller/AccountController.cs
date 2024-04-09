using Library.View;
using Library.Model;
using System;

namespace Library.Controller
{
    public class AccountController
    {

        private AccountScreen accountScreen;
        private AccountsDto accounts;
        private ExceptionHandler handler;

        public AccountController()
        {
            this.accountScreen = new AccountScreen();
            this.accounts = new AccountsDto();
            this.handler = new ExceptionHandler();
        }

        public void InputLogIn()    // 박윤경
        {
            bool isLogin = true;
            accountScreen.PrintLogInWindow();
            while(isLogin)
            {
                Console.SetCursorPosition(15, 23);
                string id = handler.HandleInputException(15, false);
                if (id == null)
                    continue;
                Console.SetCursorPosition(15, 25);
                string password = handler.HandleInputException(15, true);
                if (password != null)
                    isLogin = false;
            }
        }

        public void InputSignUp()
        {
            accountScreen.PrintSignUpWindow();
            
        }


    }
}
