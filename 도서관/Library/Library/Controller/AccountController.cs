using Library.Model;
using Library.Utility;
using Library.View;
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
        private MenuSelector menuSelector;
        private InputManager inputManager;
        private UserRepository user;
        private ManagerRepository manager;
        private string[] signUpStrings;
        private string[] modifyStrings;
        private string logInId, logInPassword;

        public AccountController()
        {
            this.menuSelector = new MenuSelector();
            this.inputManager = new InputManager();
            this.user = UserRepository.Instance;    // singleton 생성
            this.manager = ManagerRepository.Instance;  // singleton 생성
            this.signUpStrings = new string[] { null, null, null, null, null };
            this.modifyStrings = new string[] { null, null, null, null };
            this.logInId = null;
            this.logInPassword = null;
        }

        public bool IsLogIn(int modeType)
        {
            bool isSelected = true;
            menuSelector.menuValue = 0;
            Console.SetWindowSize(50, 20);
            Console.Clear();

            while (isSelected)
            {
                isSelected = menuSelector.IsMenuSelection((int)Constants.MenuType.LogIn);
                if (!isSelected)
                    continue;

                if (menuSelector.menuValue == (int)Constants.LogInMenu.Check)
                {
                    Console.Clear();
                    if (IsLogInValid(modeType))
                    {
                        Console.SetWindowSize(50, 20);
                        return true;
                    }
                }
                else
                    InputLogIn(menuSelector.menuValue);
            }
            return false;
        }

        public bool IsSignUp()
        {
            bool isSelected = true;
            menuSelector.menuValue = 0;
            Console.SetWindowSize(50, 20);
            Console.Clear();

            while (isSelected)
            {
                isSelected = menuSelector.IsMenuSelection((int)Constants.MenuType.SignUp);
                if (!isSelected)
                    continue;

                if (menuSelector.menuValue == (int)Constants.SignUpMenu.Check)
                {
                    Console.Clear();
                    if (IsSignUpValid())
                    {
                        ExplainingScreen.ExplainSuccessScreen();
                        ExplainingScreen.ExplainEcsKey();
                        return true;
                    }
                }
                else
                    InputSignUp(menuSelector.menuValue);
            }
            return false;
        }

        public void IsModifyInformation()
        {
            bool isSelected = true;
            menuSelector.menuValue = 0;
            Console.SetWindowSize(50, 30);
            Console.Clear();

            while (isSelected)
            {
                isSelected = menuSelector.IsMenuSelection((int)Constants.MenuType.AccountModify);
                if (!isSelected)
                    continue;

                if (menuSelector.menuValue == (int)Constants.AccountModifyMenu.Check)
                {
                    Console.Clear();
                    if (IsModifyInfoValid())
                    {
                        ExplainingScreen.ExplainSuccessScreen();
                        ExplainingScreen.ExplainEcsKey();
                        return;
                    }
                }
                else
                    InputModifyInformation(menuSelector.menuValue);
            }
        }

        private void InputModifyInformation(int inputType)
        {
            switch(inputType)
            {
                case (int)Constants.AccountModifyMenu.Password:
                    modifyStrings[0] = inputManager.LimitInputLength((int)Constants.InputType.ModifyPassword, 5, true);
                    break;
                case (int)Constants.AccountModifyMenu.Age:
                    modifyStrings[1] = inputManager.LimitInputLength((int)Constants.InputType.ModifyAge, 4, false);
                    break;
                case (int)Constants.AccountModifyMenu.PhoneNumber:
                    modifyStrings[2] = inputManager.LimitInputLength((int)Constants.InputType.ModifyPhoneNumber, 13, false);
                    break;
                case (int)Constants.AccountModifyMenu.Address:
                    modifyStrings[3] = inputManager.LimitInputLength((int)Constants.InputType.ModifyAddress, 20, false);
                    break;
            }
        }

        private void InputLogIn(int inputType)
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

        private void InputSignUp(int inputType)
        {
            switch (inputType)
            {
                case (int)Constants.SignUpMenu.Id:
                    signUpStrings[0] = inputManager.LimitInputLength((int)Constants.InputType.Id, 9, false);
                    break;
                case (int)Constants.SignUpMenu.Password:
                    signUpStrings[1] = inputManager.LimitInputLength((int)Constants.InputType.Password, 5, true);
                    break;
                case (int)Constants.SignUpMenu.Age:
                    signUpStrings[2] = inputManager.LimitInputLength((int)Constants.InputType.Age, 4, false);
                    break;
                case (int)Constants.SignUpMenu.PhoneNumber:
                    signUpStrings[3] = inputManager.LimitInputLength((int)Constants.InputType.PhoneNumber, 13, false);
                    break;
                case (int)Constants.SignUpMenu.Address:
                    signUpStrings[4] = inputManager.LimitInputLength((int)Constants.InputType.Address, 20, false);
                    break;
            }
        }

        private bool IsModifyInfoValid()
        {
            if (modifyStrings[1] != null)
            {
                user.UpdatePassword(modifyStrings[1]);
                return true;
            }
            if (modifyStrings[2] != null)
            {
                user.UpdateAge(modifyStrings[2]);
                return true;
            }
            if (modifyStrings[3] != null)
            {
                user.UpdatePhoneNumber(modifyStrings[3]);
                return true;
            }
            if (modifyStrings[4] != null)
            {
                user.UpdateAddress(modifyStrings[4]);
                return true;
            }
            return false;
        }

        private bool IsLogInValid(int modeType)
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

        private bool IsSignUpValid()
        {
            List<UserDto> userList = user.GetUserList();
            foreach(string str in signUpStrings)
            {
                if (str == null)
                    return false;
            }

            foreach(UserDto value in userList)
                if (value.Id.Equals(signUpStrings[0]))
                    return false;

            user.AddUser(new UserDto(signUpStrings[0], signUpStrings[1], signUpStrings[2],
                signUpStrings[3], signUpStrings[4]));
            signUpStrings = new string[] { null, null, null, null, null };
            return true;
        }
    }
}
