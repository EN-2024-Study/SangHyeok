using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarPrint
{
    internal class Screen
    {
        bool isStartScreen, isSelectScreen, isStarPrintScreen;  // 어떤 화면을 띄울 지 bool 자료형으로 정함
        bool exit;
        int startScreenNumber, selectScreenNumber;  // int 자료형으로 어떤 메뉴를 선택할지 정함 
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

        public void PrintScreen()   // 각각의 화면들을 제어하는 함수
        {
            while (!exit)   
            {
                Console.Clear();
                if (isStartScreen)  // 시작화면
                {
                    startScreen = new StartScreen(startScreenNumber % 2);
                    startScreen.PrintScreen();
                    InputAtStartScreen();
                }
                else if (isSelectScreen)    // 메뉴
                {
                    selectScreen = new SelectScreen(selectScreenNumber % 5);
                    selectScreen.PrintScreen();
                    InputAtSelectScreen();
                }
                else if (isStarPrintScreen) // 별찍기 화면
                {
                    starPrintScreen = new StarPrintScreen(selectScreenNumber);
                    starPrintScreen.PrintScreen();
                    InputKeyAtStarPrintScreen();
                }
            }
            Console.Clear();
        }

        private void InputAtStartScreen()   // 시작화면에서 입력
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

        private void InputAtSelectScreen()  // 메뉴에서 입력
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

        private void InputKeyAtStarPrintScreen()    // 별찍기에서 backspace와 S키 입력
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
