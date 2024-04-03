using System;

namespace TicTacToe
{
    internal class ComputerGameScreen : Screen
    {
        int startupOrder;
        bool isErrorNumber;
        public ComputerGameScreen()
        {
            startupOrder = 0;
            isErrorNumber = false;
        }

        public override void PrintScreen()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(84, 1);
            Console.Write("<ScoreBoard>");
            Console.SetCursorPosition(79, 3);
            Console.Write("★USER★  ★COMPUTER★");
            Console.SetCursorPosition(82, 5);
            Console.Write(ScoreBoardScreen.UserScore + "            " + ScoreBoardScreen.ComputerScore);
            Console.SetCursorPosition(79, 7);
            Console.WriteLine("★★★★★★★★★★★");
            Console.SetCursorPosition(5, 0);
            Console.ResetColor();
            Console.Write(@"
#########################################################
#########################################################
##       1        ##      2222       ##      333       ##
##      11        ##     2    2      ##    3    3      ##
##     1 1        ##    2     2      ##   3    33      ##
##    1  1        ##         2       ##      333       ##
##       1        ##        2        ##   3    33      ##
##       1        ##       2         ##    3    3      ##
##    1111111     ##    222222222    ##     33333      ##
#########################################################
#########################################################
##      44        ##     5           ##        6       ##
##     4 4        ##     555555      ##      6         ##
##    4  4        ##     5           ##    66          ##
##  4444444444    ##     5555        ##   66666666     ##
##       4        ##         55      ##   66     66    ##
##       4        ##         55      ##    66    66    ##
##       4        ##     5555        ##     66666      ##
#########################################################
#########################################################
##   7777777      ##      888        ##     9999       ##
##   7     7      ##    88   88      ##   99   99      ##
##   7     7      ##    88   88      ##   99   99      ##
##         7      ##      888        ##     99999      ##
##         7      ##    88   88      ##         9      ##
##         7      ##    88   88      ##         9      ##
##         7      ##      888        ##         9      ##
#########################################################
#########################################################
");
            Console.SetCursorPosition(77, 10);
            Console.Write("첫번째로 시작하려면 1번을,");
            Console.SetCursorPosition(77, 12);
            Console.Write("두번째로 시작하려면 2번을");
            Console.SetCursorPosition(77, 14);
            Console.Write("눌러주세요: ");
            if (isErrorNumber)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(77, 16);
                Console.Write("숫자 1 또는 2를 입력해 주세요.");
                Console.ResetColor();
            }
            else if (startupOrder != 0)
            {
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
            }
        }

        public void InputOrder()
        {
            Console.SetCursorPosition(89, 14);
            string inputTemp = Console.ReadLine();
            int number;
            if (int.TryParse(inputTemp, out number))
            {
                if (1 <= number && number <= 2)
                {
                    startupOrder = number;
                    isErrorNumber = false;
                }
                else
                    isErrorNumber = true;
            }
            else
                isErrorNumber = true;
        }

        public void PlayGame()  // 컴퓨터와 사용자 대결 구현
        {
            int number = InputGameNumber();
            switch (startupOrder)
            {
                case 1:

                    break;
                case 2:

                    break;
            }
        }

        public int StartupOrder
        {
            get { return startupOrder; }
        }

        public bool IsErrorNumber
        {
            get { return isErrorNumber; }
        }

        private int InputGameNumber()
        {
            Console.SetCursorPosition(100, 12);
            string inputTemp = Console.ReadLine();
            int number;
            if (int.TryParse(inputTemp, out number))
            {
                if (1 <= number && number <= 9)
                    return number;
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
    }

}
