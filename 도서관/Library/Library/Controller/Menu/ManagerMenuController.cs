using Library.Controller.Menu;
using Library.Utility;
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
        public ManagerMenuController() : base()
        {
            this.managerModifyDeleteMenuController = new ManagerModifyDeleteMenuController();
            this.bookSearchMenuController = new BookSearchMenuController();
            this.bookAddMenuController = new BookAddMenuController();
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

                    break;
                case (int)Constants.ManagerMenu.BookModify:

                    break;
                case (int)Constants.ManagerMenu.UserControl:
                    isBack = managerModifyDeleteMenuController.Run();
                    break;
                case (int)Constants.ManagerMenu.RentalHistory:

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
    }
}
