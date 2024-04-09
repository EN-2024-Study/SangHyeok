using Library.View;
using Library.Utility;
using Library.Model;
using System;

namespace Library.Controller
{
    public class MenuController
    {
        private MenuScreen menuScreen;
        private AccountController accountController;
        private int menuValue;

        public MenuController()
        {
            this.menuScreen = new MenuScreen();
            this.accountController = new AccountController();
        }

        public void Run()
        {
            Console.Clear();
            Console.SetWindowSize(100, 30);
            Console.CursorVisible = false;
            menuValue = 0;

            SelectModeMenu();
            if (menuValue % 3 == (int)Constants.ModeMenu.Quit)
            {
                SelectYesNoMenu();
                if (menuValue % 2 == (int)Constants.YesNo.No)
                    Run();
            }
            else
            {
                SelectLogInMenu();
                switch (menuValue)
                {
                    case (int)Constants.LogInMenu.GoBack:
                        Run();
                        break;
                    case (int)Constants.LogInMenu.LogIn:
                        accountController.InputLogIn();
                        break;
                    case (int)Constants.LogInMenu.SignUp:
                        accountController.InputSignUp();
                        break;
                }
            }
        }

        private void SelectModeMenu()
        {
            bool isMenuSelect = true;
            menuValue = 0;

            while (isMenuSelect)
            {
                menuScreen.PrintModeMenu(menuValue % 3);
                isMenuSelect = InputMenu();
            }
        }

        private void SelectLogInMenu()
        {
            menuValue = 0;
            bool isMenuSelect = true;

            while (isMenuSelect)
            {
                menuScreen.PrintLogInMenu(menuValue % 3);
                isMenuSelect = InputMenu();
            }
        }

        private void SelectYesNoMenu()
        {
            bool isMenuSelect = true;
            menuValue = 0;

            while (isMenuSelect)
            {
                menuScreen.PrintYesNoWindow(menuValue % 2);
                isMenuSelect = InputMenu();
            }
        }

        private bool InputMenu()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();

            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.DownArrow:
                    menuValue++;
                    break;
                case ConsoleKey.Enter:
                case ConsoleKey.Spacebar:
                    return false;
            }
            return true;
        }
    }
}
