using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarPrint
{
    public class StartScreen
    {

        public StartScreen()
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
            PrintYellowString("        ");
            Console.Write(" ");

            PrintYellowString("       ");  // T
            Console.Write("   ");

            PrintYellowString("     ");     // A
            Console.Write("  ");

            PrintYellowString("       ");   // R 윗
            Console.WriteLine();

            // star 두번째 라인
            Console.Write("                                             ");

            PrintYellowString(" ");         // S
            Console.Write("           ");

            PrintYellowString(" ");         // t
            Console.Write("     ");

            PrintYellowString(" ");         // a
            Console.Write("     ");
            PrintYellowString(" ");         // a
            Console.Write(" ");

            PrintYellowString(" ");         // R
            Console.Write("      ");         // R
            PrintYellowString(" ");         // R
            Console.WriteLine();

            // 3번째 라인
            Console.Write("                                             ");

            PrintYellowString("        ");         // S
            Console.Write("    ");

            PrintYellowString(" ");         // T
            Console.Write("     ");

            PrintYellowString("       ");         // A
            Console.Write(" ");

            PrintYellowString("       ");         // R
            Console.WriteLine();

            // 4번째 라인
            Console.Write("                                                    ");
            PrintYellowString(" ");         // S
            Console.Write("    ");

            PrintYellowString(" ");         // T
            Console.Write("     ");

            PrintYellowString(" ");         // A
            Console.Write("     ");
            PrintYellowString(" ");         // A
            Console.Write(" ");

            PrintYellowString(" ");         // R
            Console.Write("      ");
            PrintYellowString(" ");         // R
            Console.WriteLine();

            // 5 번째 라인
            Console.Write("                                             ");
            PrintYellowString("        ");         // S
            Console.Write("    ");

            PrintYellowString(" ");         // T
            Console.Write("     ");

            PrintYellowString(" ");         // A
            Console.Write("     ");
            PrintYellowString(" ");         // A
            Console.Write(" ");

            PrintYellowString(" ");         // R
            Console.Write("      ");
            PrintYellowString(" ");         // R

            Console.WriteLine();
            Console.WriteLine();

            // PRINTING 윗부분
            Console.Write("                                  ");
            PrintYellowString("       ");   // P
            Console.Write("  ");

            PrintYellowString("       ");   // R
            Console.Write("  ");

            PrintYellowString(" "); // I
            Console.Write(" ");

            PrintYellowString("  "); // N
            Console.Write("     ");
            PrintYellowString(" "); // N
            Console.Write(" ");

            PrintYellowString("       "); // T
            Console.Write(" ");

            PrintYellowString(" "); // I
            Console.Write(" ");

            PrintYellowString("  "); // N
            Console.Write("     ");
            PrintYellowString(" "); // N
            Console.Write("  ");

            PrintYellowString("      "); // G
            Console.WriteLine("");

            // PRINTING 2번째 라인
            Console.Write("                                  ");
            PrintYellowString(" ");   // P
            Console.Write("     ");
            PrintYellowString(" ");   // P
            Console.Write("  ");

            PrintYellowString(" ");   // R
            Console.Write("     ");
            PrintYellowString(" ");   // R
            Console.Write("  ");

            PrintYellowString(" "); // I
            Console.Write(" ");

            PrintYellowString("   "); // N
            Console.Write("    ");
            PrintYellowString(" "); // N
            Console.Write("    ");

            PrintYellowString(" "); // T
            Console.Write("    ");

            PrintYellowString(" "); // I
            Console.Write(" ");

            PrintYellowString("   "); // N
            Console.Write("    ");
            PrintYellowString(" "); // N
            Console.Write(" ");

            PrintYellowString("  "); // G
            Console.WriteLine();

            // 3번째 라인
            Console.Write("                                  ");
            PrintYellowString("       ");   // P
            Console.Write("  ");

            PrintYellowString("       ");   // R
            Console.Write("  ");

            PrintYellowString(" "); // I
            Console.Write(" ");

            PrintYellowString(" "); // N
            Console.Write("  ");
            PrintYellowString(" "); // N
            Console.Write("   ");
            PrintYellowString(" "); // N
            Console.Write("    ");

            PrintYellowString(" "); // T
            Console.Write("    ");

            PrintYellowString(" "); // I
            Console.Write(" ");

            PrintYellowString(" "); // N
            Console.Write("  ");
            PrintYellowString(" "); // N
            Console.Write("   ");
            PrintYellowString(" "); // N
            Console.Write(" ");

            PrintYellowString("  "); // G
            Console.Write("   ");
            PrintYellowString("   "); // G
            Console.WriteLine();

            // 4번째 라인
            Console.Write("                                  ");
            PrintYellowString(" ");   // P
            Console.Write("        ");

            PrintYellowString(" ");   // R
            Console.Write("    ");
            PrintYellowString(" ");   // R
            Console.Write("   ");

            PrintYellowString(" "); // I
            Console.Write(" ");

            PrintYellowString(" "); // N
            Console.Write("   ");
            PrintYellowString(" "); // N
            Console.Write("  ");
            PrintYellowString(" "); // N
            Console.Write("    ");

            PrintYellowString(" "); // T
            Console.Write("    ");

            PrintYellowString(" "); // I
            Console.Write(" ");

            PrintYellowString(" "); // N
            Console.Write("   ");
            PrintYellowString(" "); // N
            Console.Write("  ");
            PrintYellowString(" "); // N
            Console.Write(" ");

            PrintYellowString("  "); // G
            Console.Write("    ");
            PrintYellowString("  "); // G
            Console.WriteLine();

            // 5 번째 라인
            Console.Write("                                  ");
            PrintYellowString(" ");   // P
            Console.Write("        ");

            PrintYellowString(" ");   // R
            Console.Write("    ");
            PrintYellowString("  ");   // R
            Console.Write("  ");

            PrintYellowString(" "); // I
            Console.Write(" ");

            PrintYellowString(" "); // N
            Console.Write("    ");
            PrintYellowString("   "); // N
            Console.Write("    ");

            PrintYellowString(" "); // T
            Console.Write("    ");

            PrintYellowString(" "); // I
            Console.Write(" ");

            PrintYellowString(" "); // N
            Console.Write("    ");
            PrintYellowString("   "); // N
            Console.Write("  ");

            PrintYellowString("      "); // G
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();


            // 시작, 종료 박스
            Console.Write("                                  ");
            PrintYellowString("                                                      ");
            Console.WriteLine();

            Console.Write("                                  ");
            PrintYellowString(" ");
            Console.Write("                                                    ");
            PrintYellowString(" ");
            Console.WriteLine();

            Console.Write("                                  ");
            PrintYellowString(" ");
            Console.Write("                     1시작하기                      ");
            PrintYellowString(" ");
            Console.WriteLine();

            Console.Write("                                  ");
            PrintYellowString(" ");
            Console.Write("                     2종료하기                      ");
            PrintYellowString(" ");
            Console.WriteLine();

            Console.Write("                                  ");
            PrintYellowString(" ");
            Console.Write("                                                    ");
            PrintYellowString(" ");
            Console.WriteLine();

            Console.Write("                                  ");
            PrintYellowString("                                                      ");
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
        private void PrintYellowString(string s)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Write(s);
            Console.ResetColor();
        }
    }
}
