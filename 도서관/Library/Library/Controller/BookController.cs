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
        private Screen screen;
        private UserRepository user;
        private string[] searchedBookStrings;
        private string[] bookInfoStrings;
        private string bookId;

        public BookController()
        {
            this.book = BookRepository.Instance; // singleton 생성
            this.menuSelector = new MenuSelector();
            this.inputManager = new InputManager();
            this.screen = new Screen();
            this.user = UserRepository.Instance;
            this.searchedBookStrings = new string[] { null, null, null };
            this.bookInfoStrings = new string[] { null, null, null, null, null, null, null, null };
            this.bookId = null;
        }

        public void SearchBook()
        {
            bool isSelected = true;
            menuSelector.menuValue = 0;

            ShowBooks((int)Constants.BookShowType.All);
            while (isSelected)
            {
                isSelected = menuSelector.IsMenuSelection((int)Constants.MenuType.BookSearch);
                if (!isSelected)
                    return;

                if (menuSelector.menuValue == (int)Constants.BookSearchMenu.Check)
                {
                    Console.Clear();
                    ShowBooks((int)Constants.BookShowType.Searched);
                    ExplainingScreen.ExplainEcsKey();
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
            while (isSelected)
            {
                isSelected = menuSelector.IsMenuSelection((int)Constants.MenuType.BookAdd);
                if (!isSelected)
                    return;

                if (menuSelector.menuValue == (int)Constants.BookAddInfo.Check)
                {
                    if (IsBookIdValid((int)Constants.BookIdType.Add))
                    {
                        ExplainingScreen.ExplainSuccessScreen();
                        book.AddBook(new BookDto(book.KeyValue.ToString(), bookInfoStrings[0], bookInfoStrings[1],
                            bookInfoStrings[2], int.Parse(bookInfoStrings[3]), bookInfoStrings[4], bookInfoStrings[5],
                            bookInfoStrings[6], bookInfoStrings[7]));
                        book.KeyValue += 1;
                    }
                    else
                        ExplainingScreen.ExplainFailScreen();

                    ExplainingScreen.ExplainEcsKey();
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
            while (isSelected)
            {
                isSelected = menuSelector.IsMenuSelection((int)Constants.MenuType.BookModify);
                if (!isSelected)
                    return;

                if (menuSelector.menuValue == (int)Constants.BookModifyInfo.Check)
                {
                    if (IsBookIdValid((int)Constants.BookIdType.Modify))
                    {
                        Modify();
                        bookId = null;
                        ExplainingScreen.ExplainSuccessScreen();
                        ExplainingScreen.ExplainEcsKey();
                        menuSelector.WaitForEscKey();
                        break;
                    }
                }
                else
                    InputBookInfo(menuSelector.menuValue);
            }

            void Modify()
            {
                if (bookInfoStrings[0] != null)
                    book.ModifyBookTitle(int.Parse(bookId), bookInfoStrings[0]);
                if (bookInfoStrings[1] != null)
                    book.ModifyBookWriter(int.Parse(bookId), bookInfoStrings[1]);
                if (bookInfoStrings[2] != null)
                    book.ModifyBookPublisher(int.Parse(bookId), bookInfoStrings[2]);
                if (bookInfoStrings[3] != null)
                    book.ModifyBookCount(int.Parse(bookId), int.Parse(bookInfoStrings[3]));
                if (bookInfoStrings[4] != null)
                    book.ModifyBookPrice(int.Parse(bookId), bookInfoStrings[4]);
                if (bookInfoStrings[5] != null)
                    book.ModifyBookReleaseDate(int.Parse(bookId), bookInfoStrings[5]);
            }
        }

        public bool IsBookIdValid(int idType)
        {
            if (idType == (int)Constants.BookIdType.Rental)
            {
                if (bookId == null)
                    return false;

                Dictionary<int, BookDto> bookDict = book.GetBookDict();
                if (bookDict[int.Parse(bookId)].Count > 0)
                    return true;
                return false;
            }
            else if (idType == (int)Constants.BookIdType.Return)
            {
                if (bookId == null)
                    return false;

                Dictionary<int, BookDto> bookDict = user.GetRentalBookDict();
                if (bookDict.ContainsKey(int.Parse(bookId)))
                    return true;
                return false;
            }
            else if (idType == (int)Constants.BookIdType.Add)
            {
                foreach (string str in bookInfoStrings)
                    if (str == null)
                        return false;
                return true;
            }
            else if (idType == (int)Constants.BookIdType.Modify || idType == (int)Constants.BookIdType.Delete)
            {
                if (bookId == null)
                    return false;

                Dictionary<int, BookDto> bookDict = book.GetBookDict();
                if (bookDict.ContainsKey(int.Parse(bookId)))
                    return true;
                return false;
            }
            return false;
        }

        public void RentalBook()
        {
            book.ReduceBookCount(int.Parse(bookId));
            user.AddRentalBook(int.Parse(bookId), book.GetBookDict()[int.Parse(bookId)]);

            bookId = null;
            ExplainingScreen.ExplainSuccessScreen();
            ExplainingScreen.ExplainEcsKey();
            menuSelector.WaitForEscKey();
        }

        public void ReturnBook()
        {
            book.IncreaseBookCount(int.Parse(bookId));
            user.SubtractRentalBook(int.Parse(bookId));

            bookId = null;
            ExplainingScreen.ExplainSuccessScreen();
            ExplainingScreen.ExplainEcsKey();
            menuSelector.WaitForEscKey();
        }

        public void DeleteBook()
        {
            book.DeleteBook(int.Parse(bookId));

            bookId = null;
            ExplainingScreen.ExplainSuccessScreen();
            ExplainingScreen.ExplainEcsKey();
            menuSelector.WaitForEscKey();
        }

        public void ShowBooks(int typeValue)
        {
            Console.Clear();

            switch (typeValue)
            {
                case (int)Constants.BookShowType.All:
                    screen.DrawBooks(book.GetBookDict().Values.ToList<BookDto>());
                    break;
                case (int)Constants.BookShowType.Searched:
                    screen.DrawBooks(ExploreSearchedBooks());
                    break;
                case (int)Constants.BookShowType.Rental:
                    screen.DrawBooks(user.GetRentalBookDict().Values.ToList<BookDto>());
                    break;
                case (int)Constants.BookShowType.Return:
                    screen.DrawBooks(user.GetReturnBookList());
                    break;
            }
        }

        public void InputBookId()
        {
            screen.DrawId("책  ");
            bookId = inputManager.LimitInputLength((int)Constants.InputType.BookId, 3, false);
        }

        private void InputBookInfo(int inputType)
        {
            switch (inputType)
            {
                case (int)Constants.BookAddInfo.Title:
                    bookInfoStrings[0] = inputManager.LimitInputLength((int)Constants.InputType.AddedTitle, 15, false);
                    break;
                case (int)Constants.BookAddInfo.Writer:
                    bookInfoStrings[1] = inputManager.LimitInputLength((int)Constants.InputType.AddedWriter, 15, false);
                    break;
                case (int)Constants.BookAddInfo.Publisher:
                    bookInfoStrings[2] = inputManager.LimitInputLength((int)Constants.InputType.AddedPublisher, 15, false);
                    break;
                case (int)Constants.BookAddInfo.Count:
                    bookInfoStrings[3] = inputManager.LimitInputLength((int)Constants.InputType.AddedCount, 15, false);
                    break;
                case (int)Constants.BookAddInfo.Price:
                    bookInfoStrings[4] = inputManager.LimitInputLength((int)Constants.InputType.AddedPrice, 15, false);
                    break;
                case (int)Constants.BookAddInfo.ReleaseDate:
                    bookInfoStrings[5] = inputManager.LimitInputLength((int)Constants.InputType.AddedReleaseDate, 15, false);
                    break;
                case (int)Constants.BookAddInfo.ISBN:
                    bookInfoStrings[6] = inputManager.LimitInputLength((int)Constants.InputType.AddedISBN, 15, false);
                    break;
                case (int)Constants.BookAddInfo.Info:
                    bookInfoStrings[7] = inputManager.LimitInputLength((int)Constants.InputType.AddedInfo, 15, false);
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

            searchedBookStrings = new string[] { null, null, null };
            return searchedBookList;
        }
    }
}
