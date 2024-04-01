using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarPrint
{
    internal class Screen
    {
        bool isStartScreen, isSelectScreen, isStarPrintScreen;
        bool exit;
        int startScreenNumber;
        int selectScreenNumber;

        public Screen()
        {
            exit = false;
            isStartScreen = true;
            isSelectScreen = false;
            isStarPrintScreen = false;
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
                else if (isSelectScreen)
                    new SelectScreen(selectScreenNumber % 5);
                else if (isStarPrintScreen)
                    new StarPrintScreen(selectScreenNumber);

                InputKeyInfo();
            }
            Console.Clear();
        }

        private void InputKeyInfo()
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
                            isSelectScreen = true;
                            break;
                        case 1:
                            exit = true;
                            break;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow || keyInfo.Key == ConsoleKey.UpArrow)
                    startScreenNumber++;
            }
            else if (isSelectScreen)
            {   
                if (keyInfo.Key == ConsoleKey.Enter || keyInfo.Key == ConsoleKey.Spacebar)
                {
                    switch (selectScreenNumber % 5)
                    {
                        case 0:
                        case 1:
                        case 2:
                        case 3:
                            isSelectScreen = false;
                            isStarPrintScreen = true;
                            break;
                        case 4:
                            exit = true;
                            break;
                    }
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                    selectScreenNumber++;
                else if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    selectScreenNumber--;
                    if (selectScreenNumber < 0)
                        selectScreenNumber += 5;
                }
            }
            else if (isStarPrintScreen)
            {
                if (keyInfo.Key == ConsoleKey.Backspace)
                {
                    isStarPrintScreen = false;
                    isSelectScreen = true;
                }
            }
        }
    }
}
