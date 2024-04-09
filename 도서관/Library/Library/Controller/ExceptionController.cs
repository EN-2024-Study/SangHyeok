using Library.Utility;
using Library.View;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
//using System.Text.RegularExpressions.Regex;


namespace Library.Controller
{
    public class ExceptionController
    {
        ExceptionScreen exceptionScreen;

        public ExceptionController()
        {
            exceptionScreen = new ExceptionScreen();
        }

        public bool HandleInputException()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            if (keyInfo.Key != ConsoleKey.Enter)
            {
                exceptionScreen.PrintException((int)Constants.Error.Length);
                return true;
            }
            return false;
        }

    }
}
