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
        private Screen screen;
        private string[] signUpStrings;
        private string[] modifyStrings;
        private string logInId, logInPassword, id;

        public AccountController()
        {
            this.menuSelector = new MenuSelector();
            this.inputManager = new InputManager();
            this.user = UserRepository.Instance;    // singleton 생성
            this.manager = ManagerRepository.Instance;  // singleton 생성
            this.screen = new Screen();
            this.signUpStrings = new string[] { null, null, null, null, null };
            this.modifyStrings = new string[] { null, null, null, null };
            this.logInId = null;
            this.logInPassword = null;
            this.id = null;
        }

        public bool IsLogIn(int modeType)
        {
            bool isSelected = true;
            menuSelector.menuValue = 0;
            Console.Clear();

            while (isSelected)
            {
                Console.SetWindowSize(70, 25);
                ExplainingScreen.DrawStartLogo();
                isSelected = menuSelector.IsMenuSelection((int)Constants.MenuType.LogIn);
                if (!isSelected)
                    continue;

                if (menuSelector.menuValue == (int)Constants.LogInMenu.Check)
                {
                    if (IsLogInValid(modeType))
                    {
                        ExplainingScreen.ExplainSuccessScreen();
                        menuSelector.WaitForEscKey();
                        return true;
                    }
                    else
                    {
                        ExplainingScreen.ExplainFailScreen();
                        menuSelector.WaitForEscKey();
                        Console.Clear();
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
            Console.SetWindowSize(70, 25);
            Console.Clear();

            while (isSelected)
            {
                ExplainingScreen.DrawSIgnUpLogo();
                isSelected = menuSelector.IsMenuSelection((int)Constants.MenuType.SignUp);
                if (!isSelected)
                    continue;

                if (menuSelector.menuValue == (int)Constants.SignUpMenu.Check)
                {
                    Console.Clear();
                    if (IsSignUpValid())
                    {
                        user.AddUser(new UserDto(signUpStrings[0], signUpStrings[1], signUpStrings[2],
                            signUpStrings[3], signUpStrings[4]));
                        signUpStrings = new string[] { null, null, null, null, null };
                        ExplainingScreen.ExplainSuccessScreen();
                        menuSelector.WaitForEscKey();
                        return true;
                    }
                    else
                    {
                        ExplainingScreen.ExplainFailScreen();
                        menuSelector.WaitForEscKey();
                        Console.Clear();
                    }
                }
                else
                    InputSignUp(menuSelector.menuValue);
            }
            return false;
        }

        public void ModifyInformation()
        {
            bool isSelected = true;
            menuSelector.menuValue = 0;
            Console.SetWindowSize(70, 25);
            Console.Clear();

            while (isSelected)
            {
                ExplainingScreen.DrawModifyLogo();
                isSelected = menuSelector.IsMenuSelection((int)Constants.MenuType.AccountModify);
                if (!isSelected)
                    continue;

                if (menuSelector.menuValue == (int)Constants.AccountModifyMenu.Check)
                {
                    if (IsModifyValid())
                    {
                        Modify();
                        ExplainingScreen.ExplainSuccessScreen();
                        menuSelector.WaitForEscKey();
                        return;
                    }
                    else
                    {
                        ExplainingScreen.ExplainFailScreen();
                        menuSelector.WaitForEscKey();
                    }
                }
                else
                    InputInformationToModify(menuSelector.menuValue);
            }

            void Modify()
            {
                if (modifyStrings[0] != null && modifyStrings[0] != "")
                    user.UpdatePassword(modifyStrings[0]);

                if (modifyStrings[1] != null && modifyStrings[1] != "")
                    user.UpdateAge(modifyStrings[1]);

                if (modifyStrings[2] != null && modifyStrings[2] != "")
                    user.UpdatePhoneNumber(modifyStrings[2]);

                if (modifyStrings[3] != null && modifyStrings[3] != "")
                    user.UpdateAddress(modifyStrings[3]);

                modifyStrings = new string[] { null, null, null, null };
            }
        }

        public void RemoveUser()
        {
            user.RemoveUser();
            user.UserIndex = -1;
            id = null;
        }

        public void InputUserId()
        {
            ExplainingScreen.ExplainInputId("유저");
            ExplainingScreen.ExplainInputAccountId();
            id = inputManager.LimitInputLength((int)Constants.InputType.UserId, 9, false);
        }

        private void InputInformationToModify(int inputType)
        {
            switch (inputType)
            {
                case (int)Constants.AccountModifyMenu.Password:
                    modifyStrings[0] = inputManager.LimitInputLength((int)Constants.InputType.ModifyPassword, 5, true);
                    break;
                case (int)Constants.AccountModifyMenu.Age:
                    modifyStrings[1] = inputManager.LimitInputLength((int)Constants.InputType.ModifyAge, 4, false);
                    break;
                case (int)Constants.AccountModifyMenu.PhoneNumber:
                    modifyStrings[2] = inputManager.LimitInputLength((int)Constants.InputType.ModifyPhoneNumber, 15, false);
                    break;
                case (int)Constants.AccountModifyMenu.Address:
                    modifyStrings[3] = inputManager.LimitInputLength((int)Constants.InputType.ModifyAddress, 4, false);
                    break;
            }
        }

        private void InputLogIn(int inputType)
        {
            switch (inputType)
            {
                case (int)Constants.LogInMenu.Id:
                    logInId = inputManager.LimitInputLength((int)Constants.InputType.LogInId, 9, false);
                    break;
                case (int)Constants.LogInMenu.Password:
                    logInPassword = inputManager.LimitInputLength((int)Constants.InputType.LogInPassword, 5, true);
                    break;
            }
        }

        private void InputSignUp(int inputType)
        {
            switch (inputType)
            {
                case (int)Constants.SignUpMenu.Id:
                    signUpStrings[0] = inputManager.LimitInputLength((int)Constants.InputType.SignUpId, 9, false);
                    break;
                case (int)Constants.SignUpMenu.Password:
                    signUpStrings[1] = inputManager.LimitInputLength((int)Constants.InputType.SignUpPassword, 5, true);
                    break;
                case (int)Constants.SignUpMenu.Age:
                    signUpStrings[2] = inputManager.LimitInputLength((int)Constants.InputType.SignUpAge, 4, false);
                    break;
                case (int)Constants.SignUpMenu.PhoneNumber:
                    signUpStrings[3] = inputManager.LimitInputLength((int)Constants.InputType.SignUpPhoneNumber, 13, false);
                    break;
                case (int)Constants.SignUpMenu.Address:
                    signUpStrings[4] = inputManager.LimitInputLength((int)Constants.InputType.SignUpAddress, 20, false);
                    break;
            }
        }

        public bool IsUserIdValid()
        {
            if (id == null)
                return false;

            List<UserDto> userList = user.GetUserList();
            for (int i = 0; i < userList.Count; i++)
            {
                if (id.Equals(userList[i].Id))
                {
                    user.UserIndex = i;
                    return true;
                }
            }
            return false;
        }

        private bool IsLogInValid(int modeType)
        {
            if (logInId == null || logInPassword == null)
                return false;
            else if (!RegularExpressionManager.IsAccountIdValid(logInId) ||
                !RegularExpressionManager.IsAccountPasswordValid(logInPassword))
                return false;

            if (modeType == (int)Constants.ModeMenu.UserMode)
            {
                List<UserDto> userList = user.GetUserList();
                for (int i = 0; i < userList.Count; i++)
                {
                    if (userList[i].Id.Equals(logInId) && userList[i].Password.Equals(logInPassword))
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
                if (logInId.Equals(manager.GetManager().Id) && logInPassword.Equals(manager.GetManager().Password))
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
            foreach (string str in signUpStrings)
            {
                if (str == null)
                    return false;
            }

            foreach (UserDto value in userList)
                if (value.Id.Equals(signUpStrings[0]))
                    return false;

            if (!RegularExpressionManager.IsAccountIdValid(signUpStrings[0]) ||
               !RegularExpressionManager.IsAccountPasswordValid(signUpStrings[1]) ||
               !RegularExpressionManager.IsAgeValid(signUpStrings[2]) ||
               !RegularExpressionManager.IsPhoneNumberValid(signUpStrings[3]) ||
               !RegularExpressionManager.IsAddressValid(signUpStrings[4]))
                return false;

            return true;
        }

        public bool IsModifyValid()
        {
            if (modifyStrings[0] != null)
            {
                if (!RegularExpressionManager.IsAccountPasswordValid(modifyStrings[0]))
                    return false;
            }
            if (modifyStrings[1] != null)
            {
                if (!RegularExpressionManager.IsAgeValid(modifyStrings[1]))
                    return false;
            }
            if (modifyStrings[2] != null)
            {
                if (!RegularExpressionManager.IsPhoneNumberValid(modifyStrings[2]))
                    return false;
            }
            if (modifyStrings[3] != null)
            {
                if (!RegularExpressionManager.IsAddressValid(modifyStrings[3]))
                    return false;
            }
            return true;
        }

        public bool IsUserRemoveValid()
        {
            if (user.GetRentalBookList().Count == 0)
                return true;
            return false;
        }

        public void ShowUsers()
        {
            Console.SetWindowSize(50, 25);
            Console.Clear();
            screen.DrawUsers(user.GetUserList());
        }
    }
}
