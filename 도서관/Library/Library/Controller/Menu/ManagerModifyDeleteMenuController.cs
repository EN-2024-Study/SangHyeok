using Library.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Controller.Menu
{
    public class ManagerModifyDeleteMenuController : MenuController
    {

        public ManagerModifyDeleteMenuController() : base()
        {

            base.menuString = base.DecideMenuType((int)Constants.MenuType.ManagerInfo);
        }

        public override bool Run()
        {
            Console.Clear();
            base.menuValue = 0;
            bool isBack = false;
            bool isMenuSelect = true;
        
            while (isMenuSelect)
            {
                menuScreen.PrintMenu(menuString, menuValue, false);
                isMenuSelect = SelectMenu();
                if (menuValue > 1)
                    menuValue = 1;
            }

            switch (menuValue)  
            {
                case (int)Constants.InfoMenu.GoBack:
                    return true;
                case (int)Constants.InfoMenu.Modify:  // 유저 정보 수정
                    
                    break;
                case (int)Constants.InfoMenu.Delete:   // 유저 계정 삭제
                    
                    break;
            }

            return false;
        }


    }

}
