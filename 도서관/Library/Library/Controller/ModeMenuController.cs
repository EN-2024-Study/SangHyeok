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
            menuValue = 0;
            bool isMenuSelect = true;

            while (isMenuSelect)
            {
                menuScreen.PrintThreeMenu((int)Constants.ModeMenu.UserMode, menuValue);
                isMenuSelect = SelectMenu();
                if (menuValue > 2)
                    menuValue = 2;
            }

            switch (menuValue)
            {
                case (int)Constants.ModeMenu.UserMode:
                case (int)Constants.ModeMenu.ManagerMode:
                    logInMenu = new LogInMenuController(menuValue);
                    logInMenu.Run();
                    break;
                case (int)Constants.ModeMenu.Quit:
                    yesNoMenu = new YesNoMenuController();
                    yesNoMenu.Run();
                    break;
            }
        }
    }
}
