using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class GameScreen : Screen
    {
        public override void PrintScreen()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(84, 1);
            Console.Write("<ScoreBoard>");
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
        }

        protected int InputGameNumber()
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
