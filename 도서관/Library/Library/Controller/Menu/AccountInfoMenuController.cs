using Library.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Controller
{
    public class AccountInfoMenuController : MenuController
    {
        private int modeValue;

        public AccountInfoMenuController(int modeValue) : base()
        {
            this.modeValue = modeValue;
        }

        public override void Run()
        {
            base.menuValue = 0;
            bool isMenuSelect = true;
            string[] menuString = null;
            switch (modeValue)
            {
                case (int)Constants.LibraryMode.User:
                    menuString = base.DecideMenuType((int)Constants.Type.UserInfo);
                    break;
                case (int)Constants.LibraryMode.Manager:
                    menuString = base.DecideMenuType((int)Constants.Type.ManagerInfo);
                    break;
            }

            while (isMenuSelect)
            {
                menuScreen.PrintMenu(menuString, menuValue, coordinate);
                isMenuSelect = SelectMenu();
                if (menuValue > 1)
                    menuValue = 1;
            }

            switch(menuValue)
            {
                case (int)Constants.InfoMenu.GoBack:
                    return;
                case (int)Constants.InfoMenu.Modify:    // 개인 또는 회원 정보 수정 기능

                    break;
                case (int)Constants.InfoMenu.Delete:    // 개인 또는 회원 정보 삭제 기능

                    break;
            }
        }
    }
}
