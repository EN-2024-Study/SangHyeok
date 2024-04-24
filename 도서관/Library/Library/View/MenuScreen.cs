using System;
using Library.Utility;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.View
{
    public class MenuScreen
    {
        public void DrawMenu(int screenValue, int selectedMenu, bool isEnter)
        {
            string[] menuStrings = SetStrings(screenValue);

            for (int i = 0; i < menuStrings.Length; i++)
            {
                if (isEnter && i == selectedMenu)    // 엔터 입력과 선택한 메뉴값
                    Console.ForegroundColor = ConsoleColor.Blue;
                else if (i == selectedMenu)  // 선택한 메뉴값
                    Console.ForegroundColor = ConsoleColor.Green;

                Console.SetCursorPosition(0, i);
                Console.Write(menuStrings[i]);
                Console.ResetColor();
            }
        }

        private string[] SetStrings(int screenValue)
        {
            string[] menuString = null;
            switch (screenValue)
            {
                case (int)Constants.MenuType.Mode:
                    menuString = new string[] { "유저 모드", "관리자 모드" };
                    break;
                case (int)Constants.MenuType.LogInSignUp:
                    menuString = new string[] { "로그인", "회원가입" };
                    break;
                case (int)Constants.MenuType.LogIn:
                    menuString = new string[] { "학번(8자리 숫자)     :",
                        "비밀번호(4자리 숫자) :", "<확인>"};
                    break;
                case (int)Constants.MenuType.UserMode:
                    menuString = new string[] { "도서 찾기", "도서 대여",
                    "도서 대여 내역", "도서 반납", "도서 반납 내역", "정보 수정", "계정 삭제"};
                    break;
                case (int)Constants.MenuType.BookSearch:
                    menuString = new string[] { "제목 찾기   :", "작가명 찾기 :", "출판사 찾기 :", "<확인>"};
                    break;
                case (int)Constants.MenuType.ManagerMode:
                    menuString = new string[] { "도서 찾기", "도서 추가",
                    "도서 삭제", "도서 수정", "유저 정보 수정", "유저 삭제", "대여 내역"};
                    break;
                case (int)Constants.MenuType.SignUp: 
                    menuString = new string[] { "학번(8자리 숫자)     :", "비밀번호(4자리 숫자) :",
                    "유저 나이            :", "유저 휴대폰 번호     :", "유저 주소            :", "<확인>"};
                    break;
                case (int)Constants.MenuType.AccountModify:
                    menuString = new string[] { "비밀번호(4자리 숫자) :",
                    "유저 나이            :", "유저 휴대폰 번호     :", "유저 주소            :", "<확인>"};
                    break;
                case (int)Constants.MenuType.BookAdd:
                    menuString = new string[] { "책 제목 :", "작가    :", "출판사  : ",
                    "수량    :", "가격    :", "출시일  :", "ISBN    :", 
                        "책 정보 :", "<확인>"};
                    break;
            }
            return menuString;
        }
    }
}
