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
        protected MenuScreen menuScreen;
        protected int menuValue;

        protected MenuController()
        {
            menuScreen = new MenuScreen();
            menuValue = 0;
        }

        public virtual void Run() { }

        public bool SelectMenu()
        {
            Console.CursorVisible = false;
            ConsoleKeyInfo keyInfo = Console.ReadKey();

            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    menuValue--;
                    if (menuValue < 0)
                        menuValue = 0;
                    break;
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
