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
            Console.Write("                                                      ");
            Console.WriteLine("1  가운데정렬");
            Console.Write("                                                      ");
            Console.WriteLine("2  1번의 반대");
            Console.Write("                                                      ");
            Console.WriteLine("3  모래 시계");
            Console.Write("                                                      ");
            Console.WriteLine("4  다이아");
            Console.Write("                                                      ");
            Console.WriteLine("5  종료");
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
