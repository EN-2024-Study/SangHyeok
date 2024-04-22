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
        private string[] inputSearchedStrings;
        private string bookId;
        public BookController()
        {
            this.book = BookRepository.Instance; // singleton 생성
            this.menuSelector = new MenuSelector();
            this.inputManager = new InputManager();
            this.bookScreen = new BookScreen();
            this.user = UserRepository.Instance;
            this.inputSearchedStrings = new string[] { "", "", "" };
            this.bookId = null;
        }

        public void SearchBook()
        {
            bool isSelected = true;
            menuSelector.menuValue = 0;

            ShowSearchedBooks();
            while(isSelected)
            {
                isSelected = menuSelector.IsMenuSelection((int)Constants.MenuType.BookSearch);
                if (!isSelected)
                    return;

                if (menuSelector.menuValue == (int)Constants.BookSearchMenu.Check)
                {
                    Console.Clear();
                    ShowSearchedBooks();
                    break;
                }
                else
                    InputSearchBook(menuSelector.menuValue);
            }
        }

        private void InputSearchBook(int inputType)
        {
            switch(inputType)
            {
                case (int)Constants.BookSearchMenu.Title:
                    inputSearchedStrings[0] = inputManager.LimitInputLength((int)Constants.InputType.Title, 15, false);
                    break;
                case (int)Constants.BookSearchMenu.Writer:
                    inputSearchedStrings[1] = inputManager.LimitInputLength((int)Constants.InputType.Writer, 15, false);
                    break;
                case (int)Constants.BookSearchMenu.Publisher:
                    inputSearchedStrings[2] = inputManager.LimitInputLength((int)Constants.InputType.Publisher, 15, false);
                    break;
            }
        }

        private void ShowSearchedBooks()
        {
            List<BookDto> bookList = book.GetBookList();
            List<BookDto> searchedBookList = bookList;

            Console.SetWindowSize(70, 40);
            Console.Clear();
            for (int i = 0; i < 3; i++)
            {
                if (inputSearchedStrings[i] == null || inputSearchedStrings[i] == "")
                    continue;

                List<BookDto> temp = new List<BookDto>();
                foreach (BookDto book in searchedBookList)
                {
                    switch (i)
                    {
                        case (int)Constants.BookSearchMenu.Title:
                            if (book.Title.Contains(inputSearchedStrings[i]))
                                temp.Add(book);
                            break;
                        case (int)Constants.BookSearchMenu.Writer:
                            if (book.Writer.Contains(inputSearchedStrings[i]))
                                temp.Add(book);
                            break;
                        case (int)Constants.BookSearchMenu.Publisher:
                            if (book.Publisher.Contains(inputSearchedStrings[i]))
                                temp.Add(book);
                            break;
                    }
                }

                searchedBookList = temp;
            }

            bookScreen.DrawBooks(searchedBookList);
            inputSearchedStrings = new string[] { "", "", "" };
        }

        public bool IsInputBookIdValid()
        {
            Console.Clear();
            ShowSearchedBooks();
            bookScreen.DrawBookId();
            bookId = inputManager.LimitInputLength((int)Constants.InputType.BookId, 3, false);
            if (bookId == null)
                return false;
            return true;
        }

        public bool IsBookRentalValid()
        {
            List<BookDto> bookList = book.GetBookList();
            if (bookId == null)
                return false;
            else if (bookList[int.Parse(bookId)].Count > 0)
            {
                user.AddRentalBook(bookList[int.Parse(bookId)]);
                return true;
            }
            return false;
        }
    }
}
