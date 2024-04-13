using Library.Utility;
using Library.View;
using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Library.Controller.Task;

namespace Library.Controller.Menu
{
    public class UserModifyMenuController : MenuController
    {
        private UserModifyScreen userModifyScreen;
        private InformationController informationController;
        private InputController inputController;

        public UserModifyMenuController() : base()
        {
            this.userModifyScreen = new UserModifyScreen();
            this.informationController = new InformationController();
            this.inputController = new InputController();
            base.menuString = base.DecideMenuType((int)Constants.MenuType.UserModify);
        }

        public override bool Run()
        {
            Console.Clear();
            AccountDto account = informationController.GetAccount();
            base.menuValue = 0;
            bool isModify = true;
            string[] inputString = new string[5];

            userModifyScreen.PrintAccountInfomation(account);
            ExplainingScreen.ExplainInputKey();
            
            while(isModify)
            {
                bool isNull = false;
                bool isMenuSelect = true;
                while (isMenuSelect)
                {
                    base.menuScreen.PrintMenu(menuString, menuValue, false);
                    isMenuSelect = base.SelectMenu();
                    if (menuValue > 4)
                        menuValue = 4;
                }
                base.menuScreen.PrintMenu(menuString, menuValue, true);

                switch (menuValue)
                {
                    case (int)Constants.UserModifyMenu.GoBack:
                        return true;
                    case (int)Constants.UserModifyMenu.Password:
                        inputString[0] = null;
                        inputString[0] = inputController.LimitInputLength(new Tuple<int, int>(41, 15), 15, true);
                        break;
                    case (int)Constants.UserModifyMenu.Name:
                        inputString[1] = null;
                        inputString[1] = inputController.LimitInputLength(new Tuple<int, int>(41, 17), 15, false);
                        break;
                    case (int)Constants.UserModifyMenu.Age:
                        inputString[2] = null;
                        inputString[2] = inputController.LimitInputLength(new Tuple<int, int>(41, 19), 15, false);
                        break;
                    case (int)Constants.UserModifyMenu.PhoneNumber:
                        inputString[3] = null;
                        inputString[3] = inputController.LimitInputLength(new Tuple<int, int>(41, 21), 15, false);
                        break;
                    case (int)Constants.UserModifyMenu.Address:
                        inputString[4] = null;
                        inputString[4] = inputController.LimitInputLength(new Tuple<int, int>(41, 23), 15, false);
                        break;
                }

                foreach(string s in inputString)
                {
                    if (s == null)
                    {
                        isNull = true;
                        break;
                    }
                }

                if (!isNull)
                {
                    ExplainingScreen.PrintEnterCheck();
                    Console.ReadLine();

                    AccountDto newAccount = new AccountDto(account.Id, inputString[0], inputString[1], inputString[2], inputString[3], inputString[4]);
                    informationController.ModifyAccount(newAccount, account);
                    return true;
                 }
            }

            return false;
        }
    }
}
