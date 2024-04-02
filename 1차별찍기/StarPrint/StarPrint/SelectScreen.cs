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

        public void PrintScreen()
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
                PrintGreenForeground("                                                      ①  가운데정렬");
            else
                Console.Write("                                                      ①  가운데정렬");
            Console.WriteLine();

            if (select == 1)
                PrintGreenForeground("                                                      ②  1번의 반대");
            else
                Console.Write("                                                      ②  1번의 반대");
            Console.WriteLine();

            if (select == 2)
                PrintGreenForeground("                                                      ③  모래 시계");
            else
                Console.Write("                                                      ③  모래 시계");
            Console.WriteLine();

            if (select == 3)
                PrintGreenForeground("                                                      ④  다이아");
            else
                Console.Write("                                                      ④  다이아");
            Console.WriteLine();

            if (select == 4)
                PrintGreenForeground("                                                      ⑤  종료");
            else
                Console.Write("                                                      ⑤  종료");
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
