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
        string name;

        public StartScreen()
        {
            menuNumber = -1;
            name = null;
        }

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
            Console.ResetColor();

            Console.SetCursorPosition(20, 15);
            if (name == null)
                Console.WriteLine("  이름을 입력해 주세요.");
            else
            {
                Console.Write("환영합니다. ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(name + "님");
                Console.ResetColor();
                Console.SetCursorPosition(20, 17);
                Console.WriteLine("방향키를 눌러 메뉴를 선택해 주세요.");
            }

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

        public int MenuNumber
        {
            get { return menuNumber; }
            set { menuNumber = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
