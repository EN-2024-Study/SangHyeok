using System;
using System.Collections.Generic;
using Microsoft.Office.Interop.Excel;
//using Excel = Microsoft.Office.Interop.Excel;

namespace LectureTimeTable
{
    public class MainProgramcs
    {
        public static void Main(string[] args)
        {
            try
            {
                Application application = new Application();
                Workbook workbook = application.Workbooks.Open(Environment.GetFolderPath
                    (Environment.SpecialFolder.DesktopDirectory) + "\\2023년도 1학기 강의시간표");

                Sheets sheets = workbook.Sheets;
                Worksheet worksheet = sheets["Sheet1"] as Worksheet;
                Range cellRange = worksheet.Range["A1", "C3"] as Range;
                Array data = cellRange.Cells.Value2;
                
                application.Workbooks.Close();
                application.Quit();
            }
            catch(SystemException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
