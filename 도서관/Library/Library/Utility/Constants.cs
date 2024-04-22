using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Utility
{
    public class Constants
    {
        public enum MenuType
        {
            Mode,
            LogInSignUp,
            LogIn,
            UserMode,
            BookSearch,
            YesNo,
            ManagerMode
        }

        public enum ModeMenu
        {
            UserMode,
            ManagerMode
        }

        public enum LogInSignUpMenu
        {
            LogIn,
            SignUp
        }

        public enum LogInMenu
        {
            Id,
            Password
        }

        public enum InputType
        {
            Id,
            Password
        }
    }
}
