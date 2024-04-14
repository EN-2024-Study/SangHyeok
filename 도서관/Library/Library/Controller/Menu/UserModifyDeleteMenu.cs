using Library.Model;
using Library.Utility;
using Library.View;
using System;

namespace Library.Controller.Menu
{
    public class UserModifyDeleteMenu : MenuController
    {
        private UserModifyMenu userModifyMenu;
        private InformationController informationController;
        private YesNoMenu yesNoMenu;

        public UserModifyDeleteMenu() : base()
        {
            this.userModifyMenu = new UserModifyMenu();
            this.informationController = new InformationController();
            this.yesNoMenu = new YesNoMenu();
            base.menuString = base.DecideMenuType((int)Constants.MenuType.UserInfo);
        }

        public override bool Run()
        {
            Console.Clear();
            base.menuValue = 0;
            bool isBack = false;
            bool isMenuSelect = true;

            while (isMenuSelect)
            {
                base.menuScreen.PrintMenu(menuString, menuValue, false);
                isMenuSelect = base.SelectMenu();
                if (menuValue > 1)
                    menuValue = 1;
            }

            switch (menuValue)
            {
                case (int)Constants.InfoMenu.GoBack:
                    return true;
                case (int)Constants.InfoMenu.Modify:    // 개인 또는 회원 정보 수정 기능
                    isBack = userModifyMenu.Run();
                    break;
                case (int)Constants.InfoMenu.Delete:    // 개인 또는 회원 정보 삭제 기능
                    isBack = Delete();
                    break;
            }

            if (isBack)
                return true;
            return false;
        }


        private bool Delete()
        {
            AccountDto account = informationController.GetAccount();
            if(informationController.DeleteAccount(account))
            {
                if (yesNoMenu.Run())
                    return false;
                ExplainingScreen.PrintComplete("삭제 성공!");
                ExplainingScreen.PrintEnterCheck();
                Console.ReadLine();
                return true;
            }
            return false;
        }
    }
}
