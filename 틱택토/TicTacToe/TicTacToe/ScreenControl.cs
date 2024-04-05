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
                Console.Clear();
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

                    int menunumber = startScreen.SelectMenuButton();
                    SwitchScreen(menunumber);
                }
                else if (isComputerGameScreen)
                {
                    computerGameScreen.PrintScreen();
                    if (computerGameScreen.StartupOrder == 0 || computerGameScreen.IsErrornumber)
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
                    isStartScreen = userGameScreen.CheckEnd();

                    if (!isUserGameScreen || isStartScreen)
                    {
                        isStartScreen = true;
                        isUserGameScreen = false;
                        userGameScreen = new UserGameScreen();
                    }
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

        private void SwitchScreen(int menunumber)
        {
            switch (menunumber)
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