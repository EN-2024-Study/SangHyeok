using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarPrint
{
    internal class StartScreen : Screen
    {
        int select;

        public StartScreen()
        {
            select = 0;  
        }

        public override void PrintScreen()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@"
 ________  _________  ________  ________                                     
|\   ____\|\___   ___\\   __  \|\   __  \                                    
\ \  \___|\|___ \  \_\ \  \|\  \ \  \|\  \                                   
 \ \_____  \   \ \  \ \ \   __  \ \   _  _\                                  
  \|____|\  \   \ \  \ \ \  \ \  \ \  \\  \|                                 
    ____\_\  \   \ \__\ \ \__\ \__\ \__\\ _\                                 
   |\_________\   \|__|  \|__|\|__|\|__|\|__|                                
   \|_________|                                                              
                                                                             
                                                                             
 ________  ________  ___  ________   _________  ___  ________   ________     
|\   __  \|\   __  \|\  \|\   ___  \|\___   ___\\  \|\   ___  \|\   ____\    
\ \  \|\  \ \  \|\  \ \  \ \  \\ \  \|___ \  \_\ \  \ \  \\ \  \ \  \___|    
 \ \   ____\ \   _  _\ \  \ \  \\ \  \   \ \  \ \ \  \ \  \\ \  \ \  \  ___  
  \ \  \___|\ \  \\  \\ \  \ \  \\ \  \   \ \  \ \ \  \ \  \\ \  \ \  \|\  \ 
   \ \__\    \ \__\\ _\\ \__\ \__\\ \__\   \ \__\ \ \__\ \__\\ \__\ \_______\
    \|__|     \|__|\|__|\|__|\|__| \|__|    \|__|  \|__|\|__| \|__|\|_______|

               ________________ 
               \|            \|

               \|____________\|
               ________________ 
               \|            \|

               \|____________\|
");
            Console.ResetColor();
            Console.SetCursorPosition(40, 20);
            Console.Write("숫자 키 또는 방향키를 눌러");
            Console.SetCursorPosition(40, 22);
            Console.Write("Enter 또는 spacebar 를 통해");
            Console.SetCursorPosition(40, 24);
            Console.Write("메뉴를 선택해 주세요.");

            Console.SetCursorPosition(17, 21);
            if (select == 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("①시작하기");
                Console.ResetColor();
            }
            else
            {
                Console.ResetColor();
                Console.WriteLine("①시작하기");
            }
            Console.SetCursorPosition(17, 25);
            if (select == 1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("②종료하기");
                Console.ResetColor();
            }
            else
            {
                Console.ResetColor();
                Console.WriteLine("②종료하기");
            }
        }

        public int Select
        {
            get { return select; }
            set { select = value; }
        }
    }
}
