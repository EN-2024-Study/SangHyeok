using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarPrint
{
    public class StartScreen : PrintColorStringInterface
    {
        int select;

        public StartScreen(int select)
        {
            this.select = select;   // 시작하기와 종료하기를 int 자료형으로 정함
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
            Console.ResetColor();
        }

        public void PrintScreen()   // 화면 출력
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥");  // 윗부분
            Console.ResetColor();
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine();

            // star 첫 부분
            Console.Write("                                             ");     // S
            PrintYellowBackground("        ");
            Console.Write(" ");

            PrintYellowBackground("       ");  // T
            Console.Write("   ");

            PrintYellowBackground("     ");     // A
            Console.Write("  ");

            PrintYellowBackground("       ");   // R 윗
            Console.WriteLine();

            // star 두번째 라인
            Console.Write("                                             ");

            PrintYellowBackground(" ");         // S
            Console.Write("           ");

            PrintYellowBackground(" ");         // t
            Console.Write("     ");

            PrintYellowBackground(" ");         // a
            Console.Write("     ");
            PrintYellowBackground(" ");         // a
            Console.Write(" ");

            PrintYellowBackground(" ");         // R
            Console.Write("      ");         // R
            PrintYellowBackground(" ");         // R
            Console.WriteLine();

            // 3번째 라인
            Console.Write("                                             ");

            PrintYellowBackground("        ");         // S
            Console.Write("    ");

            PrintYellowBackground(" ");         // T
            Console.Write("     ");

            PrintYellowBackground("       ");         // A
            Console.Write(" ");

            PrintYellowBackground("       ");         // R
            Console.WriteLine();

            // 4번째 라인
            Console.Write("                                                    ");
            PrintYellowBackground(" ");         // S
            Console.Write("    ");

            PrintYellowBackground(" ");         // T
            Console.Write("     ");

            PrintYellowBackground(" ");         // A
            Console.Write("     ");
            PrintYellowBackground(" ");         // A
            Console.Write(" ");

            PrintYellowBackground(" ");         // R
            Console.Write("      ");
            PrintYellowBackground(" ");         // R
            Console.WriteLine();

            // 5 번째 라인
            Console.Write("                                             ");
            PrintYellowBackground("        ");         // S
            Console.Write("    ");

            PrintYellowBackground(" ");         // T
            Console.Write("     ");

            PrintYellowBackground(" ");         // A
            Console.Write("     ");
            PrintYellowBackground(" ");         // A
            Console.Write(" ");

            PrintYellowBackground(" ");         // R
            Console.Write("      ");
            PrintYellowBackground(" ");         // R

            Console.WriteLine();
            Console.WriteLine();

            // PRINTING 윗부분
            Console.Write("                                  ");
            PrintYellowBackground("       ");   // P
            Console.Write("  ");

            PrintYellowBackground("       ");   // R
            Console.Write("  ");

            PrintYellowBackground(" "); // I
            Console.Write(" ");

            PrintYellowBackground("  "); // N
            Console.Write("     ");
            PrintYellowBackground(" "); // N
            Console.Write(" ");

            PrintYellowBackground("       "); // T
            Console.Write(" ");

            PrintYellowBackground(" "); // I
            Console.Write(" ");

            PrintYellowBackground("  "); // N
            Console.Write("     ");
            PrintYellowBackground(" "); // N
            Console.Write("  ");

            PrintYellowBackground("      "); // G
            Console.WriteLine("");

            // PRINTING 2번째 라인
            Console.Write("                                  ");
            PrintYellowBackground(" ");   // P
            Console.Write("     ");
            PrintYellowBackground(" ");   // P
            Console.Write("  ");

            PrintYellowBackground(" ");   // R
            Console.Write("     ");
            PrintYellowBackground(" ");   // R
            Console.Write("  ");

            PrintYellowBackground(" "); // I
            Console.Write(" ");

            PrintYellowBackground("   "); // N
            Console.Write("    ");
            PrintYellowBackground(" "); // N
            Console.Write("    ");

            PrintYellowBackground(" "); // T
            Console.Write("    ");

            PrintYellowBackground(" "); // I
            Console.Write(" ");

            PrintYellowBackground("   "); // N
            Console.Write("    ");
            PrintYellowBackground(" "); // N
            Console.Write(" ");

            PrintYellowBackground("  "); // G
            Console.WriteLine();

            // 3번째 라인
            Console.Write("                                  ");
            PrintYellowBackground("       ");   // P
            Console.Write("  ");

            PrintYellowBackground("       ");   // R
            Console.Write("  ");

            PrintYellowBackground(" "); // I
            Console.Write(" ");

            PrintYellowBackground(" "); // N
            Console.Write("  ");
            PrintYellowBackground(" "); // N
            Console.Write("   ");
            PrintYellowBackground(" "); // N
            Console.Write("    ");

            PrintYellowBackground(" "); // T
            Console.Write("    ");

            PrintYellowBackground(" "); // I
            Console.Write(" ");

            PrintYellowBackground(" "); // N
            Console.Write("  ");
            PrintYellowBackground(" "); // N
            Console.Write("   ");
            PrintYellowBackground(" "); // N
            Console.Write(" ");

            PrintYellowBackground("  "); // G
            Console.Write("   ");
            PrintYellowBackground("   "); // G
            Console.WriteLine();

            // 4번째 라인
            Console.Write("                                  ");
            PrintYellowBackground(" ");   // P
            Console.Write("        ");

            PrintYellowBackground(" ");   // R
            Console.Write("    ");
            PrintYellowBackground(" ");   // R
            Console.Write("   ");

            PrintYellowBackground(" "); // I
            Console.Write(" ");

            PrintYellowBackground(" "); // N
            Console.Write("   ");
            PrintYellowBackground(" "); // N
            Console.Write("  ");
            PrintYellowBackground(" "); // N
            Console.Write("    ");

            PrintYellowBackground(" "); // T
            Console.Write("    ");

            PrintYellowBackground(" "); // I
            Console.Write(" ");

            PrintYellowBackground(" "); // N
            Console.Write("   ");
            PrintYellowBackground(" "); // N
            Console.Write("  ");
            PrintYellowBackground(" "); // N
            Console.Write(" ");

            PrintYellowBackground("  "); // G
            Console.Write("    ");
            PrintYellowBackground("  "); // G
            Console.WriteLine();

            // 5 번째 라인
            Console.Write("                                  ");
            PrintYellowBackground(" ");   // P
            Console.Write("        ");

            PrintYellowBackground(" ");   // R
            Console.Write("    ");
            PrintYellowBackground("  ");   // R
            Console.Write("  ");

            PrintYellowBackground(" "); // I
            Console.Write(" ");

            PrintYellowBackground(" "); // N
            Console.Write("    ");
            PrintYellowBackground("   "); // N
            Console.Write("    ");

            PrintYellowBackground(" "); // T
            Console.Write("    ");

            PrintYellowBackground(" "); // I
            Console.Write(" ");

            PrintYellowBackground(" "); // N
            Console.Write("    ");
            PrintYellowBackground("   "); // N
            Console.Write("  ");

            PrintYellowBackground("      "); // G
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();


            // 시작, 종료 박스
            Console.Write("                                  ");
            PrintYellowBackground("                                                      ");
            Console.WriteLine();

            Console.Write("                                  ");
            PrintYellowBackground(" ");
            Console.Write("                                                    ");
            PrintYellowBackground(" ");
            Console.WriteLine();

            Console.Write("                                  ");
            PrintYellowBackground(" ");
            if (select == 0)
                PrintGreenForeground("                     ①시작하기                     ");
            else
                Console.Write("                     ①시작하기                     ");
            PrintYellowBackground(" ");
            Console.WriteLine();

            Console.Write("                                  ");
            PrintYellowBackground(" ");
            if (select == 1)
                PrintGreenForeground("                     ②종료하기                     ");
            else
                Console.Write("                     ②종료하기                     ");
            PrintYellowBackground(" ");
            Console.WriteLine();

            Console.Write("                                  ");
            PrintYellowBackground(" ");
            Console.Write("                                                    ");
            PrintYellowBackground(" ");
            Console.WriteLine();

            Console.Write("                                  ");
            PrintYellowBackground("                                                      ");
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥");  // 아랫부분
            Console.ResetColor();
            Console.WriteLine();
        }

    }
}
