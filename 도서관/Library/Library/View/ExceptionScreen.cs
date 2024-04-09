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


        public void PrintException(int errorNumber)
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
    }


}
