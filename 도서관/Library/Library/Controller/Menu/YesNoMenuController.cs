using Library.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Controller
{
    public class YesNoMenuController : MenuController
    {
        private ModeMenuController modeMenu;   

        public YesNoMenuController()
        {
            modeMenu = new ModeMenuController();
        }

        public override void Run()
        {
            menuValue = 0;
            bool isMenuSelect = true;

            while (isMenuSelect)
            {
                menuScreen.PrintMenu((int)Constants.Type.YesNo, menuValue + 1, coordinate);
                isMenuSelect = SelectMenu();

                if (menuValue > 1)
                    menuValue = 1;
            }

            if (menuValue == (int)Constants.YesNo.No + 1)
                modeMenu.Run(); 
        }
    }
}
