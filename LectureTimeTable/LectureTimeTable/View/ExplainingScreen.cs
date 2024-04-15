using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable.View
{
    public class ExplainingScreen
    {
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
    }
}
