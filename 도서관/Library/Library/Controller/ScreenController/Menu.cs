using Library.Constants;
using Library.View;
using System;

namespace Library.Controller.ScreenController
{
    public class Menu
    {
        private MenuSelector menuSelector;
        private Account account;
        private Book bookController;
        private ApiController apiController;
        private LogManager logManager;

        public Menu()
        {
            this.menuSelector = new MenuSelector();
            this.logManager = new LogManager(menuSelector);
            this.account = new Account(menuSelector, logManager);
            this.bookController = new Book(menuSelector, account, logManager);
            this.apiController = new ApiController(menuSelector, bookController, account);
        }

        public void ControllModeMenu()
        {
            bool isSelected = true;
            menuSelector.menuValue = 0;

            while (isSelected)
            {
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
                        if (account.IsLogIn((int)Enums.ModeMenu.ManagerMode))
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
                Console.Clear();
                ExplainingScreen.DrawStartLogo();

                isSelected = menuSelector.IsMenuSelection((int)Enums.MenuType.LogInSignUp);
                if (!isSelected)
                    continue;

                switch (menuSelector.menuValue)
                {
                    case (int)Enums.LogInSignUpMenu.LogIn:
                        if (account.IsLogIn((int)Enums.ModeMenu.UserMode))
                            ControllUserModeMenu();
                        break;
                    case (int)Enums.LogInSignUpMenu.SignUp:
                        if (account.IsSignUp())
                            return;
                        break;
                }
            }
        }

        private void ControllUserModeMenu()
        {
            bool isSelected = true;
            menuSelector.menuValue = 0;
            logManager.AddLog(account.LoggedInId, LogStrings.LOGIN, LogStrings.BLANK);
            while (isSelected)
            {
                Console.Clear();
                ExplainingScreen.DrawLibraryLogo();

                isSelected = menuSelector.IsMenuSelection((int)Enums.MenuType.UserMode);
                if (!isSelected)
                    continue;

                switch (menuSelector.menuValue)
                {
                    case (int)Enums.UserMode.BookSearch:
                        bookController.ControllBookSearchScreen((int)Enums.ModeMenu.UserMode);
                        break;
                    case (int)Enums.UserMode.BookRental:
                        bookController.ControllBookRentalScreen();
                        break;
                    case (int)Enums.UserMode.BookRentalHistory:
                        bookController.ShowRentalBooks();
                        ExplainingScreen.ExplainEcsKey(0);
                        menuSelector.WaitForEscKey();
                        break;
                    case (int)Enums.UserMode.BookReturn:
                        bookController.ControllReturnBookScreen();
                        break;
                    case (int)Enums.UserMode.BookReturnHistory:
                        bookController.ShowReturnBooks();
                        ExplainingScreen.ExplainEcsKey(0);
                        menuSelector.WaitForEscKey();
                        break;
                    case (int)Enums.UserMode.AccountModify:
                        account.ControllUserModifyScreen();
                        break;
                    case (int)Enums.UserMode.AccountDelete:
                        if (account.ControllUserDeleteScreen())
                            return;
                        break;
                    case (int)Enums.UserMode.NaverSearch:
                        apiController.SearchNaver((int)Enums.ModeMenu.UserMode);
                        break;
                    case (int)Enums.UserMode.RequestBookHistory:
                        bookController.ShowNaverBook((int)Enums.ModeMenu.UserMode);
                        ExplainingScreen.ExplainEcsKey(0);
                        menuSelector.WaitForEscKey();
                        break;
                }
            }
        }

        private void ControllManagerModeMenu()
        {
            bool isSelected = true;
            menuSelector.menuValue = 0;
            logManager.AddLog(LogStrings.MANAGER, LogStrings.LOGIN, LogStrings.BLANK);

            while (isSelected)
            {
                Console.Clear();
                ExplainingScreen.DrawLibraryLogo();

                isSelected = menuSelector.IsMenuSelection((int)Enums.MenuType.ManagerMode);
                if (!isSelected)
                    continue;

                switch (menuSelector.menuValue)
                {
                    case (int)Enums.ManagerMode.BookSearch:
                        bookController.ControllBookSearchScreen((int)Enums.ModeMenu.ManagerMode);
                        break;
                    case (int)Enums.ManagerMode.BookAdd:
                        bookController.ControllBookAddScreen();
                        break;
                    case (int)Enums.ManagerMode.BookDelete:
                        bookController.ControllBookDeleteScreen();
                        break;
                    case (int)Enums.ManagerMode.BookModify:
                        bookController.InputBookModify();
                        break;
                    case (int)Enums.ManagerMode.AccountModify:
                        account.ControllMemberModifyScreen();
                        break;
                    case (int)Enums.ManagerMode.AccountDelete:
                        account.ControllMemberDeleteMenu();
                        break;
                    case (int)Enums.ManagerMode.RentalHistory:
                        bookController.ShowAllUserRentalHistory();
                        ExplainingScreen.ExplainEcsKey(0);
                        menuSelector.WaitForEscKey();
                        break;
                    case (int)Enums.ManagerMode.NaverSearch:
                        apiController.SearchNaver((int)Enums.ModeMenu.ManagerMode);
                        break;
                    case (int)Enums.ManagerMode.LogManage:
                        ControllLogMenu();
                        break;
                    case (int)Enums.ManagerMode.RequestBook:
                        bookController.AddRequestedBook();
                        break;
                }
            }
        }


        private void ControllLogMenu()
        {
            bool isSelected = true;
            menuSelector.menuValue = 0;

            while (isSelected)
            {
                Console.Clear();
                ExplainingScreen.DrawLibraryLogo();

                isSelected = menuSelector.IsMenuSelection((int)Enums.MenuType.Log);
                if (!isSelected)
                    continue;

                switch (menuSelector.menuValue)
                {
                    case (int)Enums.LogMenu.History:
                        logManager.ControllHistoryScreen();
                        break;
                    case (int)Enums.LogMenu.Delete:
                        logManager.ControllDeleteScreen();
                        break;
                    case (int)Enums.LogMenu.FileSave:
                        logManager.SaveFile();
                        break;
                    case (int)Enums.LogMenu.FileDelete:
                        logManager.DeleteFile();
                        break;
                    case (int)Enums.LogMenu.Reset:
                        logManager.DeleteAllLog();
                        break;
                }
            }
        }
    }
}
