using Library.Controller.Task;
using Library.Utility;
using Library.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Controller.Menu
{
    public class LogInMenuController : MenuController
    {
        private InputTaskController inputTaskController;
        private UserMenuController userMenuController;
        private ManagerMenuController managerMenuController;
        private CheckInformation checkInformation;
        private int modeValue;

        public LogInMenuController(int modeValue)
        {
            inputTaskController = new InputTaskController();
            userMenuController = new UserMenuController();
            managerMenuController = new ManagerMenuController();
            checkInformation = new CheckInformation();
            this.modeValue = modeValue;
        }

        public override bool Run()
        {
            base.menuValue = 0;
            bool isLogIn = true;
            bool isCheckId = false;
            bool isCheckPassword = false;
            int isCheckCount = 0;
            string[] menuString = base.DecideMenuType((int)Constants.MenuType.LogIn);
            string id = null, password = null;

            base.menuScreen.EraseMenu();
            while (isLogIn)
            {
                bool isMenuSelect = true;
                while (isMenuSelect)
                {
                    menuScreen.PrintMenu(menuString, menuValue, false);
                    ExplainingScreen.ExplainInputKey();
                    isMenuSelect = SelectMenu();
                    if (menuValue > 1)
                        menuValue = 1;
                }
                menuScreen.PrintMenu(menuString, menuValue, true);  // 선택한 메뉴를 파란색으로 다시 띄우기

                switch (menuValue)
                {
                    case (int)Constants.LogInMenu.GoBack:
                        return true;
                    case (int)Constants.LogInMenu.Id:
                        id = inputTaskController.LimitInputLength(new Tuple<int, int>(25, 25), 15, false);
                        break;
                    case (int)Constants.LogInMenu.Password:
                        password = inputTaskController.LimitInputLength(new Tuple<int, int>(31, 27), 15, true);
                        break;
                }

                if (id != null)
                {
                    if (modeValue == (int)Constants.LibraryMode.User)
                        isCheckId = checkInformation.CheckUser(id, (int)Constants.InputType.Id);
                    else if (modeValue == (int)Constants.LibraryMode.Manager)
                        isCheckId = checkInformation.CheckManager(id, (int)Constants.InputType.Id);
                    isCheckCount++;
                }
                if (password != null)
                {
                    if (modeValue == (int)Constants.LibraryMode.User)
                        isCheckPassword = checkInformation.CheckUser(password, (int)Constants.InputType.Password);
                    else if (modeValue == (int)Constants.LibraryMode.Manager)
                        isCheckPassword = checkInformation.CheckManager(password, (int)Constants.InputType.Password);
                    isCheckCount++;
                }

                if (isCheckCount > 2)
                {
                    if (isCheckId && isCheckPassword)
                        break;
                    else
                    {
                        isLogIn = false;
                        break;
                    }
                }
            }

            if (isLogIn)
            {
                switch (modeValue)
                {
                    case (int)Constants.LibraryMode.User:
                        userMenuController.Run();
                        break;
                    case (int)Constants.LibraryMode.Manager:
                        managerMenuController.Run();
                        break;
                }
            }
            else
            {
                // 입력한 정보가 맞지 않다는 설명 출력
                Run();  // 입력정보가 없을 떄
            }

            return false;
        }
    }
}
