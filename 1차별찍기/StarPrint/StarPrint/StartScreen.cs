using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarPrint
{
    public class StartScreen
    {
        int select;

        public StartScreen(int select)
        {
            this.select = select;   // 시작하기와 종료하기를 int 자료형으로 정함
        }

        public void PrintScreen()
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
    }
}
