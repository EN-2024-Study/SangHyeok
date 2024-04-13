using Library.Model;
using Library.Utility;
using Library.View;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Controller.Task
{
    public class BookController
    {
        private BookRepository book;
        private BookScreen bookScreen;

        public BookController()
        {
            book = BookRepository.Instance; // singleton 생성
            bookScreen = new BookScreen();
        }

        public bool ControlUserBook(int menuValue)
        {
            List<BookDto> bookList = book.BookList;
            Console.Clear();

            switch(menuValue)
            {
                case (int)Constants.UserMenu.BookSearch:
                    bookScreen.PrintAllBook(bookList);
                    bookScreen.PrintSearchBook();
                    break;
                case (int)Constants.UserMenu.BookRental:
                    bookScreen.PrintAllBook(bookList);
                    bookScreen.PrintSearchBook();

                    break;
                case (int)Constants.UserMenu.BookRentalHistory:

                    break;
                case (int)Constants.UserMenu.BookReturn:

                    break;
                case (int)Constants.UserMenu.BookReturnHistory:

                    break;
            }

            return false;
        }

        
    }
}
