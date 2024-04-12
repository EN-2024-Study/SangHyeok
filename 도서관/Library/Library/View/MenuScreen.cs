using System;
using Library.Utility;

namespace Library.View
{
    public class MenuScreen
    {
        public void PrintMenu(string[] menuString, int CurrentMenuValue, Tuple<int, int> coordinate)
        {
            ExplainingScreen.ExplainDirectionKey();
            ExplainingScreen.ExplainSelectKey();
            if (menuString[0].Equals("유저 모드") || menuString[0].Equals("도서 조회"))
                ExplainingScreen.PrintQuit();

            for (int i = 0; i < menuString.Length; i++)
            {
                Console.SetCursorPosition(coordinate.Item1, coordinate.Item2 + i * 2);
                if (CurrentMenuValue == i)
                    Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(menuString[i]);
                Console.ResetColor();
            }
        }
    }
}
