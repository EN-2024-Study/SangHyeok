using System;
using Library.Controller;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class MainProgram
    {
        public static void Main(string[] args)
        {
            MenuController menu = new MenuController();
            menu.ControllModeMenu();
        }
    }
}
