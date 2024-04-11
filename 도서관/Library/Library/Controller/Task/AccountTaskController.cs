using Library.Utility;
using Library.View;
using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

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
            this.userMenuController = new UserMenuController();
            this.managerMenuController = new ManagerMenuController();
            this.accountScreen = new AccountScreen();
            this.accounts = new AccountRepository();
        }

        public bool LogIn(int modeValue)
        {
            id = null;
            password = null;
            bool isLogIn = true;
            Tuple<int, int> coordinate = new Tuple<int, int>(20, 25);

            while (isLogIn)     // ID 입력과 Password 입력 중 선택
            {
                accountScreen.PrintLogInScreen(menuController.menuValue, false, coordinate);
                isLogIn = menuController.SelectMenu();
                if (menuController.menuValue > 1)
                    menuController.menuValue = 1;
            }

            if (menuController.menuValue == -1) // esc 입력 -> mode 선택 화면
                return false;

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

                accountScreen.PrintLogInScreen(menuController.menuValue, true, coordinate);

                if (menuController.menuValue == (int)Constants.LogIn.Id)
                {
                    id = LimitInputLength(15, new Tuple<int, int>(coordinate.Item1 + 5, coordinate.Item2 + 1), false);
                    id = LimitInputRegex(id);

                    if (id == null)     // esc 입력 -> 다시 로그인
                        return LogIn(modeValue);
                }
                else if (menuController.menuValue == (int)Constants.LogIn.Password)
                {
                    password = LimitInputLength(15, new Tuple<int, int>(coordinate.Item1 + 11, coordinate.Item2 + 2), true);
                    password = LimitInputRegex(password);
                    if (password == null)   // esc 입력 -> 다시 로그인
                        return LogIn(modeValue);
                }
            }

            string[] ids = id.Split('\0');
            string[] passwords = password.Split('\0');
            
            AccountDto logInInfo = new AccountDto(ids[0], passwords[0]);  // ID, PASSWORD 확인

            if (modeValue == (int)Constants.LibraryMode.User)
            {
                bool isCheck = false;
                foreach (AccountDto value in accounts.AccountList)
                {
                    if (logInInfo.Id == value.Id && logInInfo.Password == value.Password)
                    {
                        userMenuController.Run();
                        isCheck = true;
                        break;
                    }
                }

                if (!isCheck)
                {

                    return LogIn(modeValue);
                }
            }
            else
            {
                if (logInInfo.Id == accounts.Manager.Id && logInInfo.Password == accounts.Manager.Password)
                {
                    managerMenuController.Run();
                }
                else
                {

                    return LogIn(modeValue);
                }
            }

            return true;
        }
    }
}
