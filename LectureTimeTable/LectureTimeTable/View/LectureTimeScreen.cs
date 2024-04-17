using System;
using LectureTimeTable.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LectureTimeTable.Utility;

namespace LectureTimeTable.View
{
    public class LectureTimeScreen
    {
        private const string SCHEDULE = @"
 ============================================================= 시간표 ===========================================================
====================월=====================화====================수====================목====================금=================== 

08:30 ~ 09:00

09:00 ~ 09:30

09:30 ~ 10:00

10:00 ~ 10:30

10:30 ~ 11:00

11:00 ~ 11:30

11:30 ~ 12:00

12:00 ~ 12:30

12:30 ~ 13:00

13:00 ~ 13:30

13:30 ~ 14:00

14:00 ~ 14:30

14:30 ~ 15:00

15:00 ~ 15:30

15:30 ~ 16:00

16:00 ~ 16:30

16:30 ~ 17:00

17:00 ~ 17:30

17:30 ~ 18:00

18:00 ~ 18:30

18:30 ~ 19:00

19:00 ~ 19:30

19:30 ~ 20:00

20:00 ~ 20:30

20:30 ~ 21:00
====================월=====================화====================수====================목====================금=================== 
";

        public void DrawLectureTimeSheetScreen(List<LectureVo> lectureList)
        {
            int[] coordinateX = new int[] { 0, 4, 23, 31, 36, 69, 83, 87, 90, 121, 135, 162, 169};
            int y = 1;
            Console.SetCursorPosition(coordinateX[0], y);
            Console.Write("NO");
            Console.SetCursorPosition(coordinateX[1], y);
            Console.Write("개설학과전공");
            Console.SetCursorPosition(coordinateX[2], y);
            Console.Write("학수번호");
            Console.SetCursorPosition(coordinateX[3], y);
            Console.Write("분반");
            Console.SetCursorPosition(coordinateX[4], y);
            Console.Write("교과목명");
            Console.SetCursorPosition(coordinateX[5], y);
            Console.Write("이수구분");
            Console.SetCursorPosition(coordinateX[6] - 1, y);
            Console.Write("학년");
            Console.SetCursorPosition(coordinateX[7] - 1, y);
            Console.Write("학점");
            Console.SetCursorPosition(coordinateX[8] - 1, y);
            Console.Write("요일 및 강의시간");
            Console.SetCursorPosition(coordinateX[9], y);
            Console.Write("강의실");
            Console.SetCursorPosition(coordinateX[10], y);
            Console.Write("메인교수명");
            Console.SetCursorPosition(coordinateX[11], y);
            Console.Write("강의언어");
            y = 2;
            foreach (LectureVo lecture in lectureList)
            {
                int index = 0;
                Console.SetCursorPosition(coordinateX[index++], y);
                Console.Write(lecture.Id);
                Console.SetCursorPosition(coordinateX[index++], y);
                Console.Write(lecture.Major);
                Console.SetCursorPosition(coordinateX[index++], y);
                Console.Write(lecture.Number);
                Console.SetCursorPosition(coordinateX[index++], y);
                Console.Write(lecture.Group);
                Console.SetCursorPosition(coordinateX[index++], y);
                Console.Write(lecture.SubjectTitle);
                Console.SetCursorPosition(coordinateX[index++], y);
                Console.Write(lecture.CreditClassification); 
                Console.SetCursorPosition(coordinateX[index++], y);
                Console.Write(lecture.Grade); 
                Console.SetCursorPosition(coordinateX[index++], y);
                Console.Write(lecture.Score); 
                Console.SetCursorPosition(coordinateX[index++], y);
                Console.Write(lecture.Day); 
                Console.SetCursorPosition(coordinateX[index++], y);
                Console.Write(lecture.Room); 
                Console.SetCursorPosition(coordinateX[index++], y);
                Console.Write(lecture.ProfessorName); 
                Console.SetCursorPosition(coordinateX[index++], y);
                Console.Write(lecture.Language);
                y++;
            }
        }

        public void DrawScheduleScreen(List<LectureVo> lectureList)
        {
            int[] y = new int[] {4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30, 32, 34, 36, 38, 40, 42, 44, 46, 48, 50, 52, 54, 56 };
            int index = 0;
            int[] x = new int[] { 15, 37, 60, 80, 103 };
            string[] times = Constants.TIMES;
            List<List<string>> dayList = ExceptionManager.GetDayList(lectureList);

            Console.SetCursorPosition(0, 0);
            Console.Write(SCHEDULE);

            foreach (List<string> day in dayList)
            {
                int col = ExceptionManager.SetCol(day[0]);
                int row = -1;
                int lastRow = -1;

                if (day.Count == 3)   // 요일이 하나일 때
                {
                    for (int i = 0; i < times.Length; i++)
                    {
                        if (row == -1 && times[i].Equals(day[1]))
                            row = i;
                        else if (times[i].Equals(day[2]))
                        {
                            lastRow = i;
                            break;
                        }
                    }

                    for (int i = row; i < lastRow; i++)
                    {
                        Console.SetCursorPosition(x[col], y[row]);
                        Console.Write(lectureList[index].SubjectTitle);
                        Console.SetCursorPosition(x[col], y[row] + 1);
                        Console.Write(lectureList[index].Room);
                    }
                }
                else if (day.Count == 4)  // 요일이 두개에 시간이 같을 때
                {
                    for (int i = 0; i < times.Length; i++)
                    {
                        if (row == -1 && times[i].Equals(day[2]))
                            row = i;
                        else if (times[i].Equals(day[3]))
                        {
                            lastRow = i;
                            break;
                        }
                    }
                    for (int i = row; i < lastRow; i++)
                    {
                        Console.SetCursorPosition(x[col], y[row]);
                        Console.Write(lectureList[index].SubjectTitle);
                        Console.SetCursorPosition(x[col], y[row] + 1);
                        Console.Write(lectureList[index].Room);
                    }

                    col = ExceptionManager.SetCol(day[1]);
                    for (int i = row; i < lastRow; i++)
                    {
                        Console.SetCursorPosition(x[col], y[row]);
                        Console.Write(lectureList[index].SubjectTitle);
                        Console.SetCursorPosition(x[col], y[row] + 1);
                        Console.Write(lectureList[index].Room);
                    }
                }
                else if (day.Count == 6)  // 요일이 두개에 시간이 다를 때
                {
                    for (int i = 0; i < times.Length; i++)
                    {
                        if (row == -1 && times[i].Equals(day[1]))
                            row = i;
                        else if (times[i].Equals(day[2]))
                        {
                            lastRow = i;
                            break;
                        }
                    }

                    for (int i = row; i < lastRow; i++)
                    {
                        Console.SetCursorPosition(x[col], y[row]);
                        Console.Write(lectureList[index].SubjectTitle);
                        Console.SetCursorPosition(x[col], y[row] + 1);
                        Console.Write(lectureList[index].Room);
                    }

                    col = ExceptionManager.SetCol(day[3]);
                    row = -1;
                    lastRow = -1;

                    for (int i = 0; i < times.Length; i++)
                    {
                        if (row == -1 && times[i].Equals(day[4]))
                            row = i;
                        else if (times[i].Equals(day[5]))
                        {
                            lastRow = i;
                            break;
                        }
                    }

                    for (int i = row; i < lastRow; i++)
                    {
                        Console.SetCursorPosition(x[col], y[row]);
                        Console.Write(lectureList[index].SubjectTitle);
                        Console.SetCursorPosition(x[col], y[row] + 1);
                        Console.Write(lectureList[index].Room);
                    }

                    index++;
                }
            }
        }
    }
}
