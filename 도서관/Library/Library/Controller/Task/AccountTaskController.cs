using Library.Utility;
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
        private MenuController menuController;
        private AccountScreen accountScreen;

        public AccountTaskController()
        {
            menuController = new MenuController();
            accountScreen = new AccountScreen();
        }

        public bool LogIn()
        {
            bool isLogIn = true;
            string id = null, password = null;
            Tuple<int, int> coordinate = new Tuple<int, int>(20, 25);

            while (isLogIn)
            {
                accountScreen.PrintLogInScreen(menuController.menuValue, false, coordinate);
                isLogIn = menuController.SelectMenu();
                if (menuController.menuValue > 1)
                    menuController.menuValue = 1;
            }

            if (menuController.menuValue == -1)
                return false;

            isLogIn = true;
            while (isLogIn)
            {
                accountScreen.PrintLogInScreen(menuController.menuValue, true, coordinate);
                switch (menuController.menuValue)
                {
                    case (int)Constants.LogIn.Id:
                        id = LimitInputLength(15, new Tuple<int, int>(coordinate.Item1 + 5, coordinate.Item2 + 1), false);
                        MatchPattern(id);
                        break;
                    case (int)Constants.LogIn.Password:
                        password = LimitInputLength(15, new Tuple<int, int>(coordinate.Item1 + 11, coordinate.Item2 + 2), true);
                        MatchPattern(password);
                        break;
                }
            }

            return true;
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

        private void MatchPattern(string str)
        {
            if (str == null)
                LogIn();
            else
            {   // 정규표현식 검사

            }
        }
    }
}
