using Library.Utility;
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
            this.accountController = new AccountController();
            this.bookController = new BookController();
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
                isSelected = menuSelector.IsMenuSelection((int)Constants.MenuType.Mode);
                if (!isSelected)
                    continue;

                switch (menuSelector.menuValue)
                {
                    case (int)Constants.ModeMenu.UserMode:
                        ControllLogInSignUpMenu();
                        break;
                    case (int)Constants.ModeMenu.ManagerMode:
                        if (accountController.IsLogIn((int)Constants.ModeMenu.ManagerMode))
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

                isSelected = menuSelector.IsMenuSelection((int)Constants.MenuType.LogInSignUp);
                if (!isSelected)
                    continue;

                switch (menuSelector.menuValue)
                {
                    case (int)Constants.LogInSignUpMenu.LogIn:
                        if (accountController.IsLogIn((int)Constants.ModeMenu.UserMode))
                            ControllUserModeMenu();
                        break;
                    case (int)Constants.LogInSignUpMenu.SignUp:
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

                isSelected = menuSelector.IsMenuSelection((int)Constants.MenuType.UserMode);
                if (!isSelected)
                    continue;

                switch(menuSelector.menuValue)
                {
                    case (int)Constants.UserMode.BookSearch:
                        bookController.SearchBook();
                        break;
                    case (int)Constants.UserMode.BookRental:
                        ControllRentalBookMenu();
                        break;
                    case (int)Constants.UserMode.BookRentalHistory:
                        bookController.ShowRentalBooks();
                        ExplainingScreen.ExplainEcsKey(0);
                        menuSelector.WaitForEscKey();
                        break;
                    case (int)Constants.UserMode.BookReturn:
                        ControllReturnBookMenu();
                        break;
                    case (int)Constants.UserMode.BookReturnHistory:
                        bookController.ShowReturnBooks();
                        ExplainingScreen.ExplainEcsKey(0);
                        menuSelector.WaitForEscKey();
                        break;
                    case (int)Constants.UserMode.AccountModify:
                        accountController.ModifyInformation();
                        break;
                    case (int)Constants.UserMode.AccountDelete:
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

                isSelected = menuSelector.IsMenuSelection((int)Constants.MenuType.ManagerMode);
                if (!isSelected)
                    continue;

                switch(menuSelector.menuValue)
                {
                    case (int)Constants.ManagerMode.BookSearch:
                        bookController.SearchBook();
                        break;
                    case (int)Constants.ManagerMode.BookAdd:
                        bookController.AddBook();
                        break;
                    case (int)Constants.ManagerMode.BookDelete:
                        ControllBookDeleteMenu();
                        break;
                    case (int)Constants.ManagerMode.BookModify:
                        ControllBookModifyMenu();
                        break;
                    case (int)Constants.ManagerMode.AccountModify:
                        ControllAccountModifyMenu();
                        break;
                    case (int)Constants.ManagerMode.AccountDelete:
                        ControllAccountDeleteMenu();
                        break;
                    case (int)Constants.ManagerMode.RentalHistory:
                        bookController.ShowAllUserRentalHistory();
                        ExplainingScreen.ExplainEcsKey(0);
                        menuSelector.WaitForEscKey();
                        break;
                }
            }
        }

        private void ControllRentalBookMenu()
        {
            bookController.ShowBooks((int)Constants.BookShowType.All);
            bookController.InputBookId();
            if (bookController.BookId == null)
                return;
            else if (bookController.IsBookRentalValid())
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
            else if (bookController.IsBookReturnValid())
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
            accountController.ShowUsers();
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
            accountController.ShowUsers();
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
            bookController.ShowBooks((int)Constants.BookShowType.All);
            bookController.InputBookId();
            if (bookController.BookId == null)
                return;
            else if (bookController.IsBookDeleteValid())
            {
                bookController.DeleteBook();
                ExplainingScreen.ExplainSuccessScreen();
            }

            menuSelector.WaitForEscKey();
        }

        private void ControllBookModifyMenu()
        {
            bookController.ShowBooks((int)Constants.BookShowType.All);
            bookController.InputBookId();
            if (bookController.BookId == null)
                return;
            else 
                bookController.ModifyBook();
        }
    }
}
