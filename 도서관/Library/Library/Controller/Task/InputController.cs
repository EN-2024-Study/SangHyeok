using System;
using System.Reflection;
using Library.Model;
using Library.Utility;

namespace Library.Controller.Task
{
    public class InputController
    {
        public string LimitInputLength(Tuple<int, int> coordinate, int stringLength, bool isPassword)
        {
            Console.CursorVisible = true;
            bool isError = false;
            int index = 0;
            int x = coordinate.Item1;
            int y = coordinate.Item2;
            string resultString = null;
            char[] inputString = new char[stringLength];

            while (!isError)
            {
                if (index == stringLength)
                {
                    isError = true;
                    break;
                }

                Console.SetCursorPosition(x + index, y);
                ConsoleKeyInfo keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.Enter)
                    break;
                else if (keyInfo.Key == ConsoleKey.Backspace)
                {
                    if (index == 0)
                        continue;

                    Erase(x + index - 1, y);
                    inputString[--index] = '\0';
                }
                else if (keyInfo.Key == ConsoleKey.Escape)
                    break;
                else
                    inputString[index++] = keyInfo.KeyChar;

                if (isPassword) // * 비밀번호 입력일 때 표시 처리
                {
                    Console.SetCursorPosition(x + index - 1, y);
                    if (index == 0)
                        continue;
                    Console.Write("*");
                }
            }

            if (isError)
            {
                ExplainingScreen.PrintInputFailure(new Tuple<int, int>(x + index + 2, y));
                for (int i = x; i < x + index; i++)
                    Erase(i, y);
                return LimitInputLength(coordinate, stringLength, isPassword);
            }

            for (int i = 0; i < stringLength; i++)
                resultString += inputString[i];

            Console.CursorVisible = false;
            return CheckRegularExpression(resultString);
        }

        private string CheckRegularExpression(string str)   // 정규 표현식 구현
        {

            return str;
        }

        private void Erase(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
            Console.SetCursorPosition(x, y);
        }

    }
}
