using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class StartScreen : Screen
    {
        int menuNumber;
        string name;

        public StartScreen()
        {
            menuNumber = -1;
            name = null;
        }

        public override void PrintScreen()
        {
            string startString = @"
     ____________________________________________________________________
     ___  __/___  _/_  ____/__  __/__    |_  ____/__  __/_  __ \__  ____/
     __  /   __  / _  /    __  /  __  /| |  /    __  /  _  / / /_  __/   
     _  /   __/ /  / /___  _  /   _  ___ / /___  _  /   / /_/ /_  /___   
     /_/    /___/  \____/  /_/    /_/  |_\____/  /_/    \____/ /_____/   
                                                                    

                                                                
                   






                 ______________________________________________
";
            byte[] bytes = Encoding.Default.GetBytes(startString);
            startString = Encoding.UTF8.GetString(bytes);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(startString);
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

            Console.SetCursorPosition(80, 13);
            if (menuNumber == 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("㉠  vs Computer");
                Console.ResetColor();
            }
            else
            {
                Console.ResetColor();
                Console.WriteLine("㉠  vs Computer");
            }

            Console.SetCursorPosition(80, 15);
            if (menuNumber == 1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("㉡  vs User");
                Console.ResetColor();
            }
            else
            {
                Console.ResetColor();
                Console.WriteLine("㉡  vs User");
            }

            Console.SetCursorPosition(80, 17);
            if (menuNumber == 2)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("㉢  ScoreBoard");
                Console.ResetColor();
            }
            else
            {
                Console.ResetColor();
                Console.WriteLine("㉢  ScoreBoard");
            }

            Console.SetCursorPosition(80, 19);
            if (menuNumber == 3)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("㉣  Quit");
                Console.ResetColor();
            }
            else
            {
                Console.ResetColor();
                Console.WriteLine("㉣  Quit");
            }
        }

        public void InputUserName()
        {
            Console.SetCursorPosition(22, 17);  // 이름 입력 좌표
            name = Console.ReadLine();
        }

        public void SelectMenuButton()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();

            switch (keyInfo.Key)
            {
                case ConsoleKey.Enter:
                case ConsoleKey.Spacebar:
                    switch (menuNumber)
                    {
                        case 0:
                            ScreenControl.IsStartScreen = false;
                            ScreenControl.IsComputerGameScreen = true;
                            break;
                        case 1:
                            ScreenControl.IsStartScreen = false;
                            ScreenControl.IsUserGameScreen = true;
                            break;
                        case 2:
                            ScreenControl.IsStartScreen = false;
                            ScreenControl.IsScoreBoard = true;
                            break;
                        case 3:
                            ScreenControl.Quit = true;
                            break;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    menuNumber += 1;
                    break;
                case ConsoleKey.UpArrow:
                    menuNumber -= 1;
                    if (menuNumber < 0)
                        menuNumber = 3;
                    break;
                case ConsoleKey.D0:
                    name = null;
                    menuNumber = -1;
                    
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
        }

        public int MenuNumber
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
