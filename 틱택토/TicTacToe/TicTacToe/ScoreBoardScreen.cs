using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class ScoreBoardScreen : Screen
    {
        public override void PrintScreen()
        {
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
        }

        public bool InputBackMenu()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();

            if (keyInfo.Key == ConsoleKey.D0)
                return false;
            return true;
        }
    }
}
