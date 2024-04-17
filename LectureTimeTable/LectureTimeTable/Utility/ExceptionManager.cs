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
            string[] times = new string[] {"08:30", "09:00", "09:30", "10:00", "10:30" ,
                "11:00", "11:30" , "12:00", "12:30" , "13:00", "13:30" ,
                "14:00", "14:30" , "15:00", "15:30" , "16:00", "16:30" ,
                "17:00", "17:30" , "18:00", "18:30" , "19:00", "19:30" ,
                "20:00", "20:30" , "21:00", "21:30" };
            List<List<string>> dayList = new List<List<string>>();
            int[,] matrix = new int[27, 5];
            List<string> course = new List<string>();

            foreach (LectureVo lecture in lectureList)
            {
                if (lecture.Day == null)
                    continue;

                string[] temp2 = lecture.Day.Split(new char[] { ' ', ',', '~' });
                List<string> strings = new List<string>();  // split으로 나눈 값들을 list에 저장

                for (int i = 0; i < temp2.Length; i++)
                {
                    if (temp2[i].Equals(""))
                        continue;
                    strings.Add(temp2[i]);
                }

                dayList.Add(strings);   // 저장한 list들을 dayList에 저장
            }

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

            int SetCol(string day)
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
}
