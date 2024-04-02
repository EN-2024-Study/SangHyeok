using System;
using System.Security.Cryptography;

namespace StarPrint
{
    public class CodeFile1
    {
        public static void Main(string[] args)
        {
            Screen screen = new Screen();   // 각각의 화면들을 담당하는 클래스
            screen.PrintScreen();
        }
    }
}
