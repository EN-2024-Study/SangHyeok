using Library.Controller.Task;
using Library.Model;
using Library.Utility;
using Library.View;
using System;
using System.Collections.Generic;

namespace Library.Controller.Menu
{
    public class BookSearchMenu : MenuController
    {
        private InputController inputController;
        private InformationController informationController;
        private InformationScreen screen;

        public BookSearchMenu()
        {
            this.inputController = new InputController();
            this.informationController = new InformationController();
            this.screen = new InformationScreen();
            base.menuString = base.DecideMenuType((int)Constants.MenuType.SearchBook);
        }

        public override bool Run()
        {
            Console.Clear();
            ExplainingScreen.ExplainInputKey();
            ExplainingScreen.PrintEsc();
            ExplainingScreen.PrintEnter();
            informationController.ShowAllBookInfo();
            base.menuValue = 0;
            bool isInput = false;
            string[] inputString = new string[3] { "", "", "" };

            while (!isInput)
            {
                bool isMenuSelect = true;
                while (isMenuSelect)
                {
                    menuScreen.PrintMenu(menuString, menuValue, false);
                    isMenuSelect = SelectMenu();
                    if (menuValue > 3)
                        menuValue = 3;
                }

                menuScreen.PrintMenu(menuString, menuValue, true);  // 선택한 메뉴를 파란색으로 다시 띄우기
                switch (menuValue)
                {
                    case (int)Constants.BookInfo.GoBack:
                        return true;
                    case (int)Constants.BookInfo.Title:
                        inputString[0] = inputController.LimitInputLength(new Tuple<int, int>(21, 0), 15, false);
                        break;
                    case (int)Constants.BookInfo.Writer:
                        inputString[1] = inputController.LimitInputLength(new Tuple<int, int>(21, 2), 15, false);
                        break;
                    case (int)Constants.BookInfo.Publisher:
                        inputString[2] = inputController.LimitInputLength(new Tuple<int, int>(21, 4), 15, false);
                        break;
                    case 3:  // 확인 버튼
                        isInput = true;
                        break;
                }

                if (isInput)
                    break;
            }

            for (int i = 0; i < 3; i++)
                if (inputString[i] != "")
                    inputString[i] = informationController.TrimString(inputString[i]);
            
            Console.Clear();

            List<BookDto> searchedBooks = informationController.SearchBooks(inputString);
            screen.PrintBookInfo(searchedBooks);
            ExplainingScreen.PrintEnterCheck();
            Console.ReadLine();

            return true;
        }

        public int SearchId()
        {
            Console.SetCursorPosition(8, 2);
            Console.CursorVisible = true;
            int id = int.Parse(Console.ReadLine());
            Console.CursorVisible = false;
            return id;
        }
    }
}
