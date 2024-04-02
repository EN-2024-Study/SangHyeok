using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class StartScreen : Screen
    {
        int menuNumber;

        public StartScreen(int number)
        { menuNumber = number; }
        public override void PrintScreen()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@"
              ___   ___                                                                                      
 /__  ___/       / /        //   ) )  /__  ___/     // | |     //   ) )  /__  ___/     //   ) )     //   / / 
   / /          / /        //           / /        //__| |    //           / /        //   / /     //____    
  / /          / /        //           / /        / ___  |   //           / /        //   / /     / ____     
 / /          / /        //           / /        //    | |  //           / /        //   / /     //          
/ /        __/ /___     ((____/ /    / /        //     | | ((____/ /    / /        ((___/ /     //____/ /    









                    ━━━━━━━━━━♥♥♥━━━━━━━━━━

                    ━━━━━━━━━━♥♥♥━━━━━━━━━━

            ");
            Console.SetCursorPosition(20, 15);
            Console.WriteLine("  이름을 입력해 주세요.");
            Console.SetCursorPosition(80, 13);
            if (menuNumber == 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("㉠  vs Computer");
                Console.ResetColor();
            }
            else
            {
                Console.ResetColor();
                Console.WriteLine("㉠  vs Computer");
            }
            Console.SetCursorPosition(80, 15);
            if (menuNumber == 1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("㉡  vs User");
                Console.ResetColor();
            }
            else
            {
                Console.ResetColor();
                Console.WriteLine("㉡  vs User");
            }
            Console.SetCursorPosition(80, 17);
            if (menuNumber == 2)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("㉢  vs ScoreBoard");
                Console.ResetColor();
            }
            else
            {
                Console.ResetColor();
                Console.WriteLine("㉢  vs ScoreBoard");
            }
            Console.SetCursorPosition(80, 19);
            if (menuNumber == 3)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("㉣  Quit");
                Console.ResetColor();
            }
            else
            {
                Console.ResetColor();
                Console.WriteLine("㉣  Quit");
            }
        }
    }
}
