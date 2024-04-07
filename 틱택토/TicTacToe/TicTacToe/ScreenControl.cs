using System;
using System.Runtime.InteropServices;

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
                if (isStartScreen)  // 시작화면
                {
                    startScreen.PrintScreen();
                    if (startScreen.Name == null)   // 사용자 이름을 아직 안 정했을 때
                    {
                        startScreen.InputUserName(); 
                        startScreen.Menunumber = 0; 
                        continue;
                    }

                    int menuNumber = startScreen.SelectMenuButton();    // 메뉴 선택
                    if (menuNumber != -1)   // enter키 입력이 되었을 때
                        SwitchScreen(menuNumber);
                }
                else if (isComputerGameScreen)  // 컴퓨터와 게임 화면
                {
                    computerGameScreen.PrintScreen();
                    int checkEnd = computerGameScreen.CheckEnd();  
                    if (checkEnd > 0)   // 게임이 끝났을 때
                    {
                        computerGameScreen.ExpressEnd();
                        SwitchScreen(4);
                        computerGameScreen = new ComputerGameScreen();  // 컴퓨터와 게임 화면 초기화
                        RecordScore(1, checkEnd);   // 점수 기록
                        continue;
                    }

                    isComputerGameScreen = computerGameScreen.PlayGame();
                    if (!isComputerGameScreen)  // 시작화면으로 돌아가기가 선택 됐다면
                    {
                        SwitchScreen(4);
                        computerGameScreen = new ComputerGameScreen();  // 컴퓨터와 게임 화면 초기화
                    }
                }
                else if (isUserGameScreen)  // 유저끼리 게임 화면
                {
                    userGameScreen.PrintScreen();
                    int checkEnd = userGameScreen.CheckEnd();  
                    if (checkEnd > 0)   // 게임이 끝났을 때
                    {
                        userGameScreen.ExpressEnd();
                        SwitchScreen(4);
                        userGameScreen = new UserGameScreen();
                        RecordScore(2, checkEnd);   // 점수 기록
                        continue;
                    }

                    isUserGameScreen = userGameScreen.PlayGame();
                    if (!isUserGameScreen)   // 시작화면으로 돌아가기가 선택 됐다면
                    {
                        SwitchScreen(4);
                        userGameScreen = new UserGameScreen();  // 유저와 게임 화면 초기화
                    }

                }
                else if (isScoreBoard)  // 점수판 화면
                {
                    scoreBoardScreen.PrintScreen();
                    isScoreBoard = scoreBoardScreen.InputBackMenu();    

                    if (!isScoreBoard)  // 시작화면으로 돌아가기가 선택 됐다면
                        SwitchScreen(4);
                }
            }
            Console.Clear();
        }

        private void SwitchScreen(int menuNumber)   // 화면 선택
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

        private void RecordScore(int type, int checkEnd)    // 점수 기록
        {  
            int score1 = 0, score2 = 0;
            switch(checkEnd)
            {
                case 1:
                    score1 = 1;
                    break;
                case 2:
                    score2 = 1;
                    break;
            }

            switch (type)
            {
                case 1:
                    scoreBoardScreen.SetScore(1, score1, score2);
                    break;
                case 2:
                    scoreBoardScreen.SetScore(2, score1, score2);
                    break;
            }
        }
    }
}