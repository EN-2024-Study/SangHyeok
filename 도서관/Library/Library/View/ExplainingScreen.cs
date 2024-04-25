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
            Console.SetCursorPosition(0, 0);
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
