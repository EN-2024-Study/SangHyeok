using Library.Model;
using Library.Model.DtoVo;
using Library.Constants;
using Library.View;
using System;
using System.Collections.Generic;
using Library.Service;

namespace Library.Controller.ScreenController
{
    public class Book
    {
        private BookDao bookDao;
        private UserDao userDao;
        private BookService bookService;
        private MenuSelector menuSelector;
        private InputManager inputManager;
        private Account account;
        private LogManager logManager;
        private Screen screen;
        private string[] searchedBookStrings;
        private string[] bookInfoStrings;
        private string bookId;

        public Book(MenuSelector menuSelector, Account account, LogManager logManager)
        {
            this.menuSelector = menuSelector;
            this.account = account;
            this.logManager = logManager;
            this.bookService = new BookService(bookDao, userDao);
            this.bookDao = new BookDao();
            this.userDao = new UserDao();
            this.inputManager = new InputManager();
            this.screen = new Screen();
            this.searchedBookStrings = new string[] { null, null, null };
            this.bookInfoStrings = new string[] { null, null, null, null, null, null, null, null };
            this.bookId = null;
        }

        public void ControllBookSearchScreen(int type)
        {
            bool isSelected = true;
            menuSelector.menuValue = 0;

            ShowBooks((int)Enums.BookShowType.All);
            ExplainingScreen.ExplainSearchBookInfo();
            ExplainingScreen.DrawSearchLogo();
            while (isSelected)
            {
                isSelected = menuSelector.IsMenuSelection((int)Enums.MenuType.BookSearch);
                if (!isSelected)
                    return;

                if (menuSelector.menuValue == (int)Enums.BookSearchMenu.Check)
                {
                    ShowBooks((int)Enums.BookShowType.Searched);
                    RecordSearchedLog(type);
                    searchedBookStrings = new string[] { null, null, null };
                    ExplainingScreen.ExplainEcsKey(0);
                    menuSelector.WaitForEscKey();
                    break;
                }
                else
                    InputSearchBook(menuSelector.menuValue);
            }
        }

        public void ControllBookRentalScreen()
        {
            ShowBooks((int)Enums.BookShowType.All);
            InputBookId();
            if (BookId == null)
                return;
            else if (bookService.IsBookRentalValid(bookId, account.LoggedInId) && 
                bookService.IsBookCountValid(bookId))
            {
                bookService.RentalBook(bookId, account.LoggedInId);
                logManager.AddLog(account.LoggedInId, LogStrings.BOOK_RENTAL, bookId + LogStrings.BOOK_ID);
                bookId = null;
                ExplainingScreen.ExplainSuccessScreen();
            }
            menuSelector.WaitForEscKey();
        }

        public void ControllReturnBookScreen()
        {
            ShowRentalBooks();
            InputBookId();

            if (BookId == null)
                return;
            else if (bookService.IsBookReturnValid(bookId, account.LoggedInId))
            {
                logManager.AddLog(account.LoggedInId, LogStrings.BOOK_RETURN, bookId + LogStrings.BOOK_ID);
                ExplainingScreen.ExplainSuccessScreen();
            }
            menuSelector.WaitForEscKey();
        }

        public void ControllBookAddScreen()
        {
            bool isSelected = true;
            menuSelector.menuValue = 0;

            Console.Clear();
            ExplainingScreen.ExplainSearchBookInfo();
            ExplainingScreen.ExplainInputBookInfo();
            while (isSelected)
            {
                isSelected = menuSelector.IsMenuSelection((int)Enums.MenuType.BookAdd);
                if (!isSelected)
                    return;

                if (menuSelector.menuValue == (int)Enums.BookAddInfo.Check)
                {
                    if (bookService.IsBookAddValid(bookInfoStrings))
                    {
                        bookService.AddBook(bookInfoStrings);
                        logManager.AddLog(LogStrings.MANAGER, LogStrings.BOOK_ADD, bookInfoStrings[0]);
                    }
                    menuSelector.WaitForEscKey();
                    break;
                }
                else
                    InputBookInfo(menuSelector.menuValue);
            }
        }

