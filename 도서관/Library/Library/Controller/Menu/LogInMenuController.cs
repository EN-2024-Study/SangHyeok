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
        private InputController inputController;
        private UserMenuController userMenuController;
        private ManagerMenuController managerMenuController;
        private InformationController infoController;
        private int modeValue;
        private bool isCheckId;
        private bool isCheckPassword;
        private int checkCount;

        public LogInMenuController(int modeValue) : base()
        {
            this.inputController = new InputController();
            this.userMenuController = new UserMenuController();
            this.managerMenuController = new ManagerMenuController();
            this.infoController = new InformationController();
            this.modeValue = modeValue;
            this.isCheckId = false;
            this.isCheckPassword = false;
            this.checkCount = 0;
            base.menuString = base.DecideMenuType((int)Constants.MenuType.LogIn);
        }

        public override bool Run()
        {
            bool isBack = false;
            base.menuValue = 0;
            bool isLogIn = true;
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
                        id = null;
                        id = inputController.LimitInputLength(new Tuple<int, int>(25, 25), 15, false);
                        break;
                    case (int)Constants.LogInMenu.Password:
                        password = null;
                        password = inputController.LimitInputLength(new Tuple<int, int>(31, 27), 15, true);
                        break;
                }

                if (id != null)
                {
                    id = infoController.TrimString(id);
                    if (modeValue == (int)Constants.LibraryMode.User)
                        isCheckId = infoController.CheckUserLogIn(id, (int)Constants.InputType.Id);
                    else if (modeValue == (int)Constants.LibraryMode.Manager)
                        isCheckId = infoController.CheckManagerLogIn(id, (int)Constants.InputType.Id);
                    checkCount++;
                }
                if (password != null)
                {
                    password = infoController.TrimString(password);
                    if (modeValue == (int)Constants.LibraryMode.User)
                        isCheckPassword = infoController.CheckUserLogIn(password, (int)Constants.InputType.Password);
                    else if (modeValue == (int)Constants.LibraryMode.Manager)
                        isCheckPassword = infoController.CheckManagerLogIn(password, (int)Constants.InputType.Password);
                    checkCount++;
                }

                if (checkCount > 2)
                {
                    ExplainingScreen.PrintEnterCheck();
                    Console.ReadLine();
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
                        isBack = userMenuController.Run();
                        break;
                    case (int)Constants.LibraryMode.Manager:
                        isBack = managerMenuController.Run();
                        break;
                }
            }
            else
            {
                ExplainingScreen.PrintIncorrectInput();
                Console.ReadLine();
                return true;
            }

            if (isBack)
                return true;
            return false;
        }
    }
}
