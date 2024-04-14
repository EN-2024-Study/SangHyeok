using Library.Controller.Menu;
using Library.Model;
using Library.Utility;
using Library.View;
using System;

namespace Library.Controller
{
    public class ManagerMenu : MenuController
    {
        private MemberModifyDeleteMenu memberModifyDeleteMenu;
        private BookSearchMenu bookSearchMenu;
        private BookAddMenu bookAddMenu;
        private InformationController informationController;
        private BookModifyMenu bookModifyMenuController;
        private InformationScreen screen;
        public ManagerMenu() : base()
        {
            this.memberModifyDeleteMenu = new MemberModifyDeleteMenu();
            this.bookSearchMenu = new BookSearchMenu();
            this.bookAddMenu = new BookAddMenu();
            this.informationController = new InformationController();
            this.bookModifyMenuController = new BookModifyMenu();
            this.screen = new InformationScreen();
            base.menuString = base.DecideMenuType((int)Constants.MenuType.Manager);
        }

        public override bool Run()
        {
            Console.Clear();
            base.menuValue = 0;
            bool isMenuSelect = true;
            bool isBack = false;

            while (isMenuSelect)
            {
                menuScreen.PrintMenu(menuString, menuValue, false);
                isMenuSelect = base.SelectMenu();
                if (menuValue > 5)
                    menuValue = 5;
            }

            switch (menuValue)  // 기능 구현
            {
                case (int)Constants.UserMenu.GoBack:
                    return true;
                case (int)Constants.ManagerMenu.BookSearch:
                    isBack = SearchBook();
                    break;
                case (int)Constants.ManagerMenu.BookAdd:
                    isBack = bookAddMenu.Run();
                    break;
                case (int)Constants.ManagerMenu.BookDelete:
                    isBack = DeleteBook();
                    break;
                case (int)Constants.ManagerMenu.BookModify:
                    isBack = ModifyBook();
                    break;
                case (int)Constants.ManagerMenu.UserControll:
                    isBack = memberModifyDeleteMenu.Run();
                    break;
                case (int)Constants.ManagerMenu.AccountDelete:

                    break;
            }

            if (isBack)
                return true;
            return false;
        }

        private bool SearchBook()
        {
            bool isBack = bookSearchMenu.Run();
            if (isBack)
            {
                ExplainingScreen.PrintEnterCheck();
                Console.ReadLine();
                return true;
            }
            return false;
        }

        private bool DeleteBook()
        {
            Console.Clear();
            screen.PrintBookInfo(informationController.GetBookList());

            screen.PrintIdSearch("삭제할 책의 ID를 입력해 주세요");
            int id = bookSearchMenu.SearchId();
            BookDto book = informationController.SearchIdBooks(id);
            if (book != null)
            {
                Console.Clear();
                ExplainingScreen.PrintComplete("책을 삭제하는데 성공!");
                Console.ReadLine();
                informationController.DeleteBook(id);
                return true;
            }
            return false;
        }

        private bool ModifyBook()
        {
            if (bookModifyMenuController.FindBookToEdit())
                return bookModifyMenuController.Run();
            return false;
        }
    }
}
