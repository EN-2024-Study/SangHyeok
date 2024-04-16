using System;
using System.Collections.Generic;
using LectureTimeTable.Controller;
using LectureTimeTable.Model;
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


            //LectureRepository lecture = LectureRepository.Instance;
            //Array data = lecture.Data;
            //Console.SetWindowSize(170, 40);

            //for (int j = 1; j <= data.GetLength(1); j++)
            //{
            //    Console.WriteLine(data.GetValue(1, j).GetType());
            //}

        }
    }
}
