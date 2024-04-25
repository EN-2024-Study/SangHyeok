using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Utility
{
    public class InputManager
    {
        public string LimitInputLength(int digitType, int stringLength, bool isPassword)
        {
            Console.CursorVisible = true;
            Tuple<int, int> coordinate = GetCoordinate(digitType);
            int x = coordinate.Item1;
            int y = coordinate.Item2;
            bool isError = false;

            char[] inputString = new char[stringLength];
            int[] bytes = new int[stringLength];
            int index = 0;

            Console.SetCursorPosition(x, y);
            for (int i = 0; i < stringLength * 2; i++)  // 입력란 지우기
                Console.Write(" ");
            Console.SetCursorPosition(x, y);

            while (!isError)
            {
                if (index == stringLength)  // 입력 길이 초과했을 때
                {
                    inputString = new char[stringLength];   // 초기화
                    bytes = new int[stringLength];
                    index = 0;

                    Console.SetCursorPosition(x, y);
                    for (int i = 0; i < stringLength * 2; i++)  // 입력란 지우기
                        Console.Write(" ");
                    Console.SetCursorPosition(x, y);
                    continue;
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey(true); // 입력 받기

                if (keyInfo.Key == ConsoleKey.Enter)
                    break;
                else if (keyInfo.Key == ConsoleKey.Backspace)
                {
                    if (index == 0)
                        continue;

                    int totalByte = 0;
                    for (int i = 0; i < index; i++)
                        totalByte += bytes[i];

                    Console.SetCursorPosition(x + totalByte - bytes[index - 1], y); // 현재 길이에서 마지막 byte 빼주기
                    if (bytes[index - 1] == 2)
                        Console.Write("  ");
                    else
                        Console.Write(" ");
                    Console.SetCursorPosition(x + totalByte - bytes[index - 1], y);

                    inputString[--index] = '\0';
                }
                else if (keyInfo.Key == ConsoleKey.Escape)
                {
                    Console.SetCursorPosition(x, y);
                    for (int i = 0; i < stringLength * 2; i++)  // 입력란 지우기
                        Console.Write(" ");
                    return null;    // esc 입력 시 null 반환
                }
                else
                {
                    inputString[index] = keyInfo.KeyChar;   // 입력값 저장
                    bytes[index++] = Encoding.Default.GetByteCount(keyInfo.KeyChar.ToString());
                    Console.Write(keyInfo.KeyChar);
                }

                if (isPassword) // * 비밀번호 입력일 때 표시 처리
                {
                    if (index == 0)
                        continue;

                    int totalByte = 0;
                    for (int i = 0; i < index; i++)
                        totalByte += bytes[i];

                    Console.SetCursorPosition(x + totalByte - bytes[index - 1], y);
                    Console.Write("*");
                }
            }

            Console.CursorVisible = false;
            return SetResultString(inputString);
        }

        private string SetResultString(char[] inputString)
        {
            string resultString = null;
            for (int i = 0; i < inputString.Length; i++)  // 입력값 string으로 저장
            {
                if (inputString[i] == '\0')
                    break;
                resultString += inputString[i];
            }

            return resultString;
        }

        private Tuple<int, int> GetCoordinate(int digitType)
        {
            int x = 0, y = 0;
            switch (digitType)
            {
                case (int)Constants.InputType.LogInId:
                    x = 33;
                    y = 20;
                    break;
                case (int)Constants.InputType.LogInPassword:
                    x = 33;
                    y = 21;
                    break;
                case (int)Constants.InputType.SignUpId:
                    x = 23;
                    y = 13;
                    break;
                case (int)Constants.InputType.SignUpPassword:
                case (int)Constants.InputType.ModifyPassword:
                    x = 23;
                    y = 14;
                    break;
                case (int)Constants.InputType.SignUpAge:
                case (int)Constants.InputType.ModifyAge:
                    x = 23;
                    y = 15;
                    break;
                case (int)Constants.InputType.SignUpPhoneNumber:
                case (int)Constants.InputType.ModifyPhoneNumber:
                    x = 23;
                    y = 16;
                    break;
                case (int)Constants.InputType.SignUpAddress:
                case (int)Constants.InputType.ModifyAddress:
                    x = 23;
                    y = 17;
                    break;
                case (int)Constants.InputType.SearchedTitle:
                    x = 14;
                    y = 0;
                    break;
                case (int)Constants.InputType.SearchedWriter:
                    x = 14;
                    y = 1;
                    break;
                case (int)Constants.InputType.SearchedPublisher:
                    x = 14;
                    y = 2;
                    break;
                case (int)Constants.InputType.BookId:
                case (int)Constants.InputType.UserId:
                    x = 18;
                    y = 0;
                    break;
                case (int)Constants.InputType.Title:
                    x = 10;
                    y = 0;
                    break;
                case (int)Constants.InputType.Writer:
                    x = 10;
                    y = 1;
                    break;
                case (int)Constants.InputType.Publisher:
                    x = 10;
                    y = 2;
                    break;
                case (int)Constants.InputType.Count:
                    x = 10;
                    y = 3;
                    break;
                case (int)Constants.InputType.Price:
                    x = 10;
                    y = 4;
                    break;
                case (int)Constants.InputType.ReleaseDate:
                    x = 10;
                    y = 5;
                    break;
                case (int)Constants.InputType.ISBN:
                    x = 10;
                    y = 6;
                    break;
                case (int)Constants.InputType.Info:
                    x = 10;
                    y = 7;
                    break;
            }
            return new Tuple<int, int>(x, y);
        }
    }
}
