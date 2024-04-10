using Library.Controller;
using Library.Utility;
using System;

namespace Library
{
    public class MainProgram
    {

        public static void Main(string[] args)
        {
            Console.SetWindowSize(100, 40);
            Console.CursorVisible = false;

            ModeMenuController modeMenuController = new ModeMenuController();
            modeMenuController.Run();
        }
    }
}
