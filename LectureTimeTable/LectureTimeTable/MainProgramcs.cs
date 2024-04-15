using System;
using System.Collections.Generic;
using LectureTimeTable.Controller;
using Microsoft.Office.Interop.Excel;
//using Excel = Microsoft.Office.Interop.Excel;

namespace LectureTimeTable
{
    public class MainProgramcs
    {
        public static void Main(string[] args)
        {
            Console.SetWindowSize(130, 40);
            MenuController menu = new MenuController();
            menu.ControlLogIn();
        }
    }
}
