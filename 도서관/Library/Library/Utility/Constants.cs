using System;

namespace Library.Utility
{
    public class Constants
    {
        public enum YesNo
        {
            GoBack = -1,
            Yes = 0,
            No = 1,
        }

        public enum LogInSigInMenu
        {
            GoBack = -1,
            LogIn = 0,
            SignUp = 1,
        }

        public enum LogInMenu
        {
            GoBack = -1,
            Id = 0,
            Password = 1
        }

        public enum LibraryMode
        {
            Quit = -1,
            User = 0,
            Manager = 1
        }

        public enum MenuType
        {
            UserManager,
            LogInSignUp,
            YesNo,
            UserInfo,
            ManagerInfo,
            User,
            Manager,
            LogIn,
            SignUp
        }

        public enum UserMenu
        {
            GoBack = -1,
            BookSearch = 0,
            BookRental = 1,
            BookRentalHistory = 2,
            BookReturn = 3,
            BookReturnHistory = 4,
            InfoModify = 5
        }

        public enum ManagerMenu
        {
            GoBack = -1,
            BookSearch = 0,
            BookAdd = 1,
            BookDelete = 2,
            BookModify = 3,
            UserControl = 4,
            RentalHistory = 5
        }

        public enum InfoMenu
        {
            GoBack = -1,
            Modify = 0,
            Delete = 1,
        }

        public enum SignUpMenu
        {
            GoBack = -1,
            Id = 0,
            Password = 1,
            PasswordCheck = 2,
            Name = 3,
            Age = 4,
            PhoneNumber = 5,
            Address = 6
        }

        public enum InputType
        {
            Id,
            Password
        }
    }
}
