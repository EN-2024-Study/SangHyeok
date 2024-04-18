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

        public static void ExplaningSave()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("저장되었습니다. 계속 이용하시려면 Enter를 눌러주세요.");
        }

        public static void ExplaningInvalidInput()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("잘못된 입력입니다.");
            Console.Write("Enter를 누른 후 다시 입력하여 주세요.");
        }

        public static void ExplaningSuccessInput()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("성공입니다.!");
            Console.Write("Enter를 누른 후 계속 진행하여 주세요.");
        }

        public static void ExplaningLogIn()
        {
            Console.SetCursorPosition(5, 35);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Esc : 종료");
            Console.ResetColor();
        }
    }
}
