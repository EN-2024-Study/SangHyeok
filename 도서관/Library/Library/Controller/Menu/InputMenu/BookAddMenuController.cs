using Library.Controller.Task;
using Library.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Controller.Menu
{
    public class BookAddMenuController : MenuController
    {
        private InputController inputController;
        private InformationController informationController;

        public BookAddMenuController() : base()
        {
            this.inputController = new InputController();
            this.informationController = new InformationController();
            base.menuString = base.DecideMenuType((int)Constants.MenuType.BookAdd);
        }

        public override bool Run()
        {
            base.menuValue = 0;
            bool isModify = true;
            string[] inputString = new string[8] { "", "", "", "", "", "", "", "" };

            Console.Clear();
            ExplainingScreen.PrintBookInfo("도    서    추    가");
            ExplainingScreen.ExplainInputKey();
            while (isModify)
            {
                bool isMenuSelect = true;
                while (isMenuSelect)
                {
                    menuScreen.PrintMenu(menuString, menuValue, false);
                    isMenuSelect = SelectMenu();
                    if (menuValue > 9)
                        menuValue = 9;
                }

                menuScreen.PrintMenu(menuString, menuValue, true);  

                switch (menuValue)
                {
                    case (int)Constants.BookInfo.GoBack:
                        return true;
                    case (int)Constants.BookInfo.Title:
                        inputString[0] = inputController.LimitInputLength(new Tuple<int, int>(20, 7), 15, false);
                        break;
                    case (int)Constants.BookInfo.Writer:
                        inputString[1] = inputController.LimitInputLength(new Tuple<int, int>(20, 9), 15, false);
                        break;
                    case (int)Constants.BookInfo.Publisher:
                        inputString[2] = inputController.LimitInputLength(new Tuple<int, int>(20, 11), 15, false);
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
                    case (int)Constants.BookInfo.ISBN:
                        inputString[6] = inputController.LimitInputLength(new Tuple<int, int>(20, 19), 15, false);
                        break;
                    case (int)Constants.BookInfo.Info:
                        inputString[7] = inputController.LimitInputLength(new Tuple<int, int>(20, 21), 15, false);
                        break;
                    case (int)Constants.BookInfo.Check:
                        isModify = false;
                        break;
                }

                if (!isModify)
                    break;
            }

            for (int i = 0; i < 8; i++)
                if (inputString[i] != "")
                    inputString[i] = informationController.TrimString(inputString[i]);
           
            ExplainingScreen.PrintComplete("책 추가 성공!");
            ExplainingScreen.PrintEnterCheck();
            Console.ReadLine();
            informationController.SaveBookData(inputString);
            return true;
        }


    }
}
