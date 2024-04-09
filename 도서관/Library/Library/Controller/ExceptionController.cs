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

        public void HandleInputException()
        {
            exceptionScreen.PrintInputException((int)Constants.Error.Length);
        }

        public void HandleSignUpException()
        {
            exceptionScreen.PrintSignUpException();
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.Escape)
                return;
            HandleSignUpException();
        }

    }
}
