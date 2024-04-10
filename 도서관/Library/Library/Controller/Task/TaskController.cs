using Library.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Controller.Task
{
    public class TaskController
    {
        //SuccessFailureScreen successFailureScreen;

        //public TaskController()
        //{
        //    successFailureScreen = new SuccessFailureScreen();
        //}

        protected string LimitInputLength(int length, Tuple<int, int> coordinate, bool isPassword)
        {
            string str = null;
            char[] inputString = new char[length];
            bool isBreak = false;
            int x = coordinate.Item1;
            int y = coordinate.Item2;
            Console.CursorVisible = true;
            Console.SetCursorPosition(x, y);

            for (int i = 0; i < length + 2; i++)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                switch (keyInfo.Key)
                {
                    case ConsoleKey.Enter:
                        isBreak = true;
                        break;
                    case ConsoleKey.Backspace:
                        Console.SetCursorPosition(15, y - i - 1);
                        Console.Write(" ");
                        Console.SetCursorPosition(15, y - i);
                        break;
                    case ConsoleKey.Escape:
                        return null;
                }

                if (isBreak)
                    break;
                else if (isPassword)
                {
                    Console.SetCursorPosition(x, 25);
                    Console.Write("*");
                    x++;
                }
                inputString[i] = keyInfo.KeyChar;
            }

            if (!isBreak)
            {
                SuccessFailureScreen successFailureScreen = new SuccessFailureScreen();
                successFailureScreen.PrintSuccessFailure(new Tuple<int, int>(x, y), false);
                return LimitInputLength(length, coordinate, isPassword);
            }

            return str;
        }

        protected string LimitInputRegex()
        {
            string str = null;

            return str;
        }

        protected void DeleteControl()
        {

        }
    }
}
