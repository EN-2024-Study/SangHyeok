using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class UserGameScreen : GameScreen
    {
        GameScreen gameScreen;
        int order;
        int[] gameCoordinate;

        public UserGameScreen()
        {
            gameScreen = new GameScreen();
            order = 0;
            gameCoordinate = new int[9];
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
                Console.Write("USER1 차례입니다. ");
            else
                Console.Write("USER2 차례입니다. ");
            Console.ResetColor();
        }

        public bool PlayGame()
        {
            int num = base.InputGameNumber();
            if (num == 0)
                return false;
            else if (gameCoordinate[num - 1] == 0)
            {
                base.ExpressXOrO(order, num);
                switch (order)
                {
                    case 0:
                        gameCoordinate[num - 1] = 1;
                        break;
                    case 1:
                        gameCoordinate[num - 1] = 2;
                        break;
                }
            }

            order = (order + 1) % 2;
            return true;
        }

        //public bool CheckEnd()
        //{
        //    for (int i = 0; i < 3; i++) // 세로와 대각선 확인
        //    {
        //        if (gameCoordinate[i] == gameCoordinate[2 + i] && gameCoordinate[i] == gameCoordinate[8 - i])
        //        {
        //            //if (gameCoordinate[i] == 1)
        //            //    ScoreBoardScreen.OneUserScore += 1;
        //            //else if (gameCoordinate[i] == 2)
        //            //    ScoreBoardScreen.TwoUserScore += 1;
        //            //return true;
        //        }
        //    }

        //    for (int i = 0; i < 9; i += 3)  // 가로 확인
        //    {
        //        if (gameCoordinate[i] == gameCoordinate[i + 1] && gameCoordinate[i + 1] == gameCoordinate[i + 2])
        //        {
        //            //if (gameCoordinate[i] == 1)
        //            //    ScoreBoardScreen.OneUserScore += 1;
        //            //else if (gameCoordinate[i] == 2)
        //            //    ScoreBoardScreen.TwoUserScore += 1;
        //            //return true;
        //        }
        //    }
        //    return false;
        //}

    }
}
