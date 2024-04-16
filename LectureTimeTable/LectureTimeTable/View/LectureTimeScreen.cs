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

        public void DrawSheetScreen(List<LectureVo> lectureList)
        {
            int[] coordinateX = new int[] { 0, 4, 23, 31, 36, 69, 83, 85, 88, 119, 133, 160, 167};
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
            Console.SetCursorPosition(coordinateX[6], y);
            Console.Write("학년");
            Console.SetCursorPosition(coordinateX[7], y);
            Console.Write("학점");
            Console.SetCursorPosition(coordinateX[8], y);
            Console.Write("요일및강의시간");
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
    }
}
