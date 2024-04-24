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
            SignUp,
            AccountModify,
            BookAdd,
            BookModify
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

        public enum AccountModifyMenu
        {
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
            AccountModify,
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

        public enum BookIdType
        {
            Rental,
            Return,
            Add,
            Modify,
            Delete
        }

        public enum BookSearchMenu
        {
            Title,
            Writer,
            Publisher,
            Check
        }

        public enum BookShowType
        {
            All,
            Searched,
            Rental,
            Return
        }

        public enum BookAddInfo
        {
            Title,
            Writer,
            Publisher,
            Count,
            Price,
            ReleaseDate,
            ISBN,
            Info,
            Check
        }

        public enum BookModifyInfo
        {
            Title,
            Writer,
            Publisher,
            Count,
            Price,
            ReleaseDate,
            Check
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
            BookId,
            ModifyPassword,
            ModifyAge,
            ModifyPhoneNumber,
            ModifyAddress,
            AddedTitle,
            AddedWriter,
            AddedPublisher,
            AddedCount,
            AddedPrice,
            AddedReleaseDate,
            AddedISBN,
            AddedInfo,
            ModifiedTitle,
            ModifiedWriter,
            ModifiedPublisher,
            ModifiedCount,
            ModifiedPrice,
            ModifiedReleaseData,
            UserId
        }
    }
}
