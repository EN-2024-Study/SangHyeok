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
                menuValue = 0;
                isSelected = IsPromptMenuSelection((int)Constants.MenuType.LogIn);
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
                menuValue = 0;
                menuScreen.ClearBottomScreen();
                isSelected = IsPromptMenuSelection((int)Constants.MenuType.Main);
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
                menuValue = 0;
                menuScreen.ClearBottomScreen();
                isSelected = IsPromptMenuSelection((int)Constants.MenuType.FavoriteSubject);
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
                menuValue = 0;
                menuScreen.ClearBottomScreen();
                isSelected = IsPromptMenuSelection((int)Constants.MenuType.CourseApply);
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
                menuValue = 0;
                menuScreen.ClearBottomScreen();
                isSelected = IsPromptMenuSelection((int)Constants.MenuType.SearchAndApply);
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

            while (isSelected)
            {
                menuValue = 0;
                menuScreen.ClearBottomScreen();
                isSelected = IsPromptMenuSelection((int)Constants.MenuType.Search);
                if (!isSelected)
                    continue;

                switch (menuValue)
                {
                    case (int)Constants.SearchMenu.Major:   // 개설 학과 전공

                        break;
                    case (int)Constants.SearchMenu.CreditClassification:    // 이수 구분

                        break;
                    case (int)Constants.SearchMenu.subjectName: // 교과목 명

                        break;
                    case (int)Constants.SearchMenu.ProfessorName:   // 교수 명

                        break;
                    case (int)Constants.SearchMenu.Grade:   // 학년

                        break;
                }
            }
        }


        private bool IsPromptMenuSelection(int screenValue)
        {
            bool isMenuSelect = true;
            int menuCount = GetMenuCount(screenValue);
            Console.CursorVisible = false;

            while (isMenuSelect)
            {
                menuScreen.DrawMenu(screenValue, menuCount, menuValue, false);
                ConsoleKeyInfo keyInfo = Console.ReadKey();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.Escape:
                        return false;
                    case ConsoleKey.UpArrow:
                        menuValue--;
                        break;
                    case ConsoleKey.DownArrow:
                        menuValue++;
                        break;
                    case ConsoleKey.Enter:
                        menuScreen.DrawMenu(screenValue, menuCount, menuValue, true);
                        return true;
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
                    length = 4;
                    break;
                case (int)Constants.MenuType.Search:
                    length = 5;
                    break;
            }
            return length;
        }
    }
}
