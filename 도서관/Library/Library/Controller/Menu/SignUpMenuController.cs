using Library.Controller.Task;
using Library.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Controller.Menu
{
    public class SignUpMenuController : MenuController
    {
        private InputController inputController;
        private InformationController infoController;

        public SignUpMenuController() : base()
        {
            inputController = new InputController();
            infoController = new InformationController();
            base.menuString = base.DecideMenuType((int)Constants.MenuType.SignUp);
        }

        public override bool Run()
        {
            base.menuScreen.EraseMenu();
            base.menuValue = 0;
            bool isSignUp = false;
            string[] inputString = new string[7];

            //bool isId = false, isPassword = false, isPasswordCheck = false, isName = false,
            //    isAge = false, isPhoneNumber = false, isAddress = false;
            //string id = null, password = null, passwordCheck = null, name = null, age = null,
            //    phoneNumber = null, address = null;

            while (!isSignUp)
            {
                bool isMenuSelect = true;
                bool isNull = false;
                while (isMenuSelect)
                {
                    menuScreen.PrintMenu(menuString, menuValue, false);
                    isMenuSelect = SelectMenu();
                    if (menuValue > 6)
                        menuValue = 6;
                }

                menuScreen.PrintMenu(menuString, menuValue, true);  // 선택한 메뉴를 파란색으로 다시 띄우기

                switch (menuValue)
                {
                    case (int)Constants.SignUpMenu.GoBack:
                        return true;
                    case (int)Constants.SignUpMenu.Id:
                        inputString[0] = inputController.LimitInputLength(new Tuple<int, int>(35, 15), 15, false);
                        break;
                    case (int)Constants.SignUpMenu.Password:
                        inputString[1] = inputController.LimitInputLength(new Tuple<int, int>(35, 17), 15, true);
                        break;
                    case (int)Constants.SignUpMenu.PasswordCheck:
                        inputString[2] = inputController.LimitInputLength(new Tuple<int, int>(35, 19), 15, true);
                        break;
                    case (int)Constants.SignUpMenu.Name:
                        inputString[3] = inputController.LimitInputLength(new Tuple<int, int>(35, 21), 15, false);
                        break;
                    case (int)Constants.SignUpMenu.Age:
                        inputString[4] = inputController.LimitInputLength(new Tuple<int, int>(35, 23), 15, false);
                        break;
                    case (int)Constants.SignUpMenu.PhoneNumber:
                        inputString[5] = inputController.LimitInputLength(new Tuple<int, int>(35, 25), 15, false);
                        break;
                    case (int)Constants.SignUpMenu.Address:
                        inputString[6] = inputController.LimitInputLength(new Tuple<int, int>(35, 27), 15, false);
                        break;
                }

                for (int i = 0; i < 7; i++)
                {
                    if (inputString[i] == null)
                    {
                        isNull = true;
                        break;
                    }
                }

                if (!isNull)
                {
                    ExplainingScreen.PrintEnterCheck();
                    Console.ReadLine();
                    infoController.SaveUserData(inputString);
                    return true;
                }
            }
            return false;
        }
    }
}
