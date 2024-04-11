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
        protected Tuple<int, int> coordinate;
        public int menuValue;
        

        public MenuController()
        {
            menuScreen = new MenuScreen();
            coordinate = new Tuple<int, int>(20, 25);
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
                case ConsoleKey.Escape:
                    menuValue = -1;
                    return false;
            }
            return true;
        }
    }
}
