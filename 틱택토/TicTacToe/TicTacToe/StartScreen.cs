using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class StartScreen : Screen
    {
        private int menunumber;
        private string[] menuNames;
        private string name;

        public StartScreen()
        {
            menunumber = -1;
            menuNames = new string[] { "㉠  vs Computer", "㉡  vs User", "㉢  ScoreBoard", "㉣  Quit" };
            name = null;
        }

        public override void PrintScreen()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(@"
     ____________________________________________________________________
     ___  __/___  _/_  ____/__  __/__    |_  ____/__  __/_  __ \__  ____/
     __  /   __  / _  /    __  /  __  /| |  /    __  /  _  / / /_  __/   
     _  /   __/ /  / /___  _  /   _  ___ / /___  _  /   / /_/ /_  /___   
     /_/    /___/  \____/  /_/    /_/  |_\____/  /_/    \____/ /_____/   
                                                                    

                                                                
                   






                 ______________________________________________
");
            Console.ResetColor();

            Console.SetCursorPosition(20, 15);
            if (name == null)
                Console.WriteLine("  이름을 입력해 주세요.");
            else
            {
                Console.Write("환영합니다. ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(name + "님");
                Console.ResetColor();
                Console.SetCursorPosition(20, 18);
                Console.WriteLine("방향키 또는 한글 키를 눌러 메뉴를 선택 후,");
                Console.SetCursorPosition(20, 20);
                Console.WriteLine("Enter 또는 spacebar를 입력해 주세요.");
                Console.SetCursorPosition(20, 22);
                Console.WriteLine("이름을 다시 입력하시려면 숫자 0을 눌러주세요.");
            }

            for(int i = 0; i < 4; i++)
            {
                Console.SetCursorPosition(80, i * 2 + 13);
                if (menunumber == i)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(menuNames[i]);
                    Console.ResetColor();
                }
                else
                    Console.Write(menuNames[i]);
            }
        }

        public void InputUserName()
        {
            Console.SetCursorPosition(22, 17);  // 이름 입력 좌표
            name = Console.ReadLine();
        }

        public int SelectMenuButton()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();

            switch (keyInfo.Key)
            {
                case ConsoleKey.Enter:
                case ConsoleKey.Spacebar:
                    return menunumber;
                case ConsoleKey.DownArrow:
                    menunumber += 1;
                    break;
                case ConsoleKey.UpArrow:
                    menunumber -= 1;
                    if (menunumber < 0)
                        menunumber = 3;
                    break;
                case ConsoleKey.D0:
                    name = null;
                    menunumber = -1;
                    break;
                case ConsoleKey.R:
                    menunumber = 0;
                    break;
                case ConsoleKey.S:
                    menunumber = 1;
                    break;
                case ConsoleKey.E:
                    menunumber = 2;
                    break;
                case ConsoleKey.F:
                    menunumber = 3;
                    break;                    
            }
            menunumber %= 4;
            return 5;
        }

        public int Menunumber
        {
            get { return menunumber; }
            set { menunumber = value; }
        }

        public string Name
        {
            get { return name; }
        }
    }
}