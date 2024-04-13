using Library.Controller.Task;
using Library.Model;
using Library.Utility;
using Library.View;
using System;
using System.Collections.Generic;

namespace Library.Controller.Menu
{
    public class BookSearchMenuController : MenuController
    {
        private InputController inputController;
        private InformationController infoController;
        private BookScreen bookScreen;

        public BookSearchMenuController()
        {
            inputController = new InputController();
            infoController = new InformationController();
            bookScreen = new BookScreen();
            base.menuString = base.DecideMenuType((int)Constants.MenuType.SearchBook);
        }
        public override bool Run()
        {
            Console.Clear();
            ExplainingScreen.ExplainInputKey();
            ExplainingScreen.PrintEsc();
            ExplainingScreen.PrintEnter();
            infoController.ShowAllBookInfo();
            base.menuValue = 0;
            bool isInput = false;
            string[] inputString = new string[3];

            while (!isInput)
            {
                bool isMenuSelect = true;
                bool isNull = false;

                while (isMenuSelect)
                {
                    menuScreen.PrintMenu(menuString, menuValue, false);
                    isMenuSelect = SelectMenu();
                    if (menuValue > 2)
                        menuValue = 2;
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
                }

                for (int i = 0; i < 3; i++)
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
                    Console.Clear();

                    List<BookDto> searchedBooks = infoController.SearchBooks(inputString);
                    bookScreen.PrintBookInfo(searchedBooks);
                    return true;
                }
            }

            return false;
        }
    }
}
