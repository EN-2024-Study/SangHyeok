using Library.Model;
using Library.Model.DtoVo;
using Library.Constants;
using Library.View;
using System;
using System.Collections.Generic;

namespace Library.Controller
{
    public class BookController
    {
        private BookDao bookDao;
        private UserDao userDao;
        private MenuSelector menuSelector;
        private InputManager inputManager;
        private AccountController accountController;
        private Screen screen;
        private string[] searchedBookStrings;
        private string[] bookInfoStrings;
        private string bookId;

        public BookController(MenuSelector menuSelector, AccountController accountController)
        {
            this.menuSelector = menuSelector;
            this.accountController = accountController;
            this.bookDao = new BookDao();
            this.userDao = new UserDao();
            this.inputManager = new InputManager();
            this.screen = new Screen();
            this.searchedBookStrings = new string[] { null, null, null };
            this.bookInfoStrings = new string[] { null, null, null, null, null, null, null, null };
            this.bookId = null;
        }

        public void SearchBook()
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
                    ExplainingScreen.ExplainEcsKey(0);
                    menuSelector.WaitForEscKey();
                    break;
                }
                else
                    InputSearchBook(menuSelector.menuValue);
            }
        }

        public void AddBook()
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
                    if (IsBookAddValid())
                    {
                        bookDao.AddBook(new BookDto("0", bookInfoStrings[0], bookInfoStrings[1],
                            bookInfoStrings[2], int.Parse(bookInfoStrings[3]), bookInfoStrings[4], bookInfoStrings[5],
                            bookInfoStrings[6], bookInfoStrings[7]));
                    }
                    menuSelector.WaitForEscKey();
                    break;
                }
                else
                    InputBookInfo(menuSelector.menuValue);
            }
        }

        public void ModifyBook()
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
                    if (IsBookDeleteValid() && IsBookModifyValid())
                    {
                        Modify();
                        bookId = null;
                        ExplainingScreen.ExplainSuccessScreen();
                    }
     
                    menuSelector.WaitForEscKey();
                    break;
                }
                else
                    InputBookInfo(menuSelector.menuValue);
            }

            void Modify()
            {
                if (bookInfoStrings[0] != null)
                    bookDao.ModifyBookInfo(bookId, "title", bookInfoStrings[0]);
                if (bookInfoStrings[1] != null)
                    bookDao.ModifyBookInfo(bookId, "writer", bookInfoStrings[1]);
                if (bookInfoStrings[2] != null)
                    bookDao.ModifyBookInfo(bookId, "publisher", bookInfoStrings[2]);
                if (bookInfoStrings[3] != null)
                    bookDao.ModifyBookInfo(bookId, "count", int.Parse(bookInfoStrings[3]));
                if (bookInfoStrings[4] != null)
                    bookDao.ModifyBookInfo(bookId, "price", bookInfoStrings[4]);
                if (bookInfoStrings[5] != null)
                    bookDao.ModifyBookInfo(bookId, "releaseDate", bookInfoStrings[5]);
            }
        }

        public bool IsBookIdValid()
        {
            if (bookId == null)
            {
                ExplainingScreen.ExplainFailScreen();
                ExplainingScreen.ExplainInvalidInput("책 아이디");
                return false;
            }
            return true;
        }

        private bool IsBookModifyValid()
        {
            if (bookInfoStrings[1] != null && !RegularExpressionManager.IsWriterValid(bookInfoStrings[1]))
            {
                ExplainingScreen.ExplainFailScreen();
                ExplainingScreen.ExplainInvalidInput("작가");
                return false;
            }
            if (bookInfoStrings[5] != null && !RegularExpressionManager.IsReleaseDateValid(bookInfoStrings[5]))
            {
                ExplainingScreen.ExplainFailScreen();
                ExplainingScreen.ExplainInvalidInput("출시일");
                return false;
            }
            if (bookInfoStrings[6] != null && !RegularExpressionManager.IsISBNValid(bookInfoStrings[6]))
            {
                ExplainingScreen.ExplainFailScreen();
                ExplainingScreen.ExplainInvalidInput("ISBN");
                return false;
            }
            if (bookInfoStrings[3] != null)
            {
                foreach (char value in bookInfoStrings[3])
                {
                    if (('a' <= value && value <= 'z') ||   // 숫자가 아니면 false
                    ('A' <= value && value <= 'Z') ||
                    value == '-' || value == ' ')
                    {
                        ExplainingScreen.ExplainFailScreen();
                        ExplainingScreen.ExplainInvalidInput("수량");
                        return false;
                    }
                }
            }

            return true;
        }

        private bool IsBookAddValid()
        {
            foreach (string str in bookInfoStrings) // 모든 정보가 기입되지 않았다면 false
            {
                if (str == null)
                {
                    ExplainingScreen.ExplainFailScreen();
                    ExplainingScreen.ExplainNoInput();
                    return false;
                }
            }
               
            if (!IsBookModifyValid())
                return false;
            return true;
        }

        public bool IsBookRentalValid()
        {
            List<BookDto> bookList = bookDao.GetBookList();
            List<RentalBookDto> rentalBookList = bookDao.GetRentalBookList();

            foreach(RentalBookDto book in rentalBookList)  
            {
                if (book.UserId.Equals(accountController.LoggedInId))
                {
                    DateTime now = DateTime.Now;
                    DateTime returnTime = DateTime.ParseExact(book.ReturnTime, "yyyy-MM-dd HH:mm:ss", null);
                    if (now > returnTime)   // 연체 된 도서가 있다면 false
                    {
                        ExplainingScreen.ExplainFailScreen();
                        ExplainingScreen.ExplainDatePassed();
                        return false;
                    }

                    if (book.Id.Equals(bookId))  // 이미 같은 책을 빌렸다면 false
                    {
                        ExplainingScreen.ExplainFailScreen();
                        ExplainingScreen.ExplainDuplicationExist("책");
                        return false;
                    }
                }
            }

            foreach (BookDto book in bookList)  // 책의 수량이 1이상이면 true
                if (book.Id.Equals(bookId) && book.Count > 0)
                    return true;

            ExplainingScreen.ExplainFailScreen();
            ExplainingScreen.ExplainInvalidInput("입력");
            return false;
        }

        public bool IsBookReturnValid()
        {
            List<RentalBookDto> bookList = bookDao.GetRentalBookList();
            foreach (RentalBookDto book in bookList)
            {
                if (book.Id.Equals(bookId) && accountController.LoggedInId.Equals(book.UserId))
                {   // 책 아이디 입력이 빌린 책이 맞다면 true 
                    bookDao.ReturnBook(book);
                    bookId = null;
                    return true;
                }
            }

            ExplainingScreen.ExplainFailScreen();
            ExplainingScreen.ExplainInvalidInput("책 아이디");
            return false;
        }

        public bool IsBookDeleteValid()
        {
            List<RentalBookDto> rentalBookList = bookDao.GetRentalBookList();
            List<BookDto> bookList = bookDao.GetBookList();

            foreach(RentalBookDto book in rentalBookList)   // 도서가 대여 중이라면 false
            {
                if (book.Id.Equals(bookId))
                {
                    ExplainingScreen.ExplainFailScreen();
                    ExplainingScreen.ExplainDuplicationExist("빌린 도서");
                    return false;
                }
            }
                
            foreach (BookDto book in bookList)  
                if (book.Id.Equals(bookId))
                    return true;

            ExplainingScreen.ExplainFailScreen();
            ExplainingScreen.ExplainInvalidInput("책 아이디");
            return false;
        }

        public void RentalBook()
        {
            List<BookDto> bookList = bookDao.GetBookList();
            DateTime time = DateTime.Now;
            foreach (BookDto book in bookList)
            {
                if (book.Id.Equals(bookId) && book.Count > 0)
                {
                    bookDao.RentalBook(new RentalBookDto(book,
                        accountController.LoggedInId, time.ToString("yyyy-MM-dd HH:mm:ss"),
                        time.AddDays(7).ToString("yyyy-MM-dd HH:mm:ss")));
                    bookId = null;
                }
            }
        }

        public void DeleteBook()
        {
            List<BookDto> bookList = bookDao.GetBookList();
            for (int i = 0; i < bookList.Count; i++)
            {
                if (bookList[i].Id.Equals(bookId))
                {
                    bookDao.DeleteBook(bookId);
                    break;
                }
            }
            bookId = null;
        }

        public void ShowBooks(int typeValue)
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
            {
                if (accountController.LoggedInId.Equals(book.UserId))
                    rentalBookList.Add(book);
            }
            screen.DrawRentalBooks(17, accountController.LoggedInId, rentalBookList);
        }

        public void ShowReturnBooks()
        {
            Console.Clear();
            Console.SetWindowSize(70, 40);

            List<ReturnBookDto> bookList = bookDao.GetReturnBookList();
            List<ReturnBookDto> returnBookList = new List<ReturnBookDto>();
            foreach(ReturnBookDto book in bookList)
            {
                if (accountController.LoggedInId.Equals(book.UserId))
                    returnBookList.Add(book);
            }
            screen.DrawReturnBooks(accountController.LoggedInId, returnBookList);
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

                screen.DrawRentalBooks(y, user.Id, rentalBookList);
                y += rentalBookList.Count * 13 + 1;
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
            screen.DrawBookInfo(20, book);
        }

        public void InputBookId()
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

            searchedBookStrings = new string[] { null, null, null };
            return searchedBookList;
        }

        public string BookId
        {
            get { return bookId; }
        }
    }
}