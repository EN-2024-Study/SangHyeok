using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Utility
{
    public class ExplainingScreen
    {
        public static void ExplainSelectKey()
        {
            Console.SetCursorPosition(75, 21);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("ESC: 뒤로가기");
            Console.SetCursorPosition(75, 22);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("ENTER: 입력하기");
            Console.ResetColor();
        }

        public static void ExplainDirectionKey()
        {
            Console.SetCursorPosition(75, 24);
            Console.Write("방향키를 눌러 모드를");
            Console.SetCursorPosition(75, 25);
            Console.Write("선택해 주세요.");
        }

        public static void ExplainInputKey()
        {
            int x = 75, y = 27;
            Console.SetCursorPosition(x, y);
            Console.Write("커서가 ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("초록색");
            Console.ResetColor();
            Console.Write("이면 Enter를");
            Console.SetCursorPosition(x, y + 1);
            Console.Write("눌러");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("파란색");
            Console.ResetColor();
            Console.Write("으로 만든 후");
            Console.SetCursorPosition(x, y + 2);
            Console.Write("정보를 입력하세요.");
        }

        public static void PrintQuit()
        {
            Console.SetCursorPosition(75, 21);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("ESC: 종료하기");
            Console.ResetColor();
        }

        //public static void PrintInputError()
        //{
        //    Console.ForegroundColor = ConsoleColor.Red;
        //    Console.SetCursorPosition(75, 23);
        //    Console.Write("잘못된 입력입니다.");
        //    Console.SetCursorPosition(75, 24);
        //    Console.Write("다시 입력하세요.");
        //    Console.ResetColor();
        //}

        public static void PrintInputFailure(Tuple<int, int> coordinate)
        {
            Console.SetCursorPosition(coordinate.Item1, coordinate.Item2);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("[Fail]");
            Console.ResetColor();
        }
    }
}
