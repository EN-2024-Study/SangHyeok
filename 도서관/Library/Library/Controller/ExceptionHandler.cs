using Library.Utility;
using Library.View;
using System;
using System.Collections.Generic;
//using System.Text.RegularExpressions.Regex;


namespace Library.Controller
{
    public class ExceptionHandler
    {
        AccountScreen accountScreen;


        public ExceptionHandler()
        {
            accountScreen = new AccountScreen();
        }

        public string HandleInputException(int length, bool isPassword)
        {
            char[] inputString = new char[length];
            string str = null;
            bool isBreak = false;
            int passwordX = 15;

            for (int i = 0; i < length; i++)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    isBreak = true;
                    break;
                }
                else if (isPassword)
                {
                    Console.SetCursorPosition(passwordX, 25);
                    Console.Write("*");
                    passwordX++;
                }
                inputString[i] = keyInfo.KeyChar;
            }

            if (!isBreak)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key != ConsoleKey.Enter)
                {
                    accountScreen.PrintException((int)Constants.Error.Length);
                    return null;
                }
            }

            for (int i = 0; i < length; i++)
                str += inputString[i];
            return str;
        }

    }
}
