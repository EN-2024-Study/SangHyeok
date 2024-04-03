using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace StarPrint
{
    internal class ScreenControl
    {
        bool isStartScreen, isSelectScreen, isStarPrintScreen;  // 어떤 화면을 띄울 지 bool 자료형으로 정함
        bool exit;
        StartScreen startScreen;
        SelectScreen selectScreen;
        StarPrintScreen starPrintScreen;

        public ScreenControl()
        {
            exit = false;
            isStartScreen = true;
            isSelectScreen = false;
            isStarPrintScreen = false;
            startScreen = new StartScreen();
            selectScreen = new SelectScreen();
            starPrintScreen = new StarPrintScreen();
        }

        public void ControlScreen()   // 각각의 화면들을 제어하는 함수
        {
            while (!exit)
            {
                Console.Clear();
                if (isStartScreen)  // 시작화면
                {
                    startScreen.PrintScreen();
                    InputAtStartScreen();
                }
                else if (isSelectScreen)    // 메뉴 화면
                {
                    selectScreen.PrintScreen();
                    InputAtSelectScreen();
                }
                else if (isStarPrintScreen) // 별찍기 화면
                {
                    starPrintScreen.PrintScreen();
                    InputKeyAtStarPrintScreen();
                }
            }
            Console.Clear();
        }

        private void InputAtStartScreen()   // 시작화면에서 입력
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();

            switch(keyInfo.Key)
            {
                case ConsoleKey.Enter:
                case ConsoleKey.Spacebar:
                    switch (startScreen.Select)
                    {
                        case 0:     // 시작하기 메뉴 입력
                            isStartScreen = false;
                            isSelectScreen = true;
                            break;
                        case 1:     // 종료하기 메뉴 입력
                            exit = true;
                            break;
                    }
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.UpArrow:
                    startScreen.Select++;
                    break;
                case ConsoleKey.D1:
                    startScreen.Select = 0;
                    break;
                case ConsoleKey.D2:
                    startScreen.Select = 1;
                    break;
            }
            startScreen.Select %= 2;
        }

        private void InputAtSelectScreen()  // 메뉴에서 입력
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();

            switch(keyInfo.Key)
            {
                case ConsoleKey.Enter:
                case ConsoleKey.Spacebar:
                    if (SelectScreen.Select < 4)
                    {
                        isSelectScreen = false;
                        isStarPrintScreen = true;
                    }
                    else if (SelectScreen.Select == 4)  // 종료하기 입력
                        exit = true;
                    break;
                case ConsoleKey.DownArrow:
                    SelectScreen.Select++;
                    break;
                case ConsoleKey.UpArrow:
                    SelectScreen.Select--;
                    if (SelectScreen.Select < 0)
                        SelectScreen.Select = 4;
                    break;
                case ConsoleKey.D1:
                    SelectScreen.Select = 0;
                    break;
                case ConsoleKey.D2:
                    SelectScreen.Select = 1;
                    break;
                case ConsoleKey.D3:
                    SelectScreen.Select = 2;
                    break;
                case ConsoleKey.D4:
                    SelectScreen.Select = 3;
                    break;
                case ConsoleKey.D5:
                    SelectScreen.Select = 4;
                    break;

            }
            SelectScreen.Select %= 5;
        }

        private void InputKeyAtStarPrintScreen()    // 별찍기 후 backspace나 S키 입력
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();

            switch (keyInfo.Key)
            {
                case ConsoleKey.Backspace:
                    isStarPrintScreen = false;
                    isSelectScreen = true;
                    break;
                case ConsoleKey.S:
                    isStarPrintScreen = false;
                    isStartScreen = true;
                    break;
            }
        }
    }
}