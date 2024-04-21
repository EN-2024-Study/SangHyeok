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
            Tuple<int[], int[]> coordinate = Constantss.ScheduleScreenCoordinate;
            int[] x = coordinate.Item1;
            int[] y = coordinate.Item2;
            int index = 0;
            string[] times = Constantss.TIMES;

            Console.SetCursorPosition(0, 0);
            Console.Write(Constantss.SCHEDULE);

            foreach (LectureVo lecture in lectureList)
            {
                List<string> day = LectureDayManager.GetLectureDay(lecture);
                if (day == null)    // k-mooc 강좌
                {
                    Console.SetCursorPosition(15, 55);
                    Console.WriteLine(lecture.SubjectTitle);
                    Console.Write("================================================================================================================================");
                    continue;
                }

                int column = LectureDayManager.GetDayMatrixColumn(day[0]);
                if (day.Count == 3 || day.Count == 6)   // 요일이 하나일 때
                {
                    int row = LectureDayManager.GetDayMatrixRow(day[1]);
                    int lastRow = LectureDayManager.GetDayMatrixRow(day[2]);
                    Set(row, lastRow, column);
                }
                else if (day.Count == 4)  // 요일이 두개에 시간이 같을 때
                {
                    int row = LectureDayManager.GetDayMatrixRow(day[2]);
                    int lastRow = LectureDayManager.GetDayMatrixRow(day[3]);
                    Set(row, lastRow, column);

                    column = LectureDayManager.GetDayMatrixColumn(day[1]);
                    Set(row, lastRow, column);
                }

                if (day.Count == 6)  // 요일이 두개에 시간이 다를 때
                {
                    column = LectureDayManager.GetDayMatrixColumn(day[3]);
                    int row = LectureDayManager.GetDayMatrixRow(day[4]);
                    int lastRow = LectureDayManager.GetDayMatrixRow(day[5]);
                    Set(row, lastRow, column);
                }

                index++;
            }

            void Set(int row, int lastRow, int col)
            {
                for (int i = row; i < lastRow; i++)
                {
                    Console.SetCursorPosition(x[col], y[i]);
                    if (lectureList[index].SubjectTitle.Contains("Capstone"))
                        Console.Write(lectureList[index].SubjectTitle.Split(new char[] { '(' })[0]);
                    else
                        Console.Write(lectureList[index].SubjectTitle);
                    Console.SetCursorPosition(x[col], y[i] + 1);
                    Console.Write(lectureList[index].Room);
                }
            }
        }
    }
}
