using System;

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
                Console.CursorVisible = false;
                if (isStartScreen)
                {
                    startScreen.PrintScreen();
                    if (startScreen.Name == null)   // 처음 입력시 초기화
                    {
                        startScreen.InputUserName();
                        startScreen.Menunumber = 0;
                        continue;
                    }

                    int menuNumber = startScreen.SelectMenuButton();
                    if (menuNumber != -1)
                        SwitchScreen(menuNumber);
                }
                else if (isComputerGameScreen)
                {
                    computerGameScreen.PrintScreen();
                    int checkEnd = computerGameScreen.CheckEnd();
                    if (checkEnd > 0)
                    {
                        computerGameScreen.ExpressEnd();
                        SwitchScreen(4);
                        computerGameScreen = new ComputerGameScreen();
                        continue;
                    }

                    isComputerGameScreen = computerGameScreen.PlayGame();
                    if (!isComputerGameScreen)
                    {
                        SwitchScreen(4);
                        computerGameScreen = new ComputerGameScreen();
                    }
                }
                else if (isUserGameScreen)
                {
                    userGameScreen.PrintScreen();
                    int checkEnd = userGameScreen.CheckEnd();
                    if (checkEnd > 0)
                    {
                        userGameScreen.ExpressEnd();
                        SwitchScreen(4);
                        userGameScreen = new UserGameScreen();
                        continue;
                    }

                    isUserGameScreen = userGameScreen.PlayGame();
                    if (!isUserGameScreen)
                    {
                        SwitchScreen(4);
                        userGameScreen = new UserGameScreen();
                    }

                }
                else if (isScoreBoard)
                {
                    scoreBoardScreen.PrintScreen();
                    isScoreBoard = scoreBoardScreen.InputBackMenu();

                    if (!isScoreBoard)
                        SwitchScreen(4);
                }
            }
            Console.Clear();
        }

        private void SwitchScreen(int menuNumber)
        {
            Console.Clear();
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
                case 4:
                    isComputerGameScreen = false;
                    isUserGameScreen = false;
                    isScoreBoard = false;
                    isStartScreen = true;
                    break;
            }
        }
    }
}