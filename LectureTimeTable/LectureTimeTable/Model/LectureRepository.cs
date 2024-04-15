using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable.Model
{
    public class LectureRepository  // singleton
    {
        private static LectureRepository instance;
        private Array data;

        private LectureRepository()
        {
            try
            {
                Application application = new Application();
                Workbook workbook = application.Workbooks.Open(Environment.GetFolderPath
                    (Environment.SpecialFolder.DesktopDirectory) + "\\2023년도 1학기 강의시간표");

                Sheets sheets = workbook.Sheets;
                Worksheet worksheet = sheets["Sheet1"] as Worksheet;
                Range cellRange = worksheet.Range["A1", "L184"] as Range;
                this.data = cellRange.Cells.Value2;

                application.Workbooks.Close();
                application.Quit();
            }
            catch (SystemException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static LectureRepository Instance
        {
            get
            {
                if (instance == null)
                    instance = new LectureRepository();
                return instance;
            }
        }

        public Array Data
        { get { return data; } }
    }
}