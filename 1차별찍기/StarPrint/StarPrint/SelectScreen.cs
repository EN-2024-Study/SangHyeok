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
            UpDownSort();
            Console.Write("                                               ");
            PrintYellowBackground("                                  ");
            Console.WriteLine();
            Console.Write("                                               ");
            



        }
        private void UpDownSort()
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

        }
    }
}
