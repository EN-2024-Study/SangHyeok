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

        public void ControlLogIn()
        {
            bool isSelected = true;
            menuValue = 0;
            menuScreen.ClearBottomScreen();

            while (isSelected)
            {
                string id = null, password = null;
                isSelected = IsPromptMenuSelection((int)Constants.MenuType.LogIn);
                switch(menuValue)
                {
                    case (int)Constants.LogInMenu.Quit:
                        isSelected = false;
                        break;
                    case (int)Constants.LogInMenu.Id:
                        id = inputManager.LimitInputLength((int)Constants.DigitType.Id, 8, false);
                        break;
                    case (int)Constants.LogInMenu.Password:
                        password = inputManager.LimitInputLength((int)Constants.DigitType.Password, 10, true);
                        break;
                }
                if (id == null || password == null)
                    continue;

                if (userInfoController.IsLogIn(id, password))
                    ControllMainScreen();
            }
        }

        private void ControllMainScreen()
        {
            bool isSelected = true;
            menuValue = 0;
            menuScreen.ClearBottomScreen();

            while (isSelected)
            {
                isSelected = IsPromptMenuSelection((int)Constants.MenuType.Main);
                switch(menuValue)
                {
                    case (int)Constants.MainMenu.GoBack:
                        return;
                    case (int)Constants.MainMenu.LectureScheduleSearch:
                    case (int)Constants.MainMenu.FavoriteSubjectsPut:
                    case (int)Constants.MainMenu.CourseRegistration:
                    case (int)Constants.MainMenu.CourseRegistrationHistoryCheck:
                        break;
                }   // 여기부터
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
                case (int)Constants.MenuType.Search:
                    length = 2;
                    break;
                case (int)Constants.MenuType.Main:
                case (int)Constants.MenuType.FavoriteSubject:
                case (int)Constants.MenuType.CourseRegistration:
                    length = 4;
                    break;
                case (int)Constants.MenuType.InputSearch:
                    length = 5;
                    break;
            }
            return length;
        }
    }
}
