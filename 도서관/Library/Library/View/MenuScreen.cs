using System;
using System.Runtime.InteropServices;
using Library.Utility;

namespace Library.View
{
    public class MenuScreen
    {
        public void PrintMenu(int CurrentMenuValue, int modeValue, Tuple<int, int> coordinate)
        {
            Console.Clear();
            ExplainingScreen.ExplainDirectionKey();
            ExplainingScreen.ExplainSelectKey();

            string[] str = new string[6];
            int stringLength = 0;
            switch (modeValue)
            {
                case (int)Constants.Type.UserManager:
                    str[0] = "유저 모드";
                    str[1] = "관리자 모드";
                    stringLength = 2;
                    ExplainingScreen.PrintQuit();
                    break;
                case (int)Constants.Type.LogInSignUp:
                    str[0] = "로그인";
                    str[1] = "회원가입";
                    stringLength = 2;
                    break;
                case (int)Constants.Type.YesNo:
                    str[0] = "정말이십니까?";
                    str[1] = "예.";
                    str[2] = "아니요.";
                    stringLength = 3;
                    break;
                case (int)Constants.Type.UserInfo:
                    str[0] = "정보 수정";
                    str[1] = "정보 삭제";
                    stringLength = 2;
                    break;
                case (int)Constants.Type.ManagerInfo:
                    str[0] = "유저 정보 수정";
                    str[1] = "유저 삭제";
                    stringLength = 2;
                    break;
                case (int)Constants.Type.User:
                    str[0] = "도서 조회";
                    str[1] = "도서 대여";
                    str[2] = "도서 대여 내역";
                    str[3] = "도서 반납";
                    str[4] = "도서 반납 내역";
                    str[5] = "정보 수정";
                    stringLength = 6;
                    ExplainingScreen.PrintQuit();
                    break;
                case (int)Constants.Type.Manager:
                    str[0] = "도서 조회";
                    str[1] = "도서 추가";
                    str[2] = "도서 삭제";
                    str[3] = "도서 수정";
                    str[4] = "회원 관리";
                    str[5] = "대여 내역";
                    stringLength = 6;
                    ExplainingScreen.PrintQuit();
                    break;
            }

            for (int i = 0; i < stringLength; i++)
            {
                Console.SetCursorPosition(coordinate.Item1, coordinate.Item2 + i * 2);
                if (CurrentMenuValue == i)
                    Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(str[i]);
                Console.ResetColor();
            }
        }

        //public void PrintLibraryMenu(int modeValue, int currentMenuValue, Tuple<int, int> coordinate)
        //{
        //    Console.Clear();
        //    ExplainingScreen.ExplainDirectionKey();
        //    ExplainingScreen.PrintQuit();
        //    string[] str = new string[6];
        //    str[0] = "도서 조회";

        //    switch (modeValue)
        //    {
        //        case (int)Constants.LibraryMode.User:
        //            str[1] = "도서 대여";
        //            str[2] = "도서 대여 내역";
        //            str[3] = "도서 반납";
        //            str[4] = "도서 반납 내역";
        //            str[5] = "정보 수정";
        //            break;
        //        case (int)Constants.LibraryMode.Manager:
        //            str[1] = "도서 추가";
        //            str[2] = "도서 삭제";
        //            str[3] = "도서 수정";
        //            str[4] = "회원 관리";
        //            str[5] = "대여 내역";
        //            break;
        //    }

        //    for(int i = 0; i < 6; i++)
        //    {
        //        Console.SetCursorPosition(coordinate.Item1, coordinate.Item2 + i);
        //        if (currentMenuValue == i)
        //            Console.ForegroundColor = ConsoleColor.Green;
        //        Console.Write(str[i]);
        //        Console.ResetColor();
        //    }
        //}


    }
}