        public void ControllBookDeleteScreen()
        {
            ShowBooks((int)Enums.BookShowType.All);
            InputBookId();
            if (BookId == null)
                return;
            else if (bookService.IsBookDeleteValid(bookId))
            {
                bookService.DeleteBook(bookId);
                logManager.AddLog(LogStrings.MANAGER, LogStrings.BOOK_DELETE, bookId + LogStrings.BOOK_ID);
                bookId = null;
                ExplainingScreen.ExplainSuccessScreen();
            }

            menuSelector.WaitForEscKey();
        }

        public void InputBookModify()
        {
            ShowBooks((int)Enums.BookShowType.All);
            InputBookId();
            if (BookId == null)
                return;
            else
                ControllBookModifyScreen();
            menuSelector.WaitForEscKey();
        }

        private void ControllBookModifyScreen()
        {
            bool isSelected = true;
            menuSelector.menuValue = 0;

            ShowBookInfo();
            ExplainingScreen.ExplainSearchBookInfo();
            ExplainingScreen.ExplainInputBookInfo();
            while (isSelected)
            {
                isSelected = menuSelector.IsMenuSelection((int)Enums.MenuType.BookModify);
                if (!isSelected)
                    return;

                if (menuSelector.menuValue == (int)Enums.BookModifyInfo.Check)
                {
                    if (bookService.IsBookDeleteValid(bookId) && bookService.IsBookModifyValid(bookInfoStrings))
                    {
                        bookService.ModifyBook(bookInfoStrings, bookId);
                        logManager.AddLog(LogStrings.MANAGER, LogStrings.BOOK_MODIFY, bookId + LogStrings.BOOK_ID);
                        bookId = null;
                        ExplainingScreen.ExplainSuccessScreen();
                    }
     
                    menuSelector.WaitForEscKey();
                    break;
                }
                else
                    InputBookInfo(menuSelector.menuValue);
            }
        }

        public void RequestBook(List<NaverBookVo> bookList)
        {
            ExplainingScreen.ExplainRequestTitle("요청할");
            string inputString = inputManager.LimitInputLength((int)Enums.InputType.RequestBook, false);
            if (inputString == null)
                return;

            NaverBookVo book = GetSearchedRequestBook(bookList, inputString);
            if (!bookService.IsRequestValid((int)Enums.ModeMenu.UserMode, bookDao.GetNaverBookList(), book))
            {
                menuSelector.WaitForEscKey();
                return;
            }

            logManager.AddLog(account.LoggedInId, LogStrings.REQUEST_BOOK, book.Title.ToString());
            bookDao.RequestBook(book, account.LoggedInId);
            ExplainingScreen.ExplainSuccessScreen();
            menuSelector.WaitForEscKey();
        }

        public void AddRequestedBook()
        {
            ShowNaverBook((int)Enums.ModeMenu.ManagerMode);
            ExplainingScreen.ExplainRequestTitle("추가할");
            string inputString = inputManager.LimitInputLength((int)Enums.InputType.RequestBook, false);
            if (inputString == null)
                return;

            List<NaverBookVo> bookList = bookDao.GetNaverBookList();
            NaverBookVo book = GetSearchedRequestBook(bookList, inputString);
            if (!bookService.IsRequestValid((int)Enums.ModeMenu.ManagerMode, bookList, book))
            {
                menuSelector.WaitForEscKey();
                return;
            }

            bookDao.AddRequestedBook(book);
            logManager.AddLog(LogStrings.MANAGER, LogStrings.REQUESTED_BOOK_ADD, book.Title.ToString());
            ExplainingScreen.ExplainSuccessScreen();
            menuSelector.WaitForEscKey();
        }

        private void ShowBooks(int typeValue)
        {
            Console.Clear();
            switch (typeValue)
            {
                case (int)Enums.BookShowType.All:
                    screen.DrawBooks(bookDao.GetBookList());
                    break;
                case (int)Enums.BookShowType.Searched:
                    screen.DrawBooks(ExploreSearchedBooks());
                    break;
            }
        }

