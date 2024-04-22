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

                workSheet.Cells[1, 6] = "수강";
                workSheet.Cells[1, 7] = "신청";
                workSheet.Cells[1, 8] = "내역";
                workSheet.Cells[1, 17] = "시간표";
                workSheet.Cells[2, 15] = "월";
                workSheet.Cells[2, 16] = "화";
                workSheet.Cells[2, 17] = "수";
                workSheet.Cells[2, 18] = "목";
                workSheet.Cells[2, 19] = "금";
                workSheet.Cells[2, 1] = "NO";
                workSheet.Cells[2, 2] = "개설학과전공";
                workSheet.Cells[2, 3] = "학수번호";
                workSheet.Cells[2, 4] = "분반";
                workSheet.Cells[2, 5] = "교과목명";
                workSheet.Cells[2, 6] = "이수구분";
                workSheet.Cells[2, 7] = "학년";
                workSheet.Cells[2, 8] = "학점";
                workSheet.Cells[2, 9] = "요일 및 강의시간";
                workSheet.Cells[2, 10] = "강의실";
                workSheet.Cells[2, 11] = "메인교수명";
                workSheet.Cells[2, 12] = "강의언어";

                workSheet.Cells[3, 14] = "09:00~09:30";
                workSheet.Cells[5, 14] = "09:30~10:00";
                workSheet.Cells[7, 14] = "10:00~10:30";
                workSheet.Cells[9, 14] = "10:30~11:00";
                workSheet.Cells[11, 14] = "11:00~11:30";
                workSheet.Cells[13, 14] = "11:30~12:00";
                workSheet.Cells[15, 14] = "12:00~12:30";
                workSheet.Cells[17, 14] = "12:30~13:00";
                workSheet.Cells[19, 14] = "13:00~13:30";
                workSheet.Cells[21, 14] = "13:30~14:00";
                workSheet.Cells[23, 14] = "14:00~14:30";
                workSheet.Cells[25, 14] = "14:30~15:00";
                workSheet.Cells[27, 14] = "15:00~15:30";
                workSheet.Cells[29, 14] = "15:30~16:00";
                workSheet.Cells[31, 14] = "16:00~16:30";
                workSheet.Cells[33, 14] = "16:30~17:00";
                workSheet.Cells[35, 14] = "17:00~17:30";
                workSheet.Cells[37, 14] = "17:30~18:00";
                workSheet.Cells[39, 14] = "18:00~18:30";
                workSheet.Cells[41, 14] = "18:30~19:00";
                workSheet.Cells[43, 14] = "19:00~19:30";
                workSheet.Cells[45, 14] = "19:30~20:00";
                workSheet.Cells[47, 14] = "20:00~20:30";
                workSheet.Cells[49, 14] = "20:30~21:00";

                List<LectureVo> lectureList = userInfoController.GetAppliedCourseList();
                for (int i = 3; i < lectureList.Count + 3; i++)
                {
                    workSheet.Cells[i, 1] = lectureList[i - 3].Id.ToString();   // 수강 신청 내역
                    workSheet.Cells[i, 2] = lectureList[i - 3].Major;
                    workSheet.Cells[i, 3] = lectureList[i - 3].Number;
                    workSheet.Cells[i, 4] = lectureList[i - 3].Group;
                    workSheet.Cells[i, 5] = lectureList[i - 3].SubjectTitle;
                    workSheet.Cells[i, 6] = lectureList[i - 3].CreditClassification;
                    workSheet.Cells[i, 7] = lectureList[i - 3].Grade;
                    workSheet.Cells[i, 8] = lectureList[i - 3].Score;
                    workSheet.Cells[i, 9] = lectureList[i - 3].Day;
                    workSheet.Cells[i, 10] = lectureList[i - 3].Room;
                    workSheet.Cells[i, 11] = lectureList[i - 3].ProfessorName;
                    workSheet.Cells[i, 12] = lectureList[i - 3].Language;

                    List<string> day = LectureDayManager.GetLectureDay(lectureList[i - 3]); // 수강 신청 시간표
                    if (day == null)    // k-mooc 강좌
                    {
                        workSheet.Cells[51, 14] = lectureList[i - 3].SubjectTitle;
                        continue;
                    }
                    
                    int column = LectureDayManager.GetDayMatrixColumn(day[0]);
                    if (day.Count == 3 || day.Count == 6)   // 요일이 하나일 때
                    {
                        int row = LectureDayManager.GetDayMatrixRow(day[1]);
                        int lastRow = LectureDayManager.GetDayMatrixRow(day[2]);
                        Set(row, lastRow, column, workSheet, lectureList, i - 3);
                    }
                    else if (day.Count == 4)  // 요일이 두개에 시간이 같을 때
                    {
                        int row = LectureDayManager.GetDayMatrixRow(day[2]);
                        int lastRow = LectureDayManager.GetDayMatrixRow(day[3]);
                        Set(row, lastRow, column, workSheet, lectureList, i - 3);

                        column = LectureDayManager.GetDayMatrixColumn(day[1]);
                        Set(row, lastRow, column, workSheet, lectureList, i - 3);
                    }

                    if (day.Count == 6)  // 요일이 두개에 시간이 다를 때
                    {
                        column = LectureDayManager.GetDayMatrixColumn(day[3]);
                        int row = LectureDayManager.GetDayMatrixRow(day[4]);
                        int lastRow = LectureDayManager.GetDayMatrixRow(day[5]);
                        Set(row, lastRow, column, workSheet, lectureList, i - 3);
                    }
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

            void Set(int row, int lastRow, int column, Worksheet workSheet, List<LectureVo> lectureList, int index)
            {
                for (int j = row, i = 2; j < lastRow; j++, i += 1)
                {
                    if (lectureList[index].SubjectTitle.Contains("Capstone"))
                        workSheet.Cells[j + i, column + 15] = "Capstone디자인";
                    else
                        workSheet.Cells[j + i, column + 15] = lectureList[index].SubjectTitle;
                    workSheet.Cells[j + i + 1, column + 15] = lectureList[index].Room;
                }
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
