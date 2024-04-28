using Library.Model;
using Library.Model.DtoVo;
using Library.Utility;
using Library.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Controller
{
    public class BookController
    {
        private BookRepository bookRepository;
        private UserRepository userRepository;
        private MenuSelector menuSelector;
        private InputManager inputManager;
        private AccountController accountController;
        private Screen screen;
        private string[] searchedBookStrings;
        private string[] bookInfoStrings;
        private string bookId;

        public BookController()
        {
            this.bookRepository = new BookRepository();
            this.userRepository = new UserRepository();
            this.menuSelector = new MenuSelector();
            this.inputManager = new InputManager();
            this.accountController = new AccountController();
            this.screen = new Screen();
            this.searchedBookStrings = new string[] { null, null, null };
            this.bookInfoStrings = new string[] { null, null, null, null, null, null, null, null };
            this.bookId = null;
        }

        public void SearchBook()
        {
            bool isSelected = true;
            menuSelector.menuValue = 0;

            ShowBooks((int)Constants.BookShowType.All);
            ExplainingScreen.ExplainSearchBookInfo();
            ExplainingScreen.DrawSearchLogo();
            while (isSelected)
            {
                isSelected = menuSelector.IsMenuSelection((int)Constants.MenuType.BookSearch);
                if (!isSelected)
                    return;

                if (menuSelector.menuValue == (int)Constants.BookSearchMenu.Check)
                {
                    ShowBooks((int)Constants.BookShowType.Searched);
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
                isSelected = menuSelector.IsMenuSelection((int)Constants.MenuType.BookAdd);
                if (!isSelected)
                    return;

                if (menuSelector.menuValue == (int)Constants.BookAddInfo.Check)
                {
                    if (IsBookAddValid())
                    {
                        bookRepository.AddBook(new BookDto("0", bookInfoStrings[0], bookInfoStrings[1],
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
                isSelected = menuSelector.IsMenuSelection((int)Constants.MenuType.BookModify);
                if (!isSelected)
                    return;

                if (menuSelector.menuValue == (int)Constants.BookModifyInfo.Check)
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
                    bookRepository.ModifyBookInfo(bookId, "title", bookInfoStrings[0]);
                if (bookInfoStrings[1] != null)
                    bookRepository.ModifyBookInfo(bookId, "writer", bookInfoStrings[1]);
                if (bookInfoStrings[2] != null)
                    bookRepository.ModifyBookInfo(bookId, "publisher", bookInfoStrings[2]);
                if (bookInfoStrings[3] != null)
                    bookRepository.ModifyBookInfo(bookId, "count", int.Parse(bookInfoStrings[3]));
                if (bookInfoStrings[4] != null)
                    bookRepository.ModifyBookInfo(bookId, "price", bookInfoStrings[4]);
                if (bookInfoStrings[5] != null)
                    bookRepository.ModifyBookInfo(bookId, "releaseDate", bookInfoStrings[5]);
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
            List<BookDto> bookList = bookRepository.GetBookList();
            List<RentalBookDto> rentalBookList = bookRepository.GetRentalBookList();

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
            List<RentalBookDto> bookList = bookRepository.GetRentalBookList();
            foreach (RentalBookDto book in bookList)
            {
                if (book.Id.Equals(bookId) && accountController.LoggedInId.Equals(book.UserId))
                {   // 책 아이디 입력이 빌린 책이 맞다면 true 
                    bookRepository.ReturnBook(book);
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
            List<RentalBookDto> rentalBookList = bookRepository.GetRentalBookList();
            List<BookDto> bookList = bookRepository.GetBookList();

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
            List<BookDto> bookList = bookRepository.GetBookList();
            DateTime time = DateTime.Now;
            foreach (BookDto book in bookList)
            {
                if (book.Id.Equals(bookId) && book.Count > 0)
                {
                    bookRepository.RentalBook(new RentalBookDto(book,
                        accountController.LoggedInId, time.ToString("yyyy-MM-dd HH:mm:ss"),
                        time.AddDays(7).ToString("yyyy-MM-dd HH:mm:ss")));
                    bookId = null;
                }
            }
        }

        public void DeleteBook()
        {
            List<BookDto> bookList = bookRepository.GetBookList();
            for (int i = 0; i < bookList.Count; i++)
            {
                if (bookList[i].Id.Equals(bookId))
                {
                    bookRepository.DeleteBook(bookId);
                    break;
                }
            }
            bookId = null;
        }

        public void ShowBooks(int typeValue)
        {
            Console.Clear();
            Console.SetWindowSize(70, 30);
            switch (typeValue)
            {
                case (int)Constants.BookShowType.All:
                    screen.DrawBooks(bookRepository.GetBookList());
                    break;
                case (int)Constants.BookShowType.Searched:
                    screen.DrawBooks(ExploreSearchedBooks());
                    break;
            }
        }

        public void ShowRentalBooks()
        {
            Console.Clear();
            Console.SetWindowSize(70, 30);

            List<RentalBookDto> bookList = bookRepository.GetRentalBookList();
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
            Console.SetWindowSize(70, 30);

            List<ReturnBookDto> bookList = bookRepository.GetReturnBookList();
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
            Console.SetWindowSize(70, 30);

            int y = 17;
            List<UserDto> userList = userRepository.GetUserList();
            List<RentalBookDto> bookList = bookRepository.GetRentalBookList();
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
            List<BookDto> bookList = bookRepository.GetBookList();
            BookDto book = null;
            foreach(BookDto value in bookList)
            {
                if (value.Id.Equals(bookId))
                {
                    book = value;
                    break;
                }
            }

            Console.SetWindowSize(70, 35);
            Console.Clear();
            screen.DrawBookInfo(20, book);
        }

        public void InputBookId()
        {
            ExplainingScreen.ExplainInputId("책  ");
            ExplainingScreen.ExplainInputBookId();
            ExplainingScreen.DrawIdLogo();
            bookId = inputManager.LimitInputLength((int)Constants.InputType.BookId, false);
        }

        private void InputBookInfo(int inputType)
        {
            switch (inputType)
            {
                case (int)Constants.BookAddInfo.Title:
                    bookInfoStrings[0] = inputManager.LimitInputLength((int)Constants.InputType.Title, false);
                    break;
                case (int)Constants.BookAddInfo.Writer:
                    bookInfoStrings[1] = inputManager.LimitInputLength((int)Constants.InputType.Writer, false);
                    break;
                case (int)Constants.BookAddInfo.Publisher:
                    bookInfoStrings[2] = inputManager.LimitInputLength((int)Constants.InputType.Publisher, false);
                    break;
                case (int)Constants.BookAddInfo.Count:
                    bookInfoStrings[3] = inputManager.LimitInputLength((int)Constants.InputType.Count, false);
                    break;
                case (int)Constants.BookAddInfo.Price:
                    bookInfoStrings[4] = inputManager.LimitInputLength((int)Constants.InputType.Price, false);
                    break;
                case (int)Constants.BookAddInfo.ReleaseDate:
                    bookInfoStrings[5] = inputManager.LimitInputLength((int)Constants.InputType.ReleaseDate, false);
                    break;
                case (int)Constants.BookAddInfo.ISBN:
                    bookInfoStrings[6] = inputManager.LimitInputLength((int)Constants.InputType.ISBN, false);
                    break;
                case (int)Constants.BookAddInfo.Info:
                    bookInfoStrings[7] = inputManager.LimitInputLength((int)Constants.InputType.Info, false);
                    break;
            }
        }

        private void InputSearchBook(int inputType)
        {
            switch (inputType)
            {
                case (int)Constants.BookSearchMenu.Title:
                    searchedBookStrings[0] = inputManager.LimitInputLength((int)Constants.InputType.SearchedTitle, false);
                    break;
                case (int)Constants.BookSearchMenu.Writer:
                    searchedBookStrings[1] = inputManager.LimitInputLength((int)Constants.InputType.SearchedWriter, false);
                    break;
                case (int)Constants.BookSearchMenu.Publisher:
                    searchedBookStrings[2] = inputManager.LimitInputLength((int)Constants.InputType.SearchedPublisher, false);
                    break;
            }
        }

        private List<BookDto> ExploreSearchedBooks()
        {
            List<BookDto> searchedBookList = bookRepository.GetBookList();

            for (int i = 0; i < 3; i++)
            {
                if (searchedBookStrings[i] == null || searchedBookStrings[i] == "")
                    continue;

                List<BookDto> temp = new List<BookDto>();
                foreach (BookDto book in searchedBookList)
                {
                    switch (i)
                    {
                        case (int)Constants.BookSearchMenu.Title:
                            if (book.Title.Contains(searchedBookStrings[i]))
                                temp.Add(book);
                            break;
                        case (int)Constants.BookSearchMenu.Writer:
                            if (book.Writer.Contains(searchedBookStrings[i]))
                                temp.Add(book);
                            break;
                        case (int)Constants.BookSearchMenu.Publisher:
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