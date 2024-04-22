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
                    if (accountController.IsSignUpValid())  // 아이디가 중복이 아니라면
                    {
                        accountController.SetSignUpAccount();   // 회원가입
                        return;
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

                    switch (menuSelector.menuValue)
                    {
                        case (int)Constants.UserMode.BookSearch:
                            ControllBookSearchMenu();
                            menuSelector.InputEsc();
                            break;
                        case (int)Constants.UserMode.BookRental:
                            ControllBookSearchMenu();   // esc 입력 시 뒤로가기 기능 처리해야 됨
                            bookController.RentalBook();
                            break;
                        case (int)Constants.UserMode.BookRentalHistory:

                            break;
                        case (int)Constants.UserMode.BookReturn:

                            break;
                        case (int)Constants.UserMode.BookReturnHistory:

                            break;
                        case (int)Constants.UserMode.AccountInfo:

                            break;
                        case (int)Constants.UserMode.AccountDelete:

                            break;
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
                            ControllBookSearchMenu();
                            menuSelector.InputEsc();
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

        private void ControllBookSearchMenu()
        {
            bool isSelected = true;
            menuSelector.menuValue = 0;
            Console.SetWindowSize(70, 40);
            Console.Clear();

            bookController.ShowSearchedBooks();

            isSelected = menuSelector.IsMenuSelection((int)Constants.MenuType.BookSearch);
            if (!isSelected)
                return;

            if (menuSelector.menuValue == (int)Constants.BookSearchMenu.Check)
            {
                Console.Clear();
                bookController.ShowSearchedBooks();
            }
            else
                bookController.InputSearchBook(menuSelector.menuValue);

        }

    }
}
