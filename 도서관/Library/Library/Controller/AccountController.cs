using Library.Model;
using Library.View;
using System;
using System.Collections.Generic;
using Library.Constants;
using Library.Service;
using Library.Model.DtoVo;

namespace Library.Controller
{
    public class AccountController
    {
        private MenuSelector menuSelector;
        private InputManager inputManager;
        private UserDao userDao;
        private BookDao bookDao;
        private ManagerDao managerDao;
        private LogController logController;
        private AccountService accountService;
        private Screen screen;
        private string[] signUpStrings, modifyStrings, logInStrings;
        private string searchId;
        private static string loggedInId;

        public AccountController(MenuSelector menuSelector, LogController logController)
        {
            this.menuSelector = menuSelector;
            this.logController = logController;
            this.inputManager = new InputManager();
            this.userDao = new UserDao();
            this.bookDao = new BookDao();
            this.managerDao = new ManagerDao(); 
            this.screen = new Screen();
            this.accountService = new AccountService(userDao, managerDao, bookDao);
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
                    if (accountService.IsLogInValid(modeType, logInStrings, loggedInId))
                    {
                        loggedInId = logInStrings[(int)Enums.LogInMenu.Id];
                        logInStrings = new string[] { null, null };
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
                    if (accountService.IsSignUpValid(signUpStrings))
                    {
                        userDao.AddUser(new UserDto(signUpStrings[(int)Enums.SignUpMenu.Id], 
                            signUpStrings[(int)Enums.SignUpMenu.Password], signUpStrings[(int)Enums.SignUpMenu.Age],
                            signUpStrings[(int)Enums.SignUpMenu.PhoneNumber], signUpStrings[(int)Enums.SignUpMenu.Address]));

                        logController.AddLog(signUpStrings[(int)Enums.SignUpMenu.Id], LogStrings.SIGNUP, LogStrings.BLANK);
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
                    if (accountService.IsModifyValid(modifyStrings))
                    {
                        accountService.ModifyAccount(modifyStrings, loggedInId);
                        logController.AddLog(loggedInId, LogStrings.ACCOUNT_MODIFY, LogStrings.BLANK);
                        modifyStrings = new string[] { null, null, null, null };
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
            if (accountService.IsUserRemoveValid(loggedInId))
            {
                logController.AddLog(loggedInId, LogStrings.ACCOUNT_DELETE, LogStrings.BLANK);
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
            else if (accountService.IsUserIdValid(loggedInId, searchId))
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
            else if (accountService.IsUserIdValid(loggedInId, searchId) && accountService.IsUserRemoveValid(loggedInId))
            {
                logController.AddLog(LogStrings.MANAGER, loggedInId, LogStrings.ACCOUNT_DELETE);
                RemoveUser();
                ExplainingScreen.ExplainSuccessScreen();
            }
            menuSelector.WaitForEscKey();
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