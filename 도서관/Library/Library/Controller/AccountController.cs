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
        private string signUpId, signUpPassword, signUpAge, signUpPhoneNumber, signUpAddress;
        private string logInId, logInPassword;

        public AccountController()
        {
            this.inputManager = new InputManager();
            this.user = UserRepository.Instance;    // singleton 생성
            this.manager = ManagerRepository.Instance;  // singleton 생성
            this.signUpId = null;
            this.signUpPassword = null;
            this.signUpAge = null;
            this.signUpPhoneNumber = null;
            this.signUpAddress = null;
            this.logInId = null;
            this.logInPassword = null;
        }

        public void InputLogIn(int inputType)
        {
            switch(inputType)
            {
                case (int)Constants.LogInMenu.Id:
                    logInId = inputManager.LimitInputLength((int)Constants.InputType.Id, 9, false);
                    break;
                case (int)Constants.LogInMenu.Password:
                    logInPassword = inputManager.LimitInputLength((int)Constants.InputType.Password, 5, true);
                    break;
            }
        }

        public bool IsLogInValid(int modeType)
        {
            if (modeType == (int)Constants.ModeMenu.UserMode)
            {
                List<UserDto> userList = user.GetUserList();
                for (int i = 0; i < userList.Count; i++)
                {
                    if (logInId != null && logInPassword != null && 
                        userList[i].Id.Equals(logInId) && userList[i].Password.Equals(logInPassword))
                    {
                        user.UserIndex = i;
                        logInId = null;
                        logInPassword = null;
                        return true;
                    }
                }
            }
            else if (modeType == (int)Constants.ModeMenu.ManagerMode)
            {
                if (logInId != null && logInPassword != null &&
                    logInId.Equals(manager.GetManager().Id) && logInPassword.Equals(manager.GetManager().Password))
                {
                    logInId = null;
                    logInPassword = null;
                    return true;
                }
            }

            return false;
        }

        public void InputSignUp(int inputType)
        {
            switch (inputType)
            {
                case (int)Constants.SignUpMenu.Id:
                    signUpId = inputManager.LimitInputLength((int)Constants.InputType.Id, 9, false);
                    break;
                case (int)Constants.SignUpMenu.Password:
                    signUpPassword = inputManager.LimitInputLength((int)Constants.InputType.Password, 5, true);
                    break;
                case (int)Constants.SignUpMenu.Age:
                    signUpAge = inputManager.LimitInputLength((int)Constants.InputType.Age, 4, false);
                    break;
                case (int)Constants.SignUpMenu.PhoneNumber:
                    signUpPhoneNumber = inputManager.LimitInputLength((int)Constants.InputType.PhoneNumber, 13, false);
                    break;
                case (int)Constants.SignUpMenu.Address:
                    signUpAddress = inputManager.LimitInputLength((int)Constants.InputType.Address, 20, false);
                    break;
            }
        }

        public bool IsSignUpValid()
        {
            List<UserDto> userList = user.GetUserList();
            if (signUpId == null || signUpPassword == null || signUpAge == null ||
                signUpPhoneNumber == null || signUpAddress == null)
                return false;

            foreach(UserDto value in userList)
                if (value.Id.Equals(signUpId))
                    return false;

            user.AddUser(new UserDto(signUpId, signUpPassword, signUpAge, signUpPhoneNumber, signUpAddress));
            signUpId = null;
            signUpPassword = null;
            signUpAge = null;
            signUpPhoneNumber = null;
            signUpAddress = null;
            return true;
        }
    }
}
