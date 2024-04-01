using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarPrint
{
    internal class StarPrintScreen
    {
        int select;
        int lineNumber;
        public StarPrintScreen(int select)
        {
            this.select = select;
            PrintScreen();
        }

        private int InputLineNumber()
        {
            int number;
            String inputString = Console.ReadLine();
            if (int.TryParse(inputString, out number))
            {
                if (number < 1)
                    return 0;
                else if (number > 60)
                    return -1;
                else
                    return number;
            }
            return -2;
        }

        private void PrintScreen()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("줄 수를 입력해 주세요 : ");
            Console.ResetColor();
            lineNumber = InputLineNumber();
            switch (lineNumber)
            {
                case -2:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("숫자를 입력해 주세요.");
                    Console.ResetColor();
                    new StarPrintScreen(select);
                    break;
                case -1:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("너무 큽니다. 60 이하의 숫자를 입력해주세요.");
                    Console.ResetColor();
                    new StarPrintScreen(select);
                    break;
                case 0:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("0 이상의 숫자를 입력해 주세요.");
                    Console.ResetColor();
                    new StarPrintScreen(select);
                    break;
                default:
                    PrintStar();
                    break;
            }
            
        }

        private void PrintStar()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            switch (select)
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
            Console.WriteLine("Backspace를 눌러 메뉴로 돌아가기");
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
