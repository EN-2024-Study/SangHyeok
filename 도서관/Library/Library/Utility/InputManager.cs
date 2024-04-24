using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Utility
{
    public class InputManager
    {
        public string LimitInputLength(int digitValue, int stringLength, bool isPassword)
        {
            Console.CursorVisible = true;
            Tuple<int, int> coordinate = GetCoordinate(digitValue);
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

        private Tuple<int, int> GetCoordinate(int digitValue)
        {
            int x = 23, y = 0;
            switch (digitValue)
            {
                case (int)Constants.InputType.Id:
                case (int)Constants.InputType.ModifyPassword:
                    y = 0;
                    break;
                case (int)Constants.InputType.Password:
                case (int)Constants.InputType.ModifyAge:
                    y = 1;
                    break;
                case (int)Constants.InputType.Age:
                case (int)Constants.InputType.ModifyPhoneNumber:
                    y = 2;
                    break;
                case (int)Constants.InputType.PhoneNumber:
                case (int)Constants.InputType.ModifyAddress:
                    y = 3;
                    break;
                case (int)Constants.InputType.Address:
                    y = 4;
                    break;
                case (int)Constants.InputType.Title:
                    x = 14;
                    y = 0;
                    break;
                case (int)Constants.InputType.Writer:
                    x = 14;
                    y = 1;
                    break;
                case (int)Constants.InputType.Publisher:
                    x = 14;
                    y = 2;
                    break;
                case (int)Constants.InputType.BookId:
                    x = 16;
                    y = 0;
                    break;
                case (int)Constants.InputType.AddedTitle:
                    x = 10;
                    y = 0;
                    break;
                case (int)Constants.InputType.AddedWriter:
                    x = 10;
                    y = 1;
                    break;
                case (int)Constants.InputType.AddedPublisher:
                    x = 10;
                    y = 2;
                    break;
                case (int)Constants.InputType.AddedCount:
                    x = 10;
                    y = 3;
                    break;
                case (int)Constants.InputType.AddedPrice:
                    x = 10;
                    y = 4;
                    break;
                case (int)Constants.InputType.AddedReleaseDate:
                    x = 10;
                    y = 5;
                    break;
                case (int)Constants.InputType.AddedISBN:
                    x = 10;
                    y = 6;
                    break;
                case (int)Constants.InputType.AddedInfo:
                    x = 10;
                    y = 7;
                    break;
            }
            return new Tuple<int, int>(x, y);
        }
    }
}
