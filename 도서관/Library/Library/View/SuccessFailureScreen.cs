using Library.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.View
{
    public class SuccessFailureScreen
    {

        public void PrintSuccessFailure(Tuple<int, int> coordinate, bool success)
        {
            Console.SetCursorPosition(coordinate.Item1, coordinate.Item2);
            if (success)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("[Sussess!]");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("[Fail]");
                Console.ResetColor();
            }

        }
    }
}
