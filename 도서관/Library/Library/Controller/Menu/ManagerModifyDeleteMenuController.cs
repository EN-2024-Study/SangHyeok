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

            switch (menuValue)  // 수정 ㄱㄱ
            {
                case (int)Constants.InfoMenu.GoBack:
                    return true;
                case (int)Constants.InfoMenu.Modify:    
                    break;
                case (int)Constants.InfoMenu.Delete:    
                    break;
            }

            return false;
        }


    }

}
