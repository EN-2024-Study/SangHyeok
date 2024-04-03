using System;
using System.Security.Cryptography;

namespace StarPrint
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            Console.SetWindowSize(100, 30);
            ScreenControl screen = new ScreenControl();
            screen.ControlScreen();
        }

    }
}
