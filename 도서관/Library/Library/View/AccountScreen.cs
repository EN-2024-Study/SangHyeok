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
            string[] str = new string[2];
            //if (Id == null)
            //    str[0] = "ID : ";
            //else
            //    str[0] = "ID : " + Id;
            str[0] = "ID : ";
            str[1] = "PASSWORD : ";

            ExplainingScreen.ExplainSelectKey();
            ExplainingScreen.ExplainDirectionKey();
            ExplainingScreen.ExplainInputKey();
            Console.SetCursorPosition(coordinate.Item1, coordinate.Item2);
            Console.Write("로그인");
            for (int i = 0; i < 2; i++)
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

        public void PrintSignUpScreen(int menuValue)
        {

        }

        public void Erase(Tuple<int, int> coordinate, int length)
        {
            Console.SetCursorPosition(coordinate.Item1, coordinate.Item2);
            for (int i = 0; i < length; i++)
                Console.Write(" ");
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
