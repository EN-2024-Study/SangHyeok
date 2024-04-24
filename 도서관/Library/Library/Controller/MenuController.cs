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
                Console.SetWindowSize(40, 20);
                Console.Clear();
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
                Console.SetWindowSize(40, 20);
                Console.Clear();
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
                Console.SetWindowSize(50, 30);
                Console.Clear();

                isSelected = menuSelector.IsMenuSelection((int)Constants.MenuType.UserMode);
                if (!isSelected)
                    continue;

                if (menuSelector.menuValue == (int)Constants.UserMode.BookSearch)
                {
                    bookController.ShowBooks((int)Constants.Book.All);
                    bookController.SearchBook();
                    menuSelector.WaitForEscKey();
                }
                else if (menuSelector.menuValue == (int)Constants.UserMode.BookRental)
                {
                    bookController.ShowBooks((int)Constants.Book.All);
                    if (bookController.IsInputBookIdValid())
                    {
                        if (bookController.IsBookRentalValid())
                        {
                            bookController.RentalBook();
                            ExplainingScreen.ExplainSuccessScreen();
                            ExplainingScreen.ExplainEcsKey();
                            menuSelector.WaitForEscKey();
                        }
                    }
                }
                else if (menuSelector.menuValue == (int)Constants.UserMode.BookRentalHistory)
                {
                    bookController.ShowBooks((int)Constants.Book.Rental);
                    ExplainingScreen.ExplainEcsKey();
                    menuSelector.WaitForEscKey();
                }
                else if (menuSelector.menuValue == (int)Constants.UserMode.BookReturn)
                {
                    bookController.ShowBooks((int)Constants.Book.Rental);
                    if (bookController.IsInputBookIdValid())
                    {
                        if (bookController.IsBookReturnValid())
                        {
                            bookController.ReturnBook();
                            ExplainingScreen.ExplainSuccessScreen();
                            ExplainingScreen.ExplainEcsKey();
                            menuSelector.WaitForEscKey();
                        }
                    }
                }
                else if (menuSelector.menuValue == (int)Constants.UserMode.BookReturnHistory)
                {
                    bookController.ShowBooks((int)Constants.Book.Return);
                    ExplainingScreen.ExplainEcsKey();
                    menuSelector.WaitForEscKey();
                }
                else if (menuSelector.menuValue == (int)Constants.UserMode.AccountModify)
                    accountController.IsModifyInformation();
                else if (menuSelector.menuValue == (int)Constants.UserMode.AccountDelete)
                {

                }
            }
        }

        private void ControllManagerModeMenu()
        {
            bool isSelected = true;
            menuSelector.menuValue = 0;

            while (isSelected)
            {
                Console.SetWindowSize(50, 30);
                Console.Clear();

                isSelected = menuSelector.IsMenuSelection((int)Constants.MenuType.ManagerMode);
                if (!isSelected)
                    continue;

                switch (menuSelector.menuValue)
                {
                    case (int)Constants.ManagerMode.BookSearch:
                        bookController.SearchBook();
                        menuSelector.WaitForEscKey();
                        break;
                    case (int)Constants.ManagerMode.BookAdd:

                        break;
                    case (int)Constants.ManagerMode.BookDelete:

                        break;
                    case (int)Constants.ManagerMode.BookModify:

                        break;
                    case (int)Constants.ManagerMode.AccountModify:

                        break;
                    case (int)Constants.ManagerMode.AccountDelete:

                        break;
                    case (int)Constants.ManagerMode.RentalHistory:

                        break;
                }
            }
        }
    }
}
