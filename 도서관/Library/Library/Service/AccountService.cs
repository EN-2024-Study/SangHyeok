using Library.Constants;
using Library.Controller;
using Library.Model;
using Library.Model.DtoVo;
using Library.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service
{
    public class AccountService
    {
        private UserDao userDao;
        private ManagerDao managerDao;
        private BookDao bookDao;
        private ExceptionManager exceptionManager;

        public AccountService(UserDao userDao, ManagerDao managerDao, BookDao bookDao) 
        { 
            this.userDao = userDao;
            this.managerDao = managerDao;
            this.bookDao = bookDao;
            this.exceptionManager = new ExceptionManager();
        }

        public bool IsLogInValid(int modeType, string[] logInStrings, string loggedInId)
        {
            if (logInStrings[(int)Enums.LogInMenu.Id] == null || logInStrings[(int)Enums.LogInMenu.Password] == null)
            {
                ExplainingScreen.ExplainFailScreen();
                ExplainingScreen.ExplainNoInput();
                return false;
            }
            else if (!exceptionManager.IsExoressionValid((int)Enums.InputType.SignUpId, logInStrings[(int)Enums.LogInMenu.Id]) ||
                !exceptionManager.IsExoressionValid((int)Enums.InputType.SignUpPassword, logInStrings[(int)Enums.LogInMenu.Password]))
            {
                ExplainingScreen.ExplainFailScreen();
                ExplainingScreen.ExplainInvalidInput("로그인");
                return false;
            }

            if (modeType == (int)Enums.ModeMenu.UserMode)
            {
                List<UserDto> userList = userDao.GetUserList();
                foreach (UserDto user in userList)
                    if (user.Id.Equals(logInStrings[(int)Enums.LogInMenu.Id]) && user.Password.Equals(logInStrings[(int)Enums.LogInMenu.Password]))
                        return true;
            }
            else if (modeType == (int)Enums.ModeMenu.ManagerMode)
            {
                if (logInStrings[(int)Enums.LogInMenu.Id].Equals(managerDao.GetManager().Id) && logInStrings[(int)Enums.LogInMenu.Password].Equals(managerDao.GetManager().Password))
                    return true;
            }

            ExplainingScreen.ExplainFailScreen();
            ExplainingScreen.ExplainInvalidInput("로그인");
            return false;
        }

        public bool IsSignUpValid(string[] signUpStrings)
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
                if (value.Id.Equals(signUpStrings[(int)Enums.SignUpMenu.Id]))
                {
                    ExplainingScreen.ExplainFailScreen();
                    ExplainingScreen.ExplainDuplicationExist("아이디");
                    return false;
                }
            }

            if (!exceptionManager.IsExoressionValid((int)Enums.InputType.SignUpId, signUpStrings[(int)Enums.SignUpMenu.Id]))
            {
                ExplainingScreen.ExplainFailScreen();
                ExplainingScreen.ExplainInvalidInput("아이디");
                return false;
            }
            if (!exceptionManager.IsExoressionValid((int)Enums.InputType.SignUpPassword, signUpStrings[(int)Enums.SignUpMenu.Password]))
            {
                ExplainingScreen.ExplainFailScreen();
                ExplainingScreen.ExplainInvalidInput("비밀번호");
                return false;
            }
            if (!exceptionManager.IsExoressionValid((int)Enums.InputType.SignUpAge, signUpStrings[(int)Enums.SignUpMenu.Age]))
            {
                ExplainingScreen.ExplainFailScreen();
                ExplainingScreen.ExplainInvalidInput("나이");
                return false;
            }
            if (!exceptionManager.IsExoressionValid((int)Enums.InputType.SignUpPhoneNumber, signUpStrings[(int)Enums.SignUpMenu.PhoneNumber]))
            {
                ExplainingScreen.ExplainFailScreen();
                ExplainingScreen.ExplainInvalidInput("휴대폰");
                return false;
            }
            if (!exceptionManager.IsAddressValid(signUpStrings[(int)Enums.SignUpMenu.Address]))
            {
                ExplainingScreen.ExplainFailScreen();
                ExplainingScreen.ExplainInvalidInput("주소");
                return false;
            }

            return true;
        }

        public bool IsModifyValid(string[] modifyStrings)
        {
            if (modifyStrings[(int)Enums.AccountModifyMenu.Password] != null && 
                !exceptionManager.IsExoressionValid((int)Enums.InputType.SignUpPassword, modifyStrings[(int)Enums.AccountModifyMenu.Password]))
            {
                ExplainingScreen.ExplainFailScreen();
                ExplainingScreen.ExplainInvalidInput("비밀번호");
                return false;
            }
            if (modifyStrings[(int)Enums.AccountModifyMenu.Age] != null && 
                !exceptionManager.IsExoressionValid((int)Enums.InputType.SignUpAge, modifyStrings[(int)Enums.AccountModifyMenu.Age]))
            {
                ExplainingScreen.ExplainFailScreen();
                ExplainingScreen.ExplainInvalidInput("나이");
                return false;
            }
            if (modifyStrings[(int)Enums.AccountModifyMenu.PhoneNumber] != null && 
                !exceptionManager.IsExoressionValid((int)Enums.InputType.SignUpPhoneNumber, modifyStrings[(int)Enums.AccountModifyMenu.PhoneNumber]))
            {
                ExplainingScreen.ExplainFailScreen();
                ExplainingScreen.ExplainInvalidInput("휴대폰 번호");
                return false;
            }
            if (modifyStrings[(int)Enums.AccountModifyMenu.Address] != null && 
                !exceptionManager.IsAddressValid(modifyStrings[(int)Enums.AccountModifyMenu.Address]))
            {
                ExplainingScreen.ExplainFailScreen();
                ExplainingScreen.ExplainInvalidInput("주소");
                return false;
            }
            return true;
        }

        public bool IsUserRemoveValid(string loggedInId)
        {
            List<RentalBookDto> bookList = bookDao.GetRentalBookList();
            foreach (RentalBookDto book in bookList)
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

        public bool IsUserIdValid(string loggedInId, string searchId)
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

        public void ModifyAccount(string[] modifyStrings, string loggedInId)
        {
            if (modifyStrings[(int)Enums.AccountModifyMenu.Password] != null && modifyStrings[0] != "")
                userDao.UpdateUser(loggedInId, "password", modifyStrings[(int)Enums.AccountModifyMenu.Password]);

            if (modifyStrings[(int)Enums.AccountModifyMenu.Age] != null && modifyStrings[1] != "")
                userDao.UpdateUser(loggedInId, "age", modifyStrings[(int)Enums.AccountModifyMenu.Age]);

            if (modifyStrings[(int)Enums.AccountModifyMenu.PhoneNumber] != null && modifyStrings[2] != "")
                userDao.UpdateUser(loggedInId, "phonenumber", modifyStrings[(int)Enums.AccountModifyMenu.PhoneNumber]);

            if (modifyStrings[(int)Enums.AccountModifyMenu.Address] != null && modifyStrings[3] != "")
                userDao.UpdateUser(loggedInId, "address", modifyStrings[(int)Enums.AccountModifyMenu.Address]);
        }
    }
}
