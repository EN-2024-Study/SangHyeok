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
        string id;
        string password;

        public AccountTaskController()
        {
            id = null;
            password = null;
            menuController = new MenuController();
            accountScreen = new AccountScreen();
        }

        public bool LogIn(int modeValue)
        {
            id = null;
            password = null;
            bool isLogIn = true;
            Tuple<int, int> coordinate = new Tuple<int, int>(20, 25);

            while (isLogIn)
            {
                accountScreen.PrintLogInScreen(menuController.menuValue, false, null, coordinate);
                isLogIn = menuController.SelectMenu();
                if (menuController.menuValue > 1)
                    menuController.menuValue = 1;
            }

            if (menuController.menuValue == -1)
                return false;

            isLogIn = true;
            while (isLogIn)
            {
                if (id != null && password != null)
                    isLogIn = false;

                accountScreen.PrintLogInScreen(menuController.menuValue, true, id, coordinate);
                if (menuController.menuValue == (int)Constants.LogIn.Id)
                {
                    id = LimitInputLength(15, new Tuple<int, int>(coordinate.Item1 + 5, coordinate.Item2 + 1), false);
                    id = LimitInputRegex(id);

                    if (id == null) // 입력 길이가 맞지 않을 때
                    {
                        accountScreen.PrintInputError((int)Constants.Error.Length, new Tuple<int, int>(coordinate.Item1 + 5, coordinate.Item2 + 1));
                    }
                }
                else if (menuController.menuValue == (int)Constants.LogIn.Password)
                {
                    password = LimitInputLength(15, new Tuple<int, int>(coordinate.Item1 + 11, coordinate.Item2 + 2), true);
                    password = LimitInputRegex(password);
                    if (password == null)   // 입력 길이가 맞지 않을 때
                    {
                        accountScreen.PrintInputError((int)Constants.Error.Length, new Tuple<int, int>(coordinate.Item1 + 5, coordinate.Item2 + 2));
                    }
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

        private void ValidateInput()
        {

        }
    }
}
