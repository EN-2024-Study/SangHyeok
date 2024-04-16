using Microsoft.Office.Interop.Excel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable.Model
{
    public class LectureRepository  // singleton
    {
        private static LectureRepository instance;
        private List<LectureVo> lectureList;
        //private Array data = null; // 행 : 183개, 열 : 12개

        private LectureRepository()
        {
            lectureList = new List<LectureVo>();

            try
            {
                Application application = new Application();
                Workbook workbook = application.Workbooks.Open(Environment.GetFolderPath
                    (Environment.SpecialFolder.DesktopDirectory) + "\\2023년도 1학기 강의시간표");

                Sheets sheets = workbook.Sheets;
                Worksheet worksheet = sheets["Sheet1"] as Worksheet;
                Range cellRange = worksheet.Range["A2", "L185"];
                Array data = cellRange.Cells.Value2;

                application.Workbooks.Close();
                application.Quit();

                LectureVo lectureVo = null;
                for (int i = 1; i <= data.GetLength(0); i++)
                {
                    lectureVo = new LectureVo((Double)data.GetValue(i, 1),
                        (string)data.GetValue(i, 2), (string)data.GetValue(i, 3),
                        (string)data.GetValue(i, 4), (string)data.GetValue(i, 5),
                        (string)data.GetValue(i, 6), (string)data.GetValue(i, 7),
                        (string)data.GetValue(i, 8), (string)data.GetValue(i, 9),
                        (string)data.GetValue(i, 10), (string)data.GetValue(i, 11),
                        (string)data.GetValue(i, 12));
                    lectureList.Add(lectureVo);
                }
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

        public List<LectureVo> LectureList
        { get { return lectureList; } }

        //public Array Data
        //{ get { return data; } }
    }
}