﻿using Library.Utility;
using System;

namespace Library.Controller
{
    public class YesNoMenuController : MenuController
    {

        public YesNoMenuController() : base()
        {
            base.menuString = base.DecideMenuType((int)Constants.MenuType.YesNo);
        }

        public override bool Run()
        {
            base.menuValue = 0;
            bool isMenuSelect = true;

            base.menuScreen.EraseMenu();
            while (isMenuSelect)
            {
                base.menuScreen.PrintMenu(menuString, menuValue + 1, false);
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
