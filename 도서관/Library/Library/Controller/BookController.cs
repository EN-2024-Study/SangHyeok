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
        private MenuSelector menuSelector;
        private InputManager inputManager;
        private BookScreen bookScreen;
        private UserRepository user;
        private string[] searchedBookStrings;
        private string bookId;
        public BookController()
        {
            this.book = BookRepository.Instance; // singleton 생성
            this.menuSelector = new MenuSelector();
            this.inputManager = new InputManager();
            this.bookScreen = new BookScreen();
            this.user = UserRepository.Instance;
            this.searchedBookStrings = new string[] { "", "", "" };
            this.bookId = null;
        }

        public void SearchBook()
        {
            bool isSelected = true;
            menuSelector.menuValue = 0;

            while (isSelected)
            {
                isSelected = menuSelector.IsMenuSelection((int)Constants.MenuType.BookSearch);
                if (!isSelected)
                    return;

                if (menuSelector.menuValue == (int)Constants.BookSearchMenu.Check)
                {
                    Console.Clear();
                    ShowBooks((int)Constants.Book.Searched);
                    break;
                }
                else
                    InputSearchBook(menuSelector.menuValue);
            }
        }

        public bool IsInputBookIdValid()
        {
            bookScreen.DrawBookId();
            bookId = inputManager.LimitInputLength((int)Constants.InputType.BookId, 3, false);
            if (bookId == null)
                return false;
            return true;
        }

        public bool IsBookRentalValid()
        {
            Dictionary<int, BookDto> bookDict = book.GetBookDict();

            if (bookId == null)
                return false;
            else if (bookDict[int.Parse(bookId)].Count > 0)
                return true;
            return false;
        }

        public bool IsBookReturnValid()
        {
            Dictionary<int, BookDto> bookDict = user.GetRentalBookDict();
            if (bookDict.ContainsKey(int.Parse(bookId)))
                return true;
            return false;
        }

        public void RentalBook()
        {
            book.ReduceBookCount(int.Parse(bookId));
            user.AddRentalBook(int.Parse(bookId), book.GetBookDict()[int.Parse(bookId)]);
            bookId = null;
        }

        public void ReturnBook()
        {
            book.IncreaseBookCount(int.Parse(bookId));
            user.SubtractRentalBook(int.Parse(bookId));
        }

        public void ShowBooks(int typeValue)
        {
            Console.Clear();

            switch(typeValue)
            {
                case (int)Constants.Book.All:
                    bookScreen.DrawBooks(book.GetBookDict().Values.ToList<BookDto>());
                    break;
                case (int)Constants.Book.Searched:
                    bookScreen.DrawBooks(ExploreSearchedBooks());
                    break;
                case (int)Constants.Book.Rental:
                    bookScreen.DrawBooks(user.GetRentalBookDict().Values.ToList<BookDto>());
                    break;
                case (int)Constants.Book.Return:
                    bookScreen.DrawBooks(user.GetReturnBookList());
                    break;
            }
        }

        private void InputSearchBook(int inputType)
        {
            switch (inputType)
            {
                case (int)Constants.BookSearchMenu.Title:
                    searchedBookStrings[0] = inputManager.LimitInputLength((int)Constants.InputType.Title, 15, false);
                    break;
                case (int)Constants.BookSearchMenu.Writer:
                    searchedBookStrings[1] = inputManager.LimitInputLength((int)Constants.InputType.Writer, 15, false);
                    break;
                case (int)Constants.BookSearchMenu.Publisher:
                    searchedBookStrings[2] = inputManager.LimitInputLength((int)Constants.InputType.Publisher, 15, false);
                    break;
            }
        }

        private List<BookDto> ExploreSearchedBooks()
        {
            List<BookDto> searchedBookList = book.GetBookDict().Values.ToList<BookDto>();

            Console.SetWindowSize(70, 40);
            Console.Clear();
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

            searchedBookStrings = new string[] { "", "", "" };
            return searchedBookList;
        }
    }
}
