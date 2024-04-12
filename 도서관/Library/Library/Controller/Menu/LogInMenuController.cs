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
        private CheckInformation checkInformation;
        private UserMenuController userMenuController;
        private ManagerMenuController managerMenuController;
        private int modeValue;

        public LogInMenuController(int modeValue)
        {
            inputTaskController = new InputTaskController();
            checkInformation = new CheckInformation();
            userMenuController = new UserMenuController();
            managerMenuController = new ManagerMenuController();
            this.modeValue = modeValue;
        }

        public override bool Run()
        {
            base.menuValue = 0;
            bool isLogIn = false;
            string[] menuString = base.DecideMenuType((int)Constants.MenuType.LogIn);
            string id = null, password = null;

            base.menuScreen.EraseMenu();
            while (!isLogIn)
            {
                bool isMenuSelect = true;
                while (isMenuSelect)
                {
                    menuScreen.PrintMenu(menuString, menuValue, false);
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

                if (id != null && password != null)
                    break;
            }
           
            isLogIn = checkInformation.Check(new string[] {id, password}, (int)Constants.MenuType.LogInSignUp);
 
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
                Run();  // 입력정보가 없을 때

            return false;
        }
    }
}
