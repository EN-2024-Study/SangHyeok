using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class ScoreBoardScreen : Screen
    {
        private List<string> scoreList;
        private int y;
        
        public ScoreBoardScreen()
        {
            scoreList = new List<string>();
            y = 10;
        }
        public override void PrintScreen()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(@"
                         ________                       ________                    _________
                         __  ___/__________________________  __ )___________ _____________  /
                         _____ \_  ___/  __ \_  ___/  _ \_  __  |  __ \  __ `/_  ___/  __  / 
                         ____/ // /__ / /_/ /  /   /  __/  /_/ // /_/ / /_/ /_  /   / /_/ /  
                         /____/ \___/ \____//_/    \___//_____/ \____/\__,_/ /_/    \__,_/   
");

            Console.SetCursorPosition(77, 20);
            Console.Write("이전 화면으로 돌아가실려면");
            Console.SetCursorPosition(77, 22);
            Console.Write("숫자 0 을 눌러주세요.");

            Console.ForegroundColor = ConsoleColor.Yellow;
            for(int i = 0; i < scoreList.Count; i++)
            {
                Console.SetCursorPosition(10, y);
                Console.Write(scoreList[i]);
                y += 4;
            }
            Console.ResetColor();
        }

        public bool InputBackMenu()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();

            if (keyInfo.Key == ConsoleKey.D0)
                return false;
            return true;
        }

        public void SetScore(int type, int score1, int score2)
        {
            switch(type)
            {
                case 1:
                    scoreList.Add("★USER ★   ★COMPUTER★\n");
                    break;
                case 2:
                    scoreList.Add("★USER1★   ★ USER2 ★\n");
                    break;
            }
            scoreList[scoreList.Count - 1] += "             " + score1 + "             " + score2;
        }

        public int GetScoreListCount()
        {
            return scoreList.Count;
        }
    }
}
