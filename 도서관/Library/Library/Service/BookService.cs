using Library.Constants;
using Library.Controller;
using Library.Model;
using Library.Model.DtoVo;
using Library.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Library.Service
{
    public class BookService
    {
        private BookDao bookDao;
        private UserDao userDao;
        private ExceptionManager exceptionManager;

        public BookService(BookDao bookDao, UserDao userDao)
        {
            this.bookDao = bookDao;
            this.userDao = userDao;
            this.exceptionManager = new ExceptionManager();
        }

        public bool IsBookRentalValid(string bookId, string loggedInId)
        {
            List<BookDto> bookList = bookDao.GetBookList();
            List<RentalBookDto> rentalBookList = bookDao.GetRentalBookList();

            foreach (RentalBookDto book in rentalBookList)
            {
                if (book.UserId.Equals(loggedInId))
                {
                    DateTime now = DateTime.Now;
                    DateTime returnTime = DateTime.ParseExact(book.ReturnTime, BookStrings.TIME, null);
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

            ExplainingScreen.ExplainFailScreen();
            ExplainingScreen.ExplainInvalidInput("입력");
            return false;
        }

        public bool IsBookCountValid(string bookId)
        {
            List<BookDto> bookList = bookDao.GetBookList();
            foreach (BookDto book in bookList)  // 책의 수량이 1이상이면 true
                if (book.Id.Equals(bookId) && book.Count > 0)
                    return true;

            ExplainingScreen.ExplainFailScreen();
            ExplainingScreen.ExplainInvalidInput("입력");
            return false;
        }

        public bool IsBookReturnValid(string bookId, string loggedInId)
        {
            List<RentalBookDto> bookList = bookDao.GetRentalBookList();
            foreach (RentalBookDto book in bookList)
            {
                if (book.Id.Equals(bookId) && loggedInId.Equals(book.UserId))
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

        public bool IsBookAddValid(string[] bookInfoStrings)
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

            if (!IsBookModifyValid(bookInfoStrings))
                return false;
            return true;
        }

        public bool IsBookDeleteValid(string bookId)
        {
            List<RentalBookDto> rentalBookList = bookDao.GetRentalBookList();
            List<BookDto> bookList = bookDao.GetBookList();

            foreach (RentalBookDto book in rentalBookList)   // 도서가 대여 중이라면 false
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

        public bool IsBookModifyValid(string[] bookInfoStrings)
        {
            if (bookInfoStrings[1] != null && !exceptionManager.IsExoressionValid((int)Enums.InputType.Writer, bookInfoStrings[1]))
            {
                ExplainingScreen.ExplainFailScreen();
                ExplainingScreen.ExplainInvalidInput("작가");
                return false;
            }
            if (bookInfoStrings[3] != null && !exceptionManager.IsExoressionValid((int)Enums.InputType.Count, bookInfoStrings[3]))
            {
                ExplainingScreen.ExplainFailScreen();
                ExplainingScreen.ExplainInvalidInput("수량");
                return false;
            }
            if (bookInfoStrings[5] != null && !exceptionManager.IsExoressionValid((int)Enums.InputType.ReleaseDate, bookInfoStrings[5]))
            {
                ExplainingScreen.ExplainFailScreen();
                ExplainingScreen.ExplainInvalidInput("출시일");
                return false;
            }
            if (bookInfoStrings[6] != null && !exceptionManager.IsExoressionValid((int)Enums.InputType.ISBN, bookInfoStrings[6]))
            {
                ExplainingScreen.ExplainFailScreen();
                ExplainingScreen.ExplainInvalidInput("ISBN");
                return false;
            }

            return true;
        }

        public bool IsRequestValid(int type, List<NaverBookVo> bookList, NaverBookVo book)
        {
            if (book == null)
            {
                ExplainingScreen.ExplainFailScreen();
                ExplainingScreen.ExplainInvalidInput("도서 제목");
                return false;
            }

            bool isDuplication = false;
            if (type == (int)Enums.ModeMenu.UserMode)
            {
                foreach (NaverBookVo item in bookList)
                {
                    if (item.Equals(book))  // 이미 요청한 책이라면 false
                    {
                        isDuplication = true;
                        break;
                    }
                }
            }
            else if (type == (int)Enums.ModeMenu.ManagerMode)
            {
                foreach (NaverBookVo item in bookList)
                    if (item.Equals(book))  // user가 요청한 책 이름과 같다면 true
                        return true;

                isDuplication = true;
            }

            if (isDuplication)
            {
                ExplainingScreen.ExplainFailScreen();
                ExplainingScreen.ExplainDuplicationExist("요청 도서");
                return false;
            }
            return true;
        }

        public void RentalBook(string bookId, string loggedInId)
        {
            List<BookDto> bookList = bookDao.GetBookList();
            DateTime time = DateTime.Now;
            foreach (BookDto book in bookList)
            {
                if (book.Id.Equals(bookId) && book.Count > 0)
                {
                    bookDao.RentalBook(new RentalBookDto(book,
                        loggedInId, time.ToString(BookStrings.TIME),
                        time.AddDays(7).ToString(BookStrings.TIME)));
                }
            }
        }

        public void AddBook(string[] bookInfoStrings)
        {
            bookDao.AddBook(new BookDto(BookStrings.BLANK, bookInfoStrings[(int)Enums.BookAddInfo.Title], bookInfoStrings[(int)Enums.BookAddInfo.Writer],
                           bookInfoStrings[(int)Enums.BookAddInfo.Publisher], int.Parse(bookInfoStrings[(int)Enums.BookAddInfo.Count]), bookInfoStrings[(int)Enums.BookAddInfo.Price], 
                           bookInfoStrings[(int)Enums.BookAddInfo.ReleaseDate], bookInfoStrings[(int)Enums.BookAddInfo.ISBN], bookInfoStrings[(int)Enums.BookAddInfo.Info]));
        }

        public void DeleteBook(string bookId)
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
        }

        public void ModifyBook(string[] bookInfoStrings, string bookId)
        {
            if (bookInfoStrings[(int)Enums.BookModifyInfo.Title] != null)
                bookDao.ModifyBookInfo(bookId, BookStrings.TITLE, bookInfoStrings[0]);

            if (bookInfoStrings[(int)Enums.BookModifyInfo.Writer] != null)
                bookDao.ModifyBookInfo(bookId, BookStrings.WRITER, bookInfoStrings[1]);

            if (bookInfoStrings[(int)Enums.BookModifyInfo.Publisher] != null)
                bookDao.ModifyBookInfo(bookId, BookStrings.PUBLISHER, bookInfoStrings[2]);

            if (bookInfoStrings[(int)Enums.BookModifyInfo.Count] != null)
                bookDao.ModifyBookInfo(bookId, BookStrings.COUNT, int.Parse(bookInfoStrings[3]));
            
            if (bookInfoStrings[(int)Enums.BookModifyInfo.Price] != null)
                bookDao.ModifyBookInfo(bookId, BookStrings.PRICE, bookInfoStrings[4]);
           
            if (bookInfoStrings[(int)Enums.BookModifyInfo.ReleaseDate] != null)
                bookDao.ModifyBookInfo(bookId, BookStrings.RELEASEDATE, bookInfoStrings[5]);
        }
    }
}
