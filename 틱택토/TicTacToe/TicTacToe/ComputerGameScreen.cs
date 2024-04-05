using System;

namespace TicTacToe
{
    internal class ComputerGameScreen : GameScreen
    {
        private GameScreen gameScreen;
        private int startupOrder;
        private bool isErrornumber;
        public ComputerGameScreen()
        {
            gameScreen = new GameScreen();
            startupOrder = 0;
            isErrornumber = false;
        }

        public override void PrintScreen()
        {
            base.PrintScreen();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(79, 3);
            Console.Write("★USER★  ★COMPUTER★");
            Console.SetCursorPosition(82, 5);
            //Console.Write(ScoreBoardScreen.UserScore + "            " + ScoreBoardScreen.ComputerScore);
            Console.ResetColor();
            Console.SetCursorPosition(77, 10);
            Console.Write("첫번째로 시작하려면 1번을,");
            Console.SetCursorPosition(77, 12);
            Console.Write("두번째로 시작하려면 2번을");
            Console.SetCursorPosition(77, 14);
            Console.Write("눌러주세요: ");

            if (isErrornumber)
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

        public bool InputOrder()
        {
            Console.SetCursorPosition(89, 14);
            string inputTemp = Console.ReadLine();
            int number;
            if (int.TryParse(inputTemp, out number))
            {
                if (number == 0)
                    return false;
                else if (1 <= number && number <= 2)
                {
                    startupOrder = number;
                    isErrornumber = false;
                }
                else
                    isErrornumber = true;
            }
            else
                isErrornumber = true;
            return true;
        }

        //public override bool PlayGame(int order)
        //{
        //    return base.PlayGame(startupOrder);
        //}

        public override bool PlayGame()  // 컴퓨터와 사용자 대결 구현
        {
            int number = base.InputGamenumber();
            if (number == 0)
                return false;

            switch (startupOrder)
            {
                case 1:
                    base.ExpressXOrO(0, number);
                    break;
                case 2:

                    break;
            }
            return base.PlayGame();
        }

        public int StartupOrder
        {
            get { return startupOrder; }
        }

        public bool IsErrornumber
        {
            get { return isErrornumber; }
        }
    }
}
