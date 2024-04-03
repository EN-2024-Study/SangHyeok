using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarPrint
{
    internal class StarPrintScreen : Screen
    {
        int lineNumber;
        string numberString;

        public StarPrintScreen()
        {
            lineNumber = 0;
            numberString = null;
        }

        public override void PrintScreen()
        {
            bool isBreak = false;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("줄 수를 입력해 주세요 : ");
            Console.ResetColor();
            while(!isBreak) // 정상 입력까지 반복
            {
                lineNumber = InputLineNumber(); 

                switch (lineNumber)
                {
                    case -2:
                        PrintError("숫자를 입력해 주세요.");
                        break;
                    case -1:
                        PrintError("너무 큽니다. 60 이하의 숫자를 입력해주세요.");
                        break;
                    case 0:
                        PrintError("0 이상의 숫자를 입력해 주세요.");
                        break;
                    default:
                        PrintStar();
                        isBreak = true;
                        break;
                }
            }
        }

        private int InputLineNumber()
        {
            int number;
            numberString = Console.ReadLine();
            if (int.TryParse(numberString, out number))
            {
                if (number < 1) // 0이하의 숫자 입력시 예외 처리
                    return 0;
                else if (number > 60)   // 너무 큰 숫자 입력시 예외 처리
                    return -1;
                else
                    return number;  // 정상 입력
            }
            return -2;  // 문자 입력시 예외 처리
        }

        private void PrintError(string s)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(s);   // 예외 처리 구문
            Console.ResetColor();
            Console.SetCursorPosition(24, 0);
            for (int i = 0; i < numberString.Length; i++)    // 잘못 입력된 문자 삭제
                Console.Write(" ");
            Console.SetCursorPosition(24, 0);
        }

        private void PrintStar()    // 별 출력
        {
            Console.SetCursorPosition(0, 1);
            Console.WriteLine("                              ");    // error 문자 삭제
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            switch (SelectScreen.Select)
            {
                case 0:
                    FirstPrintStar();
                    break;
                case 1:
                    SecondPrintStar();
                    break;
                case 2:
                    ThirdPrintStar();
                    break;
                case 3:
                    FourPrintStar();
                    break;
            }
            Console.ResetColor();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("← Backspace를 눌러 메뉴로 돌아가기");
            Console.WriteLine();
            Console.WriteLine("S키를 눌러 시작화면으로 돌아가기");
        }

        private void FirstPrintStar()
        {
            for (int i = 0; i < lineNumber; i++)
            {
                for (int j = 0; j < lineNumber - i; j++)
                    Console.Write(" ");
                for (int j = 0; j < i * 2 + 1; j++)
                    Console.Write("*");
                Console.WriteLine();
            }
        }

        private void SecondPrintStar()
        {
            for (int i = 0; i < lineNumber; i++)
            {
                for (int j = 0; j < i; j++)
                    Console.Write(" ");
                for (int j = 0; j < lineNumber * 2 - (i * 2) - 1; j++)
                    Console.Write("*");
                Console.WriteLine();
            }
        }
        private void ThirdPrintStar()
        {
            lineNumber /= 2;
            lineNumber++;
            bool first = true;

            for (int i = 0; i < lineNumber; i++)
            {
                for (int j = 0; j < i + 1; j++)
                    Console.Write(" ");
                for (int j = 0; j < lineNumber * 2 - (i * 2) - 1; j++)
                    Console.Write("*");
                Console.WriteLine();
            }
            for (int i = 0; i < lineNumber; i++)
            {
                if (first)
                {
                    first = false;
                    continue;
                }
                for (int j = 0; j < lineNumber - i; j++)
                    Console.Write(" ");
                for (int j = 0; j < i * 2 + 1; j++)
                    Console.Write("*");
                Console.WriteLine();
            }
        }
        private void FourPrintStar()
        {
            lineNumber /= 2;
            lineNumber++;
            bool first = true;

            for (int i = 0; i < lineNumber; i++)
            {
                for (int j = 0; j < lineNumber - i; j++)
                    Console.Write(" ");
                for (int j = 0; j < i * 2 + 1; j++)
                    Console.Write("*");
                Console.WriteLine();
            }

            for (int i = 0; i < lineNumber; i++)
            {
                if (first)
                {
                    first = false;
                    continue;
                }
                for (int j = 0; j < i + 1; j++)
                    Console.Write(" ");
                for (int j = 0; j < lineNumber * 2 - (i * 2) - 1; j++)
                    Console.Write("*");
                Console.WriteLine();
            }
        }
    }
}
