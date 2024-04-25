using Library.Model;
using Library.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.View
{
    public class Screen
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

        public void DrawUsers(List<UserDto> userList)
        {
            int y = 10;
            Console.ForegroundColor = ConsoleColor.Green;

            for (int i = 0; i < userList.Count; i++)
            {
                Console.SetCursorPosition(0, y);
                Console.Write("=====================================");
                Console.SetCursorPosition(0, y + 1);
                Console.Write("유저 아이디      :" + userList[i].Id);
                Console.SetCursorPosition(0, y + 2);
                Console.Write("유저 이름        :" + userList[i].Password);
                Console.SetCursorPosition(0, y + 3);
                Console.Write("유저 나이        :" + userList[i].Age);
                Console.SetCursorPosition(0, y + 4);
                Console.Write("유저 휴대폰 번호 :" + userList[i].PhoneNumber);
                Console.SetCursorPosition(0, y + 5);
                Console.Write("유저 주소        :" + userList[i].Address);
                y += 6;
            }
            Console.ResetColor();
        }

        public void DrawBooks(List<BookDto> bookList)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            int y = 10;
            for (int i = 0; i < bookList.Count; i++)
            {
                Console.SetCursorPosition(0, y);
                Console.Write("=====================================");
                Console.SetCursorPosition(0, y + 1);
                Console.Write("책 아이디 :" + bookList[i].Id);
                Console.SetCursorPosition(0, y + 2);
                Console.Write("책 제목   :" + bookList[i].Title);
                Console.SetCursorPosition(0, y + 3);
                Console.Write("작가      :" + bookList[i].Writer);
                Console.SetCursorPosition(0, y + 4);
                Console.Write("출판사    :" + bookList[i].Publisher);
                Console.SetCursorPosition(0, y + 5);
                Console.Write("수량      :" + bookList[i].Count);
                Console.SetCursorPosition(0, y + 6);
                Console.Write("가격      :" + bookList[i].Price);
                Console.SetCursorPosition(0, y + 7);
                Console.Write("출시일    :" + bookList[i].ReleaseDate);
                Console.SetCursorPosition(0, y + 8);
                Console.Write("ISBN      :" + bookList[i].ISBN);
                Console.SetCursorPosition(0, y + 9);
                Console.Write("책 정보   :" + bookList[i].Info);
                y += 10;
            }
            Console.ResetColor();
        }

        public void DrawRentalBooks(int coordinateY, List<RentalBookDto> bookList)
        {
            int y = coordinateY;
            for (int i = 0; i < bookList.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(0, y);
                Console.Write("=====================================");
                Console.SetCursorPosition(0, y + 1);
                Console.Write("책 아이디   :" + bookList[i].Id);
                Console.SetCursorPosition(0, y + 2);
                Console.Write("책 제목     :" + bookList[i].Title);
                Console.SetCursorPosition(0, y + 3);
                Console.Write("작가        :" + bookList[i].Writer);
                Console.SetCursorPosition(0, y + 4);
                Console.Write("출판사      :" + bookList[i].Publisher);
                Console.SetCursorPosition(0, y + 5);
                Console.Write("수량        :" + bookList[i].Count);
                Console.SetCursorPosition(0, y + 6);
                Console.Write("가격        :" + bookList[i].Price);
                Console.SetCursorPosition(0, y + 7);
                Console.Write("출시일      :" + bookList[i].ReleaseDate);
                Console.SetCursorPosition(0, y + 8);
                Console.Write("ISBN        :" + bookList[i].ISBN);
                Console.SetCursorPosition(0, y + 9);
                Console.Write("책 정보     :" + bookList[i].Info);
                Console.SetCursorPosition(0, y + 10);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("빌린 시간   :" + bookList[i].RentalTime.ToString("yyyy-MM-dd hh:mm:ss"));
                Console.SetCursorPosition(0, y + 11);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("반납 시간   :" + bookList[i].RentalTime.AddDays(7).ToString("yyyy-MM-dd hh:mm:ss"));
                Console.ResetColor();
                y += 12;
            }
            Console.ResetColor();
        }

        public void DrawUserRentalHistory(List<UserDto> userList)  
        {
            int y = 10;
            for (int i = 0; i < userList.Count; i++)
            {
                Console.SetCursorPosition(0, y);
                Console.Write("=====================================");
                Console.SetCursorPosition(0, y + 1);
                Console.Write("유저 아이디      :" + userList[i].Id);
                DrawRentalBooks(y + 2, userList[i].GetRentalBookList());
                y += userList[i].GetRentalBookList().Count * 12 + 2;
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
                    menuString = new string[] { "제목 찾기   :", "작가명 찾기 :", "출판사 찾기 :", "<확인>" };
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
                case (int)Constants.MenuType.BookModify:
                    menuString = new string[] { "책 제목 :", "작가    :", "출판사  : ",
                    "수량    :", "가격    :", "출시일  :", "<확인>"};
                    break;
            }
            return menuString;
        }
    }
}
