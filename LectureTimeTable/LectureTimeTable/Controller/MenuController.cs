using LectureTimeTable.Utility;
using LectureTimeTable.View;
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
        private InputManager inputManager;
        private UserInfoController userInfoController;
        private int menuValue;

        public MenuController()
        {
            this.menuScreen = new MenuScreen();
            this.inputManager = new InputManager();
            this.userInfoController = new UserInfoController();
        }

        public void ControlLogInMenu()
        {
            bool isSelected = true;
            string id = null, password = null;

            while (isSelected)
            {
                isSelected = IsMenuSelection((int)Constants.MenuType.LogIn, true);
                if (!isSelected)
                    continue;

                switch(menuValue)
                {
                    case (int)Constants.LogInMenu.Id:
                        id = null;
                        id = inputManager.LimitInputLength((int)Constants.DigitType.Id, 9, false);
                        break;
                    case (int)Constants.LogInMenu.Password:
                        password = null;
                        password = inputManager.LimitInputLength((int)Constants.DigitType.Password, 5, true);
                        break;
                }
                if (id == null || password == null)
                    continue;

                if (userInfoController.IsLogIn(id, password))
                {
                    ControllMainMenu();
                    menuScreen.ClearBottomScreen();
                    id = null;
                    password = null;
                }
            }
        }

        private void ControllMainMenu()
        {
            bool isSelected = true;

            while (isSelected)
            {
                menuScreen.ClearBottomScreen();
                isSelected = IsMenuSelection((int)Constants.MenuType.Main, true);
                if (!isSelected)
                    continue;

                switch (menuValue)
                {
                    case (int)Constants.MainMenu.LectureScheduleSearch: // 강의 시간표 조회
                        ControllSearchMenu();
                        break;
                    case (int)Constants.MainMenu.FavoriteSubjectsPut:   // 관심 과목 담기
                        ControllFavoriteSubjectsMenu();
                        break;
                    case (int)Constants.MainMenu.CourseApply:   // 수강 신청
                        ControllCourseApplyMenu();
                        break;
                    case (int)Constants.MainMenu.CourseApplyHistoryCheck:   // 수강 내역 조회
                       
                        break;
                }
            }
        }

        private void ControllFavoriteSubjectsMenu()
        {
            bool isSelected = true;
            menuValue = 0;

            while (isSelected)
            {
                menuScreen.ClearBottomScreen();
                isSelected = IsMenuSelection((int)Constants.MenuType.FavoriteSubject, true);
                if (!isSelected)
                    continue;

                switch (menuValue)
                {
                    case (int)Constants.ApplyMenu.Apply:    // 관심 과목 신청
                        ControllSearchMenu();
                        break;
                    case (int)Constants.ApplyMenu.Statement:    //관심 과목 내역

                        break;
                    case (int)Constants.ApplyMenu.Schedule: // 관심 과목 시간표

                        break;
                    case (int)Constants.ApplyMenu.Delete:   // 관심 과목 삭제
                        break;
                }
            }
        }

        private void ControllCourseApplyMenu()
        {
            bool isSelected = true;
            menuValue = 0;

            while (isSelected)
            {
                menuScreen.ClearBottomScreen();
                isSelected = IsMenuSelection((int)Constants.MenuType.CourseApply, true);
                if (!isSelected)
                    continue;

                switch (menuValue)
                {
                    case (int)Constants.ApplyMenu.Apply:    // 수강 신청
                        ControllSearchAndApplyMenu();
                        break;
                    case (int)Constants.ApplyMenu.Statement:    // 수강 신청 내역

                        break;
                    case (int)Constants.ApplyMenu.Schedule: // 수강 신청 시간표

                        break;
                    case (int)Constants.ApplyMenu.Delete:   // 수강 과목 삭제

                        break;
                }
            }
        }

        private void ControllSearchAndApplyMenu()
        {
            bool isSelected = true;

            while (isSelected)
            {
                menuScreen.ClearBottomScreen();
                isSelected = IsMenuSelection((int)Constants.MenuType.SearchAndApply, true);
                if (!isSelected)
                    continue;

                switch (menuValue)
                {
                    case (int)Constants.SearchAndApplyMenu.Search:  // 검색 후 신청
                        ControllSearchMenu();
                        break;
                    case (int)Constants.SearchAndApplyMenu.FavoriteSubjects:    // 관심 과목 신청

                        break;
                }
            }
        }

        private void ControllSearchMenu()
        {
            bool isSelected = true;
            string subjectName = "", professorName = "";
            menuScreen.ClearBottomScreen();

            while (isSelected)
            {
                isSelected = IsMenuSelection((int)Constants.MenuType.Search, true);
                if (!isSelected)
                    continue;

                switch (menuValue)
                {
                    case (int)Constants.SearchMenu.Major:   // 개설 학과 전공
                        IsMenuSelection((int)Constants.MenuType.Major, false);
                        break;
                    case (int)Constants.SearchMenu.CreditClassification:    // 이수 구분
                        IsMenuSelection((int)Constants.MenuType.CreditClassification, false);
                        break;
                    case (int)Constants.SearchMenu.subjectName: // 교과목 명
                        subjectName = "";
                        subjectName = inputManager.LimitInputLength((int)Constants.DigitType.SubjectTitle, 10, false);
                        break;
                    case (int)Constants.SearchMenu.ProfessorName:   // 교수 명
                        professorName = "";
                        professorName = inputManager.LimitInputLength((int)Constants.DigitType.ProfessorName, 10, false);
                        break;
                    case (int)Constants.SearchMenu.Grade:   // 학년
                        IsMenuSelection((int)Constants.MenuType.Grade, false);
                        break;
                    case (int)Constants.SearchMenu.Enter:   // 강의 시간표 차트 띄우기

                        break;
                }
                
               
            }
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
                ConsoleKeyInfo keyInfo = Console.ReadKey();

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
                    }
                }

                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    menuScreen.DrawMenu(screenValue, menuValue, true, isMenuVisible);
                    return true;
                }
                else if (keyInfo.Key == ConsoleKey.Escape)
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
                case (int)Constants.MenuType.LogIn:
                case (int)Constants.MenuType.SearchAndApply:
                    length = 2;
                    break;
                case (int)Constants.MenuType.Main:
                case (int)Constants.MenuType.FavoriteSubject:
                case (int)Constants.MenuType.CourseApply:
                case (int)Constants.MenuType.CreditClassification:
                case (int)Constants.MenuType.Grade:
                    length = 4;
                    break;
                case (int)Constants.MenuType.Major:
                    length = 5;
                    break;
                case (int)Constants.MenuType.Search:
                    length = 6;
                    break;
            }
            return length;
        }
    }
}
