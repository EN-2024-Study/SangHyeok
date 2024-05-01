using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.View
{
    public class ExplainingScreen
    {
        public static void ExplainInvalidInput(string str)
        {
            Console.SetCursorPosition(15, 9);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write(str + " 정보가 맞지 않습니다!");
            Console.ResetColor();
        }

        public static void ExplainDuplicationExist(string str)
        {
            Console.SetCursorPosition(15, 9);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write(str + " 정보가 존재합니다!");
            Console.ResetColor();
        }

        public static void ExplainNoInput()
        {
            Console.SetCursorPosition(15, 9);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write("모두 입력 후 Enter를 누르세요!");
            Console.ResetColor();
        }


        public static void ExplainDatePassed()
        {
            Console.SetCursorPosition(15, 9);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write("연체 된 도서가 존재합니다!");
            Console.ResetColor();
        }

        public static void ExplainInputId(string str)
        {
            Console.SetCursorPosition(20, 13);
            Console.Write(str + " 아이디 입력 :");
        }

        public static void ExplainSearchNaver()
        {
            Console.SetCursorPosition(0, 0);
            Console.Write("책 키워드 : ");
            Console.SetCursorPosition(0, 2);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("ESC : 뒤로가기  ");
            Console.ResetColor();
        }

        public static void ExplainRequestTitle(string str)
        {
            Console.SetCursorPosition(0, 15);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(str + " 책 키워드 : ");
            Console.ResetColor();
        }

        public static void ExplainInputBookId()
        {
            Console.SetCursorPosition(20, 11);
            Console.Write("1 부터 99 까지의 정수 입력");
        }

        public static void ExplainInputAccountId()
        {
            Console.SetCursorPosition(20, 11);
            Console.Write("8 자리 정수 입력");
        }

        public static void ExplainInputAddress()
        {
            Console.SetCursorPosition(0, 19);
            Console.Write("(주소 형식 : XX시 XX구 or XX시 XX구 XX동)");
        }

        public static void ExplainArrowKeys()
        {
            Console.SetCursorPosition(40, 18);
            Console.Write("<키보드 방향키를 눌러");
            Console.SetCursorPosition(40, 19);
            Console.Write("메뉴를 선택해 주세요.>");
        }

        public static void ExplainQuitKey()
        {
            Console.SetCursorPosition(40, 21);
            Console.WriteLine("<종료는 ESC를 눌러주세요.>");
        }

        public static void ExplainSearchBookInfo()
        {
            Console.SetCursorPosition(0, 0);
            Console.Write("책 제목 - 1 글자 이상 15 글자 이하의 문자 또는 숫자");
            Console.SetCursorPosition(0, 1);
            Console.Write("작가    - 1 글자 이상 10 글자 이하의 문자");
            Console.SetCursorPosition(0, 2);
            Console.Write("출판사  - 1 글자 이상 10 글자 이하의 문자 또는 숫자");
        }

        public static void ExplainInputBookInfo()
        {
            Console.SetCursorPosition(0, 3);
            Console.Write("수량    - 0 부터 999 사이의 자연수");
            Console.SetCursorPosition(0, 4);
            Console.Write("가격    - 0 부터 999999 사이의 자연수");
            Console.SetCursorPosition(0, 5);
            Console.Write("출시일  - 20xx-xx-xx");
            Console.SetCursorPosition(0, 6);
            Console.Write("ISBN    - 정수 13 개");
            Console.SetCursorPosition(0, 7);
            Console.Write("정보    - 특수문자를 제외한 문자 또는 숫자");
            Console.SetCursorPosition(0, 8);
            Console.Write("=====================================================");
        }

        public static void ExplainSuccessScreen()
        {
            Console.Clear();
            Console.SetWindowSize(70, 30);
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"
  #####   ##   ##    ####     ####   #######   #####    #####
 ##   ##  ##   ##   ##  ##   ##  ##   ##   #  ##   ##  ##   ##
 #        ##   ##  ##       ##        ## #    #        #
  #####   ##   ##  ##       ##        ####     #####    #####
      ##  ##   ##  ##       ##        ## #         ##       ##
 ##   ##  ##   ##   ##  ##   ##  ##   ##   #  ##   ##  ##   ##
  #####    #####     ####     ####   #######   #####    #####
");
            Console.ResetColor();
            ExplainEcsKey(9);
        }

        public static void ExplainEcsKey(int coordinateY)
        {
            Console.SetCursorPosition(0, coordinateY);
            Console.WriteLine(@"
 ######
  ##  ##
  ##  ##  ######    ####     #####    #####
  #####    ##  ##  ##  ##   ##       ##
  ##       ##      ######    #####    #####
  ##       ##      ##            ##       ##
 ####     ####      #####   ######   ######

 #######   #####     ####            ###  ##
  ##   #  ##   ##   ##  ##            ##  ##
  ## #    #        ##                 ## ##    ####    ##  ##
  ####     #####   ##                 ####    ##  ##   ##  ##
  ## #         ##  ##                 ## ##   ######   ##  ##
  ##   #  ##   ##   ##  ##            ##  ##  ##        #####
 #######   #####     ####            ###  ##   #####       ##
                                                       #####
");
        }

        public static void ExplainFailScreen()
        {
            Console.Clear();
            Console.SetWindowSize(70, 30);
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"
 #######    ##      ####    ####
  ##   #   ####      ##      ##
  ## #    ##  ##     ##      ##
  ####    ##  ##     ##      ##
  ## #    ######     ##      ##   #
  ##      ##  ##     ##      ##  ##
 ####     ##  ##    ####    #######
");
            Console.ResetColor();
            ExplainEcsKey(9);
        }

        public static void DrawSearchLogo()
        {
            Console.SetCursorPosition(0, 8);
            Console.Write(@"
  #####   #######    ##     ######     ####   ##   ##                                               
 ##   ##   ##   #   ####     ##  ##   ##  ##  ##   ##                               
 #         ## #    ##  ##    ##  ##  ##       ##   ##  
  #####    ####    ##  ##    #####   ##       #######
      ##   ## #    ######    ## ##   ##       ##   ##  
 ##   ##   ##   #  ##  ##    ##  ##   ##  ##  ##   ##  
  #####   #######  ##  ##   #### ##    ####   ##   ## 
");
        }

        public static void DrawIdLogo()
        {
            Console.SetCursorPosition(0, 0);
            Console.Write(@"
  ####                                 ##
   ##                                  ##
   ##     #####    ######   ##  ##    #####
   ##     ##  ##    ##  ##  ##  ##     ##
   ##     ##  ##    ##  ##  ##  ##     ##
   ##     ##  ##    #####   ##  ##     ## ##
  ####    ##  ##    ##       ######     ###
                   ####

  ####    #####
   ##      ## ##
   ##      ##  ##
   ##      ##  ##
   ##      ##  ##
   ##      ## ##
  ####    #####
");
        }

        public static void DrawStartLogo()
        {
            Console.SetCursorPosition(0, 0);
            Console.Write(@"
 #######           ##   ##                     ## ##
  ##   #           ###  ##           ##        ## ##
  ## #             #### ##            ##      #######
  ####             ## ####             ##      ## ##
  ## #             ##  ###              ##    #######
  ##   #           ##   ##               ##    ## ##
 #######           ##   ##                ##   ## ##

 ####       ##     ###
  ##                ##
  ##       ###      ##      ######    ####    ######   ##  ##
  ##        ##      #####    ##  ##      ##    ##  ##  ##  ##
  ##   #    ##      ##  ##   ##       #####    ##      ##  ##
  ##  ##    ##      ##  ##   ##      ##  ##    ##       #####
 #######   ####    ######   ####      #####   ####         ##
                                                       #####
");
        }

        public static void DrawSIgnUpLogo()
        {
            Console.SetCursorPosition(0, 0);
            Console.Write(@"
  #####     ##                                ##   ##
 ##   ##                                      ##   ##
 #         ###      ### ##  #####             ##   ##  ######
  #####     ##     ##  ##   ##  ##            ##   ##   ##  ##
      ##    ##     ##  ##   ##  ##            ##   ##   ##  ##
 ##   ##    ##      #####   ##  ##            ##   ##   #####
  #####    ####        ##   ##  ##             #####    ##
                   #####                               ####
");
        }

        public static void DrawLibraryLogo()
        {
            Console.SetCursorPosition(0, 0);
            Console.Write(@"
 ####       ##     ###
  ##                ##
  ##       ###      ##      ######    ####    ######   ##  ##
  ##        ##      #####    ##  ##      ##    ##  ##  ##  ##
  ##   #    ##      ##  ##   ##       #####    ##      ##  ##
  ##  ##    ##      ##  ##   ##      ##  ##    ##       #####
 #######   ####    ######   ####      #####   ####         ##
                                                       #####
");
        }

        public static void DrawModifyLogo()
        {
            Console.SetCursorPosition(0, 0);
            Console.Write(@"
 ##   ##              ###     ##       ###
 ### ###               ##             ## ##
 #######   ####        ##    ###       #      ##  ##
 #######  ##  ##    #####     ##     ####     ##  ##
 ## # ##  ##  ##   ##  ##     ##      ##      ##  ##
 ##   ##  ##  ##   ##  ##     ##      ##       #####
 ##   ##   ####     ######   ####    ####         ##
                                              #####
");
        }
    }
}
