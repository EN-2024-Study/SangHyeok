using System;
using Library.Utility;

namespace Library.View
{
    public class MenuScreen
    {
        private int x = 20, y = 20;

        public void PrintModeMenu(int menu)
        {
            Console.SetCursorPosition(x, y);
            if (menu == (int)Constants.ModeMenu.UserMode)
                Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("유저 모드");
            Console.ResetColor();

            Console.SetCursorPosition(x, y + 2);
            if (menu == (int)Constants.ModeMenu.ManagerMode)
                Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("관리자 모드");
            Console.ResetColor();

            Console.SetCursorPosition(x, y + 4);
            if (menu == (int)Constants.ModeMenu.Quit)
                Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("종료하기");
            Console.ResetColor();

            Console.SetCursorPosition(x + 30, y);
            Console.Write("방향키를 눌러 모드를");
            Console.SetCursorPosition(x + 30, y + 2);
            Console.Write("선택해 주세요.");
        }

        public void PrintLogInMenu(int menu)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("            ");
            Console.SetCursorPosition(x, y + 2);
            Console.Write("            ");
            Console.SetCursorPosition(x, y + 4);
            Console.Write("            ");
            switch (menu)
            {
                case (int)Constants.LogInMenu.LogIn:
                    Console.SetCursorPosition(x, y);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("로그인");
                    Console.ResetColor();
                    Console.SetCursorPosition(x, y + 2);
                    Console.Write("회원가입");
                    Console.SetCursorPosition(x, y + 4);
                    Console.Write("뒤로가기");
                    break;
                case (int)Constants.LogInMenu.SignUp:
                    Console.SetCursorPosition(x, y);
                    Console.Write("로그인");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(x, y + 2);
                    Console.Write("회원가입");
                    Console.ResetColor();
                    Console.SetCursorPosition(x, y + 4);
                    Console.Write("뒤로가기");
                    break;
                case (int)Constants.LogInMenu.GoBack:
                    Console.SetCursorPosition(x, y);
                    Console.Write("로그인");
                    Console.SetCursorPosition(x, y + 2);
                    Console.Write("회원가입");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(x, y + 4);
                    Console.Write("뒤로가기");
                    Console.ResetColor();
                    break;
            }
        }


        public void PrintYesNoWindow(int menu)
        {
            Console.SetCursorPosition(0, 0);
            Console.SetWindowSize(50, 15);
            Console.Write("정말이십니까?");

            switch(menu)
            {
                case (int)Constants.YesNo.Yes:
                    Console.SetCursorPosition(0, 2);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("예.");
                    Console.ResetColor();
                    Console.SetCursorPosition(0, 4);
                    Console.Write("아니요.");
                    break;
                case (int)Constants.YesNo.No:
                    Console.SetCursorPosition(0, 2);
                    Console.Write("예.");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(0, 4);
                    Console.Write("아니요.");
                    Console.ResetColor();
                    break;
            }
        }

    }
}
