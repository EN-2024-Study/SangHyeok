using System;
using System.Security.Cryptography;

namespace StarPrint
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            ScreenControl screen = new ScreenControl();
            screen.ControlScreen();
        }

    }
}
