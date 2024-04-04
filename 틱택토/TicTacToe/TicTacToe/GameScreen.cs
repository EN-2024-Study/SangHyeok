using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class GameScreen : Screen
    {
        string[,] numberScreen;

        public GameScreen()
        {
            numberScreen = new string[9, 7]
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
                    "    5           ",
                    "    555555      ",
                    "    5           ",
                    "    55          ",
                    "      555       ",
                    "       555      ",
                    "    5555        "
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

            for(int i = 0; i < 9; i++)
            {
                int x = SetX(i), y = SetY(i);

                if (numberScreen[i, 0].Equals("X              X"))
                    Console.ForegroundColor = ConsoleColor.Green;
                else if (numberScreen[i, 0].Equals("       OO       "))
                    Console.ForegroundColor = ConsoleColor.Blue;

                for (int j = 0; j < 7; j++)
                {
                    Console.SetCursorPosition(x, y + j + 1);
                    Console.Write(numberScreen[i, j]);
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

        //public virtual bool PlayGame(int order)
        //{
        //    int num = InputGameNumber();
        //    if (num == 0)
        //        return false;

        //    ExpressXOrO(order, num);
        //    return true;
        //}

        //public virtual bool CheckEnd() { }

        protected int InputGameNumber()
        {
            Console.SetCursorPosition(100, 12);
            string inputTemp = Console.ReadLine();
            int number;
            if (int.TryParse(inputTemp, out number))
            {
                if (1 <= number && number <= 9)
                    return number;
                else if (number == 0)
                    return 0;
                else
                {
                    ExpressGameNumberError(number.ToString());
                    return InputGameNumber();
                }
            }
            ExpressGameNumberError(inputTemp);
            return InputGameNumber();
        }

        private void ExpressGameNumberError(string stringNumber)
        {
            Console.SetCursorPosition(100, 12);
            for (int i = 0; i < stringNumber.Length; i++)
                Console.Write(" ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(77, 14);
            Console.Write("숫자 오류로 다시 입력해 주세요.");
            Console.ResetColor();
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
    }
}
