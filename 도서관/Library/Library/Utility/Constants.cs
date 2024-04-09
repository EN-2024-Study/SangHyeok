using System;
using System.Collections.Generic;

namespace Library.Utility
{
    public class Constants
    {

        public enum YesNo
        {
            Yes,
            No
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
    }
}
