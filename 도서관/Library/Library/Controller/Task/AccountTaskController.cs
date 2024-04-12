using Library.Utility;
using Library.View;
using Library.Model;
using System;

namespace Library.Controller.Task
{
    public class AccountTaskController : TaskController
    {
        private MenuController menuController;
        private UserMenuController userMenuController;
        private ManagerMenuController managerMenuController;
        private AccountScreen accountScreen;
        private AccountRepository accounts;
        private string id;
        private string password;

        public AccountTaskController() : base()
        {
            this.menuController = new MenuController();
            this.accountScreen = new AccountScreen();
            this.accounts = new AccountRepository();
            this.id = null;
            this.password = null;
        }

        public bool SelectLogInMenu(int modeValue)
        {
            Tuple<int, int> coordinate = new Tuple<int, int>(20, 25);
            bool isLogIn = true;

            while (isLogIn)     // ID 입력과 Password 입력 중 선택
            {
                accountScreen.PrintScreen(menuController.menuValue, false, true, coordinate);
                isLogIn = menuController.SelectMenu();
                if (menuController.menuValue > 1)
                    menuController.menuValue = 1;
            }

            if (menuController.menuValue == -1) // esc 입력 -> mode 선택 화면
                return false;
            return true;
        }

        public bool LogIn(int modeValue)
        {
            id = null;
            password = null;
            menuController.menuValue = 0;
            bool isLogIn = true;
            Tuple<int, int> coordinate = new Tuple<int, int>(20, 25);



        

            isLogIn = true;
            while (isLogIn)     // 입력
            {

                if (id != null && password != null)
                {
                    isLogIn = false;
                    break;
                }
                else if (id != null)    // id만 입력 되었을 때
                    menuController.menuValue = 1;
                else if (password != null)  // password만 입력 되었을 때
                    menuController.menuValue = 0;

                accountScreen.PrintScreen(menuController.menuValue, true, true, coordinate);

                if (menuController.menuValue == (int)Constants.LogIn.Id)
                {
                    id = LimitInputLength(15, new Tuple<int, int>(coordinate.Item1 + 5, coordinate.Item2 + 1), false);
                    id = LimitInputRegex(id);

                    if (id == null)     // esc 입력 -> 다시 로그인
                        return false;
                }
                else if (menuController.menuValue == (int)Constants.LogIn.Password)
                {
                    password = LimitInputLength(15, new Tuple<int, int>(coordinate.Item1 + 11, coordinate.Item2 + 2), true);
                    password = LimitInputRegex(password);
                    if (password == null)   // esc 입력 -> 다시 로그인
                        return false;
                }
            }

            string[] ids = id.Split('\0');
            string[] passwords = password.Split('\0');

            AccountDto logInInfo = new AccountDto(ids[0], passwords[0]);  // ID, PASSWORD 확인

            if (modeValue == (int)Constants.LibraryMode.User)
            {
                bool isComplete = false;
                foreach (AccountDto value in accounts.AccountList)
                {
                    if (logInInfo.Id == value.Id && logInInfo.Password == value.Password)
                    {
                        userMenuController = new UserMenuController();
                        userMenuController.Run();
                        isComplete = true;
                        break;
                    }
                }

                if (!isComplete)
                {

                    return false;
                }
            }
            else
            {
                if (logInInfo.Id == accounts.Manager.Id && logInInfo.Password == accounts.Manager.Password)
                {
                    managerMenuController = new ManagerMenuController();
                    managerMenuController.Run();
                }
                else
                {

                    return false;
                }
            }

            return true;
        }
    }
}
