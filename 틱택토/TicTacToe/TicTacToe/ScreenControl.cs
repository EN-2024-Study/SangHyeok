using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class ScreenControl
    {
        bool isStartScreen, isComputerGameScreen, isUserGameScreen, isScoreBoard;
        bool quit;
        string userName;
        int menuNumber;
        StartScreen startScreen;
        ComputerGameScreen computerGameScreen;
        UserGameScreen userGameScreen;
        ScoreBoardScreen scoreBoardScreen;

        public ScreenControl()
        {
            isStartScreen = true;
            isComputerGameScreen = false;
            isUserGameScreen = false;
            isScoreBoard = false;
            quit = false;
            menuNumber = -1;
        }

        public void Control()
        {
            while (!quit)
            {
                Console.Clear();
                if (isStartScreen)
                {
                    startScreen = new StartScreen(menuNumber);
                    startScreen.PrintScreen();

                    if (userName == null)   // 처음 입력시 초기화
                    {
                        InputUserName();
                        Console.Clear();
                        menuNumber = 0;
                        startScreen.PrintScreen();
                    }
                    SelectMenuButton();
                }
                else if (isComputerGameScreen)
                {
                    computerGameScreen = new ComputerGameScreen();
                    computerGameScreen.PrintScreen();
                }
                else if (isUserGameScreen)
                {
                    userGameScreen = new UserGameScreen();
                    userGameScreen.PrintScreen();
                }
                else if (isScoreBoard)
                {
                    scoreBoardScreen = new ScoreBoardScreen();
                    scoreBoardScreen.PrintScreen();
                }
            }
        }

        private void InputUserName()
        {
            Console.SetCursorPosition(22, 17);  // 이름 입력 좌표
            userName = Console.ReadLine();
        }

        private void SelectMenuButton()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();

            if (keyInfo.Key == ConsoleKey.DownArrow)
                menuNumber += 1;
            else if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                menuNumber -= 1;
                if (menuNumber < 0)
                    menuNumber = 3;
            }
            else if (keyInfo.Key == ConsoleKey.Enter)
            {
                switch(menuNumber)
                {
                    case 0:
                        isStartScreen = false;
                        isComputerGameScreen = true;
                        break;
                    case 1:
                        isStartScreen = false;
                        isUserGameScreen = true;
                        break;
                    case 2:
                        isStartScreen = false;
                        isScoreBoard = true;
                        break;

                    case 3:
                        quit = true;
                        break;
                }
            }
            menuNumber %= 4;
        }
    }
}
