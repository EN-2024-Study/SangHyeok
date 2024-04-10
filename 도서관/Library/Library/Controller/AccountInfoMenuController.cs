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
            menuValue = 0;
            bool isMenuSelect = true;

            while (isMenuSelect)
            {
                switch(modeValue)
                {
                    case (int)Constants.LibraryMode.User:
                        menuScreen.PrintThreeMenu((int)Constants.Type.UserInfo, menuValue);

                        break;
                    case (int)Constants.LibraryMode.Manager:
                        menuScreen.PrintThreeMenu((int)Constants.Type.ManagerInfo, menuValue);

                        break;
                }
                isMenuSelect = SelectMenu();
                if (menuValue > 2)
                    menuValue = 2;
            }

            switch(menuValue)
            {
                case (int)Constants.InfoMenu.Modify:    // 개인 정보 수정 기능

                    break;
                case (int)Constants.InfoMenu.Delete:    // 개인 정보 삭제 기능

                    break;
                case (int)Constants.InfoMenu.GoBack:
                    return;
            }
        }
    }
}
