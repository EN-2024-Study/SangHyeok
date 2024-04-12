using Library.Model;
using Library.Utility;
using Library.View;
using System;


namespace Library.Controller.Task
{
    public class TaskController
    {
        string test_inputString;
        char[] test_inputChar;

        public TaskController()
        {
            test_inputString = null;
            test_inputChar = null;
        }

        protected string LimitInputLength(int length, Tuple<int, int> coordinate, bool isPassword)
        {
            string str = null;
            char[] inputString = new char[length];
            bool isBreak = false;
            int x = coordinate.Item1;
            int y = coordinate.Item2;
            int index = 0;

            Console.CursorVisible = true;
            ResetField(x, y, length);

            while (!isBreak)
            {
                if (index == length)
                    break;
                Console.SetCursorPosition(x + index, y);
                ConsoleKeyInfo keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    isBreak = true;
                    break;
                }
                else if (keyInfo.Key == ConsoleKey.Backspace)
                {
                    if (index == 0)
                        continue;

                    Erase(x + index - 1, y);
                    inputString[--index] = '\0';
                }
                else if (keyInfo.Key == ConsoleKey.Escape)
                    return null;
                else
                    inputString[index++] = keyInfo.KeyChar;

                if (isPassword)
                {
                    Console.SetCursorPosition(x + index - 1, y);
                    if (index == 0)
                        continue;
                    Console.Write("*");
                }
            }

            if (!isBreak)
            {
                ExplainingScreen.PrintInputFailure(new Tuple<int, int>(x + index + 2, y));
                return LimitInputLength(length, coordinate, isPassword);
            }

            for (int i = 0; i < length; i++)
                str += inputString[i];

            return str;
        }

        protected string LimitInputRegex(string formerString)
        {
            if (formerString == null)
                return null;

            string currentString = formerString;
            // 정규식 구현 해야 함
            return currentString;
        }

        //protected void DeleteControl()
        //{

        //}

        private void Erase(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
            Console.SetCursorPosition(x, y);
        }

        private void ResetField(int x, int y, int length)
        {
            Console.SetCursorPosition(x, y);
            for (int i = 0; i < length; i++)
                Console.Write(" ");
            Console.SetCursorPosition(x, y);
        }
    }
}
