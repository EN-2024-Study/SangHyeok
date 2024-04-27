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
        private UserRepository userRepository;
        private BookRepository bookRepository;
        private ManagerRepository manager;
        private Screen screen;
        private string[] signUpStrings, modifyStrings, logInStrings;
        private string searchId, loggedInId;

        public AccountController()
        {
            this.menuSelector = new MenuSelector();
            this.inputManager = new InputManager();
            this.userRepository = new UserRepository();
            this.bookRepository = new BookRepository();
            this.manager = new ManagerRepository(); 
            this.screen = new Screen();
            this.signUpStrings = new string[] { null, null, null, null, null };
            this.modifyStrings = new string[] { null, null, null, null };
            this.logInStrings = new string[] { null, null };
            this.searchId = null;
            this.loggedInId = null;
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
                        userRepository.AddUser(new UserDto(signUpStrings[0], signUpStrings[1], signUpStrings[2],
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
                        Console.Clear();
                    }
                }
                else
                    InputInformationToModify(menuSelector.menuValue);
            }

            void Modify()
            {
                if (modifyStrings[0] != null && modifyStrings[0] != "")
                    userRepository.UpdateUser(loggedInId, "password", modifyStrings[0]);

                if (modifyStrings[1] != null && modifyStrings[1] != "")
                    userRepository.UpdateUser(loggedInId, "age", modifyStrings[1]);

                if (modifyStrings[2] != null && modifyStrings[2] != "")
                    userRepository.UpdateUser(loggedInId, "phonenumber", modifyStrings[2]);

                if (modifyStrings[3] != null && modifyStrings[3] != "")
                    userRepository.UpdateUser(loggedInId, "address", modifyStrings[3]);

                modifyStrings = new string[] { null, null, null, null };
            }
        }

        public void RemoveUser()
        {
            userRepository.RemoveUser(loggedInId);
            loggedInId = null;
            searchId = null;
        }

        public void InputUserId()
        {
            ExplainingScreen.ExplainInputId("유저");
            ExplainingScreen.ExplainInputAccountId();
            ExplainingScreen.DrawIdLogo();
            searchId = inputManager.LimitInputLength((int)Constants.InputType.UserId, false);
        }

        private void InputInformationToModify(int inputType)
        {
            switch (inputType)
            {
                case (int)Constants.AccountModifyMenu.Password:
                    modifyStrings[0] = inputManager.LimitInputLength((int)Constants.InputType.ModifyPassword, true);
                    break;
                case (int)Constants.AccountModifyMenu.Age:
                    modifyStrings[1] = inputManager.LimitInputLength((int)Constants.InputType.ModifyAge, false);
                    break;
                case (int)Constants.AccountModifyMenu.PhoneNumber:
                    modifyStrings[2] = inputManager.LimitInputLength((int)Constants.InputType.ModifyPhoneNumber, false);
                    break;
                case (int)Constants.AccountModifyMenu.Address:
                    modifyStrings[3] = inputManager.LimitInputLength((int)Constants.InputType.ModifyAddress, false);
                    break;
            }
        }

        private void InputLogIn(int inputType)
        {
            switch (inputType)
            {
                case (int)Constants.LogInMenu.Id:
                    logInStrings[0] = inputManager.LimitInputLength((int)Constants.InputType.LogInId, false);
                    break;
                case (int)Constants.LogInMenu.Password:
                    logInStrings[1] = inputManager.LimitInputLength((int)Constants.InputType.LogInPassword, true);
                    break;
            }
        }

        private void InputSignUp(int inputType)
        {
            switch (inputType)
            {
                case (int)Constants.SignUpMenu.Id:
                    signUpStrings[0] = inputManager.LimitInputLength((int)Constants.InputType.SignUpId, false);
                    break;
                case (int)Constants.SignUpMenu.Password:
                    signUpStrings[1] = inputManager.LimitInputLength((int)Constants.InputType.SignUpPassword, true);
                    break;
                case (int)Constants.SignUpMenu.Age:
                    signUpStrings[2] = inputManager.LimitInputLength((int)Constants.InputType.SignUpAge, false);
                    break;
                case (int)Constants.SignUpMenu.PhoneNumber:
                    signUpStrings[3] = inputManager.LimitInputLength((int)Constants.InputType.SignUpPhoneNumber, false);
                    break;
                case (int)Constants.SignUpMenu.Address:
                    signUpStrings[4] = inputManager.LimitInputLength((int)Constants.InputType.SignUpAddress, false);
                    break;
            }
        }

        public bool IsUserIdValid()
        {
            if (searchId == null)
                return false;

            List<UserDto> userList = userRepository.GetUserList();
            for (int i = 0; i < userList.Count; i++)
            {
                if (searchId.Equals(userList[i].Id))
                {
                    loggedInId = searchId;
                    return true;
                }
            }
            return false;
        }

        private bool IsLogInValid(int modeType)
        {
            if (logInStrings[0] == null || logInStrings[1] == null)
                return false;
            else if (!RegularExpressionManager.IsAccountIdValid(logInStrings[0]) ||
                !RegularExpressionManager.IsAccountPasswordValid(logInStrings[1]))
                return false;

            if (modeType == (int)Constants.ModeMenu.UserMode)
            {
                List<UserDto> userList = userRepository.GetUserList();

                for (int i = 0; i < userList.Count; i++)
                {
                    if (userList[i].Id.Equals(logInStrings[0]) && userList[i].Password.Equals(logInStrings[1]))
                    {
                        loggedInId = logInStrings[0];
                        logInStrings = new string[] { null, null };
                        return true;
                    }
                }
            }
            else if (modeType == (int)Constants.ModeMenu.ManagerMode)
            {
                if (logInStrings[0].Equals(manager.GetManager().Id) && logInStrings[1].Equals(manager.GetManager().Password))
                {
                    logInStrings = new string[] { null, null };
                    return true;
                }
            }

            return false;
        }

        private bool IsSignUpValid()
        {
            List<UserDto> userList = userRepository.GetUserList();
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
            List<RentalBookDto> bookList = bookRepository.GetRentalBookList();
            foreach(RentalBookDto book in bookList)
            {
                if (book.UserId.Equals(loggedInId))
                    return false;
            }
            return true;
        }

        public void ShowUsers()
        {
            Console.SetWindowSize(50, 25);
            Console.Clear();
            screen.DrawUsers(userRepository.GetUserList());
        }

        public string SearchId
        { get { return searchId; } }

        public string LoggedInId
        { get { return loggedInId; } }
    }
}