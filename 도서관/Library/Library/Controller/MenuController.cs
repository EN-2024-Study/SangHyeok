﻿using Library.Utility;
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
                    bookController.ShowBooks((int)Constants.BookShowType.All);
                    bookController.SearchBook();
                }
                else if (menuSelector.menuValue == (int)Constants.UserMode.BookRental)
                {
                    bookController.ShowBooks((int)Constants.BookShowType.All);
                    bookController.InputBookId();

                    if (bookController.IsBookIdValid((int)Constants.BookIdType.Rental))
                        bookController.RentalBook();
                }
                else if (menuSelector.menuValue == (int)Constants.UserMode.BookRentalHistory)
                {
                    bookController.ShowBooks((int)Constants.BookShowType.Rental);
                    ExplainingScreen.ExplainEcsKey();
                    menuSelector.WaitForEscKey();
                }
                else if (menuSelector.menuValue == (int)Constants.UserMode.BookReturn)
                {
                    bookController.ShowBooks((int)Constants.BookShowType.Rental);
                    bookController.InputBookId();

                    if (bookController.IsBookIdValid((int)Constants.BookIdType.Return))
                        bookController.ReturnBook();
                }
                else if (menuSelector.menuValue == (int)Constants.UserMode.BookReturnHistory)
                {
                    bookController.ShowBooks((int)Constants.BookShowType.Return);
                    ExplainingScreen.ExplainEcsKey();
                    menuSelector.WaitForEscKey();
                }
                else if (menuSelector.menuValue == (int)Constants.UserMode.AccountModify)
                    accountController.ModifyInformation();
                else if (menuSelector.menuValue == (int)Constants.UserMode.AccountDelete)
                {
                    if (accountController.IsUserRemoveValid())
                    {
                        accountController.RemoveUser();
                        ExplainingScreen.ExplainSuccessScreen();
                        ExplainingScreen.ExplainEcsKey();
                        menuSelector.WaitForEscKey();
                        ControllModeMenu();
                    }
                    else
                    {
                        ExplainingScreen.ExplainFailScreen();
                        ExplainingScreen.ExplainEcsKey();
                        menuSelector.WaitForEscKey();
                    }
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

                if (menuSelector.menuValue == (int)Constants.ManagerMode.BookSearch)
                {
                    bookController.ShowBooks((int)Constants.BookShowType.All);
                    bookController.SearchBook();
                }
                else if (menuSelector.menuValue == (int)Constants.ManagerMode.BookAdd)
                    bookController.AddBook();
                else if (menuSelector.menuValue == (int)Constants.ManagerMode.BookDelete)
                {
                    bookController.ShowBooks((int)Constants.BookShowType.All);
                    bookController.InputBookId();

                    if (bookController.IsBookIdValid((int)Constants.BookIdType.Delete))
                        bookController.DeleteBook();
                }
                else if (menuSelector.menuValue == (int)Constants.ManagerMode.BookModify)
                {
                    bookController.ShowBooks((int)Constants.BookShowType.All);
                    bookController.InputBookId();

                    if (bookController.IsBookIdValid((int)Constants.BookIdType.Modify))
                        bookController.ModifyBook();
                }
                else if (menuSelector.menuValue == (int)Constants.ManagerMode.AccountModify)
                {
                    accountController.ShowUsers();
                    accountController.InputUserId();

                    if (accountController.IsUserIdValid())
                        accountController.ModifyInformation();
                }
                else if (menuSelector.menuValue == (int)Constants.ManagerMode.AccountDelete)
                {
                    accountController.ShowUsers();
                    accountController.InputUserId();

                    if (accountController.IsUserIdValid() && accountController.IsUserRemoveValid())
                    {
                        accountController.RemoveUser();
                        ExplainingScreen.ExplainSuccessScreen();
                        ExplainingScreen.ExplainEcsKey();
                        menuSelector.WaitForEscKey();
                    }
                }
                else if (menuSelector.menuValue == (int)Constants.ManagerMode.RentalHistory)
                {
                    bookController.ShowUserRentalHistory();
                    ExplainingScreen.ExplainEcsKey();
                    menuSelector.WaitForEscKey();
                }
            }
        }
    }
}
