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
            Password,
            Check
        }

        public enum SignUpMenu
        {
            Id,
            Password,
            Age,
            PhoneNumber,
            Address,
            Check
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

        public enum BookSearchMenu
        {
            Title,
            Writer,
            Publisher,
            Check
        }

        public enum Book
        {
            All,
            Searched,
            Rental,
            Return
        }

        public enum InputType
        {
            Id,
            Password,
            Age,
            PhoneNumber,
            Address,
            Title,
            Writer,
            Publisher,
            BookId
        }
    }
}
