using System;
using System.Linq;
using System.Text;
using Library.Constants;

namespace Library.Controller
{
    public class InputManager
    {
        public string LimitInputLength(int digitType, bool isPassword)
        {
            Console.CursorVisible = true;
            Tuple<int, int> coordinate = GetCoordinate(digitType);
            int x = coordinate.Item1;
            int y = coordinate.Item2;
            int stringLength = GetStringLength(digitType);
            bool isError = false;

            char[] inputString = new char[stringLength];
            int[] bytes = new int[stringLength];
            int index = 0;

            EraseField(x, y, stringLength);
            while (!isError)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true); // 입력 받기

                if (keyInfo.Key == ConsoleKey.Enter)
                    break;
                else if (keyInfo.Key == ConsoleKey.Backspace)
                {
                    if (index == 0)
                        continue;
                    ProcessBackspace(bytes, x, y, index);
                    inputString[--index] = '\0';
                }
                else if (keyInfo.Key == ConsoleKey.Escape)
                {
                    Console.SetCursorPosition(x, y);
                    for (int i = 0; i < stringLength * 2; i++)  // 입력란 지우기
                        Console.Write(" ");
                    return null;    // esc 입력 시 null 반환
                }
                else if (char.IsLetterOrDigit(keyInfo.KeyChar) || keyInfo.KeyChar == '-' || keyInfo.KeyChar == ' ')
                {
                    if (index == stringLength)  // 입력 길이 초과했을 때 더이상 입력받지 않기
                        continue;

                    inputString[index] = keyInfo.KeyChar;   // 입력값 저장
                    bytes[index++] = Encoding.Default.GetByteCount(keyInfo.KeyChar.ToString());
                    Console.Write(keyInfo.KeyChar);

                    if (isPassword) // * 비밀번호 입력일 때 표시 처리
                        ProcessPassword(bytes, x, y, index);
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

        private void ProcessBackspace(int[] bytes, int x, int y, int index)
        {
            int totalByte = 0;
            for (int i = 0; i < index; i++)
                totalByte += bytes[i];

            Console.SetCursorPosition(x + totalByte - bytes[index - 1], y); // 현재 길이에서 마지막 byte 빼주기
            if (bytes[index - 1] == 2)
                Console.Write("  ");
            else
                Console.Write(" ");
            Console.SetCursorPosition(x + totalByte - bytes[index - 1], y);
        }

        private void ProcessPassword(int[] bytes, int x, int y, int index)
        {
            if (index == 0)
                return;

            int totalByte = 0;
            for (int i = 0; i < index; i++)
                totalByte += bytes[i];

            Console.SetCursorPosition(x + totalByte - bytes[index - 1], y);
            Console.Write("*");
        }

        private void EraseField(int x, int y, int stringLength)
        {
            Console.SetCursorPosition(x, y);
            for (int i = 0; i < stringLength * 2; i++)  // 입력란 지우기
                Console.Write(" ");
            Console.SetCursorPosition(x, y);
        }

        private int GetStringLength(int digitType)
        {
            int length = 0;
            switch (digitType)
            {
                case (int)Enums.InputType.LogInId:
                case (int)Enums.InputType.UserId:
                case (int)Enums.InputType.SignUpId:
                    length = 9;
                    break;
                case (int)Enums.InputType.LogInPassword:
                case (int)Enums.InputType.ModifyPassword:
                case (int)Enums.InputType.SignUpPassword:
                    length = 5;
                    break;
                case (int)Enums.InputType.ModifyAge:
                case (int)Enums.InputType.SignUpAge:
                case (int)Enums.InputType.Count:
                case (int)Enums.InputType.LogId:
                    length = 4;
                    break;
                case (int)Enums.InputType.ModifyPhoneNumber:
                case (int)Enums.InputType.SignUpPhoneNumber:
                case (int)Enums.InputType.Title:
                case (int)Enums.InputType.SearchedTitle:
                    length = 15;
                    break;
                case (int)Enums.InputType.SignUpAddress:
                case (int)Enums.InputType.ModifyAddress:
                    length = 25;
                    break;
                case (int)Enums.InputType.BookId:
                    length = 3;
                    break;
                case (int)Enums.InputType.Writer:
                case (int)Enums.InputType.Publisher:
                case (int)Enums.InputType.SearchedWriter:
                case (int)Enums.InputType.SearchedPublisher:
                    length = 10;
                    break;
                case (int)Enums.InputType.Price:
                    length = 7;
                    break;
                case (int)Enums.InputType.ReleaseDate:
                    length = 11;
                    break;
                case (int)Enums.InputType.ISBN:
                    length = 14;
                    break;
                case (int)Enums.InputType.NaverSearch:
                case (int)Enums.InputType.RequestBook:
                case (int)Enums.InputType.Info:
                    length = 45;
                    break;
            }
            return length;
        }

        private Tuple<int, int> GetCoordinate(int digitType)
        {
            int x = 0, y = 0;
            switch (digitType)
            {
                case (int)Enums.InputType.LogInId:
                    x = 33;
                    y = 20;
                    break;
                case (int)Enums.InputType.LogInPassword:
                    x = 33;
                    y = 21;
                    break;
                case (int)Enums.InputType.SignUpId:
                case (int)Enums.InputType.ModifyPassword:
                    x = 33;
                    y = 13;
                    break;
                case (int)Enums.InputType.SignUpPassword:
                case (int)Enums.InputType.ModifyAge:
                    x = 33;
                    y = 14;
                    break;
                case (int)Enums.InputType.SignUpAge:
                case (int)Enums.InputType.ModifyPhoneNumber:
                    x = 33;
                    y = 15;
                    break;
                case (int)Enums.InputType.SignUpPhoneNumber:
                case (int)Enums.InputType.ModifyAddress:
                    x = 33;
                    y = 16;
                    break;
                case (int)Enums.InputType.SignUpAddress:
                    x = 33;
                    y = 17;
                    break;
                case (int)Enums.InputType.SearchedTitle:
                    x = 14;
                    y = 4;
                    break;
                case (int)Enums.InputType.SearchedWriter:
                    x = 14;
                    y = 5;
                    break;
                case (int)Enums.InputType.SearchedPublisher:
                    x = 14;
                    y = 6;
                    break;
                case (int)Enums.InputType.BookId:
                case (int)Enums.InputType.UserId:
                case (int)Enums.InputType.LogId:
                    x = 38;
                    y = 13;
                    break;
                case (int)Enums.InputType.Title:
                    x = 10;
                    y = 11;
                    break;
                case (int)Enums.InputType.Writer:
                    x = 10;
                    y = 12;
                    break;
                case (int)Enums.InputType.Publisher:
                    x = 10;
                    y = 13;
                    break;
                case (int)Enums.InputType.Count:
                    x = 10;
                    y = 14;
                    break;
                case (int)Enums.InputType.Price:
                    x = 10;
                    y = 15;
                    break;
                case (int)Enums.InputType.ReleaseDate:
                    x = 10;
                    y = 16;
                    break;
                case (int)Enums.InputType.ISBN:
                    x = 10;
                    y = 17;
                    break;
                case (int)Enums.InputType.Info:
                    x = 10;
                    y = 18;
                    break;
                case (int)Enums.InputType.NaverSearch:
                    x = 12;
                    y = 0;
                    break;
                case (int)Enums.InputType.RequestBook:
                    x = 18;
                    y = 15;
                    break;
            }
            return new Tuple<int, int>(x, y);
        }
    }
}
