using Library.Utility;
using Library.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Controller
{
    public class AccountController
    {
        private StartScreen startScreen;

        public AccountController()
        {
            this.startScreen = new StartScreen();
        }

        public void SelectModeMenu()
        {
            bool isSelected = true;
            while(isSelected)
            {
                startScreen.DrawScreen((int)Constants.ScreenType.Mode, false);
                switch(MenuSelector.SelectMenu((int)Constants.ScreenType.Mode))
                {
                    case -1:
                        isSelected = false;
                        break;
                    case 1:

                        break;
                }
                

            }
        }
    }
}
