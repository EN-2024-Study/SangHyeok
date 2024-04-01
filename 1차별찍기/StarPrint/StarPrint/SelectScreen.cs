using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarPrint
{
    internal class SelectScreen : PrintColorStringInterface
    {
        int select;

        public SelectScreen(int select)
        {
            this.select = select;
            PrintScreen();
        }

        public void PrintYellowBackground(string s)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Write(s);
            Console.ResetColor();
        }

        public void PrintGreenForeground(string s)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s);
            Console.ResetColor(); ;
        }

        private void PrintScreen()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("                                               ");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("♥♥♥♥♥♥♥♥♥♥♥♥♥♥");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            if (select == 0)
                PrintGreenForeground("                                                      1  가운데정렬");
            else
                Console.Write("                                                      1  가운데정렬");
            Console.WriteLine();

            if (select == 1)
                PrintGreenForeground("                                                      2  1번의 반대");
            else
                Console.Write("                                                      2  1번의 반대");
            Console.WriteLine();

            if (select == 2)
                PrintGreenForeground("                                                      3  모래 시계");
            else
                Console.Write("                                                      3  모래 시계");
            Console.WriteLine();

            if (select == 3)
                PrintGreenForeground("                                                      4  다이아");
            else
                Console.Write("                                                      4  다이아");
            Console.WriteLine();

            if (select == 4)
                PrintGreenForeground("                                                      5  종료");
            else
                Console.Write("                                                      5  종료");
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine();
            Console.Write("                                               ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("♥♥♥♥♥♥♥♥♥♥♥♥♥♥");
            Console.ResetColor();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
