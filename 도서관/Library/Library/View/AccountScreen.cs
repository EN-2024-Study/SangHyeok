using Library.Utility;
using System;

namespace Library.View
{
    public class AccountScreen
    {
        public void PrintLogInScreen(int menuValue, bool isSelect, Tuple<int, int> coordinateValue)
        {
            Console.Clear();
            Tuple<int, int> coordinate = coordinateValue;
            string[] str = new string[3];
            str[0] = "로그인";
            str[1] = "ID : ";
            str[2] = "PASSWORD : ";

            ExplainingScreen.ExplainSelectKey();
            ExplainingScreen.ExplainDirectionKey();
            ExplainingScreen.ExplainInputKey();
            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(coordinate.Item1, coordinate.Item2 + i);
                if (menuValue == i)
                {
                    if (isSelect)
                        Console.ForegroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                Console.Write(str[i]);
                Console.ResetColor();
            }
        }

        public void PrintSignUpScreen(int menuValue)
        {

        }
        //{

        //    Console.SetCursorPosition(5, 21);
        //    if (menuValue == (int)Constants.User.Id)
        //        Console.ForegroundColor = ConsoleColor.Green;
        //    Console.Write("User ID          (1 ~ 15 글자)   :");
        //    Console.ResetColor();

        //    Console.SetCursorPosition(5, 22);
        //    if (menuValue == (int)Constants.User.Password)
        //        Console.ForegroundColor = ConsoleColor.Green;
        //    Console.Write("User PW          (1 ~ 4 글자)    :");
        //    Console.ResetColor();

        //    Console.SetCursorPosition(5, 23);
        //    if (menuValue == (int)Constants.User.Name)
        //        Console.ForegroundColor = ConsoleColor.Green;
        //    Console.Write("User Name        (1 ~ 4 글자)    :");
        //    Console.ResetColor();

        //    Console.SetCursorPosition(5, 24);
        //    if (menuValue == (int)Constants.User.Age)
        //        Console.ForegroundColor = ConsoleColor.Green;
        //    Console.Write("User Age         (1 ~ 200세)     :");
        //    Console.ResetColor();

        //    Console.SetCursorPosition(5, 25);
        //    if (menuValue == (int)Constants.User.PhoneNumber)
        //        Console.ForegroundColor = ConsoleColor.Green;
        //    Console.Write("User PhoneNumber (010-xxxx-xxxx) :");
        //    Console.ResetColor();

        //    Console.SetCursorPosition(5, 26);
        //    if (menuValue == (int)Constants.User.Address)
        //        Console.ForegroundColor = ConsoleColor.Green;
        //    Console.Write("User Address     (1 ~ 20 글자)   :");
        //    Console.ResetColor();

        //    Console.SetCursorPosition(5, 27);
        //    if (menuValue == (int)Constants.User.Check)
        //        Console.ForegroundColor = ConsoleColor.Green;
        //    Console.Write("           가입완료              :");
        //    Console.ResetColor();
        //}
    }
}
