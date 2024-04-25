using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.View
{
    public class ExplainingScreen
    {
        public static void ExplainId(string str)
        {
            Console.SetCursorPosition(20, 13);
            Console.Write(str + " 아이디 입력 :");
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
            Console.Write("책 제목 - 영어, 한글, 숫자 1개 이상");
            Console.SetCursorPosition(0, 1);
            Console.Write("작가    - 영어, 한글 1글자 이상");
            Console.SetCursorPosition(0, 2);
            Console.Write("출판사  - 영어, 한글, 숫자 1개 이상");
        }

        public static void ExplainInputBookInfo()
        {
            Console.SetCursorPosition(0, 4);
            Console.Write("수량    - 1 ~ 999 사이의 자연수");
            Console.SetCursorPosition(0, 5);
            Console.Write("가격    - 1 ~ 999999 사이의 자연수");
            Console.SetCursorPosition(0, 6);
            Console.Write("출시일  - 20xx-xx-xx");
            Console.SetCursorPosition(0, 7);
            Console.Write("ISBN    - 정수 9개 + 영어 1개 + 공백 + 정수 13개");
            Console.SetCursorPosition(0, 8);
            Console.Write("정보    - 최소 1개의 문자");
            Console.SetCursorPosition(0, 9);
            Console.Write("===========================================");
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
