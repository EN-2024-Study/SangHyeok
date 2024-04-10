using Library.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Controller
{
    public class LogInMenuController : MenuController
    {
        private int modeValue;

        public LogInMenuController(int value) : base()
        {
            modeValue = value;
        }

        public override void Run()
        {
            bool isMenuSelect = true;

            while (isMenuSelect)
            {
                base.Screen.PrintLogInMenu(base.MenuValue % 3);
                isMenuSelect = base.SelectMenu();
            }

            switch (modeValue)  // 기능으로 넘어가기
            {
                case 0:
                    
                    break;
                case 1:

                    break;
            }
        }
    }
}
