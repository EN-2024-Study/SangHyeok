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
        StartScreen startScreen;
        SelectScreen selectScreen;
        StarPrintScreen starPrintScreen;

        public Screen()
        {
            exit = false;
            isStartScreen = true;
            isSelectScreen = false;
            isStarPrintScreen = false;
            startScreenNumber = 0;
            selectScreenNumber = 0;
        }

        public void PrintScreen()
        {
            while (!exit)
            {
                Console.Clear();
                if (isStartScreen)
                {
                    startScreen = new StartScreen(startScreenNumber % 2);
                    startScreen.PrintScreen();
                    InputAtStartScreen();
                }
                else if (isSelectScreen)
                {
                    selectScreen = new SelectScreen(selectScreenNumber % 5);
                    selectScreen.PrintScreen();
                    InputAtSelectScreen();
                }
                else if (isStarPrintScreen)
                {
                    starPrintScreen = new StarPrintScreen(selectScreenNumber);
                    starPrintScreen.PrintScreen();
                    InputKeyAtStarPrintScreen();
                }
            }
            Console.Clear();
        }

        private void InputAtStartScreen()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();

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

        private void InputAtSelectScreen()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();

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

        private void InputKeyAtStarPrintScreen()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();

            if (keyInfo.Key == ConsoleKey.Backspace)
            {
                isStarPrintScreen = false;
                isSelectScreen = true;
            }
            else if (keyInfo.Key == ConsoleKey.S)
            {
                isStarPrintScreen = false;
                isStartScreen = true;
            }
        }
    }
}
