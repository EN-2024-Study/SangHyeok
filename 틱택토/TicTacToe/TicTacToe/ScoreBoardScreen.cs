using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class ScoreBoardScreen : Screen
    {
        private static int userScore, oneUserScore, twoUserScore, computerScore;

        public override void PrintScreen()
        {
        }

        public static int UserScore
        {
            get { return userScore; }
            set { userScore = value; }
        }

        public static int OneUserScore
        {
            get { return oneUserScore; }
            set { oneUserScore = value; }
        }

        public static int TwoUserScore
        {
            get { return twoUserScore; }
            set { twoUserScore = value; }
        }

        public static int ComputerScore
        {
            get { return computerScore; }
            set { computerScore = value; }
        }
    }
}
