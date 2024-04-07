using System;
using System.Collections.Generic;

namespace TicTacToe
{
    internal class ComputerGameScreen : GameScreen
    {
        private GameScreen gameScreen;
        public ComputerGameScreen()
        {
            gameScreen = new GameScreen();
        }

        public override void PrintScreen()
        {
            base.PrintScreen();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(79, 3);
            Console.Write("★USER★  ★COMPUTER★");
            Console.ResetColor();
        }

        public override bool PlayGame()  // 컴퓨터와 사용자 대결 구현
        {
            int number = base.InputGameNumber();

            if (number == 0)
                return false;

            base.ExpressXOrO(0, number - 1);    // 사용자 차례

            int computerIndex = PlayGameByComputer();   // 컴퓨터 차례
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
            List<int> emptyCoordinates = base.GetEmptCoordinateValues();    // 비어있는 좌표들
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
            List<int> emptyCoordinates = base.GetEmptCoordinateValues();    // 비어있는 좌표들
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
