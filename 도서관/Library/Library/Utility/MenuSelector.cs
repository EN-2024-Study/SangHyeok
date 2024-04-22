using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Utility
{
    public class MenuSelector
    {
        public static int menuValue;

        public static int SelectMenu(int screenType)
        {
            int menuMaxValue = GetMenuMaxValue(screenType);

            Console.CursorVisible = false;
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
                    return 1;
                case ConsoleKey.Escape:
                    return -1;
            }

            if (menuValue < 0)
                menuValue = 0;
            else if (menuValue > menuMaxValue - 1)
                menuValue = menuMaxValue - 1;
            return 0;
        }

        private static int GetMenuMaxValue(int screenType)
        {
            int length = 0;
            switch (screenType)
            {
                case (int)Constants.ScreenType.Mode:
                case (int)Constants.ScreenType.LogInSignUp:
                case (int)Constants.ScreenType.LogIn:
                case (int)Constants.ScreenType.YesNo:
                    length = 2;
                    break;
                
            }
            return length;
        }
    }
}
