using Library.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Controller
{
    public class QuitMenuController : MenuController
    {
        public override void Run()
        {
            Console.Clear();
            base.menuValue = 0;
            bool isMenuSelect = true;
            string[] menuString = base.DecideMenuType((int)Constants.Type.YesNo);

            while (isMenuSelect)
            {
                base.menuScreen.PrintMenu(menuString, menuValue + 1, coordinate);
                isMenuSelect = SelectMenu();

                if (menuValue > 1)
                    menuValue = 1;
            }
            
            switch(menuValue)
            {
                case (int)Constants.YesNo.Yes:
                    Environment.Exit(0);
                    break;
                //case (int)Constants.YesNo.No + 1:
                //case (int)Constants.YesNo.GoBack:
                //    ModeMenuController modeMenu = new ModeMenuController();
                //    modeMenu.Run();
                //    break;
            }
        }
    }
}
