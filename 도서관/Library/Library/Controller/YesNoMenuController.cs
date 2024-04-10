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
        private ModeMenuController modeMenu;    // stackOverFlowExceptoin 주의

        public YesNoMenuController()
        {
            modeMenu = new ModeMenuController();
        }

        public override void Run()
        {
            bool isMenuSelect = true;

            while (isMenuSelect)
            {
                base.Screen.PrintYesNoWindow(base.MenuValue % 2);
                isMenuSelect = base.SelectMenu();
            }

            if (base.MenuValue % 2 == (int)Constants.YesNo.No)
                modeMenu.Run(); // stackOverFlowExceptoin 주의
        }
    }
}
