using Library.Utility;
using Library.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Controller
{
    public class ModeMenuController : MenuController
    {
        private LogInMenuController logInMenu;
        private YesNoMenuController yesNoMenu;

        public override void Run()
        {
            base.MenuValue = 0;
            bool isMenuSelect = true;

            while (isMenuSelect)
            {
                base.Screen.PrintModeMenu(base.MenuValue % 3);
                isMenuSelect = base.SelectMenu();
            }

            switch(MenuValue % 3)
            {
                case (int)Constants.ModeMenu.Quit:
                    yesNoMenu.Run();
                    break;
                case (int)Constants.ModeMenu.UserMode:
                case (int)Constants.ModeMenu.ManagerMode:
                    logInMenu = new LogInMenuController(MenuValue % 3);
                    logInMenu.Run();
                    break;
            }
        }
    }
}
