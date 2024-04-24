using Library.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Utility
{
    public class MenuSelector
    {
        public int menuValue;
        private Screen screen;

        public MenuSelector()
        {
            this.screen = new Screen();
            this.menuValue = 0;
        }

        public bool IsMenuSelection(int screenValue)
        {
            bool isMenuSelect = true;
            int menuCount = GetMenuCount(screenValue);

            Console.CursorVisible = false;
            while (isMenuSelect)
            {
                screen.DrawMenu(screenValue, menuValue, false);
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        menuValue--;
                        break;
                    case ConsoleKey.DownArrow:
                        menuValue++;
                        break;
                    case ConsoleKey.Enter:
                        screen.DrawMenu(screenValue, menuValue, true);
                        return true;
                    case ConsoleKey.Escape:
                        screen.DrawMenu(screenValue, -1, false);
                        return false;
                }

                if (menuValue < 0)
                    menuValue = 0;
                else if (menuValue > menuCount - 1)
                    menuValue = menuCount - 1;
            }
            return false;
        }

        public void WaitForEscKey()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            while (keyInfo.Key != ConsoleKey.Escape)
                keyInfo = Console.ReadKey(true);
        }

        private int GetMenuCount(int screenValue)
        {
            int length = 0;
            switch (screenValue)
            {
                case (int)Constants.MenuType.Mode:
                case (int)Constants.MenuType.LogInSignUp:
                    length = 2;
                    break;
                case (int)Constants.MenuType.LogIn:
                    length = 3;
                    break;
                case (int)Constants.MenuType.BookSearch:
                    length = 4;
                    break;
                case (int)Constants.MenuType.AccountModify:
                    length = 5;
                    break;
                case (int)Constants.MenuType.SignUp:
                    length = 6;
                    break;
                case (int)Constants.MenuType.UserMode:
                case (int)Constants.MenuType.ManagerMode:
                    length = 7;
                    break;
                case (int)Constants.MenuType.BookAdd:
                    length = 9;
                    break;
                case (int)Constants.MenuType.BookModify:
                    length = 7;
                    break;
            }
            return length;
        }
    }
}
