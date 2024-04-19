using System;
using LectureTimeTable.Controller;
using LectureTimeTable.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable.Utility
{
    public class ExceptionManager
    {
        private LectureInfoController lectureInfoController;

        public ExceptionManager()
        {
            this.lectureInfoController = new LectureInfoController();
        }

        public bool IsOverlapCheck(List<LectureVo> lectureList, LectureVo addCourse)
        {
            bool isDuplication = false;
            string[] times = Constantss.TIMES;
            int[,] matrix = new int[27, 5];
            List<string> addCourseDay = lectureInfoController.GetLectureDay(addCourse);

            if (addCourseDay == null)   // 추가할 강의가 k-mooc일 때
                return true;

            foreach (LectureVo lecture in lectureList)
            {
                List<string> day = lectureInfoController.GetLectureDay(addCourse);
                if (day == null)    // k-mooc 제외한 강좌들 요일 및 시간 저장
                    continue;

                int col = GetDayMatrixColumn(day[0]);
                if (day.Count == 3 || day.Count == 6)   // 요일이 하나일 때
                    matrix = SetMatrix(matrix, col, day[1], day[2]);
                else if (day.Count == 4)  // 요일이 두개에 시간이 같을 때
                {
                    matrix = SetMatrix(matrix, col, day[2], day[3]);
                    matrix = SetMatrix(matrix, GetDayMatrixColumn(day[1]), day[2], day[3]);
                }

                if (day.Count == 6)  // 요일이 두개에 시간이 다를 때
                {
                    col = GetDayMatrixColumn(day[3]); // 요일마다 시간이 다르므로 2번 수행
                    matrix = SetMatrix(matrix, col, day[4], day[5]);
                }
            }

            int column = GetDayMatrixColumn(addCourseDay[0]);
            if (addCourseDay.Count == 3 || addCourseDay.Count == 6)
            {
                int row = GetDayMatrixRow(addCourseDay[1]);
                int lastRow = GetDayMatrixRow(addCourseDay[2]);

                for (int i = row; i < lastRow; i++)
                    if (matrix[i, column] == 1)
                        isDuplication = true;
            }
            else if (addCourseDay.Count == 4)
            {
                int row = GetDayMatrixRow(addCourseDay[2]);
                int lastRow = GetDayMatrixRow(addCourseDay[3]);
               
                for (int i = row; i < lastRow; i++)
                    if (matrix[i, column] == 1)
                        isDuplication = true;

                column = GetDayMatrixColumn(addCourseDay[1]);
                for (int i = row; i < lastRow; i++)
                    if (matrix[i, column] == 1)
                        isDuplication = true;
            }

            if (addCourseDay.Count == 6)
            {
                column = GetDayMatrixColumn(addCourseDay[3]);
                int row = GetDayMatrixRow(addCourseDay[4]);
                int lastRow = GetDayMatrixRow(addCourseDay[5]);

                for (int i = row; i < lastRow; i++)
                    if (matrix[i, column] == 1)
                        isDuplication = true;
            }

            if (isDuplication)
                return false;
            return true;
        }

        private static int[,] SetMatrix(int[,] matrix, int column, string startTime, string endTime)
        {
            int row = GetDayMatrixRow(startTime);   
            int lastRow = GetDayMatrixRow(endTime);   

            for (int i = row; i < lastRow; i++)
                matrix[i, column] = 1;
            return matrix;
        }

        private static int GetDayMatrixColumn(string day)
        {
            int result = -1;
            if (day.Equals("월"))
                result = 0;
            else if (day.Equals("화"))
                result = 1;
            else if (day.Equals("수"))
                result = 2;
            else if (day.Equals("목"))
                result = 3;
            else if (day.Equals("금"))
                result = 4;
            return result;
        }

        private static int GetDayMatrixRow(string day)
        {
            string[] times = Constantss.TIMES;

            for (int i = 0; i < times.Length; i++)
                if (times[i].Equals(day))
                    return i;
            return -1;
        }
    }
}
