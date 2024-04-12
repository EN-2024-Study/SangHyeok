using Library.Utility;
using System;

namespace Library.View
{
    public class AccountScreen
    {
        public void PrintScreen(int menuValue, bool isSelect, bool isLogIn, Tuple<int, int> coordinate)
        {
            string[] str = new string[7];
            int stringLength = 0;

            if (isLogIn)
            {
                str[0] = "ID : ";
                str[1] = "PASSWORD : ";
                stringLength = 2;
            }
            else
            {
                str[0] = "ID           :";
                str[1] = "비밀번호     :";
                str[2] = "비밀번호 확인:";
                str[3] = "이름         :";
                str[4] = "나이         :";
                str[5] = "전화번호     :";
                str[6] = "주소         :";
                stringLength = 7;
            }


            ExplainingScreen.ExplainSelectKey();
            ExplainingScreen.ExplainDirectionKey();
            ExplainingScreen.ExplainInputKey();
            Console.SetCursorPosition(coordinate.Item1, coordinate.Item2);
            if (isLogIn)
                Console.Write("로그인");
            for (int i = 0; i < stringLength; i++)
            {
                Console.SetCursorPosition(coordinate.Item1, coordinate.Item2 + i + 1);
                if (menuValue == i)
                {
                    if (isSelect)
                        Console.ForegroundColor = ConsoleColor.Blue;
                    else
                        Console.ForegroundColor = ConsoleColor.Green;
                }
                Console.Write(str[i]);
                Console.ResetColor();
            }
        }
    }
}
