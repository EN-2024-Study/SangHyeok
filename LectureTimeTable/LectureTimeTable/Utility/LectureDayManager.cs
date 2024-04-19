using LectureTimeTable.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable.Utility
{
    public class LectureDayManager
    {
        public static List<string> GetLectureDay(LectureVo lecture)
        {
            List<string> day = new List<string>();
            string[] temp = null;

            if (lecture.Day == null)  // 시간이 없는 kmooc 제외
                return null;

            temp = lecture.Day.Split(new char[] { ' ', ',', '~' });
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i].Equals(""))
                    continue;
                day.Add(temp[i]);    // 검사할 addCourse를 split해서 저장
            }

            return day;
        }

        public static int[,] GetDayMatrix(List<LectureVo> lectureList)
        {   // 여기서 matrix 한번에 저장하고 ExceptionManager에서 사용하기
            int[,] matrix = new int[27, 5];

            foreach (LectureVo lecture in lectureList)
            {
                List<string> day = GetLectureDay(lecture);
                if (day == null)    // k-mooc 제외한 강좌들 요일 및 시간 저장
                    continue;

                int col = GetDayMatrixColumn(day[0]);
                if (day.Count == 3 || day.Count == 6)   // 요일이 하나일 때
                    matrix = Set(matrix, col, day[1], day[2]);
                else if (day.Count == 4)  // 요일이 두개에 시간이 같을 때
                {
                    matrix = Set(matrix, col, day[2], day[3]);
                    matrix = Set(matrix, GetDayMatrixColumn(day[1]), day[2], day[3]);
                }

                if (day.Count == 6)  // 요일이 두개에 시간이 다를 때
                {
                    col = GetDayMatrixColumn(day[3]); // 요일마다 시간이 다르므로 2번 수행
                    matrix = Set(matrix, col, day[4], day[5]);
                }
            }

            int[,] Set(int[,] tempmMatrix, int column, string startTime, string endTime)
            {
                int row = GetDayMatrixRow(startTime);
                int lastRow = GetDayMatrixRow(endTime);

                for (int i = row; i < lastRow; i++)
                    tempmMatrix[i, column] = 1;
                return tempmMatrix;
            }
            return matrix;
        }

        public static int GetDayMatrixColumn(string day)
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

        public static int GetDayMatrixRow(string day)
        {
            string[] times = Constantss.TIMES;

            for (int i = 0; i < times.Length; i++)
                if (times[i].Equals(day))
                    return i;
            return -1;
        }
    }
}
