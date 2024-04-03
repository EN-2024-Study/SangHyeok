using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class ComputerGameScreen : Screen
    {
        public override void PrintScreen()
        {
            Console.SetCursorPosition(45, 1);
            Console.WriteLine("<ScoreBoard>");
        }


    }
}
