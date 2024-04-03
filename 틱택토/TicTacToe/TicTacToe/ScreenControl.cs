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
            startScreen = new StartScreen();
            computerGameScreen = new ComputerGameScreen();
            userGameScreen = new UserGameScreen();
            scoreBoardScreen = new ScoreBoardScreen();
        }

        public void Control()
        {
            while (!quit)
            {
                Console.Clear();
                if (isStartScreen)
                {
                    startScreen.PrintScreen();

                    if (startScreen.Name == null)   // 처음 입력시 초기화
                    {
                        InputUserName();
                        Console.Clear();
                        startScreen.MenuNumber = 0;
                        startScreen.PrintScreen();
                    }
                    SelectMenuButton();
                }
                else if (isComputerGameScreen)
                {
                    computerGameScreen.PrintScreen();
                    PlayingWithComputer();
                }
                else if (isUserGameScreen)
                {
                    userGameScreen.PrintScreen();
                    PlayingWithUser();
                }
                else if (isScoreBoard)
                {
                    scoreBoardScreen.PrintScreen();
                    InputBackMenu();
                }
            }
        }

        private void InputUserName()
        {
            Console.SetCursorPosition(22, 17);  // 이름 입력 좌표
            startScreen.Name = Console.ReadLine();
        }

        private void SelectMenuButton()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();

            if (keyInfo.Key == ConsoleKey.DownArrow)
                startScreen.MenuNumber += 1;
            else if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                startScreen.MenuNumber -= 1;
                if (startScreen.MenuNumber < 0)
                    startScreen.MenuNumber = 3;
            }
            else if (keyInfo.Key == ConsoleKey.Enter)
            {
                switch(startScreen.MenuNumber)
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
            startScreen.MenuNumber %= 4;
        }

        private void PlayingWithComputer()
        {
            InputWhenPlayGame();
        }

        private void PlayingWithUser()
        {
            InputWhenPlayGame();

        }

        private void InputBackMenu()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();

            if (keyInfo.Key == ConsoleKey.Backspace)
            {
                isScoreBoard = false;
                isStartScreen = true;
            }
        }

        private void InputWhenPlayGame()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();

            switch (keyInfo.Key)
            {
                case ConsoleKey.Q:

                    break;
                case ConsoleKey.W:

                    break;
                case ConsoleKey.E:

                    break;
                case ConsoleKey.A:

                    break;
                case ConsoleKey.S:

                    break;
                case ConsoleKey.D:

                    break;
                case ConsoleKey.Z:

                    break;
                case ConsoleKey.X:

                    break;
                case ConsoleKey.C:

                    break;
            }
        }
    }
}

// StartScreen 클래스 생성자 지우고 Control method에서 new 지우고
// ScreenControl 생성자에서 한번에 생성자 다 넣기