using Library.Controller.Menu;
using Library.Controller.Task;
using Library.Utility;
using Library.View;
using Library.Model;
using System;
using System.Collections.Generic;

namespace Library.Controller
{
    public class UserMenu : MenuController
    {
        private  UserModifyDeleteMenu userModifyDeleteMenu;
        private InformationController informationController;
        private BookSearchMenu bookSearchMenu;
        private InformationScreen screen;

        public UserMenu() : base()
        {
            this.userModifyDeleteMenu = new UserModifyDeleteMenu();
            this.informationController = new InformationController();
            this.bookSearchMenu = new BookSearchMenu();
            this.screen = new InformationScreen();
            base.menuString = base.DecideMenuType((int)Constants.MenuType.User);
        }

        public override bool Run()
        {
            Console.Clear();
            base.menuValue = 0;
            bool isBack = false;
            bool isBackToMenu = false;
            bool isMenuSelect = true;

            while (isMenuSelect)
            {
                base.menuScreen.PrintMenu(menuString, menuValue, false);
                isMenuSelect = SelectMenu();
                if (menuValue > 5)
                    menuValue = 5;
            }

            switch (menuValue)
            {
                case (int)Constants.UserMenu.GoBack:    // 도서 검색 하고 돌아와서 누르면 false 반환이 됨
                    return true;
                case (int)Constants.UserMenu.BookSearch:
                    isBack = SearchBook();
                    break;
                case (int)Constants.UserMenu.BookRental:
                    isBack = RentalBook();
                    break;
                case (int)Constants.UserMenu.BookRentalHistory:
                    isBack = ShowRentalBookHistory();
                    break;
                case (int)Constants.UserMenu.BookReturn:
                    isBack = ReturnBook();
                    break;
                case (int)Constants.UserMenu.BookReturnHistory:
                    isBack = ShowReturnBookHistory();
                    break;
                case (int)Constants.UserMenu.InfoModify:
                    isBackToMenu = userModifyDeleteMenu.Run();
                    break;
            }

            if (isBack)
                Run();  // while문으로 처리하기
            if (isBackToMenu)
                return true;
            return false;
        }

        private bool SearchBook()
        {
            bool isBack = bookSearchMenu.Run();
            if (isBack)
                return true;
            return false;
        }

        private bool RentalBook()
        {
            bool isBack = bookSearchMenu.Run();
            if (isBack)
            {
                screen.PrintIdSearch("대여할 책의 ID를 입력해 주세요");
                int id = bookSearchMenu.SearchId();
                BookDto book = informationController.SearchIdBooks(id);

                if (book != null)
                {
                    Console.Clear();
                    ExplainingScreen.PrintComplete("책을 빌리는데 성공!");
                    Console.ReadLine();
                    informationController.RentalBook(book);
                    return true;
                }
            }
            return false;
        }

        private bool ShowRentalBookHistory()
        {
            List<BookDto> rentalBookList = informationController.GetRentalBook();
           
            Console.Clear();
            ExplainingScreen.PrintIdInputString("대여한 책의 리스트 입니다.");
            screen.PrintBookInfo(rentalBookList);
            ExplainingScreen.PrintEnterCheck();
            Console.ReadLine();
            return true;
          
        }

        private bool ReturnBook()
        {
            Console.Clear();
            List<BookDto> rentalBookList = informationController.GetRentalBook();
            
            screen.PrintBookInfo(rentalBookList);
            screen.PrintIdSearch("반납할 책의 ID를 입력해 주세요");
            int id = bookSearchMenu.SearchId();
            BookDto book = informationController.SearchIdBooks(id);

            Console.Clear();
            ExplainingScreen.PrintComplete("책을 반납하는데 성공!");
            ExplainingScreen.PrintEnterCheck();
            Console.ReadLine();
            bool isReturnBook = informationController.RemoveReturnBook(book);
            return true;
        }

        private bool ShowReturnBookHistory()
        {
            List<BookDto> returnBookList = informationController.GetReturnBook();
            
            Console.Clear();
            ExplainingScreen.PrintIdInputString("반납한 책의 리스트 입니다.");
            screen.PrintBookInfo(returnBookList);
            ExplainingScreen.PrintEnterCheck();
            Console.ReadLine();
            return true;
        }
    }
}
