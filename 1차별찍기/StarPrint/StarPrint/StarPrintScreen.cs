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
            lineNumber = 0;
            this.select = select;
            PrintScreen();
        }

        private void PrintScreen()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("줄 수를 입력해 주세요 : ");
            Console.ResetColor();

            String input = Console.ReadLine();
            if (int.TryParse(input, out lineNumber))
            {
                if (lineNumber == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("0 이상의 숫자를 입력해 주세요.");
                    Console.ResetColor();
                    PrintScreen();
                }
                else if (lineNumber > 60)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("너무 큽니다. 60 이하의 숫자를 입력해주세요.");
                    Console.ResetColor();
                    PrintScreen();
                }
                else
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
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("숫자를 입력해 주세요.");
                Console.ResetColor();
                PrintScreen();
            }
        }

        private void FirstPrintStar()
        {
            for(int i = 0; i < lineNumber; i++)
            {
                for (int j = 0; j < lineNumber - i; j++)
                    Console.Write(" ");
                for(int j = 0; j < i * 2 + 1; j++)
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
