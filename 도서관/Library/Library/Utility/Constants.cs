using System;
using System.Collections.Generic;

namespace Library.Utility
{
    public class Constants
    {
        public enum YesNo
        {
            No,
            Yes
        }

        public enum LogInMenu
        {
            GoBack = -1,
            LogIn = 0,
            SignUp = 1,
        }

        public enum LogIn
        {
            Id,
            Password
        }

        public enum LibraryMode
        {
            User,
            Manager
        }

        public enum Type
        {
            UserManager,
            LogInSignUp,
            YesNo,
            UserInfo,
            ManagerInfo
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
    }
}
