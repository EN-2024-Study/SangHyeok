using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarPrint
{
    internal class Screen
    {
        bool isStartScreen;
        bool exit;
        int startScreenNumber;
        int selectScreenNumber;

        public Screen()
        {
            exit = false;
            isStartScreen = true;
            startScreenNumber = 0;
            selectScreenNumber = 0;
            TransitionScreen();
        }

        private void TransitionScreen()
        {
            while (!exit)
            {
                Console.Clear();
                if (isStartScreen)
                    new StartScreen(startScreenNumber % 2);
                else
                    new SelectScreen(selectScreenNumber % 5);
                InputKey();
            }
            Console.Clear();
        }

        private void InputKey()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            if (isStartScreen)
            {
                if (keyInfo.Key == ConsoleKey.Enter || keyInfo.Key == ConsoleKey.Spacebar)
                {
                    switch (startScreenNumber % 2)
                    {
                        case 0:
                            isStartScreen = false;
                            break;
                        case 1:
                            exit = true;
                            break;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow || keyInfo.Key == ConsoleKey.UpArrow)
                    startScreenNumber++;
            }
            else
            {   // selectScreen
                if (keyInfo.Key == ConsoleKey.Enter || keyInfo.Key == ConsoleKey.Spacebar)
                {
                    switch (selectScreenNumber % 5)
                    {
                        case 0:
                            break;
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                        case 5:
                            break;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow || keyInfo.Key == ConsoleKey.UpArrow)
                    selectScreenNumber++;

            }
        }
    }
}
