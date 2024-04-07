using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text.RegularExpressions;

namespace TicTacToe
{
    internal class GameScreen : Screen
    {
        private string[,] numberDisplayedToScreen;  
        private string numberString;    // 숫자 입력시 담을 string 자료형
        private int[] coordinates;  

        public GameScreen()
        {
            numberString = null;
            coordinates = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
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
            Console.SetCursorPosition(0, 0);
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

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(77, 10);
            Console.Write("                             ");
            Console.SetCursorPosition(77, 12);
            Console.Write("                             ");
            Console.SetCursorPosition(77, 14);
            Console.Write("                             ");
            Console.SetCursorPosition(77, 16);
            Console.Write("                             ");
            Console.SetCursorPosition(77, 10);
            Console.Write("1부터 9까지를 입력하여");
            Console.SetCursorPosition(77, 12);
            Console.Write("게임을 진행해 주세요 : ");
            Console.ResetColor();

            for (int i = 0; i < 9; i++)
            {
                int x = SetX(i), y = SetY(i);   // 좌표들 그릴 때의 좌표

                switch (coordinates[i])
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

        public void ExpressEnd()    
        {
            Console.SetCursorPosition(77, 14);
            Console.Write("                                      ");
            Console.SetCursorPosition(77, 20);
            Console.Write("                              ");
            Console.SetCursorPosition(77, 22);
            Console.Write("                              ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(77, 16);
            Console.Write("게임이 종료되었습니다!");
            Console.SetCursorPosition(77, 18);
            Console.Write("시작화면으로 돌아가려면");
            Console.SetCursorPosition(77, 20);
            Console.Write("Enter를 눌러주세요.");
            Console.ResetColor();
            string temp = Console.ReadLine();   // enter 키를 입력받기 위함
        }

        public int CheckEnd()   // return 값 = 0: 아직 안 끝남, 1: X 승리, 2: O 승리, 3: 무승부
        {
            for (int i = 0; i < 9; i += 3)
            {
                // 가로 확인
                if (coordinates[i] == 1 && coordinates[i] == coordinates[i + 1] && coordinates[i] == coordinates[i + 2])
                    return 1;
                else if (coordinates[i] == 2 && coordinates[i] == coordinates[i + 1] && coordinates[i] == coordinates[i + 2])
                    return 2;
            }

            for (int i = 0; i < 3; i++)
            {
                // 세로 확인
                if (coordinates[i] == 1 && coordinates[i] == coordinates[i + 3] && coordinates[i] == coordinates[i + 6])
                    return 1;
                else if (coordinates[i] == 2 && coordinates[i] == coordinates[i + 3] && coordinates[i] == coordinates[i + 6])
                    return 2;

                // 대각선 확인
                if (coordinates[i] == 1 && coordinates[i] == coordinates[4] && coordinates[4] == coordinates[8 - i])
                    return 1;
                else if (coordinates[i] == 2 && coordinates[i] == coordinates[4] && coordinates[4] == coordinates[8 - i])
                    return 2;
            }

            foreach(int value in coordinates)
                if (value == 0) 
                    return 0;   // 비어있는 좌표가 있을 경우
            return 3;   // 비어있는 좌표가 없을 경우
        }

        protected void SetCoordinates(int index, int value)
        {
            coordinates[index] = value;
        }

        protected List<int> GetEmptCoordinateValues()
        {
            List<int> list = new List<int>();

            for (int i = 0; i < 9; i++)
            {
                if (coordinates[i] == 0)
                    list.Add(i);
            }
            return list;
        }

        protected int InputGameNumber()
        {
            Console.SetCursorPosition(100, 12);
            string tempInput = Console.ReadLine();
            int number;

            if (tempInput.Length > 1 && '0' <= tempInput[1] && tempInput[1] <= '9')
                return CheckNumberError(tempInput); // 숫자가 두자리 이상일 때 다시 입력받기
            else if (tempInput.Length > 0 && '1' <= tempInput[0] && tempInput[0] <= '9')
            {
                number = (int)tempInput[0] - 48;    // int형으로 변환

                if (number == 0)
                    return 0;   // 시작화면으로 돌아가기
                else
                    return CheckDuplication(number);    // 중복까지 체크 후 반환
            }
            return CheckNumberError(tempInput); // 숫자 오류로 다시 입력
        }

        protected void ExpressXOrO(int order, int index)
        {
            switch (order)
            {
                case 0:
                    coordinates[index] = 1;
                    numberDisplayedToScreen[index, 0] = "X              X";
                    numberDisplayedToScreen[index, 1] = " XX          XX ";
                    numberDisplayedToScreen[index, 2] = "   XX      XX   ";
                    numberDisplayedToScreen[index, 3] = "      XXXX      ";
                    numberDisplayedToScreen[index, 4] = "   XX      XX   ";
                    numberDisplayedToScreen[index, 5] = " XX          XX ";
                    numberDisplayedToScreen[index, 6] = "X              X";
                    break;
                case 1:
                    coordinates[index] = 2;
                    numberDisplayedToScreen[index, 0] = "       OO       ";
                    numberDisplayedToScreen[index, 1] = "    OO    OO    ";
                    numberDisplayedToScreen[index, 2] = "  OO        OO  ";
                    numberDisplayedToScreen[index, 3] = "OO            OO";
                    numberDisplayedToScreen[index, 4] = "  OO        OO  ";
                    numberDisplayedToScreen[index, 5] = "    OO    OO    ";
                    numberDisplayedToScreen[index, 6] = "       OO       ";
                    break;
            }
        }

        private int SetX(int i)
        {
            if (i == 0 || i == 3 || i == 6)
                return 14;  // 1열 좌표
            else if (i == 1 || i == 4 || i == 7)
                return 32;  // 2열 좌표    
            return 51;  // 3열 좌표
        }

        private int SetY(int i)
        {
            if (i <= 2) 
                return 2;   // 1행 좌표
            else if (i <= 5)
                return 11;  // 2행 좌표
            return 20;      // 3행 좌표
        }

        private void ExpressError(string str)
        {
            Console.SetCursorPosition(100, 12);
            if (numberString != null)
                for (int i = 0; i < numberString.Length; i++)
                    Console.Write(" ");
            Console.SetCursorPosition(77, 14);
            Console.Write("                                      ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(77, 14);
            Console.Write(str); // 오류 표시
            Console.ResetColor();
        }

        private int CheckDuplication(int number)
        {
            if (coordinates[number - 1] != 0)
            {
                ExpressError("이미 둔 좌표 입니다! 다시 입력하세요.");
                return InputGameNumber();
            }
            return number;
        }

        private int CheckNumberError(string s)
        {
            numberString = s;
            ExpressError("숫자 오류입니다! 다시 입력하세요.");
            return InputGameNumber();
        }
    }
}
