using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable.View
{
    public class ExplainingScreen
    {
        public static void PrintQuit()
        {
            Console.SetCursorPosition(75, 21);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("ESC: 종료하기");
            Console.ResetColor();
        }
    }
}
