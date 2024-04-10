using Library.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Controller.Task
{
    public class AccountTaskController : TaskController
    {
        private AccountScreen screen;

        public AccountTaskController()
        {
            screen = new AccountScreen();
        }


        public void LogIn()
        {
            screen.PrintLogInScreen();
            //string inputString = LimitInputLength();
        }

        public void SignUp(int modeValue)
        {

        }

        public void ModifyPersonalAccount()
        {

        }

        public void DeletePersonalAccount()
        {

        }
    }
}
