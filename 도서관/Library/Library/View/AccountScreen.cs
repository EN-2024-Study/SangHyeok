using Library.Utility;
using System;

namespace Library.View
{
    public class AccountScreen
    {
        public void PrintLogInWindow()
        {
            ClearConsoleBottomPart();
            Console.SetCursorPosition(17, 20);
            Console.Write("로그인"); 
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(5, 21);
            Console.Write("ESC: 뒤로가기");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("  ENTER: 입력하기");
            Console.ResetColor();
            Console.SetCursorPosition(10, 23);
            Console.Write("ID : ");
            Console.SetCursorPosition(4, 25);
            Console.Write("PASSWORD : ");
        }

        public void PrintSignUpWindow(int menuValue)
        {
            ClearConsoleBottomPart();

            Console.SetCursorPosition(5, 21);
            if (menuValue == (int)Constants.User.Id)
                Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("User ID          (1 ~ 15 글자)   :");
            Console.ResetColor();

            Console.SetCursorPosition(5, 22);
            if (menuValue == (int)Constants.User.Password)
                Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("User PW          (1 ~ 4 글자)    :");
            Console.ResetColor();

            Console.SetCursorPosition(5, 23);
            if (menuValue == (int)Constants.User.Name)
                Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("User Name        (1 ~ 4 글자)    :");
            Console.ResetColor();

            Console.SetCursorPosition(5, 24);
            if (menuValue == (int)Constants.User.Age)
                Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("User Age         (1 ~ 200세)     :");
            Console.ResetColor();

            Console.SetCursorPosition(5, 25);
            if (menuValue == (int)Constants.User.PhoneNumber)
                Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("User PhoneNumber (010-xxxx-xxxx) :");
            Console.ResetColor();

            Console.SetCursorPosition(5, 26);
            if (menuValue == (int)Constants.User.Address)
                Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("User Address     (1 ~ 20 글자)   :");
            Console.ResetColor();

            Console.SetCursorPosition(5, 27);
            if (menuValue == (int)Constants.User.Check)
                Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("           가입완료              :");
            Console.ResetColor();
        }

        private void ClearConsoleBottomPart()
        {
            for(int i = 20; i < 100; i++)
            {
                for (int j = 20; j < 30; j++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(" ");
                }
            }
            Console.SetCursorPosition(20, 20);
        }
    }
}
