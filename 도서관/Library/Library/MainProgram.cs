using System;
using Library.Controller;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Utility;
using System.Text.RegularExpressions;

namespace Library
{
    public class MainProgram
    {
        public static void Main(string[] args)
        {
            MenuController menu = new MenuController();
            menu.ControllModeMenu();

            //string str = Console.ReadLine();
            //Regex regex1 = new Regex(@"^[a-zA-Z가-힣]{1,10}$");
            //if (regex1.IsMatch(str))
            //    Console.WriteLine("성공");
            //else
            //    Console.WriteLine("실패");
        }
    }
}
