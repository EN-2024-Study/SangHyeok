using Library.Controller.Task;
using Library.Utility;
using Library.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Library.Controller.Menu
{
    public class BookModifyMenuController : MenuController
    {
        private InputController inputController;
        private InformationController infoController;

        public BookModifyMenuController() : base()
        {
            this.inputController = new InputController();
            this.infoController = new InformationController();
            base.menuString = base.DecideMenuType((int)Constants.MenuType.ManagerModify);
        }

        public override bool Run()
        {
            base.menuScreen.EraseMenu();
            base.menuValue = 0;
            bool isSignUp = false;
            string[] inputString = new string[7];

            Console.Clear();
            ExplainingScreen.PrintBookInfo("도    서    수    정");
            ExplainingScreen.ExplainInputKey();

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

                menuScreen.PrintMenu(menuString, menuValue, true); // LimitInputLength 좌표 수정하기

                switch (menuValue)
                {
                    case (int)Constants.BookInfo.GoBack:
                        return true;
                    case (int)Constants.BookInfo.Title:
                        inputString[0] = inputController.LimitInputLength(new Tuple<int, int>(20, 7), 15, false);
                        break;
                    case (int)Constants.BookInfo.Writer:
                        inputString[1] = inputController.LimitInputLength(new Tuple<int, int>(20, 9), 15, true);
                        break;
                    case (int)Constants.BookInfo.Publisher:
                        inputString[2] = inputController.LimitInputLength(new Tuple<int, int>(20, 11), 15, true);
                        break;
                    case (int)Constants.BookInfo.Count:
                        inputString[3] = inputController.LimitInputLength(new Tuple<int, int>(20, 13), 15, false);
                        break;
                    case (int)Constants.BookInfo.Price:
                        inputString[4] = inputController.LimitInputLength(new Tuple<int, int>(20, 15), 15, false);
                        break;
                    case (int)Constants.BookInfo.ReleaseDate:
                        inputString[5] = inputController.LimitInputLength(new Tuple<int, int>(20, 17), 15, false);
                        break;
                    case (int)Constants.BookInfo.Info - 1:
                        inputString[6] = inputController.LimitInputLength(new Tuple<int, int>(20, 19), 15, false);
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

                    //infoController.SaveUserData(inputString);
                    return true;
                }
            }
            return false;
        }
    }
}
