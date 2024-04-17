using System;
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

            //Console.SetWindowSize(130, 40);
            //LectureRepository instance = LectureRepository.Instance;
            //List<LectureVo> lectureList = instance.LectureList;
            //List<LectureVo> test = new List<LectureVo>()
            //{
            //    lectureList[0],
            //    lectureList[19],
            //    lectureList[21]
            //};
            //LectureTimeScreen lectureScreen = new LectureTimeScreen();
            //lectureScreen.DrawScheduleScreen(test);
        }
    }
}
