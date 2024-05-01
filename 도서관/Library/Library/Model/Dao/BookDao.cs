using Library.Constants;
using Library.Controller;
using Library.Model.DtoVo;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Library.Model
{
    public class BookDao    
    {
        private DbConnector db;

        public BookDao()
        {
            this.db = DbConnector.Instance;
        }

        public List<BookDto> GetBookList()
        {
            List<BookDto> bookList = new List<BookDto>();
            string selectQuery = QueryStrings.SELECT_BOOK;

            db.MySql.Open();
            MySqlDataReader table = db.GetTable(selectQuery);

            while (table.Read())
            {
                string[] bookInfo = GetBookInfoStrings(table);
                bookList.Add(new BookDto(bookInfo[0], bookInfo[1], bookInfo[2],
                    bookInfo[3], int.Parse(bookInfo[4]), bookInfo[5], bookInfo[6],
                    bookInfo[7], bookInfo[8]));
            }

            db.MySql.Close();
            return bookList;
        }

        public List<RentalBookDto> GetRentalBookList()
        {
            List<RentalBookDto> rentalBookList = new List<RentalBookDto>();
            string selectQuery = QueryStrings.SELECT_RENTALBOOK;

            db.MySql.Open();
            MySqlDataReader table = db.GetTable(selectQuery);

            while (table.Read())
            {
                string[] bookInfo = GetBookInfoStrings(table);
                string rentalTime = table[QueryStrings.FIELD_RENTALTIME].ToString();
                string returnTime = table[QueryStrings.FIELD_RETURNTIME].ToString();
                string userId = table[QueryStrings.FIELD_USERID].ToString();
                rentalBookList.Add(new RentalBookDto(new BookDto(bookInfo[0], bookInfo[1], bookInfo[2],
                    bookInfo[3], int.Parse(bookInfo[4]), bookInfo[5], bookInfo[6],
                    bookInfo[7], bookInfo[8]), userId, rentalTime, returnTime));
            }

            db.MySql.Close();
            return rentalBookList;
        }

        public List<ReturnBookDto> GetReturnBookList()
        {
            List<ReturnBookDto> returnBookList = new List<ReturnBookDto>();
            string selectQuery = QueryStrings.SELECT_RETURNBOOK;

            db.MySql.Open();
            MySqlDataReader table = db.GetTable(selectQuery);

            while (table.Read())
            {
                string[] bookInfo = GetBookInfoStrings(table);
                string userId = table[QueryStrings.FIELD_USERID].ToString();
                returnBookList.Add(new ReturnBookDto(new BookDto(bookInfo[0], bookInfo[1], bookInfo[2],
                    bookInfo[3], int.Parse(bookInfo[4]), bookInfo[5], bookInfo[6],
                    bookInfo[7], bookInfo[8]), userId));
            }

            db.MySql.Close();
            return returnBookList;
        }

        public List<NaverBookVo> GetNaverBookList()
        {
            List<NaverBookVo> naverBookList = new List<NaverBookVo>();
            string selectQuery = QueryStrings.SELECT_REQUESTBOOK;

            db.MySql.Open();
            MySqlDataReader table = db.GetTable(selectQuery);

            while (table.Read())
            {
                string[] bookInfo = new string[8];
                bookInfo[0] = table[QueryStrings.FIELD_TITLE].ToString();
                bookInfo[1] = table[QueryStrings.FIELD_WRITER].ToString();
                bookInfo[2] = table[QueryStrings.FIELD_PRICE].ToString();
                bookInfo[3] = table[QueryStrings.FIELD_PUBLISHER].ToString();
                bookInfo[4] = table[QueryStrings.FIELD_RELEASEDATE].ToString();
                bookInfo[5] = table[QueryStrings.FIELD_ISBN].ToString();
                bookInfo[6] = table[QueryStrings.FIELD_INFO].ToString();
                bookInfo[7] = table[QueryStrings.FIELD_USERID].ToString();

                naverBookList.Add(new NaverBookVo(bookInfo[0], bookInfo[1], bookInfo[2],
                    bookInfo[3], bookInfo[4], bookInfo[5], bookInfo[6], bookInfo[7]));
            }

            db.MySql.Close();
            return naverBookList;
        }

        public void AddBook(BookDto book)
        {
            string insertQuery = string.Format(QueryStrings.INSERT_BOOK,
                  book.Title, book.Writer, book.Publisher, book.Count, book.Price, book.ReleaseDate, book.ISBN, book.Info);
            db.SetData(insertQuery);
        }

        public void DeleteBook(string key)
        {
            string deleteQuery = string.Format(QueryStrings.DELETE_BOOK, key);
            db.SetData(deleteQuery);
        }

        public void DeleteRequestBook(string key)
        {
            string deleteQuery = string.Format(QueryStrings.DELETE_RequestBOOK, key);
            db.SetData(deleteQuery);
        }

        public void ModifyBookInfo(string key, string updateString, object value)
        {
            string modifyQuery = null;
            if (updateString.Equals(QueryStrings.FIELD_COUNT))
                modifyQuery = string.Format(QueryStrings.UPDATE_BOOKCOUNT, key, (int)value);
            else
                modifyQuery = string.Format(QueryStrings.UPDATE_BOOK, key, (string)updateString, value);

            db.SetData(modifyQuery);
        }

        public void RentalBook(RentalBookDto book)
        {
            string query = string.Format(QueryStrings.UPDATE_BOOKCOUNT_DESCEND, book.Id);
            db.SetData(query);

            query = string.Format(QueryStrings.INSERT_RENTALBOOK,
                  book.Id, book.Title, book.Writer, book.Publisher, book.Count, book.Price, book.ReleaseDate, book.ISBN, book.Info, book.RentalTime, book.ReturnTime, book.UserId);
            db.SetData(query);
        }

        public void ReturnBook(RentalBookDto book)
        {
            string query = string.Format(QueryStrings.DELETE_RENTALBOOK, book.Id);
            db.SetData(query);

            query = string.Format(QueryStrings.UPDATE_BOOKCOUNT_INCREASE, book.Id);
            db.SetData(query);

            query = string.Format(QueryStrings.INSERT_RETURNBOOK,
                  book.Id, book.Title, book.Writer, book.Publisher, book.Count, book.Price, book.ReleaseDate, book.ISBN, book.Info, book.UserId);
            db.SetData(query);
        }

        public void RequestBook(NaverBookVo book, string loggedInId)
        {
            string insertQuery = string.Format(QueryStrings.INSERT_REQUESTBOOK,
                    book.Title.ToString(), book.Writer.ToString(), book.Price.ToString(),
                    book.Publisher.ToString(), book.ReleaseDate.ToString(), book.ISBN.ToString(),
                    book.Info.ToString(), loggedInId);
            db.SetData(insertQuery);
        }

        public void AddRequestedBook(NaverBookVo book)
        {
            string insertQuery = string.Format(QueryStrings.INSERT_BOOK,
                   book.Title.ToString(), book.Writer.ToString(), book.Publisher.ToString(),
                   1, book.Price.ToString(), book.ReleaseDate.ToString(), book.ISBN.ToString(),
                   book.Info.ToString());
            db.SetData(insertQuery);
        }

        private string[] GetBookInfoStrings(MySqlDataReader table)
        {
            string[] bookInfo = new string[9];
            bookInfo[0] = table[QueryStrings.FIELD_ID].ToString();
            bookInfo[1] = table[QueryStrings.FIELD_TITLE].ToString();
            bookInfo[2] = table[QueryStrings.FIELD_WRITER].ToString();
            bookInfo[3] = table[QueryStrings.FIELD_PUBLISHER].ToString();
            bookInfo[4] = table[QueryStrings.FIELD_COUNT].ToString();
            bookInfo[5] = table[QueryStrings.FIELD_PRICE].ToString();
            bookInfo[6] = table[QueryStrings.FIELD_RELEASEDATE].ToString();
            bookInfo[7] = table[QueryStrings.FIELD_ISBN].ToString();
            bookInfo[8] = table[QueryStrings.FIELD_INFO].ToString();
            return bookInfo;
        }
    }
}
