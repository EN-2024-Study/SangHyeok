using Library.Controller.Task;
using Library.Utility;
using Library.View;
using System;

namespace Library.Controller.Menu
{
    public class LogInMenu : MenuController
    {
        private InputController inputController;
        private UserMenu userMenu;
        private ManagerMenu managerMenu;
        private InformationController informationController;
        private int modeValue;
        private bool isCheckId;
        private bool isCheckPassword;

        public LogInMenu(int modeValue) : base()
        {
            this.inputController = new InputController();
            this.userMenu = new UserMenu();
            this.managerMenu = new ManagerMenu();
            this.informationController = new InformationController();
            this.modeValue = modeValue;
            base.menuString = base.DecideMenuType((int)Constants.MenuType.LogIn);
        }

        public override bool Run()
        {
            isCheckId = false;
            isCheckPassword = false;
            bool isBack = false;
            base.menuValue = 0;
            bool isLogIn = true;
            string id = "", password = "";

            base.menuScreen.EraseMenu();
            while (isLogIn)
            {
                bool isMenuSelect = true;
                while (isMenuSelect)
                {
                    menuScreen.PrintMenu(menuString, menuValue, false);
                    ExplainingScreen.ExplainInputKey();
                    isMenuSelect = SelectMenu();
                    if (menuValue > 2)
                        menuValue = 2;
                }
                menuScreen.PrintMenu(menuString, menuValue, true);  // 선택한 메뉴를 파란색으로 다시 띄우기

                switch (menuValue)
                {
                    case (int)Constants.LogInMenu.GoBack:
                        return true;
                    case (int)Constants.LogInMenu.Id:
                        id = inputController.LimitInputLength(new Tuple<int, int>(25, 25), 15, false);
                        break;
                    case (int)Constants.LogInMenu.Password:
                        password = inputController.LimitInputLength(new Tuple<int, int>(31, 27), 15, true);
                        break;
                    case (int)Constants.LogInMenu.Check:
                        isLogIn = false;
                        break;
                }

                if (!isLogIn)
                    break;                
            }

            if (id != "")
                id = informationController.TrimString(id);
            if (password != "")
                password = informationController.TrimString(password);

            if (modeValue == (int)Constants.LibraryMode.User)
            {
                isCheckId = informationController.CheckUserLogIn(id, (int)Constants.InputType.Id);
                isCheckPassword = informationController.CheckUserLogIn(password, (int)Constants.InputType.Password);
            }
            else if (modeValue == (int)Constants.LibraryMode.Manager)
            {
                isCheckId = informationController.CheckManagerLogIn(id, (int)Constants.InputType.Id);
                isCheckPassword = informationController.CheckManagerLogIn(password, (int)Constants.InputType.Password);
            }
            
            if(isCheckId && isCheckPassword)
            {
                ExplainingScreen.PrintComplete("로그인 성공!");
                Console.ReadLine();

                switch (modeValue)
                {
                    case (int)Constants.LibraryMode.User:
                        isBack = userMenu.Run();
                        //Console.WriteLine(isBack);
                        //Console.ReadLine();
                        break;
                    case (int)Constants.LibraryMode.Manager:
                        isBack = managerMenu.Run();
                        break;
                }
            }
            else
            {
                ExplainingScreen.PrintIncorrectInput();
                Console.ReadLine();
                Run();
            }

            if (isBack)
                return true;
            return false;
        }
    }
}
