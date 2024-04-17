using System;
using System.Collections.Generic;
using System.Text;
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



            //Console.SetWindowSize(180, 40);
            //LectureTimeScreen a = new LectureTimeScreen();
            //LectureRepository lecture = LectureRepository.Instance;
            //List<LectureVo> b = lecture.LectureList;
            //a.DrawSheetScreen(b);



        }
    }
}
