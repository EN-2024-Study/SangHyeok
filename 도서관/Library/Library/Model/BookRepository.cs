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
            string[] bookInfo = new string[9];
            List<BookDto> bookList = new List<BookDto>();

            try
            {
                using (MySqlConnection mySql = new MySqlConnection(db.ConnectionAddress))
                {
                    mySql.Open();

                    MySqlCommand command = new MySqlCommand(selectQuery, mySql);
                    MySqlDataReader table = command.ExecuteReader();

                    while (table.Read())
                    {
                        bookInfo[0] = table["id"].ToString();
                        bookInfo[1] = table["title"].ToString();
                        bookInfo[2] = table["writer"].ToString();
                        bookInfo[3] = table["publisher"].ToString();
                        bookInfo[4] = table["count"].ToString();
                        bookInfo[5] = table["price"].ToString();
                        bookInfo[6] = table["releasedate"].ToString();
                        bookInfo[7] = table["iSBN"].ToString();
                        bookInfo[8] = table["info"].ToString();
                        bookList.Add(new BookDto(bookInfo[0], bookInfo[1], bookInfo[2],
                            bookInfo[3], int.Parse(bookInfo[4]), bookInfo[5], bookInfo[6],
                            bookInfo[7], bookInfo[8]));
                    }
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
            string[] bookInfo = new string[11];
            List<RentalBookDto> rentalBookList = new List<RentalBookDto>();
            selectQuery = string.Format("SELECT * FROM rentalbook");

            try
            {
                using (MySqlConnection mySql = new MySqlConnection(db.ConnectionAddress))
                {
                    mySql.Open();

                    MySqlCommand command = new MySqlCommand(selectQuery, mySql);
                    MySqlDataReader table = command.ExecuteReader();

                    while (table.Read())
                    {
                        bookInfo[0] = table["id"].ToString();
                        bookInfo[1] = table["title"].ToString();
                        bookInfo[2] = table["writer"].ToString();
                        bookInfo[3] = table["publisher"].ToString();
                        bookInfo[4] = table["count"].ToString();
                        bookInfo[5] = table["price"].ToString();
                        bookInfo[6] = table["releasedate"].ToString();
                        bookInfo[7] = table["iSBN"].ToString();
                        bookInfo[8] = table["info"].ToString();
                        bookInfo[9] = table["rentaltime"].ToString();
                        bookInfo[10] = table["userid"].ToString();
                        rentalBookList.Add(new RentalBookDto(bookInfo[0], bookInfo[1], bookInfo[2],
                            bookInfo[3], int.Parse(bookInfo[4]), bookInfo[5], bookInfo[6],
                            bookInfo[7], bookInfo[8], bookInfo[9], bookInfo[10]));
                    }
                }
            }
            catch (Exception exe)
            {
                Console.WriteLine(exe.Message);
            }
            return rentalBookList;
        }

        public void AddBook(BookDto book)
        {
            string insertQuery = string.Format("INSERT INTO book VALUES( null, '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')",
                  book.Title, book.Writer, book.Publisher, book.Count, book.Price, book.ReleaseDate, book.ISBN, book.Info);
            db.SetData(insertQuery);
        }

        public void ReduceBookCount(string key)
        {
            string updateQuery = string.Format("UPDATE book SET count = count - 1 WHERE id = {0}", key);
            db.SetData(updateQuery);
        }

        public void IncreaseBookCount(string key)
        {
            string updateQuery = string.Format("UPDATE book SET count = count + 1 WHERE id = {0}", key);
            db.SetData(updateQuery);
        }

        public void DeleteBook(string key)
        {
            string deleteQuery = string.Format("DELETE FROM book WHERE id = {0}", key);
            db.SetData(deleteQuery);
        }

        public void ModifyBookInfo(string key, string updateString, string value)
        {
            string modifyQuery = string.Format("UPDATE book SET {1} = '{2}' WHERE id = {0}", key, updateString, value);
            db.SetData(modifyQuery);
        }

        public void ModifyBookCount(string key, int count)
        {
            string modifyQuery = string.Format("UPDATE book SET count = {1} WHERE id = {0}", key, count);
            db.SetData(modifyQuery);
        }

        public void AddRentalBook(RentalBookDto book)
        {
            string insertQuery = string.Format("INSERT INTO rentalbook VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}')",
                  book.Id, book.Title, book.Writer, book.Publisher, book.Count, book.Price, book.ReleaseDate, book.ISBN, book.Info, book.RentalTime, book.UserId);
            db.SetData(insertQuery);
        }

        public void SubtractRentalBook(string key)
        {
            string deleteQuery = string.Format("DELETE FROM rentalbook WHERE id = {0}", key);
            db.SetData(deleteQuery);
        }
    }
}
