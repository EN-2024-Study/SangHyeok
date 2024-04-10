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

        public enum Error
        {
            Length,
            Correspond
        }


        public enum User
        {
            Id,
            Password,
            Name,
            Age,
            PhoneNumber,
            Address,
            Check
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
            YesNo
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
    }
}
