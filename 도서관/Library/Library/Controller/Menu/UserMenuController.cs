﻿using Library.Controller.Menu;
using Library.Controller.Task;
using Library.Utility;
using Library.View;
using Library.Model;
using System;
using System.Collections.Generic;

namespace Library.Controller
{
    public class UserMenuController : MenuController
    {
        private  UserModifyDeleteMenuController userModifyDeleteMenuController;
        private InformationController informationController;
        private BookSearchMenuController bookSearchMenuController;
        private BookScreen bookScreen;

        public UserMenuController() : base()
        {
            this.userModifyDeleteMenuController = new UserModifyDeleteMenuController();
            this.informationController = new InformationController();
            this.bookSearchMenuController = new BookSearchMenuController();
            this.bookScreen = new BookScreen();
            base.menuString = base.DecideMenuType((int)Constants.MenuType.User);
        }

        public override bool Run()
        {
            Console.Clear();
            base.menuValue = 0;
            bool isBack = false;
            bool isMenuSelect = true;

            while (isMenuSelect)
            {
                base.menuScreen.PrintMenu(menuString, menuValue, false);
                isMenuSelect = SelectMenu();
                if (menuValue > 6)
                    menuValue = 6;
            }


            switch (menuValue)
            {
                case (int)Constants.UserMenu.GoBack:
                    return true;
                case (int)Constants.UserMenu.BookSearch:
                    isBack = func1();
                    break;
                case (int)Constants.UserMenu.BookRental:
                    isBack = func2();
                    break;
                case (int)Constants.UserMenu.BookRentalHistory:
                    isBack = func3();
                    break;
                case (int)Constants.UserMenu.BookReturn:
                    isBack = func4();
                    break;
                case (int)Constants.UserMenu.BookReturnHistory:
                    isBack = func5();
                    break;
                case (int)Constants.UserMenu.InfoModify:
                    isBack = userModifyDeleteMenuController.Run();
                    break;
            }
            
            if (isBack)
                Run();
            return false;
        }

        private bool func1()
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

        private bool func2()
        {
            bool isBack = bookSearchMenuController.Run();
            if (isBack)
            {
                bookScreen.PrintIdSearch("대여할 책의 ID를 입력해 주세요");
                Console.SetCursorPosition(8, 2);
                Console.CursorVisible = true;
                int id = int.Parse(Console.ReadLine());
                Console.CursorVisible = false;

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

        private bool func3()
        {
            List<BookDto> rentalBookList = informationController.GetRentalBook();
            if (rentalBookList != null)
            {
                Console.Clear();
                ExplainingScreen.PrintIdInputString("대여한 책의 리스트 입니다.");
                bookScreen.PrintBookInfo(rentalBookList);
                ExplainingScreen.PrintEnterCheck();
                Console.ReadLine();
                return true;
            }

            return false;
        }

        private bool func4()
        {
            Console.Clear();
            List<BookDto> rentalBookList = informationController.GetRentalBook();
            if (rentalBookList != null)
            {
                bookScreen.PrintBookInfo(rentalBookList);
                bookScreen.PrintIdSearch("반납할 책의 ID를 입력해 주세요");
                Console.SetCursorPosition(8, 2);
                Console.CursorVisible = true;
                int id = int.Parse(Console.ReadLine());
                Console.CursorVisible = false;
                BookDto book = informationController.SearchIdBooks(id);
                if (book != null)
                {
                    Console.Clear();
                    ExplainingScreen.PrintComplete("책을 반납하는데 성공!");
                    Console.ReadLine();
                    bool isReturnBook = informationController.RemoveReturnBook(book);
                    return true;
                }
            }

            return false;
        }

        private bool func5()
        {
            List<BookDto> returnBookList = informationController.GetReturnBook();
            if (returnBookList != null)
            {
                Console.Clear();
                ExplainingScreen.PrintIdInputString("반납한 책의 리스트 입니다.");
                bookScreen.PrintBookInfo(returnBookList);
                ExplainingScreen.PrintEnterCheck();
                Console.ReadLine();
                return true;
            }

            return false;
        }
    }
}
