using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class ScreenControl
    {
        static bool isStartScreen, isComputerGameScreen, isUserGameScreen, isScoreBoard;
        static bool quit;
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
                        startScreen.InputUserName();
                        Console.Clear();
                        startScreen.MenuNumber = 0;
                        startScreen.PrintScreen();
                    }
                    startScreen.SelectMenuButton();
                }
                else if (isComputerGameScreen)
                {
                    computerGameScreen.PrintScreen();
                    if (computerGameScreen.StartupOrder == 0 || computerGameScreen.IsErrorNumber)
                        computerGameScreen.InputOrder();
                    else
                        computerGameScreen.PlayGame();
                }
                else if (isUserGameScreen)
                {
                    userGameScreen.PrintScreen();
                    //string str = Console.ReadLine();
                }
                else if (isScoreBoard)
                {
                    scoreBoardScreen.PrintScreen();
                    scoreBoardScreen.InputBackMenu();
                }
            }
        }

        public static bool IsStartScreen
        { 
            set { isStartScreen = value; }
        }

        public static bool IsComputerGameScreen
        {
            set { isComputerGameScreen = value; }
        }

        public static bool IsUserGameScreen
        {
            set { isUserGameScreen = value; }
        }

        public static bool IsScoreBoard
        {
            set { isScoreBoard = value; }
        }

        public static bool Quit
        {
            set { quit = value; }
        }
    }
}