using Library.Model;
using Library.View;
using System;
using System.Collections.Generic;
using Library.Constants;

namespace Library.Controller
{
    public class AccountController
    {
        private MenuSelector menuSelector;
        private ExceptionManager exceptionManager;
        private InputManager inputManager;
        private UserDao userDao;
        private BookDao bookDao;
        private ManagerDao manager;
        private Screen screen;
        private string[] signUpStrings, modifyStrings, logInStrings;
        private string searchId;
        private static string loggedInId;

        public AccountController(MenuSelector menuSelector, ExceptionManager exceptionManager)
        {
            this.menuSelector = menuSelector;
            this.exceptionManager = exceptionManager;
            this.inputManager = new InputManager();
            this.userDao = new UserDao();
            this.bookDao = new BookDao();
            this.manager = new ManagerDao(); 
            this.screen = new Screen();
            this.signUpStrings = new string[] { null, null, null, null, null };
            this.modifyStrings = new string[] { null, null, null, null };
            this.logInStrings = new string[] { null, null };
            this.searchId = null;
        }

        public bool IsLogIn(int modeType)
        {
            bool isSelected = true;
            menuSelector.menuValue = 0;
            Console.Clear();

            while (isSelected)
            {
                ExplainingScreen.DrawStartLogo();
                isSelected = menuSelector.IsMenuSelection((int)Enums.MenuType.LogIn);
                if (!isSelected)
                    continue;

                if (menuSelector.menuValue == (int)Enums.LogInMenu.Check)
                {
                    if (IsLogInValid(modeType))
                    {
                        ExplainingScreen.ExplainSuccessScreen();
                        menuSelector.WaitForEscKey();
                        return true;
                    }
                   
                    menuSelector.WaitForEscKey();
                    Console.Clear();
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
            Console.Clear();

            while (isSelected)
            {
                ExplainingScreen.DrawSIgnUpLogo();
                ExplainingScreen.ExplainInputAddress();
                isSelected = menuSelector.IsMenuSelection((int)Enums.MenuType.SignUp);
                if (!isSelected)
                    continue;

                if (menuSelector.menuValue == (int)Enums.SignUpMenu.Check)
                {
                    Console.Clear();
                    if (IsSignUpValid())
                    {
                        userDao.AddUser(new UserDto(signUpStrings[0], signUpStrings[1], signUpStrings[2],
                            signUpStrings[3], signUpStrings[4]));
                        signUpStrings = new string[] { null, null, null, null, null };
                        ExplainingScreen.ExplainSuccessScreen();
                        menuSelector.WaitForEscKey();
                        return true;
                    }
                    menuSelector.WaitForEscKey();
                    Console.Clear();
                }
                else
                    InputSignUp(menuSelector.menuValue);
            }
            return false;
        }

        public void ControllUserModifyScreen()
        {
            bool isSelected = true;
            menuSelector.menuValue = 0;

            ShowUserInfo();
            while (isSelected)
            {
                ExplainingScreen.DrawModifyLogo();
                ExplainingScreen.ExplainInputAddress();
                isSelected = menuSelector.IsMenuSelection((int)Enums.MenuType.AccountModify);
                if (!isSelected)
                    continue;

                if (menuSelector.menuValue == (int)Enums.AccountModifyMenu.Check)
                {
                    if (IsModifyValid())
                    {
                        ModifyAccount();
                        ExplainingScreen.ExplainSuccessScreen();
                        menuSelector.WaitForEscKey();
                        return;
                    }
                    menuSelector.WaitForEscKey();
                    Console.Clear();
                }
                else
                    InputInformationToModify(menuSelector.menuValue);
            }
        }

        public bool ControllUserDeleteScreen()
        {
            if (IsUserRemoveValid())
            {
                RemoveUser();
                ExplainingScreen.ExplainSuccessScreen();
                menuSelector.WaitForEscKey();
                return true;
            }

            menuSelector.WaitForEscKey();
            return false;
        }

        public void ControllMemberModifyScreen()
        {
            ShowAllUser();
            InputUserId();
            if (SearchId == null)
                return;
            else if (IsUserIdValid())
                ControllUserModifyScreen();
            else
                menuSelector.WaitForEscKey();
        }

        public void ControllMemberDeleteMenu()
        {
            ShowAllUser();
            InputUserId();
            if (SearchId == null)
                return;
            else if (IsUserIdValid() && IsUserRemoveValid())
            {
                RemoveUser();
                ExplainingScreen.ExplainSuccessScreen();
            }
            menuSelector.WaitForEscKey();
        }

        public void ModifyAccount()
        {
            if (modifyStrings[0] != null && modifyStrings[0] != "")
                userDao.UpdateUser(loggedInId, "password", modifyStrings[0]);

            if (modifyStrings[1] != null && modifyStrings[1] != "")
                userDao.UpdateUser(loggedInId, "age", modifyStrings[1]);

            if (modifyStrings[2] != null && modifyStrings[2] != "")
                userDao.UpdateUser(loggedInId, "phonenumber", modifyStrings[2]);

            if (modifyStrings[3] != null && modifyStrings[3] != "")
                userDao.UpdateUser(loggedInId, "address", modifyStrings[3]);

            modifyStrings = new string[] { null, null, null, null };
        }

        public void RemoveUser()
        {
            userDao.RemoveUser(loggedInId);
            loggedInId = null;
            searchId = null;
        }

        public void InputUserId()
        {
            ExplainingScreen.ExplainInputId("유저");
            ExplainingScreen.ExplainInputAccountId();
            ExplainingScreen.DrawIdLogo();
            searchId = inputManager.LimitInputLength((int)Enums.InputType.UserId, false);
        }

        private void InputInformationToModify(int inputType)
        {
            switch (inputType)
            {
                case (int)Enums.AccountModifyMenu.Password:
                    modifyStrings[0] = inputManager.LimitInputLength((int)Enums.InputType.ModifyPassword, true);
                    break;
                case (int)Enums.AccountModifyMenu.Age:
                    modifyStrings[1] = inputManager.LimitInputLength((int)Enums.InputType.ModifyAge, false);
                    break;
                case (int)Enums.AccountModifyMenu.PhoneNumber:
                    modifyStrings[2] = inputManager.LimitInputLength((int)Enums.InputType.ModifyPhoneNumber, false);
                    break;
                case (int)Enums.AccountModifyMenu.Address:
                    modifyStrings[3] = inputManager.LimitInputLength((int)Enums.InputType.ModifyAddress, false);
                    break;
            }
        }

        private void InputLogIn(int inputType)
        {
            switch (inputType)
            {
                case (int)Enums.LogInMenu.Id:
                    logInStrings[0] = inputManager.LimitInputLength((int)Enums.InputType.LogInId, false);
                    break;
                case (int)Enums.LogInMenu.Password:
                    logInStrings[1] = inputManager.LimitInputLength((int)Enums.InputType.LogInPassword, true);
                    break;
            }
        }

        private void InputSignUp(int inputType)
        {
            switch (inputType)
            {
                case (int)Enums.SignUpMenu.Id:
                    signUpStrings[0] = inputManager.LimitInputLength((int)Enums.InputType.SignUpId, false);
                    break;
                case (int)Enums.SignUpMenu.Password:
                    signUpStrings[1] = inputManager.LimitInputLength((int)Enums.InputType.SignUpPassword, true);
                    break;
                case (int)Enums.SignUpMenu.Age:
                    signUpStrings[2] = inputManager.LimitInputLength((int)Enums.InputType.SignUpAge, false);
                    break;
                case (int)Enums.SignUpMenu.PhoneNumber:
                    signUpStrings[3] = inputManager.LimitInputLength((int)Enums.InputType.SignUpPhoneNumber, false);
                    break;
                case (int)Enums.SignUpMenu.Address:
                    signUpStrings[4] = inputManager.LimitInputLength((int)Enums.InputType.SignUpAddress, false);
                    break;
            }
        }

        public bool IsUserIdValid()
        {
            if (searchId == null)
            {
                ExplainingScreen.ExplainFailScreen();
                ExplainingScreen.ExplainNoInput();
                return false;
            }

            List<UserDto> userList = userDao.GetUserList();
            for (int i = 0; i < userList.Count; i++)
            {
                if (searchId.Equals(userList[i].Id))
                {
                    loggedInId = searchId;
                    return true;
                }
            }

            ExplainingScreen.ExplainFailScreen();
            ExplainingScreen.ExplainInvalidInput("유저 아이디");
            return false;
        }

        private bool IsLogInValid(int modeType)
        {
            if (logInStrings[0] == null || logInStrings[1] == null)
            {
                ExplainingScreen.ExplainFailScreen();
                ExplainingScreen.ExplainNoInput();
                return false;
            }
            else if (!exceptionManager.IsExoressionValid((int)Enums.InputType.SignUpId, logInStrings[0]) ||
                !exceptionManager.IsExoressionValid((int)Enums.InputType.SignUpPassword, logInStrings[1]))
            {
                ExplainingScreen.ExplainFailScreen();
                ExplainingScreen.ExplainInvalidInput("로그인");
                return false;
            }

            if (modeType == (int)Enums.ModeMenu.UserMode)
            {
                List<UserDto> userList = userDao.GetUserList();
                foreach (UserDto user in userList)
                {
                    if (user.Id.Equals(logInStrings[0]) && user.Password.Equals(logInStrings[1]))
                    {
                        loggedInId = logInStrings[0];
                        logInStrings = new string[] { null, null };
                        return true;
                    }
                }
            }
            else if (modeType == (int)Enums.ModeMenu.ManagerMode)
            {
                if (logInStrings[0].Equals(manager.GetManager().Id) && logInStrings[1].Equals(manager.GetManager().Password))
                {
                    logInStrings = new string[] { null, null };
                    return true;
                }
            }

            ExplainingScreen.ExplainFailScreen();
            ExplainingScreen.ExplainInvalidInput("로그인");
            return false;
        }

        private bool IsSignUpValid()
        {
            List<UserDto> userList = userDao.GetUserList();
            foreach (string str in signUpStrings)
            {
                if (str == null)
                {
                    ExplainingScreen.ExplainFailScreen();
                    ExplainingScreen.ExplainNoInput();
                    return false;
                }
            }

            foreach (UserDto value in userList)
            {
                if (value.Id.Equals(signUpStrings[0]))
                {
                    ExplainingScreen.ExplainFailScreen();
                    ExplainingScreen.ExplainDuplicationExist("아이디");
                    return false;
                }
            }

            if (!exceptionManager.IsExoressionValid((int)Enums.InputType.SignUpId, signUpStrings[0]))
            {
                ExplainingScreen.ExplainFailScreen();
                ExplainingScreen.ExplainInvalidInput("아이디");
                return false;
            }
            if (!exceptionManager.IsExoressionValid((int)Enums.InputType.SignUpPassword, signUpStrings[1]))
            {
                ExplainingScreen.ExplainFailScreen();
                ExplainingScreen.ExplainInvalidInput("비밀번호");
                return false;
            }
            if (!exceptionManager.IsExoressionValid((int)Enums.InputType.SignUpAge, signUpStrings[2]))
            {
                ExplainingScreen.ExplainFailScreen();
                ExplainingScreen.ExplainInvalidInput("나이");
                return false;
            }
            if (!exceptionManager.IsExoressionValid((int)Enums.InputType.SignUpPhoneNumber, signUpStrings[3]))
            {
                ExplainingScreen.ExplainFailScreen();
                ExplainingScreen.ExplainInvalidInput("휴대폰");
                return false;
            }
            if (!exceptionManager.IsAddressValid(signUpStrings[4]))
            {
                ExplainingScreen.ExplainFailScreen();
                ExplainingScreen.ExplainInvalidInput("주소");
                return false;
            }

            return true;
        }

        public bool IsModifyValid()
        {
            if (modifyStrings[0] != null && !exceptionManager.IsExoressionValid((int)Enums.InputType.SignUpPassword, modifyStrings[0]))
            {
                ExplainingScreen.ExplainFailScreen();
                ExplainingScreen.ExplainInvalidInput("비밀번호");
                return false;
            }
            if (modifyStrings[1] != null && !exceptionManager.IsExoressionValid((int)Enums.InputType.SignUpAge, modifyStrings[1]))
            {
                ExplainingScreen.ExplainFailScreen();
                ExplainingScreen.ExplainInvalidInput("나이");
                return false;
            }
            if (modifyStrings[2] != null && !exceptionManager.IsExoressionValid((int)Enums.InputType.SignUpPhoneNumber, modifyStrings[2]))
            {
                ExplainingScreen.ExplainFailScreen();
                ExplainingScreen.ExplainInvalidInput("휴대폰 번호");
                return false;
            }
            if (modifyStrings[3] != null && !exceptionManager.IsAddressValid(modifyStrings[3]))
            {
                ExplainingScreen.ExplainFailScreen();
                ExplainingScreen.ExplainInvalidInput("주소");
                return false;
            }
            return true;
        }

        public bool IsUserRemoveValid()
        {
            List<RentalBookDto> bookList = bookDao.GetRentalBookList();
            foreach(RentalBookDto book in bookList)
            {
                if (book.UserId.Equals(loggedInId)) // 빌린 도서가 존재한다면 false
                {
                    ExplainingScreen.ExplainFailScreen();
                    ExplainingScreen.ExplainDuplicationExist("빌린 도서");
                    return false;
                }
            }
            return true;
        }

        public void ShowAllUser()
        {
            Console.SetWindowSize(50, 40);
            Console.Clear();
            screen.DrawUsers(userDao.GetUserList());
        }

        private void ShowUserInfo()
        {
            List<UserDto> userList = userDao.GetUserList();
            UserDto loggedUser = null;

            foreach(UserDto user in userList)
            {
                if (user.Id.Equals(loggedInId))
                {
                    loggedUser = user;
                    break;
                }
            }

            Console.SetWindowSize(70, 40);
            Console.Clear();
            screen.DrawUserInfo(20, loggedUser);
        }

        public string SearchId
        { get { return searchId; } }

        public string LoggedInId
        { get { return loggedInId; } }
    }
}