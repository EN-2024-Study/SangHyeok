using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class MainClass
    {

        public static void Main(string[] args)
        {
            Console.SetWindowSize(120, 30);
            ScreenControl screen = new ScreenControl();
            screen.Control();
        }
    }
}
