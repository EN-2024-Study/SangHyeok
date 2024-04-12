using Library.Utility;
using System;

namespace Library.Controller
{
    public class QuitMenuController : MenuController
    {
        public override bool Run()
        {
            base.menuValue = 0;
            bool isMenuSelect = true;
            string[] menuString = base.DecideMenuType((int)Constants.Type.YesNo);

            base.menuScreen.EraseMenu();
            while (isMenuSelect)
            {
                base.menuScreen.PrintMenu(menuString, menuValue + 1);
                isMenuSelect = SelectMenu();

                if (menuValue > 1)
                    menuValue = 1;
            }

            if (menuValue == (int)Constants.YesNo.No)
                return true;
            return false;
        }
    }
}
