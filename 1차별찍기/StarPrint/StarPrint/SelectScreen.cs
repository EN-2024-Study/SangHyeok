using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarPrint
{
    internal class SelectScreen : Screen
    {
        static int select; // 어떤 메뉴로 들어갈지 int 자료형으로 정함

        public SelectScreen()
        {
            select = 0;
        }

        public override void PrintScreen()
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

            Console.SetCursorPosition(42, 10);
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

            Console.SetCursorPosition(42, 12);
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

            Console.SetCursorPosition(42, 14);
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

            Console.SetCursorPosition(42, 16);
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

            Console.SetCursorPosition(42, 18);
            if (select == 4)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("⑤  종료");
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ResetColor();
                Console.WriteLine("⑤  종료");
            }

            Console.SetCursorPosition(70, 10);
            Console.Write("숫자 키 또는 방향키를 눌러");
            Console.SetCursorPosition(70, 12);
            Console.Write("Enter 또는 spacebar 를 통해");
            Console.SetCursorPosition(70, 14);
            Console.Write("메뉴를 선택해 주세요.");
        }

        public static int Select
        {
            get { return select; }
            set { select = value; }
        }
    }
}
