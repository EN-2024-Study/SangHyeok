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
            Console.SetCursorPosition(82, 5);
            //Console.Write(ScoreBoardScreen.OneUserScore + "            " + ScoreBoardScreen.TwoUserScore);
            Console.ResetColor();
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

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(77, 16);
            if (order == 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("USER1 차례입니다. ");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("USER2 차례입니다. ");
            }
            Console.ResetColor();
        }

        public override bool PlayGame()
        {
            int number = base.InputGamenumber();
            if (number == 0)
                return false;

            base.ExpressXOrO(order, number - 1);
            order = (order + 1) % 2;
            return base.PlayGame();
        }
    }
}
