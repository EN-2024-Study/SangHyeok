using System;
using System.Security.Cryptography;

namespace StarPrint
{
    public class CodeFile1
    {


        public static void Main(string[] args)
        {
            bool followUp = false;
            int select = 0;
            while (true)
            {
                Console.Clear();
                if (followUp)
                    new SelectScreen();
                else
                    new StartScreen(select % 2);

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.Enter && select % 2 == 0)
                    followUp = true;
                else if (keyInfo.Key == ConsoleKey.Enter && select % 2 == 1)
                    break;
                else if (keyInfo.Key == ConsoleKey.DownArrow || keyInfo.Key == ConsoleKey.UpArrow)
                    select++;
                
            }
        }

    }
}
