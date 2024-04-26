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
    public class BookController
    {
        private BookRepository book;
        private UserRepository user;
        private MenuSelector menuSelector;
        private InputManager inputManager;
        private Screen screen;
        private string[] searchedBookStrings;
        private string[] bookInfoStrings;
        private string bookId;

        public BookController()
        {
            this.book = new BookRepository();
            this.user = UserRepository.Instance;
            this.menuSelector = new MenuSelector();
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
                        book.AddBook(new BookDto("0", bookInfoStrings[0], bookInfoStrings[1],
                            bookInfoStrings[2], int.Parse(bookInfoStrings[3]), bookInfoStrings[4], bookInfoStrings[5],
                            bookInfoStrings[6], bookInfoStrings[7]));
                    }
                    else
                        ExplainingScreen.ExplainFailScreen();
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

            Console.Clear();
            ExplainingScreen.ExplainSearchBookInfo();
            ExplainingScreen.ExplainInputBookInfo();
            while (isSelected)
            {
                isSelected = menuSelector.IsMenuSelection((int)Constants.MenuType.BookModify);
                if (!isSelected)
                    return;

                if (menuSelector.menuValue == (int)Constants.BookModifyInfo.Check)
                {
                    if (IsBookIdValid((int)Constants.BookIdType.Modify) && 
                        IsModifyValid())
                    {
                        Modify();
                        bookId = null;
                        ExplainingScreen.ExplainSuccessScreen();
                    }
                    else
                        ExplainingScreen.ExplainFailScreen();
                    menuSelector.WaitForEscKey();
                    break;
                }
                else
                    InputBookInfo(menuSelector.menuValue);
            }

            void Modify()
            {
                book.ModifyBookTitle(bookId, bookInfoStrings[0]);
                book.ModifyBookWriter(bookId, bookInfoStrings[1]);
                book.ModifyBookPublisher(bookId, bookInfoStrings[2]);
                book.ModifyBookCount(bookId, int.Parse(bookInfoStrings[3]));
                book.ModifyBookPrice(bookId, bookInfoStrings[4]);
                book.ModifyBookReleaseDate(bookId, bookInfoStrings[5]);
            }
        }

        private bool IsModifyValid()
        {
            //if (bookInfoStrings[1] != null && !RegularExpressionManager.IsWriterValid(bookInfoStrings[1]))
            //    return false;
            //if (bookInfoStrings[5] != null && !RegularExpressionManager.IsReleaseDateValid(bookInfoStrings[5]))
            //    return false;
            //if (bookInfoStrings[6] != null && !RegularExpressionManager.IsISBNValid(bookInfoStrings[6]))
            //    return false;
            //if (bookInfoStrings[3] != null)
            //{
            //    foreach(char value in bookInfoStrings[3])   
            //    {
            //        if (('a' <= value && value <= 'z') ||   // 숫자가 아닐 때
            //        ('A' <= value && value <= 'Z') ||
            //        value == '-' || value == ' ')
            //            return false;
            //    }
            //}

            return true;
        }

        private bool IsBookAddValid()
        {
            foreach (string str in bookInfoStrings)
                if (str == null)
                    return false;

            if (!IsModifyValid())
                return false;
            return true;
        }

        public bool IsBookIdValid(int idType)
        {
            if (bookId == null)
                return false;
            else if (idType == (int)Constants.BookIdType.Rental)
            {
                List<BookDto> bookList = book.GetBookList();
                foreach (BookDto book in bookList)
                    if (book.Id.Equals(bookId) && book.Count > 0)
                        return true;
            }
            else if (idType == (int)Constants.BookIdType.Return)
            {
                List<RentalBookDto> bookList = user.GetRentalBookList();
                foreach (RentalBookDto book in bookList)
                    if (book.Id.Equals(bookId))
                        return true;
            }
            else if (idType == (int)Constants.BookIdType.Modify || idType == (int)Constants.BookIdType.Delete)
            {
                List<BookDto> bookList = book.GetBookList();
                foreach (BookDto book in bookList)
                    if (book.Id.Equals(bookId))
                        return true;
            }
            return false;
        }

        public void RentalBook()
        {
            List<BookDto> bookList = book.GetBookList();
            for (int i = 0; i < bookList.Count; i++)
            {
                if (bookList[i].Id.Equals(bookId))
                {
                    book.ReduceBookCount(bookId);
                    user.AddRentalBook(new RentalBookDto(bookList[i], DateTime.Now));
                    break;
                }
            }
            bookId = null;
        }

        public void ReturnBook()
        {
            List<RentalBookDto> rentalBookList = user.GetRentalBookList();
            List<BookDto> bookList = book.GetBookList();
            for (int i = 0; i < rentalBookList.Count; i++)
            {
                if (rentalBookList[i].Id.Equals(bookId))
                {
                    user.SubtractRentalBook(rentalBookList[i]);
                    break;
                }
            }

            for (int i = 0; i < bookList.Count; i++)
            {
                if (bookList[i].Id.Equals(bookId))
                {
                    book.IncreaseBookCount(bookId);
                    user.AddReturnBook(bookList[i]);
                    break;
                }
            }
            bookId = null;
        }

        public void DeleteBook()
        {
            List<BookDto> bookList = book.GetBookList();
            for (int i = 0; i < bookList.Count; i++)
            {
                if (bookList[i].Id.Equals(bookId))
                {
                    book.DeleteBook(bookId);
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
                    screen.DrawBooks(book.GetBookList());
                    break;
                case (int)Constants.BookShowType.Searched:
                    screen.DrawBooks(ExploreSearchedBooks());
                    break;
                case (int)Constants.BookShowType.Rental:
                    screen.DrawRentalBooks(17, user.GetRentalBookList());
                    break;
                case (int)Constants.BookShowType.Return:
                    screen.DrawBooks(user.GetReturnBookList());
                    break;
            }
        }

        public void ShowUserRentalHistory()
        {
            Console.Clear();
            Console.SetWindowSize(70, 30);
            screen.DrawUserRentalHistory(user.GetUserList());
        }

        public void InputBookId()
        {
            ExplainingScreen.ExplainInputId("책  ");
            ExplainingScreen.ExplainInputBookId();
            ExplainingScreen.DrawIdLogo();
            bookId = inputManager.LimitInputLength((int)Constants.InputType.BookId, 3, false);
        }

        private void InputBookInfo(int inputType)
        {
            switch (inputType)
            {
                case (int)Constants.BookAddInfo.Title:
                    bookInfoStrings[0] = inputManager.LimitInputLength((int)Constants.InputType.Title, 15, false);
                    break;
                case (int)Constants.BookAddInfo.Writer:
                    bookInfoStrings[1] = inputManager.LimitInputLength((int)Constants.InputType.Writer, 10, false);
                    break;
                case (int)Constants.BookAddInfo.Publisher:
                    bookInfoStrings[2] = inputManager.LimitInputLength((int)Constants.InputType.Publisher, 10, false);
                    break;
                case (int)Constants.BookAddInfo.Count:
                    bookInfoStrings[3] = inputManager.LimitInputLength((int)Constants.InputType.Count, 4, false);
                    break;
                case (int)Constants.BookAddInfo.Price:
                    bookInfoStrings[4] = inputManager.LimitInputLength((int)Constants.InputType.Price, 7, false);
                    break;
                case (int)Constants.BookAddInfo.ReleaseDate:
                    bookInfoStrings[5] = inputManager.LimitInputLength((int)Constants.InputType.ReleaseDate, 11, false);
                    break;
                case (int)Constants.BookAddInfo.ISBN:
                    bookInfoStrings[6] = inputManager.LimitInputLength((int)Constants.InputType.ISBN, 25, false);
                    break;
                case (int)Constants.BookAddInfo.Info:
                    bookInfoStrings[7] = inputManager.LimitInputLength((int)Constants.InputType.Info, 10, false);
                    break;
            }
        }

        private void InputSearchBook(int inputType)
        {
            switch (inputType)
            {
                case (int)Constants.BookSearchMenu.Title:
                    searchedBookStrings[0] = inputManager.LimitInputLength((int)Constants.InputType.SearchedTitle, 15, false);
                    break;
                case (int)Constants.BookSearchMenu.Writer:
                    searchedBookStrings[1] = inputManager.LimitInputLength((int)Constants.InputType.SearchedWriter, 10, false);
                    break;
                case (int)Constants.BookSearchMenu.Publisher:
                    searchedBookStrings[2] = inputManager.LimitInputLength((int)Constants.InputType.SearchedPublisher, 10, false);
                    break;
            }
        }

        private List<BookDto> ExploreSearchedBooks()
        {
            List<BookDto> searchedBookList = book.GetBookList();

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