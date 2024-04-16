using System;
using LectureTimeTable.Utility;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LectureTimeTable.View;

namespace LectureTimeTable.Model
{
    public class LectureInfoController
    {
        private LectureRepository lecture;  
        private LectureTimeScreen lectureTimeScreen;
        private InputManager inputManager;
        private string inputSubjectTitle, inputProfessorName;

        public LectureInfoController()
        {
            this.lecture = LectureRepository.Instance;  // singleton 생성
            this.lectureTimeScreen = new LectureTimeScreen();
            this.inputManager = new InputManager();
            this.inputSubjectTitle = "";
            this.inputProfessorName = "";
        }

        public bool IsLectureValid(int digitValue)
        {
            switch (digitValue)
            {
                case (int)Constants.DigitType.SubjectTitle:
                    inputSubjectTitle = "";
                    inputSubjectTitle = inputManager.LimitInputLength((int)Constants.DigitType.SubjectTitle, 10, false);
                    break;
                case (int)Constants.DigitType.ProfessorName:
                    inputProfessorName = "";
                    inputProfessorName = inputManager.LimitInputLength((int)Constants.DigitType.ProfessorName, 10, false);
                    break;
            }

            if (inputSubjectTitle == null || inputProfessorName == null)
                return false;
            return true;
        }

        public List<LectureVo> ManageLectureList(int[] searchValues)
        {
            string[] searchString = GetSearchStrings(searchValues);
            List<LectureVo> lectureList = lecture.LectureList;
            List<LectureVo> resultLectureList = new List<LectureVo>();
            
            foreach (LectureVo lecture in lectureList)
            {
                int count = 0;
                if (searchString[0] == "")
                    count++;
                else if (lecture.Major.Contains(searchString[(int)Constants.SearchMenu.Major]))
                    count++;

                if (searchString[1] == "")
                    count++;
                else if (lecture.CreditClassification.Contains(searchString[(int)Constants.SearchMenu.CreditClassification]))
                    count++;

                if (searchString[2] == "")
                    count++;
                else if (lecture.Grade.Contains(searchString[2]))
                    count++;

                if (inputSubjectTitle == "")
                    count++;
                else if (lecture.SubjectTitle.Contains(inputSubjectTitle))
                    count++;

                if (inputProfessorName == "")
                    count++;
                else if (lecture.ProfessorName.Contains(inputProfessorName))
                    count++;

                if (count == 5)
                    resultLectureList.Add(lecture);
            }

            return resultLectureList;
        }

        public void ManageLectureTimeSheet(List<LectureVo> lectureList)
        {
            Console.SetWindowSize(180, 40);
            Console.Clear();
            lectureTimeScreen.DrawSheetScreen(lectureList);
            Console.ReadLine();
            Console.Clear();
        }

        private string[] GetSearchStrings(int[] searchValues)
        {
            // int [0] : Major, [1] : CreditClassification, [2] : grade
            string[] resultString = new string[3] { "", "", ""};
            switch (searchValues[0])    // 학과 
            {
                case (int)Constants.MajorMenu.Computer:
                    resultString[0] = "컴퓨터공학과";
                    break;
                case (int)Constants.MajorMenu.Software:
                    resultString[0] = "소프트웨어학과";
                    break;
                case (int)Constants.MajorMenu.Inteligent:
                    resultString[0] = "지능기전공학부";
                    break;
                case (int)Constants.MajorMenu.space:
                    resultString[0] = "기계항공우주공학부";
                    break;
            }

            switch (searchValues[1])    // 이수 구분
            {
                case (int)Constants.CreditClassificationMenu.Culture:
                    resultString[1] = "공통교양필수";
                    break;
                case (int)Constants.CreditClassificationMenu.Essential:
                    resultString[1] = "전공필수";
                    break;
                case (int)Constants.CreditClassificationMenu.Selected:
                    resultString[1] = "전공선택";
                    break;
            }

            switch (searchValues[2])    // 학년
            {
                case 1:
                    resultString[2] = "1";
                    break;
                case 2:
                    resultString[2] = "2";
                    break;
                case 3:
                    resultString[2] = "3";
                    break;
                case 4:
                    resultString[2] = "4";
                    break;
            }

            return resultString;
        }
    }
}
