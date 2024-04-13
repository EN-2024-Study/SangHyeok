using System;
using Library.Utility;

namespace Library.View
{
    public class MenuScreen
    {
        public void PrintMenu(string[] menuString, int menuValue, bool isSelect)
        {
            Tuple<int, int> coordinate;
            if (menuString.Length == 8) // 도서 추가 화면
                coordinate = new Tuple<int, int>(10, 7);
            else if (menuString.Length == 7)    // 도서 수정 화면
                coordinate = new Tuple<int, int>(10, 7);    
            else if (menuString.Length > 5)
                coordinate = new Tuple<int, int>(20, 15);
            else if (menuString[0].Equals("제목으로 찾기       :"))
                coordinate = new Tuple<int, int>(0, 0);
            else if (menuString.Length == 5)    // UserModifyMenu
                coordinate = new Tuple<int, int>(1, 15);
            else
                coordinate = new Tuple<int, int>(20, 25);
            ExplainingScreen.ExplainDirectionKey();
            ExplainingScreen.ExplainSelectKey();

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
