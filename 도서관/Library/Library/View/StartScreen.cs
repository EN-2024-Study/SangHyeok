using Library.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.View
{
    public class StartScreen
    {
        public void DrawScreen(int screenValue, bool isEnter)
        {
            string[] strings = SetStrings(screenValue);

            DrawLogo();
            for(int i = 0; i < strings.Length; i++)
            {
                Console.SetCursorPosition(40, 30 + i);
                if (isEnter && MenuSelector.menuValue == i)
                    Console.ForegroundColor = ConsoleColor.Blue;
                else if (MenuSelector.menuValue == i)
                    Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(strings[i]);
                Console.ResetColor();
            }
        }

        private string[] SetStrings(int screenValue)
        {
            string[] strings = null;
            switch(screenValue)
            {
                case (int)Constants.ScreenType.Mode:
                    strings = new string[] { "유저 모드", "관리자 모드"};
                    break;
                case (int)Constants.ScreenType.LogInSignUp:
                    strings = new string[] { "로그인", "회원가입" };
                    break;
            }

            return strings;
        }

        private void DrawLogo()
        {
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(@"
 #######           ##   ##                 ## ##
  ##   #           ###  ##                ## ##
  ## #             #### ##              #######
  ####             ## ####               ## ##
  ## #             ##  ###             #######
  ##   #           ##   ##             ## ##
 #######           ##   ##            ## ##

 ####       ##     ###
  ##                ##
  ##       ###      ##      ######    ####    ######   ##  ##
  ##        ##      #####    ##  ##      ##    ##  ##  ##  ##
  ##   #    ##      ##  ##   ##       #####    ##      ##  ##
  ##  ##    ##      ##  ##   ##      ##  ##    ##       #####
 #######   ####    ######   ####      #####   ####         ##
                                                       #####
");
            Console.ResetColor();
        }
    }
}
