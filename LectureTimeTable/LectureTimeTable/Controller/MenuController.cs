using LectureTimeTable.Utility;
using LectureTimeTable.View;
using LectureTimeTable.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable.Controller
{
    public class MenuController
    {
        private MenuScreen menuScreen;
        private UserInfoController userInfoController;
        private LectureInfoController lectureInfoController;
        private int menuValue;

        public MenuController()
        {
            this.menuScreen = new MenuScreen();
            this.userInfoController = new UserInfoController();
            this.lectureInfoController = new LectureInfoController();
        }

        public void ControlLogInMenu()
        {
            bool isSelected = true;
            bool isId = false, isPassword = false;
            Console.SetWindowSize(80, 40);
            menuScreen.ClearBottomScreen();

            while (isSelected)
            {
                ExplaningScreen.ExplaningArrowPress();  // 설명란 띄우기
                ExplaningScreen.ExplaningLogIn();
                isSelected = IsMenuSelection((int)Constantss.MenuType.LogIn, true); 
                if (!isSelected)
                    continue;

                switch(menuValue)
                {
                    case (int)Constantss.DigitType.Id:  // id 입력
                        isId = userInfoController.IsUserIdValid();
                        break;
                    case (int)Constantss.DigitType.Password:    // password 입력
                        isPassword = userInfoController.IsUserPasswordValid();
                        break;
                }

                if (isId && isPassword) // id와 password가 일치하다면
                {
                    ControllMainMenu(); // 메인 메뉴로 이동
                    isId = false;
                    isPassword = false;
                }
            }
        }

        private void ControllMainMenu()
        {
            bool isSelected = true;

            while (isSelected)
            {
                Console.SetWindowSize(80, 40);
                menuScreen.ClearBottomScreen();
                ExplaningScreen.ExplaningArrowPress();
                isSelected = IsMenuSelection((int)Constantss.MenuType.Main, true);
                if (!isSelected)
                    continue;

                switch (menuValue)
                {
                    case (int)Constantss.MainMenu.LectureScheduleSearch: // 강의 시간표 조회
                        ControllSearchMenu((int)Constantss.LectureType.CourseSearch);
                        break;
                    case (int)Constantss.MainMenu.FavoriteSubjectsPut:   // 관심 과목 담기
                        ControllFavoriteSubjectsMenu();
                        break;
                    case (int)Constantss.MainMenu.CourseApply:   // 수강 신청
                        ControllCourseApplyMenu();
                        break;
                    case (int)Constantss.MainMenu.CourseApplyHistoryCheck:   // 수강 내역 조회
                        lectureInfoController.ManageSchedule((int)Constantss.LectureType.AppliedCourseHistory);
                        break;
                }
            }
            Console.Clear();
        }

        private void ControllFavoriteSubjectsMenu()
        {
            bool isSelected = true;
            menuValue = 0;

            while (isSelected)
            {
                Console.SetWindowSize(80, 40);
                menuScreen.ClearBottomScreen();
                ExplaningScreen.ExplaningArrowPress();
                isSelected = IsMenuSelection((int)Constantss.MenuType.FavoriteSubject, true);
                if (!isSelected)
                    continue;

                switch (menuValue)
                {
                    case (int)Constantss.ApplyMenu.Apply:    // 관심 과목 신청
                        ControllSearchMenu((int)Constantss.LectureType.FavoriteSubjectApply);
                        break;
                    case (int)Constantss.ApplyMenu.Statement:    //관심 과목 내역
                        lectureInfoController.ManageLectureTimeSheet((int)Constantss.LectureType.FavoriteSubjectHistory);
                        break;
                    case (int)Constantss.ApplyMenu.Schedule: // 관심 과목 시간표
                        lectureInfoController.ManageSchedule((int)Constantss.LectureType.FavoriteSubjectHistory);
                        break;
                    case (int)Constantss.ApplyMenu.Delete:   // 관심 과목 삭제
                        lectureInfoController.ManageLectureTimeSheet((int)Constantss.LectureType.FavoriteSubjectDelete);
                        break;
                }
                Console.Clear();
            }
        }

        private void ControllCourseApplyMenu()
        {
            bool isSelected = true;
            menuValue = 0;

            while (isSelected)
            {
                Console.SetWindowSize(80, 40);
                menuScreen.ClearBottomScreen();
                ExplaningScreen.ExplaningArrowPress();
                isSelected = IsMenuSelection((int)Constantss.MenuType.CourseApply, true);
                if (!isSelected)
                    continue;

                switch (menuValue)
                {
                    case (int)Constantss.ApplyMenu.Apply:    // 수강 신청
                        ControllSearchAndApplyMenu();
                        break;
                    case (int)Constantss.ApplyMenu.Statement:    // 수강 신청 내역
                        lectureInfoController.ManageLectureTimeSheet((int)Constantss.LectureType.AppliedCourseHistory);
                        break;
                    case (int)Constantss.ApplyMenu.Schedule: // 수강 신청 시간표
                        lectureInfoController.ManageSchedule((int)Constantss.LectureType.AppliedCourseHistory);
                        break;
                    case (int)Constantss.ApplyMenu.Delete:   // 수강 과목 삭제
                        lectureInfoController.ManageLectureTimeSheet((int)Constantss.LectureType.CourseDelete);
                        break;
                }
                Console.Clear();
            }
        }

        private void ControllSearchAndApplyMenu()
        {
            bool isSelected = true;

            while (isSelected)
            {
                Console.SetWindowSize(80, 40);
                menuScreen.ClearBottomScreen();
                ExplaningScreen.ExplaningArrowPress();
                isSelected = IsMenuSelection((int)Constantss.MenuType.SearchAndApply, true);
                if (!isSelected)
                    continue;

                switch (menuValue)
                {
                    case (int)Constantss.SearchAndApplyMenu.Search:  // 검색 후 신청
                        ControllSearchMenu((int)Constantss.LectureType.ApplyAfterSearch);
                        break;
                    case (int)Constantss.SearchAndApplyMenu.FavoriteSubjects:    // 관심 과목 신청
                        lectureInfoController.ManageLectureTimeSheet((int)Constantss.LectureType.ApplyForFavoriteSubject);
                        break;
                }
            }
            Console.Clear();
        }

        private void ControllSearchMenu(int typeValue)
        {
            bool isSelected = true;
            int[] searchValues = new int[] { -1, -1, -1 };
            lectureInfoController.SearchValues = searchValues;
           
            menuScreen.ClearBottomScreen();

            while (isSelected)
            {
                Console.SetWindowSize(130, 40);
                ExplaningScreen.ExplaningArrowPress();
                isSelected = IsMenuSelection((int)Constantss.MenuType.Search, true);
                if (!isSelected)
                    continue;
                
                switch (menuValue)
                {
                    case (int)Constantss.SearchMenu.Major:   // 개설 학과 전공
                        IsMenuSelection((int)Constantss.MenuType.Major, false);
                        searchValues[0] = menuValue;
                        break;
                    case (int)Constantss.SearchMenu.CreditClassification:    // 이수 구분
                        IsMenuSelection((int)Constantss.MenuType.CreditClassification, false);
                        searchValues[1] = menuValue;
                        break;
                    case (int)Constantss.SearchMenu.SubjectTitle: // 교과목 명
                    case (int)Constantss.SearchMenu.ProfessorName:   // 교수 명
                        if (lectureInfoController.IsSearchedLectureValid(menuValue))
                            continue;
                        break;
                    case (int)Constantss.SearchMenu.Grade:   // 학년
                        IsMenuSelection((int)Constantss.MenuType.Grade, false);
                        searchValues[2] = menuValue;
                        break;
                    case (int)Constantss.SearchMenu.Enter:   // 강의 시간표 차트 띄우기
                        lectureInfoController.ManageLectureTimeSheet(typeValue);
                        searchValues = new int[] { -1, -1, -1 };
                        Console.Clear();
                        break;
                }
                lectureInfoController.SearchValues = searchValues;
            }
            Console.Clear();
        }

        private bool IsMenuSelection(int screenValue, bool isMenuVisible)
        {
            bool isMenuSelect = true;
            int menuCount = GetMenuCount(screenValue);
            menuValue = 0;
            Console.CursorVisible = false;

            while (isMenuSelect)
            {
                menuScreen.DrawMenu(screenValue, menuValue, false, isMenuVisible);
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                if (isMenuVisible)  // 메뉴일 때
                {
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.UpArrow:
                            menuValue--;
                            break;
                        case ConsoleKey.DownArrow:
                            menuValue++;
                            break;
                        case ConsoleKey.Enter:
                            menuScreen.DrawMenu(screenValue, menuValue, true, isMenuVisible);
                            return true;
                    }
                }
                else    // 부가 메뉴일 때
                {
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.LeftArrow:
                            menuValue--;
                            break;
                        case ConsoleKey.RightArrow:
                            menuValue++;
                            break;
                        case ConsoleKey.Enter: 
                            menuScreen.DrawMenu(screenValue, menuValue, true, isMenuVisible);
                            return true;
                    }
                }

                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    menuScreen.DrawMenu(screenValue, -1, false, isMenuVisible);
                    return false;
                }

                if (menuValue < 0)
                    menuValue = 0;
                else if (menuValue > menuCount - 1)
                    menuValue = menuCount - 1;
            }
            return false;
        }

        private int GetMenuCount(int screenValue)
        {
            int length = 0;
            switch (screenValue)
            {
                case (int)Constantss.MenuType.LogIn:
                case (int)Constantss.MenuType.SearchAndApply:
                    length = 2;
                    break;
                case (int)Constantss.MenuType.Main:
                case (int)Constantss.MenuType.FavoriteSubject:
                case (int)Constantss.MenuType.CourseApply:
                case (int)Constantss.MenuType.CreditClassification:
                case (int)Constantss.MenuType.Grade:
                    length = 4;
                    break;
                case (int)Constantss.MenuType.Major:
                    length = 5;
                    break;
                case (int)Constantss.MenuType.Search:
                    length = 6;
                    break;
            }
            return length;
        }
    }
}
