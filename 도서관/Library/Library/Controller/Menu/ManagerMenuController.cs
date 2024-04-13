using Library.Controller.Menu;
using Library.Model;
using Library.Utility;
using Library.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Controller
{
    public class ManagerMenuController : MenuController
    {
        private ManagerModifyDeleteMenuController managerModifyDeleteMenuController;
        private BookSearchMenuController bookSearchMenuController;
        private BookAddMenuController bookAddMenuController;
        private InformationController informationController;
        private BookModifyMenuController bookModifyMenuController;
        private BookScreen bookScreen;
        public ManagerMenuController() : base()
        {
            this.managerModifyDeleteMenuController = new ManagerModifyDeleteMenuController();
            this.bookSearchMenuController = new BookSearchMenuController();
            this.bookAddMenuController = new BookAddMenuController();
            this.informationController = new InformationController();
            this.bookModifyMenuController = new BookModifyMenuController();
            this.bookScreen = new BookScreen();
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
                    isBack = bookAddMenuController.Run();
                    break;
                case (int)Constants.ManagerMenu.BookDelete:
                    isBack = DeleteBook();
                    break;
                case (int)Constants.ManagerMenu.BookModify:
                    isBack = bookModifyMenuController.Run();
                    break;
                case (int)Constants.ManagerMenu.UserControll:
                    isBack = managerModifyDeleteMenuController.Run();
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
            bool isBack = bookSearchMenuController.Run();
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

            bookScreen.PrintIdSearch("삭제할 책의 ID를 입력해 주세요");
            Console.SetCursorPosition(8, 2);
            Console.CursorVisible = true;
            int id = int.Parse(Console.ReadLine());
            Console.CursorVisible = false;

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
    }
}
