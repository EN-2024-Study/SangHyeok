using Library.Controller.Task;
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
        private UserAccountTaskController userAccountTask;

        public LogInMenuController(int modeValue) : base()
        {
            this.modeValue = modeValue;
            this.userAccountTask = new UserAccountTaskController();
        }

        public override void Run()
        {
            menuValue = 0;
            bool isMenuSelect = true;
            bool isLogIn = true;

            while (isMenuSelect)
            {
                menuScreen.PrintThreeMenu((int)Constants.Type.LogInSignUp, menuValue);
                isMenuSelect = SelectMenu();
                if (menuValue > 2)
                    menuValue = 2;
            }

            switch(menuValue)   
            {
                case (int)Constants.LogInMenu.LogIn:
                    isLogIn = userAccountTask.LogIn(modeValue);
                    break;
                case (int)Constants.LogInMenu.SignUp:   // 회원가입(user인지 manager인지 체크)기능으로 가기
                    userAccountTask.SignUp(modeValue);
                    break;
                case (int)Constants.LogInMenu.GoBack:
                    modeMenuController = new ModeMenuController();
                    modeMenuController.Run();
                    break;
            }

            if (!isLogIn)
                Run();
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
