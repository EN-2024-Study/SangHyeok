using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class GameScreen : Screen
    {
        private string[,] numberDisplayedToScreen;
        private string numberString;
        private int[] numberCoordinate;

        public GameScreen()
        {
            numberString = null;
            numberCoordinate = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            numberDisplayedToScreen = new string[9, 7]
            {
                {
                    "       1        ",
                    "     111        ",
                    "    1  1        ",
                    "       1        ",
                    "       1        ",
                    "       1        ",
                    "    1111111     "
                },
                {
                    "      22        ",
                    "    22  22      ",
                    "   2      2     ",
                    "         22     ",
                    "        2       ",
                    "      2         ",
                    "   222222222    "
                },
                {
                    "      333       ",
                    "    33   3      ",
                    "   3     33     ",
                    "      33333     ",
                    "   3     33     ",
                    "    33   3      ",
                    "      333       "
                },
                {
                    "       44       ",
                    "      4 4       ",
                    "     4  4       ",
                    "    44444444    ",
                    "        4       ",
                    "        4       ",
                    "        4       "
                },
                {
                    "     5          ",
                    "     555555     ",
                    "     5          ",
                    "     55         ",
                    "       555      ",
                    "        555     ",
                    "     5555       "
                },
                {
                    "        6       ",
                    "       6        ",
                    "     66666      ",
                    "    6     6     ",
                    "   6       6    ",
                    "     6    6     ",
                    "      666       "
                },
                {
                    "    7777777     ",
                    "    7     7     ",
                    "    7     7     ",
                    "          7     ",
                    "          7     ",
                    "          7     ",
                    "          7     "
                },
                {
                    "      888      ",
                    "    88   88    ",
                    "    88   88    ",
                    "      888      ",
                    "    88   88    ",
                    "    88   88    ",
                    "      888      "
                },
                {
                    "      999       ",
                    "    99   99     ",
                    "    99   99     ",
                    "      99999     ",
                    "         99     ",
                    "          9     ",
                    "          9     "
                }
            };
        }

        public override void PrintScreen()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(@"
            #########################################################
            #########################################################
            ##                ##                 ##                ##
            ##                ##                 ##                ##
            ##                ##                 ##                ##
            ##                ##                 ##                ##
            ##                ##                 ##                ##
            ##                ##                 ##                ##
            ##                ##                 ##                ##
            #########################################################
            #########################################################
            ##                ##                 ##                ##
            ##                ##                 ##                ##
            ##                ##                 ##                ##
            ##                ##                 ##                ##
            ##                ##                 ##                ##
            ##                ##                 ##                ##
            ##                ##                 ##                ##
            #########################################################
            #########################################################
            ##                ##                 ##                ##
            ##                ##                 ##                ##
            ##                ##                 ##                ##
            ##                ##                 ##                ##
            ##                ##                 ##                ##
            ##                ##                 ##                ##
            ##                ##                 ##                ##
            #########################################################
            #########################################################
            ");
            Console.ResetColor();

            for (int i = 0; i < 9; i++)
            {
                int x = SetX(i), y = SetY(i);

                switch(numberCoordinate[i])
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        break;
                }

                for (int j = 0; j < 7; j++)
                {
                    Console.SetCursorPosition(x, y + j + 1);
                    Console.Write(numberDisplayedToScreen[i, j]);
                }
                Console.ResetColor();
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(84, 1);
            Console.Write("<ScoreBoard>");
            Console.SetCursorPosition(79, 7);
            Console.WriteLine("★★★★★★★★★★★");
            Console.SetCursorPosition(77, 20);
            Console.Write("이전 화면으로 돌아가실려면");
            Console.SetCursorPosition(77, 22);
            Console.Write("숫자 0 을 눌러주세요.");
            Console.ResetColor();
        }

        public virtual bool PlayGame()
        {
            return true;
        }

        public bool CheckEnd()
        {
            // 게임이 끝났는지 확인


            return false;
        }

        protected int InputGamenumber()
        {
            Console.SetCursorPosition(100, 12);
            string inputTemp = Console.ReadLine();
            int number;

            if (int.TryParse(inputTemp, out number))
            {
                if (number == 0)
                    return 0;
                else if (1 <= number && number <= 9)
                {
                    numberString = number.ToString();
                    return CheckDuplication(number);
                }
            }
            return CheckNumberError(inputTemp);
        }

        protected void ExpressXOrO(int order, int number)
        {
            switch (order)
            {
                case 0:
                    numberCoordinate[number - 1] = 1;
                    numberDisplayedToScreen[number - 1, 0] = "X              X";
                    numberDisplayedToScreen[number - 1, 1] = " XX          XX ";
                    numberDisplayedToScreen[number - 1, 2] = "   XX      XX   ";
                    numberDisplayedToScreen[number - 1, 3] = "      XXXX      ";
                    numberDisplayedToScreen[number - 1, 4] = "   XX      XX   ";
                    numberDisplayedToScreen[number - 1, 5] = " XX          XX ";
                    numberDisplayedToScreen[number - 1, 6] = "X              X";
                    break;
                case 1:
                    numberCoordinate[number - 1] = 2;
                    numberDisplayedToScreen[number - 1, 0] = "       OO       ";
                    numberDisplayedToScreen[number - 1, 1] = "    OO    OO    ";
                    numberDisplayedToScreen[number - 1, 2] = "  OO        OO  ";
                    numberDisplayedToScreen[number - 1, 3] = "OO            OO";
                    numberDisplayedToScreen[number - 1, 4] = "  OO        OO  ";
                    numberDisplayedToScreen[number - 1, 5] = "    OO    OO    ";
                    numberDisplayedToScreen[number - 1, 6] = "       OO       ";
                    break;
            }
        }

        private int SetX(int i)
        {
            if (i == 0 || i == 3 || i == 6)
                return 14;
            else if (i == 1 || i == 4 || i == 7)
                return 32;
            return 51;
        }

        private int SetY(int i)
        {
            if (i <= 2)
                return 2;
            else if (i <= 5)
                return 11;
            return 20;
        }

        private int CheckDuplication(int number)
        {
            if (numberCoordinate[number - 1] != 0)
            {
                ExpressError("이미 둔 좌표 입니다. 다시 입력하세요.");
                return InputGamenumber();
            }
            return number;
        }

        private int CheckNumberError(string s)
        {
            numberString = s;
            ExpressError("숫자 오류입니다. 다시 입력하세요.");
            return InputGamenumber();
        }

        private void ExpressError(string str)
        {
            Console.SetCursorPosition(100, 12);
            for (int i = 0; i < numberString.Length; i++)
                Console.Write(" ");
            Console.SetCursorPosition(77, 14);
            Console.Write("                                      ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(77, 14);
            Console.Write(str);
            Console.ResetColor();
        }
    }
}
