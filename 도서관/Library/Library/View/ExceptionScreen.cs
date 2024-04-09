using Library.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.View
{
    public class ExceptionScreen
    {
        public void PrintInputException(int errorNumber)
        {
            Console.SetCursorPosition(4, 27);
            Console.ForegroundColor = ConsoleColor.Red;
            switch (errorNumber)
            {
                case (int)Constants.Error.Length:
                    Console.Write("입력 길이가 맞지 않습니다.");
                    break;
                case 1:

                    break;
            }

            Console.SetCursorPosition(4, 28);
            Console.Write("다시 입력하여 주세요.");
            Console.SetCursorPosition(15, 23);
            Console.Write("                ");
            Console.SetCursorPosition(15, 25);
            Console.Write("                ");
            Console.ResetColor();
        }

        public void PrintSignUpException()
        {
            Console.Clear();
            Console.SetWindowSize(50, 15);
            Console.SetCursorPosition(15, 5);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("관리자는 회원가입을");
            Console.SetCursorPosition(15, 7);
            Console.Write("할 수 없습니다.");
            Console.SetCursorPosition(15, 9);
            Console.Write("뒤로 가기는 ESC를");
            Console.SetCursorPosition(15, 11);
            Console.Write("눌러주세요.");
            Console.ResetColor();
        }
    }


}
