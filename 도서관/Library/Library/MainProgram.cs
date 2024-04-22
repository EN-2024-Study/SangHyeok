using Library.Controller;
using Library.Utility;
using System;

namespace Library
{
    public class MainProgram
    {

        public static void Main(string[] args)
        {
            Console.SetWindowSize(100, 35);
            Console.CursorVisible = false;

            ModeMenu controller = new ModeMenu();
            controller.Run();
        }
    }
}
