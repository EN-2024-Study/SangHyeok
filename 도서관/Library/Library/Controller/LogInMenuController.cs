using Library.Utility;
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
        private ModeMenuController modeMenuController;

        public LogInMenuController(int value) : base()
        {
            modeValue = value;
        }

        public override void Run()
        {
            menuValue = 0;
            bool isMenuSelect = true;

            while (isMenuSelect)
            {
                menuScreen.PrintThreeMenu((int)Constants.Type.LogInSignUp, menuValue);
                isMenuSelect = SelectMenu();
                if (menuValue > 2)
                    menuValue = 2;
            }

            switch(menuValue)   
            {
                case (int)Constants.LogInMenu.LogIn:    // 로그인 기능으로 가기

                    break;
                case (int)Constants.LogInMenu.SignUp:   // 회원가입(user인지 manager인지 체크)기능으로 가기

                    break;
                case (int)Constants.LogInMenu.GoBack:
                    modeMenuController = new ModeMenuController();
                    modeMenuController.Run();
                    break;
            }
        }

        //private bool CheckMode(int modeValue)
        //{
        //    if (modeValue == )
        //    switch (modeValue)  // 기능으로 넘어가기
        //    {
        //        case (int)Constants.ModeMenu.UserMode:

        //        case 1:

        //            break;
        //    }
        //}
    }
}
