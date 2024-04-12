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
            User,
            Manager
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

        public enum ModeMenu
        {
            Quit = -1,
            UserMode = 0,
            ManagerMode = 1,    
        }

        public enum UserMenu
        {
            BookSearch,
            BookRental,
            BookRentalHistory,
            BookReturn,
            BookReturnHistory,
            InfoModify
        }

        public enum ManagerMenu
        {
            BookSearch,
            BookAdd,
            BookDelete,
            BookModify,
            UserControl,
            RentalHistory
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
    }
}
