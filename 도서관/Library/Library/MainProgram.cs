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

            ModeMenuController controller = new ModeMenuController();
            controller.Run();
        }
    }
}
