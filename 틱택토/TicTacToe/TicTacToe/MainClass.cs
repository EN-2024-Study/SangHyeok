using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class MainClass
    {
        //static bool exit = false;

        public static void Main(string[] args)
        {
            //Console.CancelKeyPress += new ConsoleCancelEventHandler(Handler);
            Console.SetWindowSize(120, 30);
            Console.CursorVisible = false;

            ScreenControl screen = new ScreenControl();
            screen.Control();
        }

        //private static void Handler(object sender, ConsoleCancelEventArgs args)
        //{
        //    Console.WriteLine("test");
        //    args.Cancel = true;
        //    //exit = true;
        //}
    }
}
