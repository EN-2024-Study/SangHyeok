using Library.Model.DtoVo;
using Library.Utility;
using Library.View;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static Mysqlx.Expect.Open.Types.Condition.Types;

namespace Library.Model
{
    public class BookRepository    
    {
        private DbConnector db;

        public BookRepository()
        {
            this.db = DbConnector.Instance;
        }

        public List<BookDto> GetBookList()
        {
            string selectQuery = string.Format("SELECT * FROM book");
            List<BookDto> bookList = new List<BookDto>();

            try
            {
                db.MySql.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, db.MySql);
                MySqlDataReader table = command.ExecuteReader();

                while (table.Read())
                {
                    string[] bookInfo = GetBookInfo(table);
                    bookList.Add(new BookDto(bookInfo[0], bookInfo[1], bookInfo[2],
                        bookInfo[3], int.Parse(bookInfo[4]), bookInfo[5], bookInfo[6],
                        bookInfo[7], bookInfo[8]));
                }
                
            }
            catch (Exception exe)
            {
                Console.WriteLine(exe.Message);
            }

            return bookList;
        }

        public List<RentalBookDto> GetRentalBookList()
        {
            string selectQuery = null;
            List<RentalBookDto> rentalBookList = new List<RentalBookDto>();
            selectQuery = string.Format("SELECT * FROM rentalbook");

            try
            {
                db.MySql.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, db.MySql);
                MySqlDataReader table = command.ExecuteReader();

                while (table.Read())
                {
                    string[] bookInfo = GetBookInfo(table);
                    string rentalTime = table["rentaltime"].ToString();
                    string returnTime = table["returntime"].ToString();
                    string userId = table["returntime"].ToString();
                    rentalBookList.Add(new RentalBookDto(new BookDto(bookInfo[0], bookInfo[1], bookInfo[2],
                        bookInfo[3], int.Parse(bookInfo[4]), bookInfo[5], bookInfo[6],
                        bookInfo[7], bookInfo[8]), rentalTime, returnTime, userId));
                }
            }
            catch (Exception exe)
            {
                Console.WriteLine(exe.Message);
            }
            return rentalBookList;
        }

        public List<ReturnBookDto> GetReturnBookList()
        {
            string selectQuery = null;
            List<ReturnBookDto> returnBookList = new List<ReturnBookDto>();
            selectQuery = string.Format("SELECT * FROM returnbook");

            try
            {
                db.MySql.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, db.MySql);
                MySqlDataReader table = command.ExecuteReader();

                while (table.Read())
                {
                    string[] bookInfo = GetBookInfo(table);
                    string userId = table["userid"].ToString();
                    returnBookList.Add(new ReturnBookDto(new BookDto(bookInfo[0], bookInfo[1], bookInfo[2],
                        bookInfo[3], int.Parse(bookInfo[4]), bookInfo[5], bookInfo[6],
                        bookInfo[7], bookInfo[8]), userId));
                }
            }
            catch (Exception exe)
            {
                Console.WriteLine(exe.Message);
            }
            return returnBookList;
        }

        private string[] GetBookInfo(MySqlDataReader table)
        {
            string[] bookInfo = new string[9];
            bookInfo[0] = table["id"].ToString();
            bookInfo[1] = table["title"].ToString();
            bookInfo[2] = table["writer"].ToString();
            bookInfo[3] = table["publisher"].ToString();
            bookInfo[4] = table["count"].ToString();
            bookInfo[5] = table["price"].ToString();
            bookInfo[6] = table["releasedate"].ToString();
            bookInfo[7] = table["iSBN"].ToString();
            bookInfo[8] = table["info"].ToString();
            return bookInfo;
        }

        public void AddBook(BookDto book)
        {
            string insertQuery = string.Format("INSERT INTO book VALUES( null, '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')",
                  book.Title, book.Writer, book.Publisher, book.Count, book.Price, book.ReleaseDate, book.ISBN, book.Info);
            db.SetData(insertQuery);
        }

        public void DeleteBook(string key)
        {
            string deleteQuery = string.Format("DELETE FROM book WHERE id = {0}", key);
            db.SetData(deleteQuery);
        }

        public void ModifyBookInfo(string key, string updateString, object value)
        {
            string modifyQuery = null;
            if (updateString.Equals("count"))
                modifyQuery = string.Format("UPDATE book SET count = {1} WHERE id = {0}", key, (int)value);
            else
                modifyQuery = string.Format("UPDATE book SET {1} = '{2}' WHERE id = {0}", key, (string)updateString, value);

            db.SetData(modifyQuery);
        }

        public void RentalBook(RentalBookDto book)
        {
            string query = string.Format("INSERT INTO rentalbook VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}')",
                  book.Id, book.Title, book.Writer, book.Publisher, book.Count, book.Price, book.ReleaseDate, book.ISBN, book.Info, book.RentalTime, book.ReturnTime, book.UserId);
            db.SetData(query);

            query = string.Format("UPDATE book SET count = count - 1 WHERE id = {0}", book.Id);
            db.SetData(query);
        }

        public void ReturnBook(RentalBookDto book)
        {
            string query = string.Format("DELETE FROM rentalbook WHERE id = {0}", book.Id);
            db.SetData(query);

            query = string.Format("UPDATE book SET count = count + 1 WHERE id = {0}", book.Id);
            db.SetData(query);

            query = string.Format("INSERT INTO returnbook VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}')",
                  book.Id, book.Title, book.Writer, book.Publisher, book.Count, book.Price, book.ReleaseDate, book.ISBN, book.Info, book.UserId);
            db.SetData(query);
        }
    }
}
