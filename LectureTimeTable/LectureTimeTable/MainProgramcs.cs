﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using LectureTimeTable.Controller;
using LectureTimeTable.Model;
using LectureTimeTable.View;
using Microsoft.Office.Interop.Excel;
//using Excel = Microsoft.Office.Interop.Excel;

namespace LectureTimeTable
{
    public class MainProgramcs
    {
        public static void Main(string[] args)
        {
            MenuController menu = new MenuController();
            menu.ControlLogInMenu();
        }
    }
}
