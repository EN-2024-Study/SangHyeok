using System;
using Library.Utility;

namespace Library.View
{
    public class MenuScreen
    {
        public void PrintMenu(string[] menuString, int menuValue, bool isSelect)
        {
            Tuple<int, int> coordinate;
            if (menuString.Length > 5)
                coordinate = new Tuple<int, int>(20, 15);
            else
                coordinate = new Tuple<int, int>(20, 25);
            ExplainingScreen.ExplainDirectionKey();
            ExplainingScreen.ExplainSelectKey();
            //if (menuString[0].Equals("유저 모드") || menuString[0].Equals("도서 조회"))
            //    ExplainingScreen.PrintQuit();


            for (int i = 0; i < menuString.Length; i++)
            {
                Console.SetCursorPosition(coordinate.Item1, coordinate.Item2 + i * 2);
                if (isSelect && menuValue == i)
                    Console.ForegroundColor = ConsoleColor.Blue;
                else if (menuValue == i)
                    Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(menuString[i]);
                Console.ResetColor();
            }
        }

        public void EraseMenu()
        {
            Tuple<int, int> coordinate = new Tuple<int, int>(15, 20);

            for (int i = coordinate.Item1; i < 100; i++)
            {
                for (int j = coordinate.Item2; j < 35; j++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(" ");
                }
            }
        }
    }
}
