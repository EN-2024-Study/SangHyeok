using Library.Utility;
using Library.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Controller
{
    public class MenuController
    {
        protected MenuScreen menuScreen;
        protected Tuple<int, int> coordinate;
        public int menuValue;
        

        public MenuController()
        {
            this.menuScreen = new MenuScreen();
            this.coordinate = new Tuple<int, int>(20, 25);
            this.menuValue = 0;
        }

        public virtual void Run() { }

        public bool SelectMenu()
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
            int stringLength;

            switch(modeValue)
            {
                case (int)Constants.Type.UserManager:
                case (int)Constants.Type.LogInSignUp:
                case (int)Constants.Type.UserInfo:
                case (int)Constants.Type.ManagerInfo:
                    stringLength = 2;
                    break;
                case (int)Constants.Type.YesNo:
                    stringLength = 3;
                    break;
                case (int)Constants.Type.User:
                case (int)Constants.Type.Manager:
                    stringLength = 6;
                    break;
                default:
                    return null;
            }

            string[] str = new string[stringLength];

            switch (modeValue)
            {
                case (int)Constants.Type.UserManager:
                    str[0] = "유저 모드";
                    str[1] = "관리자 모드";
                    break;
                case (int)Constants.Type.LogInSignUp:
                    str[0] = "로그인";
                    str[1] = "회원가입";
                    break;
                case (int)Constants.Type.YesNo:
                    str[0] = "정말이십니까?";
                    str[1] = "예.";
                    str[2] = "아니요.";
                    break;
                case (int)Constants.Type.UserInfo:
                    str[0] = "정보 수정";
                    str[1] = "정보 삭제";
                    break;
                case (int)Constants.Type.ManagerInfo:
                    str[0] = "유저 정보 수정";
                    str[1] = "유저 삭제";
                    break;
                case (int)Constants.Type.User:
                    str[0] = "도서 조회";
                    str[1] = "도서 대여";
                    str[2] = "도서 대여 내역";
                    str[3] = "도서 반납";
                    str[4] = "도서 반납 내역";
                    str[5] = "정보 수정";
                    break;
                case (int)Constants.Type.Manager:
                    str[0] = "도서 조회";
                    str[1] = "도서 추가";
                    str[2] = "도서 삭제";
                    str[3] = "도서 수정";
                    str[4] = "회원 관리";
                    str[5] = "대여 내역";
                    break;
            }

            return str;
        }
    }
}
