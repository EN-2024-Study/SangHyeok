using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable.View
{
    public class ExplaningScreen
    {

        public static void ExplaningArrowPress()
        {
            Console.SetCursorPosition(41, 5);
            Console.Write("<<방향키를 눌러 메뉴를 선택해 주세요.");
            Console.SetCursorPosition(41, 6);
            Console.Write("Enter를 눌러 메뉴 색깔이 ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("초록색");
            Console.ResetColor();
            Console.Write("에서");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(41, 7);
            Console.Write("파란색");
            Console.ResetColor();
            Console.Write("으로 바뀌면 입력해 주세요.>>");
        }

        public static void ExplaningEnterPress()
        {
            Console.SetCursorPosition(0, 0);
            Console.Write("NO: ");
            Console.SetCursorPosition(15, 0);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("[Enter]");
            Console.ResetColor();
        }

        public static void ExplaningEscPress()
        {
            Console.SetCursorPosition(27, 0);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("[Esc]");
            Console.ResetColor();
        }
    }
}
