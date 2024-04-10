using System;
using System.Runtime.InteropServices;
using Library.Utility;

namespace Library.View
{
    public class MenuScreen
    {
        private Tuple<int, int> coordinate;

        public MenuScreen()
        {
            coordinate = new Tuple<int, int>(20, 20);
        }

        public void PrintThreeMenu(int modeValue, int menuValue)
        {
            string[] str = new string[3];
            switch (modeValue)
            {
                case (int)Constants.Type.UserManager:
                    str[0] = "유저 모드";
                    str[1] = "관리자 모드";
                    str[2] = "종료하기";
                    break;
                case (int)Constants.Type.LogInSignUp:
                    str[0] = "로그인";
                    str[1] = "회원가입";
                    str[2] = "뒤로가기";
                    break;
                case (int)Constants.Type.YesNo:
                    str[0] = "정말이십니까?";
                    str[1] = "예.";
                    str[2] = "아니요.";
                    break;
            }

            Console.Clear();
            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(coordinate.Item1, coordinate.Item2 + i * 2);
                if (menuValue == i)
                    Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(str[i]);
                Console.ResetColor();
            }

            Console.SetCursorPosition(coordinate.Item1 + 30, coordinate.Item2);
            Console.Write("방향키를 눌러 모드를");
            Console.SetCursorPosition(coordinate.Item1 + 30, coordinate.Item2 + 2);
            Console.Write("선택해 주세요.");
        }

        public void PrintLibraryMenu(int currentMenuValue, int modeValue)
        {
            Console.Clear();
            Tuple<int, int> currentCoordinate = new Tuple<int, int>(coordinate.Item1 + 50, coordinate.Item2 - 5);
            string[] str = new string[6];
            str[0] = "도서 조회";
            switch (modeValue)
            {
                case (int)Constants.LibraryMode.User:
                    str[1] = "도서 대여";
                    str[2] = "도서 대여 내역";
                    str[3] = "도서 반납";
                    str[4] = "도서 반납 내역";
                    str[5] = "정보 수정";
                    break;
                case (int)Constants.LibraryMode.Manager:
                    str[1] = "도서 추가";
                    str[2] = "도서 삭제";
                    str[3] = "도서 수정";
                    str[4] = "회원 관리";
                    str[5] = "대여 내역";
                    break;
            }

            for(int i = 0; i < 6; i++)
            {
                Console.SetCursorPosition(currentCoordinate.Item1, currentCoordinate.Item2 + i);
                if (currentMenuValue == i)
                    Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(str[i]);
                Console.ResetColor();
            }
        }
    }
}
