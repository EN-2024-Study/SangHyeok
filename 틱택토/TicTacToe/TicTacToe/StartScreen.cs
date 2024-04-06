using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class StartScreen : Screen
    {
        private int menuNumber;
        private string[] menuNames; // 메뉴 이름들
        private string name;
        private int nameLength;

        public StartScreen()
        {
            nameLength = 0;
            menuNumber = -1;
            menuNames = new string[] { "㉠  vs Computer", "㉡  vs User", "㉢  ScoreBoard", "㉣  Quit" };
            name = null;
        }

        public override void PrintScreen()
        {
            Console.SetCursorPosition(0, 0);
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
            {
                Console.Write("                                           ");
                Console.SetCursorPosition(20, 18);
                Console.Write("                                            ");
                Console.SetCursorPosition(20, 20);
                Console.Write("                                            ");
                Console.SetCursorPosition(20, 22);
                Console.Write("                                            ");
                Console.SetCursorPosition(20, 15);
                Console.WriteLine("  이름을 입력해 주세요.");

            }
            else
            {
                Console.SetCursorPosition(22, 17);
                for (int i = 0; i < nameLength; i++)
                    Console.Write(" ");

                Console.Write("                                    ");
                Console.SetCursorPosition(22, 17);
                Console.Write("                                    ");
                Console.SetCursorPosition(20, 15);
                Console.Write("환영합니다. ");
                Console.ForegroundColor = ConsoleColor.Blue;
                if (name.Length > 15)
                {
                    for (int i = 0; i < 15; i++)
                        Console.Write(name[i]);
                    Console.Write("...님");
                }    
                else
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
                if (menuNumber == i)    // 해당 메뉴가 선택되었을 때
                    Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(menuNames[i]);
                Console.ResetColor();
            }
        }

        public void InputUserName()     // 사용자 이름 입력 
        {
            Console.SetCursorPosition(22, 17);  
            name = Console.ReadLine();
            nameLength = name.Length;
        }

        public int SelectMenuButton()   // 메뉴 선택
        {
            Console.SetCursorPosition(110, 20);
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            switch (keyInfo.Key)
            {
                case ConsoleKey.Enter:
                case ConsoleKey.Spacebar:
                    return menuNumber;  // enter, spacebar가 눌렸을 때 해당 메뉴 반환
                case ConsoleKey.DownArrow:
                    menuNumber += 1;
                    break;
                case ConsoleKey.UpArrow:
                    menuNumber -= 1;
                    if (menuNumber < 0)
                        menuNumber = 3;
                    break;
                case ConsoleKey.D0:
                    name = null;    // 사용자 이름 다시 받기
                    nameLength = 0;
                    break;
                case ConsoleKey.R:
                    menuNumber = 0;
                    break;
                case ConsoleKey.S:
                    menuNumber = 1;
                    break;
                case ConsoleKey.E:
                    menuNumber = 2;
                    break;
                case ConsoleKey.F:
                    menuNumber = 3;
                    break;                    
            }
            menuNumber %= 4;
            Console.SetCursorPosition(110, 20);
            Console.Write(" ");
            return -1;  // enter, spacebar 입력이 아닐 때
        }

        public int Menunumber
        {
            get { return menuNumber; }
            set { menuNumber = value; }
        }

        public string Name
        {
            get { return name; }
        }
    }
}