        public void ShowRentalBooks()
        {
            Console.Clear();
            Console.SetWindowSize(70, 40);

            List<RentalBookDto> bookList = bookDao.GetRentalBookList();
            List<RentalBookDto> rentalBookList = new List<RentalBookDto>();
            foreach (RentalBookDto book in bookList)
                if (account.LoggedInId.Equals(book.UserId))
                    rentalBookList.Add(book);
            
            if (rentalBookList.Count > 0)
            {
                screen.DrawRentalBooks(17, account.LoggedInId, rentalBookList);
                logManager.AddLog(account.LoggedInId, LogStrings.BOOK_RENTAL_HISTORY, LogStrings.BLANK);
            }
        }

        public void ShowReturnBooks()
        {
            Console.Clear();
            Console.SetWindowSize(70, 40);

            List<ReturnBookDto> bookList = bookDao.GetReturnBookList();
            List<ReturnBookDto> returnBookList = new List<ReturnBookDto>();
            foreach(ReturnBookDto book in bookList)
                if (account.LoggedInId.Equals(book.UserId))
                    returnBookList.Add(book);

            if (returnBookList.Count > 0)
            {
                screen.DrawReturnBooks(account.LoggedInId, returnBookList);
                logManager.AddLog(account.LoggedInId, LogStrings.BOOK_RETURN_HISTORY, LogStrings.BLANK);
            }
        }

        public void ShowAllUserRentalHistory()
        {
            Console.Clear();
            Console.SetWindowSize(70, 40);

            int y = 17;
            List<UserDto> userList = userDao.GetUserList();
            List<RentalBookDto> bookList = bookDao.GetRentalBookList();
            foreach(UserDto user in userList)
            {
                List<RentalBookDto> rentalBookList = new List<RentalBookDto>();
                foreach (RentalBookDto book in bookList)
                    if (user.Id.Equals(book.UserId))
                        rentalBookList.Add(book);

                if (rentalBookList.Count > 0)
                {
                    screen.DrawRentalBooks(y, user.Id, rentalBookList);
                    y += rentalBookList.Count * 13 + 1;
                    logManager.AddLog(LogStrings.MANAGER, LogStrings.BOOK_RENTAL_HISTORY, LogStrings.BLANK);
                }
            }
        }

        public void ShowNaverBook(int type)
        {
            Console.Clear();
            Console.SetWindowSize(80, 40);
            List<NaverBookVo> bookList = bookDao.GetNaverBookList();

            if (type == (int)Enums.ModeMenu.UserMode)
            {
                List<NaverBookVo> naverBookList = new List<NaverBookVo>();
                foreach (NaverBookVo book in bookList)
                {
                    if (book.Userid.ToString().Equals(account.LoggedInId))
                        naverBookList.Add(book);
                }

                if (naverBookList.Count > 0)
                {
                    logManager.AddLog(account.LoggedInId, LogStrings.BOOK_REQUEST_HISTORY, LogStrings.BLANK);
                    screen.DrawNaverBooks(naverBookList);
                }
            }
            else if (type == (int)Enums.ModeMenu.ManagerMode)
            {
                logManager.AddLog(LogStrings.MANAGER, LogStrings.BOOK_REQUEST_HISTORY, LogStrings.BLANK);
                screen.DrawNaverBooks(bookList);
            }
        }

        private void ShowBookInfo()
        {
            List<BookDto> bookList = bookDao.GetBookList();
            BookDto book = null;
            foreach(BookDto value in bookList)
            {
                if (value.Id.Equals(bookId))
                {
                    book = value;
                    break;
                }
            }

            Console.SetWindowSize(70, 45);
            Console.Clear();
            Console.SetCursorPosition(0, 20);
            screen.DrawBookInfo(book);
        }

        private void InputBookId()
        {
            ExplainingScreen.ExplainInputId("책  ");
            ExplainingScreen.ExplainInputBookId();
            ExplainingScreen.DrawIdLogo();
            bookId = inputManager.LimitInputLength((int)Enums.InputType.BookId, false);
        }

