using Library.Constants;
using Library.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Controller
{
    public class MenuController
    {
        private MenuSelector menuSelector;
        private AccountController accountController;
        private BookController bookController;

        public MenuController()
        {
            this.menuSelector = new MenuSelector();
            this.accountController = new AccountController(menuSelector);
            this.bookController = new BookController(menuSelector, accountController);
        }

        public void ControllModeMenu()
        {
            bool isSelected = true;
            menuSelector.menuValue = 0;

            while (isSelected)
            {
                Console.SetWindowSize(70, 25);
                Console.Clear();
                ExplainingScreen.DrawStartLogo();
                ExplainingScreen.ExplainArrowKeys();
                ExplainingScreen.ExplainQuitKey();
                isSelected = menuSelector.IsMenuSelection((int)Enums.MenuType.Mode);
                if (!isSelected)
                    continue;

                switch (menuSelector.menuValue)
                {
                    case (int)Enums.ModeMenu.UserMode:
                        ControllLogInSignUpMenu();
                        break;
                    case (int)Enums.ModeMenu.ManagerMode:
                        if (accountController.IsLogIn((int)Enums.ModeMenu.ManagerMode))
                            ControllManagerModeMenu();
                        break;
                }
            }
        }

        private void ControllLogInSignUpMenu()
        {
            bool isSelected = true;
            menuSelector.menuValue = 0;

            while (isSelected)
            {
                Console.SetWindowSize(70, 25);
                Console.Clear();
                ExplainingScreen.DrawStartLogo();

                isSelected = menuSelector.IsMenuSelection((int)Enums.MenuType.LogInSignUp);
                if (!isSelected)
                    continue;

                switch (menuSelector.menuValue)
                {
                    case (int)Enums.LogInSignUpMenu.LogIn:
                        if (accountController.IsLogIn((int)Enums.ModeMenu.UserMode))
                            ControllUserModeMenu();
                        break;
                    case (int)Enums.LogInSignUpMenu.SignUp:
                        if (accountController.IsSignUp())
                            return;
                        break;
                }
            }
        }

        private void ControllUserModeMenu()
        {
            bool isSelected = true;
            menuSelector.menuValue = 0;

            while (isSelected)
            {
                Console.SetWindowSize(70, 20);
                Console.Clear();
                ExplainingScreen.DrawLibraryLogo();

                isSelected = menuSelector.IsMenuSelection((int)Enums.MenuType.UserMode);
                if (!isSelected)
                    continue;

                switch(menuSelector.menuValue)
                {
                    case (int)Enums.UserMode.BookSearch:
                        bookController.SearchBook();
                        break;
                    case (int)Enums.UserMode.BookRental:
                        ControllRentalBookMenu();
                        break;
                    case (int)Enums.UserMode.BookRentalHistory:
                        bookController.ShowRentalBooks();
                        ExplainingScreen.ExplainEcsKey(0);
                        menuSelector.WaitForEscKey();
                        break;
                    case (int)Enums.UserMode.BookReturn:
                        ControllReturnBookMenu();
                        break;
                    case (int)Enums.UserMode.BookReturnHistory:
                        bookController.ShowReturnBooks();
                        ExplainingScreen.ExplainEcsKey(0);
                        menuSelector.WaitForEscKey();
                        break;
                    case (int)Enums.UserMode.AccountModify:
                        accountController.ModifyInformation();
                        break;
                    case (int)Enums.UserMode.AccountDelete:
                        ControllUserDeleteMenu();
                        break;
                }
            }
        }

        private void ControllManagerModeMenu()
        {
            bool isSelected = true;
            menuSelector.menuValue = 0;

            while (isSelected)
            {
                Console.SetWindowSize(70, 20);
                Console.Clear();
                ExplainingScreen.DrawLibraryLogo();

                isSelected = menuSelector.IsMenuSelection((int)Enums.MenuType.ManagerMode);
                if (!isSelected)
                    continue;

                switch(menuSelector.menuValue)
                {
                    case (int)Enums.ManagerMode.BookSearch:
                        bookController.SearchBook();
                        break;
                    case (int)Enums.ManagerMode.BookAdd:
                        bookController.AddBook();
                        break;
                    case (int)Enums.ManagerMode.BookDelete:
                        ControllBookDeleteMenu();
                        break;
                    case (int)Enums.ManagerMode.BookModify:
                        ControllBookModifyMenu();
                        break;
                    case (int)Enums.ManagerMode.AccountModify:
                        ControllAccountModifyMenu();
                        break;
                    case (int)Enums.ManagerMode.AccountDelete:
                        ControllAccountDeleteMenu();
                        break;
                    case (int)Enums.ManagerMode.RentalHistory:
                        bookController.ShowAllUserRentalHistory();
                        ExplainingScreen.ExplainEcsKey(0);
                        menuSelector.WaitForEscKey();
                        break;
                }
            }
        }

        private void ControllRentalBookMenu()
        {
            bookController.ShowBooks((int)Enums.BookShowType.All);
            bookController.InputBookId();
            if (bookController.BookId == null)
                return;
            else if (bookController.IsBookIdValid() && bookController.IsBookRentalValid())
            {
                bookController.RentalBook();
                ExplainingScreen.ExplainSuccessScreen();
            }
            menuSelector.WaitForEscKey();
        }

        private void ControllReturnBookMenu()
        {
            bookController.ShowRentalBooks();
            bookController.InputBookId();

            if (bookController.BookId == null)
                return;
            else if (bookController.IsBookIdValid() && bookController.IsBookReturnValid())
                ExplainingScreen.ExplainSuccessScreen();
            menuSelector.WaitForEscKey();
        }

        private void ControllUserDeleteMenu()
        {
            if (accountController.IsUserRemoveValid())
            {
                accountController.RemoveUser();
                ExplainingScreen.ExplainSuccessScreen();
                menuSelector.WaitForEscKey();
                ControllModeMenu();
            }

            menuSelector.WaitForEscKey();
        }

        private void ControllAccountModifyMenu()
        {
            accountController.ShowAllUser();
            accountController.InputUserId();
            if (accountController.SearchId == null)
                return;
            else if (accountController.IsUserIdValid())
                accountController.ModifyInformation();
            else
                menuSelector.WaitForEscKey();
        }

        private void ControllAccountDeleteMenu()
        {
            accountController.ShowAllUser();
            accountController.InputUserId();
            if (accountController.SearchId == null)
                return;
            else if (accountController.IsUserIdValid() && accountController.IsUserRemoveValid())
            {
                accountController.RemoveUser();
                ExplainingScreen.ExplainSuccessScreen();
            }
            menuSelector.WaitForEscKey();
        }

        private void ControllBookDeleteMenu()
        {
            bookController.ShowBooks((int)Enums.BookShowType.All);
            bookController.InputBookId();
            if (bookController.BookId == null)
                return;
            else if (bookController.IsBookIdValid() && bookController.IsBookDeleteValid())
            {
                bookController.DeleteBook();
                ExplainingScreen.ExplainSuccessScreen();
            }

            menuSelector.WaitForEscKey();
        }

        private void ControllBookModifyMenu()
        {
            bookController.ShowBooks((int)Enums.BookShowType.All);
            bookController.InputBookId();
            if (bookController.BookId == null)
                return;
            else if (bookController.IsBookIdValid())
                bookController.ModifyBook();
            menuSelector.WaitForEscKey();
        }
    }
}
