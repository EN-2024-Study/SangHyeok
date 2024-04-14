using System;

namespace Library.Utility
{
    public class ExplainingScreen
    {
        public static void ExplainSelectKey()
        {
            Console.SetCursorPosition(75, 21);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("ESC: 뒤로가기");
            Console.SetCursorPosition(75, 22);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("ENTER: 입력하기");
            Console.ResetColor();
        }

        public static void ExplainDirectionKey()
        {
            Console.SetCursorPosition(75, 24);
            Console.Write("방향키를 눌러 모드를");
            Console.SetCursorPosition(75, 25);
            Console.Write("선택해 주세요.");
        }

        public static void ExplainInputKey()
        {
            int x = 75, y = 27;
            Console.SetCursorPosition(x, y);
            Console.Write("커서가 ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("초록색");
            Console.ResetColor();
            Console.Write("이면 Enter를");
            Console.SetCursorPosition(x, y + 1);
            Console.Write("눌러");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("파란색");
            Console.ResetColor();
            Console.Write("으로 만든 후");
            Console.SetCursorPosition(x, y + 2);
            Console.Write("정보를 입력하세요.");
        }

        public static void PrintQuit()
        {
            Console.SetCursorPosition(75, 21);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("ESC: 종료하기");
            Console.ResetColor();
        }

        public static void PrintInputFailure(Tuple<int, int> coordinate)
        {
            Console.SetCursorPosition(coordinate.Item1, coordinate.Item2);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("[Fail]");
            Console.ResetColor();
        }

        public static void PrintEnterCheck()
        {
            Console.SetCursorPosition(60, 32);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("다음은 Enter키를 눌러주세요.");
            Console.ResetColor();
        }

        public static void PrintIncorrectInput()
        {
            Console.SetCursorPosition(60, 32);
            Console.Write("                                            ");
            Console.SetCursorPosition(60, 32);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("입력 정보가 맞지 않습니다.");
            Console.SetCursorPosition(60, 33);
            Console.Write("돌아가려면 Enter를 눌러주세요.");
            Console.ResetColor();
        }

        public static void PrintEsc()
        {
            Console.SetCursorPosition(20, 6);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("ESC : 뒤로가기");
            Console.ResetColor();
        }

        public static void PrintEnter()
        {
            Console.SetCursorPosition(20, 7);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("ENTER : 선택하기");
            Console.ResetColor();
        }

        public static void PrintComplete(string str)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(20, 10);
            Console.WriteLine(str);
            ExplainingScreen.PrintEnterCheck();
            Console.ResetColor();
        }

        public static void PrintIdInputString(string str)
        {
            Console.SetCursorPosition(5, 3);
            Console.WriteLine(str);
        }

        public static void PrintBookInfo(string str)
        {
            Console.SetCursorPosition(35, 1); ;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(str);
            Console.Write(@"

=======================================================================================




















                            책 제목 - 영어, 한글, 숫자 1개 이상
                            작가    - 영어, 한글 1글자 이상
                            출판사  - 영어, 한글, 숫자 1개 이상
                            수량    - 1 ~ 999 사이의 자연수
                            가격    - 1 ~ 99999 사이의 자연수
                            출시일  - 20xx-xx-xx
                            ISBN    - 정수 9개 + 영어 1개 + 공백 + 정수 13개
                            정보    - 최소 1개의 문자 (공백 포함)
");
            Console.ResetColor();
        }
    }
}
