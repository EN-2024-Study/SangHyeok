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

        public enum ModeMenu
        {
            UserMode,
            ManagerMode,
            Quit
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
            Regex
        }


        public enum User
        {
            Id,
            Password,
            Name,
            Age,
            PhoneNumber,
            Address
        }
    }
}
