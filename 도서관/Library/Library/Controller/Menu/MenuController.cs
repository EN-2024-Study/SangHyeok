using Library.Utility;
using Library.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Controller
{
    public abstract class MenuController
    {
        protected MenuScreen menuScreen;
        protected string[] menuString;
        protected int menuValue;

        protected MenuController()
        {
            this.menuScreen = new MenuScreen();
            this.menuValue = 0;
            this.menuString = null;
        }

        public abstract bool Run();

        protected bool SelectMenu()
        {
            Console.CursorVisible = false;
            ConsoleKeyInfo keyInfo = Console.ReadKey();

            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    menuValue--;
                    break;
                case ConsoleKey.DownArrow:
                    menuValue++;
                    break;
                case ConsoleKey.Enter:
                case ConsoleKey.Spacebar:
                    return false;
                case ConsoleKey.Escape:
                    menuValue = -1;
                    return false;
            }

            if (menuValue < 0)
                menuValue = 0;
            return true;
        }

        protected string[] DecideMenuType(int modeValue)
        {
            int arraySize;

            switch(modeValue)
            {
                case (int)Constants.MenuType.UserManager:
                case (int)Constants.MenuType.LogInSignUp:
                case (int)Constants.MenuType.UserInfo:
                case (int)Constants.MenuType.ManagerInfo:
                case (int)Constants.MenuType.LogIn:
                    arraySize = 2;
                    break;
                case (int)Constants.MenuType.YesNo:
                    arraySize = 3;
                    break;
                case (int)Constants.MenuType.User:
                case (int)Constants.MenuType.Manager:
                    arraySize = 6;
                    break;
                case (int)Constants.MenuType.SignUp:
                    arraySize = 7;
                    break;
                case (int)Constants.MenuType.SearchBook:
                    arraySize = 3;
                    break;
                case (int)Constants.MenuType.UserModify:
                    arraySize = 5;
                    break;
                case (int)Constants.MenuType.ManagerModify:
                    arraySize = 7;
                    break;
                case (int)Constants.MenuType.BookAdd:
                    arraySize = 8;
                    break;
                default:
                    return null;
            }

            string[] str = new string[arraySize];

            switch (modeValue)
            {
                case (int)Constants.MenuType.UserManager:
                    str[0] = "유저 모드";
                    str[1] = "관리자 모드";
                    break;
                case (int)Constants.MenuType.LogInSignUp:
                    str[0] = "로그인";
                    str[1] = "회원가입";
                    break;
                case (int)Constants.MenuType.YesNo:
                    str[0] = "정말이십니까?";
                    str[1] = "예.";
                    str[2] = "아니요.";
                    break;
                case (int)Constants.MenuType.UserInfo:
                    str[0] = "정보 수정";
                    str[1] = "정보 삭제";
                    break;
                case (int)Constants.MenuType.ManagerInfo:
                    str[0] = "유저 정보 수정";
                    str[1] = "유저 삭제";
                    break;
                case (int)Constants.MenuType.User:
                    str[0] = "도서 조회";
                    str[1] = "도서 대여";
                    str[2] = "도서 대여 내역";
                    str[3] = "도서 반납";
                    str[4] = "도서 반납 내역";
                    str[5] = "정보 수정";
                    break;
                case (int)Constants.MenuType.Manager:
                    str[0] = "도서 조회";
                    str[1] = "도서 추가";
                    str[2] = "도서 삭제";
                    str[3] = "도서 수정";
                    str[4] = "회원 관리";
                    str[5] = "대여 내역";
                    break;
                case (int)Constants.MenuType.LogIn:
                    str[0] = "ID : ";
                    str[1] = "PASSWORD : "; 
                    break;
                case (int)Constants.MenuType.SignUp:
                    str[0] = "ID           :";
                    str[1] = "비밀번호     :";
                    str[2] = "비밀번호 확인:";
                    str[3] = "이름         :";
                    str[4] = "나이         :";
                    str[5] = "전화번호     :";
                    str[6] = "주소         :";
                    break;
                case (int)Constants.MenuType.SearchBook:
                    str[0] = "제목으로 찾기       :";
                    str[1] = "작가명으로 찾기     :";
                    str[2] = "출판사로 찾기       :";
                    break;
                case (int)Constants.MenuType.UserModify:
                    str[0] = "USER PW (8 ~ 15글자 영어, 숫자 포함)  :";
                    str[1] = "USER NAME(한글, 영어 포함 2글자 이상) :";
                    str[2] = "USER AGE(자연수 0 ~ 200세)            :";
                    str[3] = "USER PHONENUMBER(010-xxxx-xxxx)       :";
                    str[4] = "USER ADDRESS(도로면 주소 형식)        :";
                    break;
                case (int)Constants.MenuType.ManagerModify:
                    str[0] = "책 제목 :";
                    str[1] = "작가    :";
                    str[2] = "출판사  :";
                    str[3] = "수량    :";
                    str[4] = "가격    :";
                    str[5] = "출시일  :";
                    str[6] = "정보    :";
                    break;
                case (int)Constants.MenuType.BookAdd:
                    str[0] = "책 제목 :";
                    str[1] = "작가    :";
                    str[2] = "출판사  :";
                    str[3] = "수량    :";
                    str[4] = "가격    :";
                    str[5] = "출시일  :";
                    str[6] = "ISBN    :";
                    str[7] = "정보    :";
                    break;
            }
            return str;
        }
    }
}
