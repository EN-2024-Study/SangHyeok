using Library.Model;
using Library.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Library.Utility.Constants;

namespace Library.Controller
{
    public class AccountController
    {
        private InputManager inputManager;
        private UserRepository user;
        private ManagerRepository manager;
        private UserDto signUpAccount;

        public AccountController()
        {
            this.inputManager = new InputManager();
            this.user = UserRepository.Instance;    // singleton 생성
            this.manager = ManagerRepository.Instance;  // singleton 생성
            this.signUpAccount = new UserDto();
        }

        public bool IsLogInValid(int logInMenu, int modeType) // LogIn 입력 값이 유효한지 확인하는 함수
        {
            string inputstring = null;
    
            switch (logInMenu)
            {
                case (int)Constants.LogInMenu.Id:
                    inputstring = inputManager.LimitInputLength((int)Constants.InputType.Id, 9, false);
                    break;
                case (int)Constants.LogInMenu.Password:
                    inputstring = inputManager.LimitInputLength((int)Constants.InputType.Password, 5, true);
                    break;
            }

            if (modeType == (int)Constants.ModeMenu.UserMode)
            {
                List<UserDto> userList = user.GetUserList();
                for (int i = 0; i < userList.Count; i++)
                {
                    if ((logInMenu == (int)Constants.LogInMenu.Id && userList[i].Id.Equals(inputstring)) ||
                        (logInMenu == (int)Constants.LogInMenu.Password && userList[i].Password.Equals(inputstring)))
                    {
                        user.UserIndex = i;
                        return true;
                    }
                }
            }
            else if (modeType == (int)Constants.ModeMenu.ManagerMode)
            {
                if ((logInMenu == (int)Constants.LogInMenu.Id && manager.GetManager().Id.Equals(inputstring)) ||
                    (logInMenu == (int)Constants.LogInMenu.Password && manager.GetManager().Password.Equals(inputstring)))
                    return true;
            }

            return false;
        }


        public bool IsSignUpValid(int inputType)
        {
            string inputString = null;

            switch (inputType)
            {
                case (int)Constants.InputType.Id:
                    inputString = inputManager.LimitInputLength((int)Constants.InputType.Id, 9, false);
                    signUpAccount.Id = inputString;
                    break;
                case (int)Constants.InputType.Password:
                    inputString = inputManager.LimitInputLength((int)Constants.InputType.Password, 5, true);
                    signUpAccount.Password = inputString;
                    break;
                case (int)Constants.InputType.Age:
                    inputString = inputManager.LimitInputLength((int)Constants.InputType.Age, 4, false);
                    signUpAccount.Age = inputString;
                    break;
                case (int)Constants.InputType.PhoneNumber:
                    inputString = inputManager.LimitInputLength((int)Constants.InputType.PhoneNumber, 13, false);
                    signUpAccount.PhoneNumber = inputString;
                    break;
                case (int)Constants.InputType.Address:
                    inputString = inputManager.LimitInputLength((int)Constants.InputType.Address, 20, false);
                    signUpAccount.Address = inputString;
                    break;
            }

            if (inputString == null)
                return false;
            return true;
        }

        public void SetSignUpAccount()
        {
            user.AddUser(signUpAccount);
        }
    }
}
