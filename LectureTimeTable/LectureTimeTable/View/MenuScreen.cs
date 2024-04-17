using LectureTimeTable.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable.View
{
    public class MenuScreen
    {
        public void DrawMenu(int screenValue, int selectValue, bool isEnter, bool isMenuVisible)
        {
            string[] menuString = SelectmenuString(screenValue);
            Tuple<int, int> coordinate = SetCoordinate(screenValue);

            DrawLogo();
            for (int i = 0, x = 0; i < menuString.Length; i++, x+=20)
            {
                if (isEnter && i == selectValue)    // 엔터 입력과 선택한 메뉴값
                    Console.ForegroundColor = ConsoleColor.Blue;
                else if (i == selectValue)  // 선택한 메뉴값
                    Console.ForegroundColor = ConsoleColor.Green;

                if (isMenuVisible)  // 메뉴
                    Console.SetCursorPosition(coordinate.Item1, coordinate.Item2 + i);
                else    // 부가 메뉴
                    Console.SetCursorPosition(coordinate.Item1 + i + x, coordinate.Item2);
                Console.Write(menuString[i]);
                Console.ResetColor();
            }
        }

        public void ClearBottomScreen()
        {
            for (int i = 30; i < Console.WindowHeight; i++)
            {
                for (int j = 0; j < Console.WindowWidth; j++)
                {
                    Console.SetCursorPosition(j, i);
                    Console.Write(" ");
                }
            }
        }

        private Tuple<int, int> SetCoordinate(int screenValue)
        {
            int x = 0, y = 0;
            switch (screenValue)
            {
                case (int)Constants.MenuType.LogIn:
                    x = 5;
                    y = 30;
                    break;
                case (int)Constants.MenuType.Main:
                case (int)Constants.MenuType.FavoriteSubject:
                case (int)Constants.MenuType.CourseApply:
                    x = 15;
                    y = 30;
                    break;
                case (int)Constants.MenuType.SearchAndApply:
                    x = 25;
                    y = 30;
                    break;
                case (int)Constants.MenuType.Search:
                    x = 0;
                    y = 30;
                    break;
                case (int)Constants.MenuType.Major:
                    x = 20;
                    y = 30;
                    break;
                case (int)Constants.MenuType.CreditClassification:
                    x = 20;
                    y = 31;
                    break;
                case (int)Constants.MenuType.Grade:
                    x = 20;
                    y = 34;
                    break;
            }

            return new Tuple<int, int>(x, y);
        }

        private string[] SelectmenuString(int screenValue)
        {
            string[] menuString = null;
            switch (screenValue)
            {
                case (int)Constants.MenuType.LogIn:
                    menuString = new string[] { "        학번(8자리 숫자)         : ",
                        "비밀번호(영어 & 숫자 6 ~ 10글자) : " };
                    break;
                case (int)Constants.MenuType.Main:
                    menuString = new string[] { "강의 시간표 조회 ", " 관심 과목 담기",
                        "  수강 신청 ", "수강 내역 조회" };
                    break;
                case (int)Constants.MenuType.FavoriteSubject:
                    menuString = new string[] { "관심 과목 검색", "관심 과목 내역",
                    "관심 과목 시간표","관심 과목 삭제"};
                    break;
                case (int)Constants.MenuType.CourseApply:
                    menuString = new string[] { "수강 신청", "수강 신청 내역" ,
                    "수강 신청 시간표","수강 과목 삭제"};
                    break;
                case (int)Constants.MenuType.SearchAndApply:
                    menuString = new string[] { "검색 후 신청", "관심 과목 신청" };
                    break;
                case (int)Constants.MenuType.Search:
                    menuString = new string[] { "개설 학과 전공 :", "   이수 구분   :",
                        "   교과목 명   :", "    교수명     :", "     학년      :", "           < 검색 >"};
                    break;
                case (int)Constants.MenuType.Major:
                    menuString = new string[] { " 전체", "컴퓨터학과", "소프트웨어학과", "지능기전공학부", "기계항공우주공학부" };
                    break;
                case (int)Constants.MenuType.CreditClassification:
                    menuString = new string[] { " 전체", "교양필수", "전공필수", "전공선택" };
                    break;
                case (int)Constants.MenuType.Grade:
                    menuString = new string[] { "1학년", "2학년", "3학년", "4학년" };
                    break;
            }
            return menuString;
        }

        private void DrawLogo()     // y = 0 ~ 25
        {
            Console.SetCursorPosition(0, 0);
            Console.Write(@"
 ##   ##                       ###
 ##   ##                        ##
 ##   ##   ####    ######       ## 
 #######      ##    ##  ##   ##### 
 ##   ##   #####    ##      ##  ## 
 ##   ##  ##  ##    ##      ##  ##
 ##   ##   #####   ####      ######

  #### 
 ##  ##
##        ####    ##  ##   ######    #####    #### 
##       ##  ##   ##  ##    ##  ##  ##       ##  ##
##       ##  ##   ##  ##    ##       #####   ######
 ##  ##  ##  ##   ##  ##    ##           ##  ##
  ####    ####     ######  ####     ######    #####

    ##                        ###
  ####                        ##
 ##  ##   ######   ######     ##     ##  ##
 ##  ##    ##  ##   ##  ##    ##     ##  ##
 ######    ##  ##   ##  ##    ##     ##  ##
 ##  ##    #####    #####     ##      #####
 ##  ##    ##       ##       ####        ##
          ####     ####              #####
");
        }
    }
}
