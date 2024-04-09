﻿using Library.Utility;
using Library.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Controller
{
    public class InputController
    {
        private ExceptionController exceptionController;

        public InputController()
        {
            exceptionController = new ExceptionController();
        }

        public string InputLogIn(int coordinateX, int coordinateY, int length, bool isPassword)
        {
            Console.CursorVisible = true;
            Console.SetCursorPosition(coordinateX, coordinateY);
            string str = null;
            char[] inputString = new char[length];
            bool isBreak = false;

            for (int i = 0; i < length; i++)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                switch (keyInfo.Key)
                {
                    case ConsoleKey.Enter:
                        isBreak = true;
                        break;
                    case ConsoleKey.Backspace:
                        Console.SetCursorPosition(15, coordinateY - i - 1);
                        Console.Write(" ");
                        Console.SetCursorPosition(15, coordinateY - i);
                        break;
                    case ConsoleKey.Escape:
                        return null;
                }

                if (isBreak)
                    break;
                else if (isPassword)
                {
                    Console.SetCursorPosition(coordinateX, 25);
                    Console.Write("*");
                    coordinateX++;
                }
                inputString[i] = keyInfo.KeyChar;
            }

            if (!isBreak)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key != ConsoleKey.Enter)
                {
                    exceptionController.HandleInputException();
                    return InputLogIn(coordinateX, coordinateY, length, isPassword);
                }
            }

            for (int i = 0; i < length; i++)
                str += inputString[i];

            Console.CursorVisible = false;
            return str;
        }


        public string InputSignUp(int infoNumber)
        {
            string str = null;
            int lengthLimit = 0;
            switch(infoNumber)
            {
                case (int)Constants.User.Id:

                    break;
                case (int)Constants.User.Password:

                    break;
                case (int)Constants.User.Name:

                    break;
                case (int)Constants.User.Age:

                    break;
                case (int)Constants.User.PhoneNumber:

                    break;
                case (int)Constants.User.Address:

                    break;
            }

            return str;
        }
    }
}
