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
                        ControllLogInMenu((int)Constants.ModeMenu.ManagerMode);
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
                        ControllLogInMenu((int)Constants.ModeMenu.UserMode);
                        break;
                    case (int)Constants.LogInSignUpMenu.SignUp:
                        ControllSignUpMenu();
                        break;
                }
            }
        }

        private void ControllLogInMenu(int modeType)
        {
            bool isSelected = true;
            menuSelector.menuValue = 0;
            Console.SetWindowSize(50, 20);
            Console.Clear();

            while (isSelected)
            {
                isSelected = menuSelector.IsMenuSelection((int)Constants.MenuType.LogIn);
                if (!isSelected)
                    continue;
                
                if (menuSelector.menuValue == (int)Constants.LogInMenu.Check)
                {
                    if (accountController.IsLogInValid(modeType))
                    {
                        ControllLibraryMenu(modeType);
                        Console.SetWindowSize(50, 20);
                    }
                    Console.Clear();
                }
                else
                    accountController.InputLogIn(menuSelector.menuValue);
            }
        }

        private void ControllSignUpMenu()
        {
            bool isSelected = true;
            menuSelector.menuValue = 0;
            Console.SetWindowSize(50, 20);
            Console.Clear();

            while (isSelected)
            {
                isSelected = menuSelector.IsMenuSelection((int)Constants.MenuType.AccountModify);
                if (!isSelected)
                    continue;

                if (menuSelector.menuValue == (int)Constants.SignUpMenu.Check)
                {
                    if (accountController.IsSignUpValid())
                    {
                        ExplainingScreen.ExplainSuccessScreen();
                        ExplainingScreen.ExplainEcsKey();
                    }
                    Console.Clear();
                }
                else
                    accountController.InputSignUp(menuSelector.menuValue);
            }
        }

        private void ControllLibraryMenu(int modeType)
        {
            bool isSelected = true;
            menuSelector.menuValue = 0;

            while (isSelected)
            {
                Console.SetWindowSize(50, 30);
                Console.Clear();

                if (modeType == (int)Constants.ModeMenu.UserMode)
                {
                    isSelected = menuSelector.IsMenuSelection((int)Constants.MenuType.UserMode);
                    if (!isSelected)
                        continue;

                    if (menuSelector.menuValue == (int)Constants.UserMode.BookSearch)
                    {
                        bookController.SearchBook();
                        menuSelector.WaitForEscKey();
                    }
                    else if (menuSelector.menuValue == (int)Constants.UserMode.BookRental)
                    {
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
                        bookController.ShowRentalBooks();
                        ExplainingScreen.ExplainEcsKey();
                        menuSelector.WaitForEscKey();
                    }
                    else if (menuSelector.menuValue == (int)Constants.UserMode.BookReturn)
                    {
                        if (bookController.IsInputBookIdValid())
                        {

                        }
                    }
                    else if (menuSelector.menuValue == (int)Constants.UserMode.BookReturnHistory)
                    {

                    }
                    else if (menuSelector.menuValue == (int)Constants.UserMode.AccountInfo)
                    {

                    }
                    else if (menuSelector.menuValue == (int)Constants.UserMode.AccountDelete)
                    {

                    }
                }
                else if (modeType == (int)Constants.ModeMenu.ManagerMode)
                {
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
}
