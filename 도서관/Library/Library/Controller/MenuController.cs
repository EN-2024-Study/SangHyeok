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
        private ApiController apiController;
        private LogController logController;

        public MenuController()
        {
            this.menuSelector = new MenuSelector();
            this.logController = new LogController(menuSelector);
            this.accountController = new AccountController(menuSelector, logController);
            this.bookController = new BookController(menuSelector, accountController, logController);
            this.apiController = new ApiController(menuSelector, bookController, accountController);
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
                Console.Clear();
                ExplainingScreen.DrawLibraryLogo();

                isSelected = menuSelector.IsMenuSelection((int)Enums.MenuType.UserMode);
                if (!isSelected)
                    continue;

                switch (menuSelector.menuValue)
                {
                    case (int)Enums.UserMode.BookSearch:
                        bookController.ControllBookSearchScreen();
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
                        accountController.ControllUserModifyScreen();
                        break;
                    case (int)Enums.UserMode.AccountDelete:
                        if (accountController.ControllUserDeleteScreen())
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
                        bookController.ControllBookSearchScreen();
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
                        accountController.ControllMemberModifyScreen();
                        break;
                    case (int)Enums.ManagerMode.AccountDelete:
                        accountController.ControllMemberDeleteMenu();
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
                        logController.ControllHistoryScreen();
                        break;
                    case (int)Enums.LogMenu.Delete:
                        logController.ControllDeleteScreen();
                        break;
                    case (int)Enums.LogMenu.FileSave:

                        break;
                    case (int)Enums.LogMenu.FileDelete:

                        break;
                    case (int)Enums.LogMenu.Reset:
                        logController.DeleteAllLog();
                        break;
                }
            }
        }
    }
}
