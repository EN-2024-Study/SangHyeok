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
        public void DrawMenu(int screenValue, int menuCount, int selectValue, bool isEnter)
        {
            string[] menuString = SelectmenuString(screenValue, menuCount);
            Tuple<int, int> coordinate = SetCoordinate(screenValue);

            DrawLogo();
            for (int i = 0; i < menuString.Length; i++)
            {
                if (isEnter && i == selectValue)
                    Console.ForegroundColor = ConsoleColor.Blue;
                else if (i == selectValue)
                    Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(coordinate.Item1, coordinate.Item2 + i);
                Console.Write(menuString[i]);
                Console.ResetColor();
            }
        }

        public void DrawInputFailure(Tuple<int, int> coordinate)
        {
            Console.SetCursorPosition(coordinate.Item1, coordinate.Item2);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("[Fail]");
            Console.ResetColor();
        }

        public void ClearBottomScreen()
        {
            for (int i = 30; i < 40; i++)
            {
                for (int j = 0; j < 130; j++)
                {
                    Console.SetCursorPosition(j, i);
                    Console.Write(" ");
                }
            }

        }

        private string[] SelectmenuString(int screenValue, int menuCount)
        {
            int length = menuCount;

            string[] menuString = new string[length];
            switch (screenValue)
            {
                case (int)Constants.MenuType.LogIn:
                    menuString[0] = "        학번(8자리 숫자)         : ";
                    menuString[1] = "비밀번호(영어 & 숫자 6 ~ 10글자) : ";
                    break;
                case (int)Constants.MenuType.Main:
                    menuString[0] = "강의 시간표 조회 ";
                    menuString[1] = " 관심 과목 담기";
                    menuString[2] = "  수강 신청 ";
                    menuString[3] = "수강 내역 조회";
                    break;
                case (int)Constants.MenuType.FavoriteSubject:
                    menuString[0] = "관심 과목 검색";
                    menuString[1] = "관심 과목 내역";
                    menuString[2] = "관심 과목 시간표";
                    menuString[3] = "관심 과목 삭제";
                    break;
                case (int)Constants.MenuType.CourseRegistration:
                    menuString[0] = "수강 신청";
                    menuString[1] = "수강 신청 내역";
                    menuString[2] = "수강 신청 시간표";
                    menuString[3] = "수강 과목 삭제";
                    break;
                case (int)Constants.MenuType.Search:
                    menuString[0] = "검색 후 신청";
                    menuString[1] = "관심 과목 신청";
                    break;
                case (int)Constants.MenuType.InputSearch:
                    menuString[0] = "개설 학과 전공 :";
                    menuString[1] = "   이수 구분   :";
                    menuString[2] = "   교과목 명   :";
                    menuString[3] = "    교수명     :";
                    menuString[4] = "     학년      :";
                    break;
            }
            return menuString;
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
                    x = 35;
                    y = 30;
                    break;
            }

            return new Tuple<int, int>(x, y);
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

 ######                       ##                ##                         ##       ##
  ##  ##                                        ##                         ##
  ##  ##   ####     ### ##   ###      #####    #####   ######    ####     #####    ###      ####    #####
  #####   ##  ##   ##  ##     ##     ##         ##      ##  ##      ##     ##       ##     ##  ##   ##  ##
  ## ##   ######   ##  ##     ##      #####     ##      ##       #####     ##       ##     ##  ##   ##  ##
  ##  ##  ##        #####     ##          ##    ## ##   ##      ##  ##     ## ##    ##     ##  ##   ##  ##
 #### ##   #####       ##    ####    ######      ###   ####      #####      ###    ####     ####    ##  ##
                   #####
");
        }
    }
}
