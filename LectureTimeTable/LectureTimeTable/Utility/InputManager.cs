using LectureTimeTable.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable.Utility
{
    public class InputManager
    {
        private MenuScreen menuScreen;

        public InputManager()
        {
            this.menuScreen = new MenuScreen();
        }

        public string LimitInputLength(int digitValue, int stringLength, bool isPassword)
        {
            Console.CursorVisible = true;
            Tuple<int, int> coordinate = GetCoordinate(digitValue);
            Tuple<int, int> failCoordinate = null;
            int x = coordinate.Item1;
            int y = coordinate.Item2;
            bool isInput = false;

            while (!isInput)
            {
                char[] inputString = new char[stringLength];
                int index = 0;
                bool isError = false;

                for (int i = x; i < x + stringLength; i++)  // 입력란 지우기
                    menuScreen.EraseDigit(i, y);

                while (!isError)
                {
                    if (index == stringLength)  // 입력 길이 초과
                    {
                        failCoordinate = new Tuple<int, int>(x + index + 2, y);
                        menuScreen.DrawInputFailure(failCoordinate);
                        isError = true;
                        continue;
                    }

                    Console.SetCursorPosition(x + index, y);
                    ConsoleKeyInfo keyInfo = Console.ReadKey();

                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        menuScreen.EraseFail(failCoordinate);
                        break;
                    }
                    else if (keyInfo.Key == ConsoleKey.Backspace)
                    {
                        if (index == 0)
                            continue;

                        menuScreen.EraseDigit(x + index - 1, y);
                        inputString[--index] = '\0';
                    }
                    else if (keyInfo.Key == ConsoleKey.Escape)
                    {
                        for (int i = x; i < x + stringLength; i++)  // 입력란 지우기
                            menuScreen.EraseDigit(i, y);
                        menuScreen.EraseFail(failCoordinate);
                        return null;
                    }
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

                if (!isError)
                {
                    Console.CursorVisible = false;
                    return SetResultString(inputString);
                }
            }

            Console.CursorVisible = false;
            return null;
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
            int x = 0, y = 0;
            switch (digitValue)
            {
                case (int)Constants.DigitType.Id:
                    x = 40;
                    y = 30;
                    break;
                case (int)Constants.DigitType.Password:
                    x = 40;
                    y = 31;
                    break;
                case (int)Constants.DigitType.SubjectTitle:
                    x = 17;
                    y = 32;
                    break;
                case (int)Constants.DigitType.ProfessorName:
                    x = 17;
                    y = 33;
                    break;
            }
            return new Tuple<int, int>(x, y);
        }
    }
}
