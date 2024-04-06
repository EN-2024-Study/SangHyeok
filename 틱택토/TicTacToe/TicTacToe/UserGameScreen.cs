using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class UserGameScreen : GameScreen
    {
        private GameScreen gameScreen;
        private int order;

        public UserGameScreen()
        {
            gameScreen = new GameScreen();
            order = 0;
        }

        public override void PrintScreen()
        {
            base.PrintScreen();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(79, 3);
            Console.Write("★USER1★  ★USER2★");
            Console.SetCursorPosition(77, 16);
            switch(order)
            {
                case 0:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("USER1 차례입니다. ");
                    break;
                case 1:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("USER2 차례입니다. ");
                    break;
            }
            Console.ResetColor();
        }

        public override bool PlayGame()
        {
            int number = base.InputGameNumber();    // 게임 좌표 입력

            if (number == 0)
                return false;   // 시작화면으로 돌아가기

            base.ExpressXOrO(order, number - 1);    // 입력받은 좌표 값에 그리기
            order = (order + 1) % 2;
            return base.PlayGame(); // 무조건 true 반환
        }
    }
}
