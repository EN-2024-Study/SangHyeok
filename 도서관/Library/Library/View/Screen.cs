using Library.Model;
using Library.Model.DtoVo;
using Library.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Library.View
{
    public class Screen
    {
        public void DrawMenu(int screenType, int selectedMenu, bool isEnter)
        {
            string[] menuStrings = SetStrings(screenType);
            Tuple<int, int> coordinate = GetCoordinate(screenType);

            for (int i = 0; i < menuStrings.Length; i++)
            {
                if (isEnter && i == selectedMenu)    // 엔터 입력과 선택한 메뉴값
                    Console.ForegroundColor = ConsoleColor.Blue;
                else if (i == selectedMenu)  // 선택한 메뉴값
                    Console.ForegroundColor = ConsoleColor.Green;

                Console.SetCursorPosition(coordinate.Item1, coordinate.Item2 + i);
                Console.Write(menuStrings[i]);
                Console.ResetColor();
            }
        }

        public void DrawUsers(List<UserDto> userList)
        {
            int y = 17;
            Console.ForegroundColor = ConsoleColor.Green;

            foreach(UserDto user in userList)
            {
                DrawUserId(y, user.Id);
                Console.SetCursorPosition(0, y + 2);
                Console.Write("유저 이름        :" + user.Password);
                Console.SetCursorPosition(0, y + 3);
                Console.Write("유저 나이        :" + user.Age);
                Console.SetCursorPosition(0, y + 4);
                Console.Write("유저 휴대폰 번호 :" + user.PhoneNumber);
                Console.SetCursorPosition(0, y + 5);
                Console.Write("유저 주소        :" + user.Address);
                y += 6;
            }
            Console.ResetColor();
        }

        private void DrawUserId(int y, string userId)
        {
            Console.SetCursorPosition(0, y);
            Console.Write("=====================================");
            Console.SetCursorPosition(0, y + 1);
            Console.Write("유저 아이디      :" + userId);
        }
      
        public void DrawRentalBooks(int y, string userId, List<RentalBookDto> bookList)
        {
            DrawUserId(y, userId);
            foreach(RentalBookDto book in bookList)
            {
                DrawBookInfo(y + 2, book.Id, book.Title, book.Writer, book.Publisher,
                    book.Count.ToString(), book.Price, book.ReleaseDate, book.ISBN, book.Info);
                Console.SetCursorPosition(0, y + 12);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("빌린 시간   :" + book.RentalTime);
                Console.SetCursorPosition(0, y + 13);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("반납 시간   :" + book.ReturnTime);
                Console.ResetColor();
                y += 12;
            }
        }

        public void DrawReturnBooks(string userId, List<ReturnBookDto> bookList)
        {
            int y = 17;
            DrawUserId(y, userId);
            foreach (ReturnBookDto book in bookList)
            {
                DrawBookInfo(y + 2, book.Id, book.Title, book.Writer, book.Publisher,
                    book.Count.ToString(), book.Price, book.ReleaseDate, book.ISBN, book.Info);
                y += 12;
            }
        }

        public void DrawBooks(List<BookDto> bookList)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            int y = 17;
            foreach (BookDto book in bookList)
            {
                DrawBookInfo(y, book.Id, book.Title, book.Writer, book.Publisher, book.Count.ToString(),
                    book.Price, book.ReleaseDate, book.ISBN, book.Info);
                y += 10;
            }
            Console.ResetColor();
        }

        private void DrawBookInfo(int y, string id, string title, string writer, string publisher,
            string count, string price, string releaseDate, string ISBN, string info)
        {
            Console.SetCursorPosition(0, y);
            Console.Write("=====================================");
            Console.SetCursorPosition(0, y + 1);
            Console.Write("책 아이디   :" + id);
            Console.SetCursorPosition(0, y + 2);
            Console.Write("책 제목     :" + title);
            Console.SetCursorPosition(0, y + 3);
            Console.Write("작가        :" + writer);
            Console.SetCursorPosition(0, y + 4);
            Console.Write("출판사      :" + publisher);
            Console.SetCursorPosition(0, y + 5);
            Console.Write("수량        :" + count);
            Console.SetCursorPosition(0, y + 6);
            Console.Write("가격        :" + price);
            Console.SetCursorPosition(0, y + 7);
            Console.Write("출시일      :" + releaseDate);
            Console.SetCursorPosition(0, y + 8);
            Console.Write("ISBN        :" + ISBN);
            Console.SetCursorPosition(0, y + 9);
            Console.Write("책 정보     :" + info);
        }

        private Tuple<int, int> GetCoordinate(int screenType)
        {
            Tuple<int, int> coordinate = null;

            switch (screenType)
            {
                case (int)Constants.MenuType.Mode:
                case (int)Constants.MenuType.LogInSignUp:
                case (int)Constants.MenuType.LogIn:
                    coordinate = new Tuple<int, int>(10, 20);
                    break;
                case (int)Constants.MenuType.SignUp:
                case (int)Constants.MenuType.AccountModify:
                    coordinate = new Tuple<int, int>(0, 13);
                    break;
                case (int)Constants.MenuType.UserMode:
                case (int)Constants.MenuType.ManagerMode:
                    coordinate = new Tuple<int, int>(Console.WindowWidth / 2 - 10, 10);
                    break;
                case (int)Constants.MenuType.BookSearch:
                    coordinate = new Tuple<int, int>(0, 4);
                    break;
                case (int)Constants.MenuType.BookAdd:
                case (int)Constants.MenuType.BookModify:
                    coordinate = new Tuple<int, int>(0, 11);
                    break;
            }
            return coordinate;
        }

        private string[] SetStrings(int screenType)
        {
            string[] menuString = null;
            switch (screenType)
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
                    menuString = new string[] { "학번(8자리 숫자)                :", "비밀번호(4자리 숫자)            :",
                    "유저 나이(0 ~ 99세)             :", "유저 휴대폰 번호(010-xxxx-xxxx) :", "유저 주소(3자리 한글)           :", "<확인>"};
                    break;
                case (int)Constants.MenuType.AccountModify:
                    menuString = new string[] { "비밀번호(4자리 숫자)            :", "유저 나이(8 ~ 99세)             :", 
                        "유저 휴대폰 번호(010-xxxx-xxxx) :", "유저 주소(3자리 한글)           :", "<확인>"};
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
