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
            string[] times = Constantss.TIMES;
            List<List<string>> dayList = GetDayList(lectureList);
            int[,] matrix = new int[27, 5];
            List<string> course = new List<string>();            

            string[] temp = addCourse.Day.Split(new char[] { ' ', ',', '~' });
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i].Equals(""))
                    continue;
                course.Add(temp[i]);    // 검사할 addCourse를 split해서 저장
            }

            foreach (List<string> value in dayList) 
            {
                int col = SetCol(value[0]);
                int row = -1;
                int lastRow = -1;

                if (value.Count == 3)   // 요일이 하나일 때
                {
                    for (int i = 0; i < times.Length; i++)
                    {
                        if (row == -1 && times[i].Equals(value[1]))
                            row = i;
                        else if (times[i].Equals(value[2]))
                        {
                            lastRow = i;
                            break;
                        }
                    }
                    for (int i = row; i < lastRow; i++)
                        matrix[i, col] = 1;
                }
                else if (value.Count == 4)  // 요일이 두개에 시간이 같을 때
                {
                    for (int i = 0; i < times.Length; i++)
                    {
                        if (row == -1 && times[i].Equals(value[2]))
                            row = i;
                        else if (times[i].Equals(value[3]))
                        {
                            lastRow = i;
                            break;
                        }
                    }
                    for (int i = row; i < lastRow; i++)
                        matrix[i, col] = 1;

                    col = SetCol(value[1]);
                    for (int i = row; i < lastRow; i++)
                        matrix[i, col] = 1;
                }
                else if (value.Count == 6)  // 요일이 두개에 시간이 다를 때
                {
                    for (int i = 0; i < times.Length; i++)
                    {
                        if (row == -1 && times[i].Equals(value[1]))
                            row = i;
                        else if (times[i].Equals(value[2]))
                        {
                            lastRow = i;
                            break;
                        }
                    }

                    for (int i = row; i < lastRow; i++)
                        matrix[i, col] = 1;

                    col = SetCol(value[3]);
                    row = -1;
                    lastRow = -1;

                    for (int i = 0; i < times.Length; i++)
                    {
                        if (row == -1 && times[i].Equals(value[4]))
                            row = i;
                        else if (times[i].Equals(value[5]))
                        {
                            lastRow = i;
                            break;
                        }
                    }

                    for (int i = row; i < lastRow; i++)
                        matrix[i, col] = 1;
                }
            }

            int col2 = SetCol(course[0]);
            int row2 = -1;
            int lastRow2 = -1;
            bool isDuplication = false;
            if (course.Count == 3)
            {
                for (int i = 0; i < times.Length; i++)
                {
                    if (row2 == -1 && times[i].Equals(course[1]))
                        row2 = i;
                    else if (times[i].Equals(course[2]))
                    {
                        lastRow2 = i;
                        break;
                    }
                }
                for (int i = row2; i < lastRow2; i++)
                    if (matrix[i, col2] == 1)
                        isDuplication = true;
            }
            else if (course.Count == 4)
            {
                for (int i = 0; i < times.Length; i++)
                {
                    if (row2 == -1 && times[i].Equals(course[2]))
                        row2 = i;
                    else if (times[i].Equals(course[3]))
                    {
                        lastRow2 = i;
                        break;
                    }
                }
                for (int i = row2; i < lastRow2; i++)
                    if (matrix[i, col2] == 1)
                        isDuplication = true;

                col2 = SetCol(course[1]);
                for (int i = row2; i < lastRow2; i++)
                    if (matrix[i, col2] == 1)
                        isDuplication = true;
            }
            else if (course.Count == 6)
            {
                for (int i = 0; i < times.Length; i++)
                {
                    if (row2 == -1 && times[i].Equals(course[1]))
                        row2 = i;
                    else if (times[i].Equals(course[2]))
                    {
                        lastRow2 = i;
                        break;
                    }
                }

                for (int i = row2; i < lastRow2; i++)
                    if (matrix[i, col2] == 1)
                        isDuplication = true;

                col2 = SetCol(course[3]);
                row2 = -1;
                lastRow2 = -1;

                for (int i = 0; i < times.Length; i++)
                {
                    if (row2 == -1 && times[i].Equals(course[4]))
                        row2 = i;
                    else if (times[i].Equals(course[5]))
                    {
                        lastRow2 = i;
                        break;
                    }
                }

                for (int i = row2; i < lastRow2; i++)
                    if (matrix[i, col2] == 1)
                        isDuplication = true;
            }

            if (isDuplication)
                return false;
            return true;
        }

        public static List<List<string>> GetDayList(List<LectureVo> lectureList)
        {
            List<List<string>> dayList = new List<List<string>>();

            foreach (LectureVo lecture in lectureList)
            {
                if (lecture.Day == null)
                    continue;

                List<string> strings = new List<string>();  // split으로 나눈 값들을 list에 저장
                string[] temp = lecture.Day.Split(new char[] { ' ', ',', '~' });              

                for (int i = 0; i < temp.Length; i++)
                {
                    if (temp[i].Equals(""))
                        continue;
                    strings.Add(temp[i]);
                }

                dayList.Add(strings);   // 저장한 list들을 dayList에 저장
            }

            return dayList;
        }

        public static int SetCol(string day)
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
    }
}
