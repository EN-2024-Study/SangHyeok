using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.View
{
    public class ExplainingScreen
    {
        public static void ExplainSuccessScreen()
        {
            Console.Clear();
            Console.SetWindowSize(30, 10);
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("성공하였습니다!");
        }

        public static void ExplainEcsKey()
        {
            Console.SetCursorPosition(0, 1);
            Console.WriteLine("뒤로가기는 ESC를 눌러주세요.");
        }

        public static void ExplainFailScreen()
        {
            Console.Clear();
            Console.SetWindowSize(30, 10);
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("실패하였습니다!");
        }

        public static void ExplainId(string str)
        {
            Console.SetCursorPosition(0, 0);
            Console.Write(str + " 아이디 입력 :");
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
