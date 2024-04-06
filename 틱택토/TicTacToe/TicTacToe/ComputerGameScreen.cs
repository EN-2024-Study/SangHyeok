using System;
using System.Collections.Generic;

namespace TicTacToe
{
    internal class ComputerGameScreen : GameScreen
    {
        private GameScreen gameScreen;
        //private int orderByUser;
        //private bool isErrornumber;
        public ComputerGameScreen()
        {
            gameScreen = new GameScreen();
            //orderByUser = 0;
            //isErrornumber = false;
        }

        public override void PrintScreen()
        {
            base.PrintScreen();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(79, 3);
            Console.Write("★USER★  ★COMPUTER★");
            Console.SetCursorPosition(82, 5);
            //Console.Write(ScoreBoardScreen.UserScore + "            " + ScoreBoardScreen.ComputerScore);
            Console.ResetColor();
            //Console.SetCursorPosition(77, 10);
            //Console.Write("첫번째로 시작하려면 1번을,");
            //Console.SetCursorPosition(77, 12);
            //Console.Write("두번째로 시작하려면 2번을");
            //Console.SetCursorPosition(77, 14);
            //Console.Write("눌러주세요: ");

            //if (isErrornumber)
            //{
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.SetCursorPosition(77, 16);
            //    Console.Write("숫자 1 또는 2를 입력해 주세요.");
            //    Console.ResetColor();
            //}
            //else if (orderByUser != 0)
            //{
            Console.SetCursorPosition(77, 10);
            Console.Write("                             ");
            Console.SetCursorPosition(77, 12);
            Console.Write("                             ");
            Console.SetCursorPosition(77, 14);
            Console.Write("                             ");
            Console.SetCursorPosition(77, 16);
            Console.Write("                             ");
            Console.SetCursorPosition(77, 10);
            Console.Write("1부터 9까지를 입력하여");
            Console.SetCursorPosition(77, 12);
            Console.Write("게임을 진행해 주세요 : ");
            //}
        }

        //public bool InputOrder()
        //{
        //    Console.SetCursorPosition(89, 14);
        //    string inputTemp = Console.ReadLine();
        //    int number;
        //    if (int.TryParse(inputTemp, out number))
        //    {
        //        if (number == 0)
        //            return false;
        //        else if (1 <= number && number <= 2)
        //        {
        //            orderByUser = number;
        //            isErrornumber = false;
        //        }
        //        else
        //            isErrornumber = true;
        //    }
        //    else
        //        isErrornumber = true;
        //    return true;
        //}

        public override bool PlayGame()  // 컴퓨터와 사용자 대결 구현
        {
            int number = base.InputGamenumber();
            if (number == 0)
                return false;

            base.ExpressXOrO(0, number - 1);

            int computerIndex = PlayGameByComputer();
            if (computerIndex == -1)    // computer가 더이상 둘 곳이 없을 때
                return true;

            base.ExpressXOrO(1, computerIndex);
            return base.PlayGame();
        }

        private int MiniMax(bool flag)  // 미니맥스 알고리즘
        {
            int check = base.CheckEnd();    // 끝났는지 확인
            switch(check)
            {
                case 1:     // user가 이겼다면 -1 반환
                    return -1;
                case 2:     // computer가 이겼다면 1 반환
                    return 1;   
                case 3:     // 비겼다면 0 반환
                    return 0;
            }

            int bestScore = flag ? -1 : 1;  // computer차례이면 -1으로 초기화, user차례이면 1으로 초기화
            List<int> emptyCoordinates = base.GetEmptycoordinateValues();    // 비어있는 좌표들
            foreach (int index in emptyCoordinates)
            {
                if (flag)   // computer 차례일 때
                {
                    base.SetCoordinates(index, 2);  // 임의의 좌표에 computer 값 임시로 삽입
                    bestScore = Math.Max(bestScore, MiniMax(false));    // 재귀 함수로 최고의 경우의 수 갱신
                }
                else        // user 차례일 때
                {
                    base.SetCoordinates(index, 1);  // 임의의 좌표에 user 값 임시로 삽입
                    bestScore = Math.Min(bestScore, MiniMax(true));     // 재귀 함수로 최고의 경우의 수 갱신
                }

                base.SetCoordinates(index, 0);  // 임시로 삽입된 값 초기화
            }
            return bestScore;   // 최고의 경우의 수 반환
        }

        private int PlayGameByComputer()
        {
            List<int> emptyCoordinates = base.GetEmptycoordinateValues();    // 비어있는 좌표들
            int bestScore = -1; // -1이 최솟값이므로 -1으로 초기화
            int bestIndex = -1;

            foreach(int index in emptyCoordinates)
            {
                base.SetCoordinates(index, 2);  // 임의의 빈 좌표에 computer 값 임시로 삽입
                int score = MiniMax(false);     // 재귀 함수로 최고의 경우의 수 갱신
                base.SetCoordinates(index, 0);  // 임시로 삽입된 값 초기화
                if (score > bestScore)
                {
                    bestScore = score;  // 최고의 경우의 수 갱신
                    bestIndex = index;  // 최고의 경우를 가진 index값 갱신
                }
            }
            return bestIndex;   // 최고의 경우를 가진 index값 반환
        }
    }
}
