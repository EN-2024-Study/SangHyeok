using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class StartScreen : Screen
    {
        public override void PrintScreen()
        {
            const int nameFieldX = 20;
            const int nameFieldY = 15;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@"
              ___   ___                                                                                      
 /__  ___/       / /        //   ) )  /__  ___/     // | |     //   ) )  /__  ___/     //   ) )     //   / / 
   / /          / /        //           / /        //__| |    //           / /        //   / /     //____    
  / /          / /        //           / /        / ___  |   //           / /        //   / /     / ____     
 / /          / /        //           / /        //    | |  //           / /        //   / /     //          
/ /        __/ /___     ((____/ /    / /        //     | | ((____/ /    / /        ((___/ /     //____/ /    
            ");
            Console.ResetColor();
            Console.SetCursorPosition(nameFieldX, nameFieldY);
        }
    }
}
