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
                    if (user.Id.Equals(logInStrings[0]) && user.Password.Equals(logInStrings[1]))
                        return true;
            }
            else if (modeType == (int)Enums.ModeMenu.ManagerMode)
            {
                if (logInStrings[0].Equals(managerDao.GetManager().Id) && logInStrings[1].Equals(managerDao.GetManager().Password))
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

        public bool IsModifyValid(string[] modifyStrings)
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
            if (modifyStrings[0] != null && modifyStrings[0] != "")
                userDao.UpdateUser(loggedInId, "password", modifyStrings[0]);

            if (modifyStrings[1] != null && modifyStrings[1] != "")
                userDao.UpdateUser(loggedInId, "age", modifyStrings[1]);

            if (modifyStrings[2] != null && modifyStrings[2] != "")
                userDao.UpdateUser(loggedInId, "phonenumber", modifyStrings[2]);

            if (modifyStrings[3] != null && modifyStrings[3] != "")
                userDao.UpdateUser(loggedInId, "address", modifyStrings[3]);

        }
    }
}
