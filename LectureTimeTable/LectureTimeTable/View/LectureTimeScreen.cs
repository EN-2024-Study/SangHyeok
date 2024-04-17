using System;
using LectureTimeTable.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable.View
{
    public class LectureTimeScreen
    {
        private const string SCHEDULE = @"
 ============================================================= 시간표 ===========================================================
==========================월==================화=================수==================목==================금====================== 
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
==========================월==================화=================수==================목==================금====================== 
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
            int y = 3;
            Console.SetCursorPosition(0, 0);
            Console.Write(SCHEDULE);

            foreach(LectureVo lecture in lectureList)
            {

            }
        }
    }
}
