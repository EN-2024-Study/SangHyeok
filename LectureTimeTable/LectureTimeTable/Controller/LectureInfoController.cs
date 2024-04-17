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
        private LectureTimeScreen screen;
        private InputManager inputManager;
        private UserInfoController userInfoController;
        private string inputSubjectTitle, inputProfessorName;
        private int[] searchValues;

        public LectureInfoController()
        {
            this.lecture = LectureRepository.Instance;  // singleton 생성
            this.screen = new LectureTimeScreen();
            this.inputManager = new InputManager();
            this.userInfoController = new UserInfoController();
            this.inputSubjectTitle = "";
            this.inputProfessorName = "";
            this.searchValues = new int[] { -1, -1, -1 };
        }

        public int[] SearchValues
        { set { searchValues = value; } }

        public bool IsSearchedLectureValid(int digitValue)
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

        public void ManageLectureTimeSheet(int typeValue)
        {
            string subjectId = "";
            List<LectureVo> lectureList = ManageLectureList(typeValue);
            Console.SetWindowSize(180, 40);
            Console.Clear();
            screen.DrawLectureTimeSheetScreen(lectureList);

            if (typeValue == (int)Constants.LectureTimeSheetType.FavoriteSubjectHistory ||
                typeValue == (int)Constants.LectureTimeSheetType.AppliedCourseHistory ||
                typeValue == (int)Constants.LectureTimeSheetType.CourseSearch)
            {
                ConsoleKeyInfo keyInfo;  // ConsoleKeyInfo의 할당은 무조건 사용자의 입력이 있어야 하므로 do while문 사용
                do keyInfo = Console.ReadKey(true);
                while (keyInfo.Key != ConsoleKey.Escape);   // 뒤로가기 입력만 받기
            }
            else if (typeValue == (int)Constants.LectureTimeSheetType.FavoriteSubjectApply ||
                typeValue == (int)Constants.LectureTimeSheetType.CourseApply)
            {
                subjectId = inputManager.LimitInputLength((int)Constants.DigitType.SubjectId, 4, false);
                bool isCheck = IsAdditionSuccessful(typeValue, subjectId);
            }
            Console.Clear();
        }

        private bool IsAdditionSuccessful(int typeValue, string subjectId)
        {   
            List<LectureVo> lectureList = lecture.LectureList;
            LectureVo resultLecture = null;
            foreach(LectureVo value in lectureList)
            {
                if (value.Id == Double.Parse(subjectId)) // 검색한 id가 lectureList에 있는지 확인
                {
                    resultLecture = value;
                    break;
                }
            }

            // 있다면 중복된 값이 있는지 확인
            if (resultLecture != null && userInfoController.IsCourseSetValid(typeValue, resultLecture))  
                return true;
            return false;
        }

        private List<LectureVo> ManageLectureList(int typeValue)
        {
            List<LectureVo> lectureList = null;
            switch(typeValue)
            {
                case (int)Constants.LectureTimeSheetType.FavoriteSubjectApply:
                case (int)Constants.LectureTimeSheetType.CourseSearch:
                case (int)Constants.LectureTimeSheetType.CourseApply:
                    lectureList = ManageSearchedLectureList(typeValue);
                    break;
                case (int)Constants.LectureTimeSheetType.FavoriteSubjectHistory:
                case (int)Constants.LectureTimeSheetType.FavoriteSubjectDelete:
                    lectureList = userInfoController.GetFavoriteSubjectList();
                    break;
                case (int)Constants.LectureTimeSheetType.AppliedCourseHistory:
                case (int)Constants.LectureTimeSheetType.CourseDelete:
                    lectureList = userInfoController.GetAppliedCourseList();
                    break;
            }
            return lectureList;
        }

        private List<LectureVo> ManageSearchedLectureList(int typeValue)
        {
            string[] searchString = GetSearchStrings(searchValues);
            List<LectureVo> lectureList = lecture.LectureList;
            List<LectureVo> resultLectureList = new List<LectureVo>();
            //foreach(var value in searchString)
            //{
            //    Console.WriteLine(value);
            //}
            //Console.WriteLine("test");
            //Console.ReadLine();
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

        private string[] GetSearchStrings(int[] searchValues)
        {
            string[] resultString = new string[3] { "", "", "" };
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
