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
            LogIn,
            SignUp,
            GoBack
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
            UserMode,
            ManagerMode,
            Quit
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
            Modify,
            Delete,
            GoBack
        }
    }
}
