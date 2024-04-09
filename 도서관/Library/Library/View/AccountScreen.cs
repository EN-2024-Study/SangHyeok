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

        public void PrintSignUpWindow()
        {
            ClearConsoleBottomPart();
            Console.Write("test");
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

        public void PrintException(int errorNumber)
        {
            Console.SetCursorPosition(4, 27);
            Console.ForegroundColor = ConsoleColor.Red;
            switch (errorNumber)
            {
                case (int)Constants.Error.Length:
                    Console.Write("입력 길이가 맞지 않습니다.");
                    break;
                case 1:

                    break;
            }

            Console.SetCursorPosition(4, 28);
            Console.Write("다시 입력하여 주세요.");
            Console.SetCursorPosition(15, 23);
            Console.Write("                ");
            Console.SetCursorPosition(15, 25);
            Console.Write("                ");
            Console.ResetColor();
        }
    }
}
