using System;
using LectureTimeTable.Utility;
using System.Collections.Generic;
using LectureTimeTable.View;
using Microsoft.Office.Interop.Excel;
using System.IO;

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

        public string InputSubjectTitle
        { set { inputSubjectTitle = value; } }

        public string InputProfessorName
        { set { inputProfessorName = value; } }

        public bool IsSearchedLectureValid(int digitValue)  // 교과목명 또는 교수명 입력받는 함수
        {
            switch (digitValue)
            {
                case (int)Constantss.DigitType.SubjectTitle:
                    inputSubjectTitle = "";
                    inputSubjectTitle = inputManager.LimitInputLength((int)Constantss.DigitType.SubjectTitle, 21, false);
                    break;
                case (int)Constantss.DigitType.ProfessorName:
                    inputProfessorName = "";
                    inputProfessorName = inputManager.LimitInputLength((int)Constantss.DigitType.ProfessorName, 26, false);
                    break;
            }

            if (inputSubjectTitle == null || inputProfessorName == null)
                return false;
            return true;
        }

        public void ManageSchedule(int typeValue)
        {
            List<LectureVo> lectureList = GetLectureList(typeValue);
            Console.SetWindowSize(130, 40);
            Console.Clear();
            screen.DrawScheduleScreen(lectureList);

            if (typeValue == (int)Constantss.LectureType.FavoriteSubjectHistory)
            {
                ExplaningScreen.ExplaningEscPress();
                ConsoleKeyInfo keyInfo;
                do keyInfo = Console.ReadKey(true);
                 while (keyInfo.Key != ConsoleKey.Escape);
            }
            else
            {
                ExplaningScreen.ExplaningEscPress();
                ExplaningScreen.ExplaningEnterPress();
                while (true)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        SaveExcel();
                        Console.Clear();
                        Console.SetWindowSize(70, 20);
                        ExplaningScreen.ExplaningSave();
                        Console.ReadLine();
                        Console.Clear();
                        return;
                    }
                    else if (keyInfo.Key == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        return;
                    }
                }
            }
        }

        public void ManageLectureTimeSheet(int typeValue)   // 강의 시간표 차트 관리 함수
        {
            bool isSuccess = false;
            while(!isSuccess)
            {
                List<LectureVo> lectureList = GetLectureList(typeValue);
                Console.SetWindowSize(180, 40);
                Console.Clear();
                screen.DrawLectureTimeSheetScreen(lectureList);
                ExplaningScreen.ExplaningEscPress();
                if (typeValue == (int)Constantss.LectureType.FavoriteSubjectHistory ||
                    typeValue == (int)Constantss.LectureType.AppliedCourseHistory ||
                    typeValue == (int)Constantss.LectureType.CourseSearch)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    if (keyInfo.Key == ConsoleKey.Escape)   // 뒤로가기 입력만 받기
                    {
                        Console.Clear();
                        break;
                    }
                }
                else
                {
                    ExplaningScreen.ExplaningEnterPress();
                    Console.SetCursorPosition(0, 0);
                    Console.Write("NO: ");
                    string subjectId = inputManager.LimitInputLength((int)Constantss.DigitType.SubjectId, 4, false);
                    Console.Clear();
                    Console.SetWindowSize(50, 20);

                    if (subjectId == null)
                        break;
                    else if (!IsSetSuccessful(typeValue, subjectId))    // 실패 했을 때
                        ExplaningScreen.ExplaningInvalidInput();
                    else  // 성공 했을 때
                        ExplaningScreen.ExplaningSuccessInput();
                    Console.ReadLine();
                }
                Console.Clear();
            }

            InputProfessorName = "";
            InputSubjectTitle = "";
        }

        private bool IsSetSuccessful(int typeValue, string subjectId)
        {   // 입력받는 id와 일치하는 과목이 있는지 확인하는 함수
            List<LectureVo> lectureList = null;
            LectureVo resultLecture = null;
            if (typeValue == (int)Constantss.LectureType.FavoriteSubjectApply ||
                typeValue == (int)Constantss.LectureType.ApplyAfterSearch)
                lectureList = lecture.LectureList;
            else
                lectureList = GetLectureList(typeValue);
         
            foreach (LectureVo value in lectureList)
            {
                if (subjectId.Equals(value.Id.ToString()))
                {
                    resultLecture = value;
                    break;
                }
            }

            // 검색한 id가 일치하다면 추가 or 삭제 기능 수행 가능한지 확인
            if (resultLecture != null && userInfoController.IsCourseSetValid(typeValue, resultLecture))  
                return true;
            return false;
        }

        private List<LectureVo> GetLectureList(int typeValue)
        {
            List<LectureVo> lectureList = null;
            switch(typeValue)
            {
                case (int)Constantss.LectureType.FavoriteSubjectApply:
                case (int)Constantss.LectureType.CourseSearch:
                case (int)Constantss.LectureType.ApplyAfterSearch:
                    lectureList = ManageSearchedLectureList(typeValue);
                    break;
                case (int)Constantss.LectureType.FavoriteSubjectHistory:
                case (int)Constantss.LectureType.FavoriteSubjectDelete:
                case (int)Constantss.LectureType.ApplyForFavoriteSubject:
                    lectureList = userInfoController.GetFavoriteSubjectList();
                    break;
                case (int)Constantss.LectureType.AppliedCourseHistory:
                case (int)Constantss.LectureType.CourseDelete:
                    lectureList = userInfoController.GetAppliedCourseList();
                    break;
            }
            return lectureList;
        }

        private List<LectureVo> ManageSearchedLectureList(int typeValue)    // 입력에 맞는 정보 추출 함수
        {
            string[] searchString = GetSearchStrings();
            List<LectureVo> lectureList = lecture.LectureList;
            List<LectureVo> resultLectureList = new List<LectureVo>();
          
            foreach (LectureVo lecture in lectureList)
            {
                int count = 0;
                if (searchString[0] == "")
                    count++;
                else if (lecture.Major.Contains(searchString[(int)Constantss.SearchMenu.Major]))
                    count++;

                if (searchString[1] == "")
                    count++;
                else if (lecture.CreditClassification.Contains(searchString[(int)Constantss.SearchMenu.CreditClassification]))
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

        private void SaveExcel()    // excel 저장 함수
        {
            try
            {
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string path = Path.Combine(desktopPath, "AppliedCourses.xlsx");

                Application application = new Application();
                Workbook workBook = application.Workbooks.Add();
                Worksheet workSheet = workBook.Worksheets.get_Item(1) as Worksheet;

                workSheet.Cells[1, 1] = "NO";
                workSheet.Cells[1, 2] = "개설학과전공";
                workSheet.Cells[1, 3] = "학수번호";
                workSheet.Cells[1, 4] = "분반";
                workSheet.Cells[1, 5] = "교과목명";
                workSheet.Cells[1, 6] = "이수구분";
                workSheet.Cells[1, 7] = "학년";
                workSheet.Cells[1, 8] = "학점";
                workSheet.Cells[1, 9] = "요일 및 강의시간";
                workSheet.Cells[1, 10] = "강의실";
                workSheet.Cells[1, 11] = "메인교수명";
                workSheet.Cells[1, 12] = "강의언어";

                List<LectureVo> lectureList = userInfoController.GetAppliedCourseList();
                for (int i = 2; i <= lectureList.Count + 1; i++)
                {
                    workSheet.Cells[i, 1] = lectureList[i - 2].Id.ToString();
                    workSheet.Cells[i, 2] = lectureList[i - 2].Major;
                    workSheet.Cells[i, 3] = lectureList[i - 2].Number;
                    workSheet.Cells[i, 4] = lectureList[i - 2].Group;
                    workSheet.Cells[i, 5] = lectureList[i - 2].SubjectTitle;
                    workSheet.Cells[i, 6] = lectureList[i - 2].CreditClassification;
                    workSheet.Cells[i, 7] = lectureList[i - 2].Grade;
                    workSheet.Cells[i, 8] = lectureList[i - 2].Score;
                    workSheet.Cells[i, 9] = lectureList[i - 2].Day;
                    workSheet.Cells[i, 10] = lectureList[i - 2].Room;
                    workSheet.Cells[i, 11] = lectureList[i - 2].ProfessorName;
                    workSheet.Cells[i, 12] = lectureList[i - 2].Language;
                }

                workSheet.Columns.AutoFit();
                workBook.SaveAs(path, XlFileFormat.xlWorkbookDefault);
                workBook.Close(true);
                application.Quit();
            }
            catch (SystemException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private string[] GetSearchStrings()
        {
            string[] resultString = new string[3] { "", "", "" };
            switch (searchValues[0])    // 학과 
            {
                case (int)Constantss.MajorMenu.Computer:
                    resultString[0] = "컴퓨터공학과";
                    break;
                case (int)Constantss.MajorMenu.Software:
                    resultString[0] = "소프트웨어학과";
                    break;
                case (int)Constantss.MajorMenu.Inteligent:
                    resultString[0] = "지능기전공학부";
                    break;
                case (int)Constantss.MajorMenu.space:
                    resultString[0] = "기계항공우주공학부";
                    break;
            }

            switch (searchValues[1])    // 이수 구분
            {
                case (int)Constantss.CreditClassificationMenu.Culture:
                    resultString[1] = "공통교양필수";
                    break;
                case (int)Constantss.CreditClassificationMenu.Essential:
                    resultString[1] = "전공필수";
                    break;
                case (int)Constantss.CreditClassificationMenu.Selected:
                    resultString[1] = "전공선택";
                    break;
            }

            switch (searchValues[2])    // 학년
            {
                case 0:
                    resultString[2] = "1";
                    break;
                case 1:
                    resultString[2] = "2";
                    break;
                case 2:
                    resultString[2] = "3";
                    break;
                case 3:
                    resultString[2] = "4";
                    break;
            }

            return resultString;
        }
    }
}
