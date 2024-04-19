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
        public bool IsOverlapCheck(List<LectureVo> lectureList, LectureVo addCourse)
        {
            bool isDuplication = false;
            string[] times = Constantss.TIMES;
            int[,] matrix = LectureDayManager.GetDayMatrix(lectureList);
            List<string> addCourseDay = LectureDayManager.GetLectureDay(addCourse);

            if (addCourseDay == null)   // 추가할 강의가 k-mooc일 때
                return true;

            int column = LectureDayManager.GetDayMatrixColumn(addCourseDay[0]);
            if (addCourseDay.Count == 3 || addCourseDay.Count == 6)
            {
                int row = LectureDayManager.GetDayMatrixRow(addCourseDay[1]);
                int lastRow = LectureDayManager.GetDayMatrixRow(addCourseDay[2]);

                for (int i = row; i < lastRow; i++)
                    if (matrix[i, column] == 1)
                        isDuplication = true;
            }
            else if (addCourseDay.Count == 4)
            {
                int row = LectureDayManager.GetDayMatrixRow(addCourseDay[2]);
                int lastRow = LectureDayManager.GetDayMatrixRow(addCourseDay[3]);
               
                for (int i = row; i < lastRow; i++)
                    if (matrix[i, column] == 1)
                        isDuplication = true;

                column = LectureDayManager.GetDayMatrixColumn(addCourseDay[1]);
                for (int i = row; i < lastRow; i++)
                    if (matrix[i, column] == 1)
                        isDuplication = true;
            }

            if (addCourseDay.Count == 6)
            {
                column = LectureDayManager.GetDayMatrixColumn(addCourseDay[3]);
                int row = LectureDayManager.GetDayMatrixRow(addCourseDay[4]);
                int lastRow = LectureDayManager.GetDayMatrixRow(addCourseDay[5]);

                for (int i = row; i < lastRow; i++)
                    if (matrix[i, column] == 1)
                        isDuplication = true;
            }

            if (isDuplication)
                return false;
            return true;
        }
    }
}
