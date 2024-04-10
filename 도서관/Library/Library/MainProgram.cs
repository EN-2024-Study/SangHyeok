using Library.Controller;
using Library.Utility;
using System;

namespace Library
{
    public class MainProgram
    {

        public static void Main(string[] args)
        {
            ModeMenuController modeMenuController = new ModeMenuController();
            modeMenuController.Run();
        }
    }
}
