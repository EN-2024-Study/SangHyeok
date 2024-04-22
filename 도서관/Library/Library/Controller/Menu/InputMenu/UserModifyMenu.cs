using Library.Utility;
using Library.View;
using Library.Model;
using System;
using Library.Controller.Task;
using System.Collections.Generic;

namespace Library.Controller.Menu
{
    public class UserModifyMenu : MenuController
    {
        private InformationController informationController;
        private InputController inputController;
        private YesNoMenu yesNoMenu;
        private InformationScreen screen;

        public UserModifyMenu() : base()
        {
            this.screen = new InformationScreen();
            this.informationController = new InformationController();
            this.inputController = new InputController();
            this.yesNoMenu = new YesNoMenu();
            base.menuString = base.DecideMenuType((int)Constants.MenuType.UserModify);
        }

        public override bool Run()
        {
            Console.Clear();
            base.menuValue = 0;
            bool isModify = true;
            string[] inputString = new string[5] { "", "", "", "", "" };
            AccountDto account = informationController.GetAccount();

            screen.PrintAccountInfomation(account);
            ExplainingScreen.ExplainInputKey();
            
            while(isModify)
            {
                bool isMenuSelect = true;
                while (isMenuSelect)
                {
                    base.menuScreen.PrintMenu(menuString, menuValue, false);
                    isMenuSelect = base.SelectMenu();
                    if (menuValue > 5)
                        menuValue = 5;
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
                    case (int)Constants.UserModifyMenu.Check:
                        isModify = false;
                        break;
                }

                if (!isModify)
                    break;
            }

            for (int i = 0; i < 5; i++)
                if (inputString[i] != "")
                    inputString[i] = informationController.TrimString(inputString[i]);
            
            if (yesNoMenu.Run())
                return true;

            return Modify(inputString);
        }

        private bool Modify(string[] inputString)
        {
            AccountDto account = informationController.GetAccount();
            //string password, name, age, phone, address;
                
            AccountDto newAccount = new AccountDto(account.Id, inputString[0], inputString[1], inputString[2], inputString[3], inputString[4]);
            informationController.ModifyAccount(newAccount, account);

            Console.Clear();
            ExplainingScreen.PrintComplete("수정 성공!");
            ExplainingScreen.PrintEnterCheck();
            Console.ReadLine();
            return true;
        }
    }
}
