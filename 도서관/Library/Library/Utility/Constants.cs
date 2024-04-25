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
            LogInId,
            LogInPassword,
            SignUpId,
            SignUpPassword,
            SignUpAge,
            SignUpPhoneNumber,
            SignUpAddress,
            ModifyPassword,
            ModifyAge,
            ModifyPhoneNumber,
            ModifyAddress,
            SearchedTitle,
            SearchedWriter,
            SearchedPublisher,
            Title,
            Writer,
            Publisher,
            Count,
            Price,
            ReleaseDate,
            ISBN,
            Info,
            BookId,
            UserId
        }

        public static readonly ConsoleKey[] INPUTKEY = new ConsoleKey[] 
        { ConsoleKey.Q, ConsoleKey.W, ConsoleKey.E, ConsoleKey.R, ConsoleKey.T,
        ConsoleKey.Y, ConsoleKey.U, ConsoleKey.I, ConsoleKey.O, ConsoleKey.P,
        ConsoleKey.A, ConsoleKey.S, ConsoleKey.D, ConsoleKey.F, ConsoleKey.G,
        ConsoleKey.H, ConsoleKey.J, ConsoleKey.K, ConsoleKey.L, ConsoleKey.Z,
        ConsoleKey.X, ConsoleKey.C, ConsoleKey.V, ConsoleKey.B, ConsoleKey.N, 
        ConsoleKey.M, ConsoleKey.D0, ConsoleKey.D1, ConsoleKey.D2, ConsoleKey.D3,
        ConsoleKey.D4, ConsoleKey.D5, ConsoleKey.D6, ConsoleKey.D7, ConsoleKey.D8,
        ConsoleKey.D9};
    }
}
