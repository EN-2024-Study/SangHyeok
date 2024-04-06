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
        private List<string> scoreList; // 진행했던 점수들을 담을 List
        
        public ScoreBoardScreen()
        {
            scoreList = new List<string>();
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
            int y = 9;
            for(int i = 0; i < scoreList.Count; i++)    // 점수 표시
            {
                Console.SetCursorPosition(8, y);
                Console.Write(scoreList[i]);
                y += 4;
            }
            Console.ResetColor();
        }

        public bool InputBackMenu() // 뒤로 돌아가기 입력
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();

            if (keyInfo.Key == ConsoleKey.D0)
                return false;
            return true;
        }

        public void SetScore(int type, int score1, int score2) 
        {
            scoreList.Add("GAME " + scoreList.Count + "   ");
            switch(type)
            {
                case 1:
                    scoreList[scoreList.Count - 1] += "★ USER  : " + score1 + " ★    " + "★COMPUTER : " + score2 + " ★";
                    break;
                case 2:
                    scoreList[scoreList.Count - 1] += "★ USER1 : " + score1 + " ★    " + "★ USER2   : " + score2 + " ★";
                    break;
            }
        }
    }
}
