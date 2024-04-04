using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class ScreenControl
    {
        private bool isStartScreen, isComputerGameScreen, isUserGameScreen, isScoreBoard;
        private bool quit;
        private StartScreen startScreen;
        private ComputerGameScreen computerGameScreen;
        private UserGameScreen userGameScreen;
        private ScoreBoardScreen scoreBoardScreen;

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

                    int menuNumber = startScreen.SelectMenuButton();
                    SwitchScreen(menuNumber);
                }
                else if (isComputerGameScreen)
                {
                    computerGameScreen.PrintScreen();
                    if (computerGameScreen.StartupOrder == 0 || computerGameScreen.IsErrorNumber)
                        isComputerGameScreen = computerGameScreen.InputOrder();
                    else
                        isComputerGameScreen = computerGameScreen.PlayGame();

                    if (!isComputerGameScreen)
                        isStartScreen = true;
                }
                else if (isUserGameScreen)
                {
                    userGameScreen.PrintScreen();
                    isUserGameScreen = userGameScreen.PlayGame();
                    //userGameScreen.CheckEnd();

                    if (!isUserGameScreen)
                        isStartScreen = true;
                }
                else if (isScoreBoard)
                {
                    scoreBoardScreen.PrintScreen();
                    isScoreBoard = scoreBoardScreen.InputBackMenu();

                    if (!isScoreBoard)
                        isStartScreen = true;
                }
            }
            Console.Clear();
        }

        private void SwitchScreen(int menuNumber)
        {
            switch (menuNumber)
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
    }
}