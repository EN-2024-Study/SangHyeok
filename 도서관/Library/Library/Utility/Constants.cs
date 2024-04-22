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
            ManagerMode,
            BookSearch,
            YesNo,
            AccountModify
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

        public enum AccountModifyMenu
        {
            Id,
            Password,
            Age,
            PhoneNumber,
            Address,
        }

        public enum UserMode
        {
            BookSearch,
            BookRental,
            BookRentalHistory,
            BookReturn,
            BookReturnHistory,
            AccountInfo,
            AccountDelete
        }

        public enum ManagerMode
        {
            BookSearch,
            BookAdd,
            BookDelete,
            BookModify,
            AccountModify,
            AccountDelete,
            RentalHistory
        }

        public enum InputType
        {
            Id,
            Password,
            Age,
            PhoneNumber,
            Address
        }
    }
}
