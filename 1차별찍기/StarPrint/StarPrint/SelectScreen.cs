using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarPrint
{
    internal class SelectScreen : PrintColorStringInterface
    {
        int select; // 어떤 메뉴로 들어갈지 int 자료형으로 정함

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
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@"







                                           ________________________________ 
                                           \|                             \|
                                           \|                             \|
                                           \|                             \|
                                           \|                             \|
                                           \|                             \|
                                           \|                             \|
                                           \|                             \|
                                           \|                             \|
                                           \|                             \|
                                           \|                             \|
                                           \|_____________________________\|
");
            Console.SetCursorPosition(52, 10);
            if (select == 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("①  가운데정렬");
            }
            else
            {
                Console.ResetColor();
                Console.WriteLine("①  가운데정렬");
            }
            Console.SetCursorPosition(52, 12);
            if (select == 1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("②  1번의 반대");
            }
            else
            {
                Console.ResetColor();
                Console.WriteLine("②  1번의 반대");
            }
            Console.SetCursorPosition(52, 14);
            if (select == 2)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("③  모래 시계");
            }
            else
            {
                Console.ResetColor();
                Console.WriteLine("③  모래 시계");
            }
            Console.SetCursorPosition(52, 16);
            if (select == 3)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("④  다이아");
            }
            else
            {
                Console.ResetColor();
                Console.WriteLine("④  다이아");
            }
            Console.SetCursorPosition(52, 18);
            if (select == 4)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("⑤  종료");
            }
            else
            {
                Console.ResetColor();
                Console.WriteLine("⑤  종료");
            }
        }
    }
}