        private void InputBookInfo(int inputType)
        {
            switch (inputType)
            {
                case (int)Enums.BookAddInfo.Title:
                    bookInfoStrings[0] = inputManager.LimitInputLength((int)Enums.InputType.Title, false);
                    break;
                case (int)Enums.BookAddInfo.Writer:
                    bookInfoStrings[1] = inputManager.LimitInputLength((int)Enums.InputType.Writer, false);
                    break;
                case (int)Enums.BookAddInfo.Publisher:
                    bookInfoStrings[2] = inputManager.LimitInputLength((int)Enums.InputType.Publisher, false);
                    break;
                case (int)Enums.BookAddInfo.Count:
                    bookInfoStrings[3] = inputManager.LimitInputLength((int)Enums.InputType.Count, false);
                    break;
                case (int)Enums.BookAddInfo.Price:
                    bookInfoStrings[4] = inputManager.LimitInputLength((int)Enums.InputType.Price, false);
                    break;
                case (int)Enums.BookAddInfo.ReleaseDate:
                    bookInfoStrings[5] = inputManager.LimitInputLength((int)Enums.InputType.ReleaseDate, false);
                    break;
                case (int)Enums.BookAddInfo.ISBN:
                    bookInfoStrings[6] = inputManager.LimitInputLength((int)Enums.InputType.ISBN, false);
                    break;
                case (int)Enums.BookAddInfo.Info:
                    bookInfoStrings[7] = inputManager.LimitInputLength((int)Enums.InputType.Info, false);
                    break;
            }
        }

        private void InputSearchBook(int inputType)
        {
            switch (inputType)
            {
                case (int)Enums.BookSearchMenu.Title:
                    searchedBookStrings[0] = inputManager.LimitInputLength((int)Enums.InputType.SearchedTitle, false);
                    break;
                case (int)Enums.BookSearchMenu.Writer:
                    searchedBookStrings[1] = inputManager.LimitInputLength((int)Enums.InputType.SearchedWriter, false);
                    break;
                case (int)Enums.BookSearchMenu.Publisher:
                    searchedBookStrings[2] = inputManager.LimitInputLength((int)Enums.InputType.SearchedPublisher, false);
                    break;
            }
        }

        private List<BookDto> ExploreSearchedBooks()
        {
            List<BookDto> searchedBookList = bookDao.GetBookList();

            for (int i = 0; i < 3; i++)
            {
                if (searchedBookStrings[i] == null || searchedBookStrings[i] == "")
                    continue;
                List<BookDto> temp = new List<BookDto>();
                foreach (BookDto book in searchedBookList)
                {
                    switch (i)
                    {
                        case (int)Enums.BookSearchMenu.Title:
                            if (book.Title.Contains(searchedBookStrings[i]))
                                temp.Add(book);
                            break;
                        case (int)Enums.BookSearchMenu.Writer:
                            if (book.Writer.Contains(searchedBookStrings[i]))
                                temp.Add(book);
                            break;
                        case (int)Enums.BookSearchMenu.Publisher:
                            if (book.Publisher.Contains(searchedBookStrings[i]))
                                temp.Add(book);
                            break;
                    }
                }

                searchedBookList = temp;
            }

            return searchedBookList;
        }

        private NaverBookVo GetSearchedRequestBook(List<NaverBookVo> bookList, string title)
        {
            NaverBookVo book = null;
            foreach (NaverBookVo item in bookList)
            {
                if (item.Title.ToString().Contains(title))
                {
                    book = item;
                    break;
                }
            }
            return book;
        }

        private void RecordSearchedLog(int type)
        {
            string playString = " ";
            string user = null;
            switch(type)
            {
                case (int)Enums.ModeMenu.UserMode:
                    user = account.LoggedInId;
                    break;
                case (int)Enums.ModeMenu.ManagerMode:
                    user = LogStrings.MANAGER;
                    break;
            }

            foreach(string item in searchedBookStrings)
            {
                if (item != null)
                {
                    playString = item;
                    break;
                }
            }

            logManager.AddLog(user, LogStrings.BOOK_SEARCH, playString);
        }

        public string BookId
        {
            get { return bookId; }
        }
    }
}