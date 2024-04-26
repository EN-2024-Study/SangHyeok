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
                        bookInfo[6] = table["releaseDate"].ToString();
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

        public void AddBook(BookDto book)
        {
            string insertQuery = string.Format("INSERT INTO book VALUES( null, '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')",
                  book.Title, book.Writer, book.Publisher, book.Count, book.Price, book.ReleaseDate, book.ISBN, book.Info);
            SetData(insertQuery);
        }

        public void ReduceBookCount(string key)
        {
            string updateQuery = string.Format("UPDATE book SET count = count - 1 WHERE id = {0}", key);
            SetData(updateQuery);
        }

        public void IncreaseBookCount(string key)
        {
            string updateQuery = string.Format("UPDATE book SET count = count + 1 WHERE id = {0}", key);
            SetData(updateQuery);
        }

        public void DeleteBook(string key)
        {
            string deleteQuery = string.Format("DELETE FROM book WHERE id = {0}", key);
            SetData(deleteQuery);
        }

        public void ModifyBookTitle(string key, string title)
        {
            string modifyQuery = string.Format("UPDATE book SET title = {1} WHERE id = {0}", key, title);
            SetData(modifyQuery);
        }

        public void ModifyBookWriter(string key, string writer)
        {
            string modifyQuery = string.Format("UPDATE book SET writer = {1} WHERE id = {0}", key, writer);
            SetData(modifyQuery);
        }

        public void ModifyBookPublisher(string key, string publisher)
        {
            string modifyQuery = string.Format("UPDATE book SET publisher = {1} WHERE id = {0}", key, publisher);
            SetData(modifyQuery);
        }

        public void ModifyBookCount(string key, int count)
        {
            string modifyQuery = string.Format("UPDATE book SET count = {1} WHERE id = {0}", key, count);
            SetData(modifyQuery);
        }

        public void ModifyBookPrice(string key, string price)
        {
            string modifyQuery = string.Format("UPDATE book SET price = {1} WHERE id = {0}", key, price);
            SetData(modifyQuery);
        }

        public void ModifyBookReleaseDate(string key, string releaseData)
        {
            string modifyQuery = string.Format("UPDATE book SET releaseData = {1} WHERE id = {0}", key, releaseData);
            SetData(modifyQuery);
        }


        private void SetData(string query)
        {
            try
            {
                using (MySqlConnection mySql = new MySqlConnection(db.ConnectionAddress))
                {
                    mySql.Open();

                    MySqlCommand command = new MySqlCommand(query, mySql);
                    if (command.ExecuteNonQuery() == 1)
                        ExplainingScreen.ExplainSuccessScreen();
                }
            }
            catch (Exception exe)
            {
                Console.WriteLine(exe.Message);
            }
        }
    }
}
