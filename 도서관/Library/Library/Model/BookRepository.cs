using Library.Utility;
using Library.View;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class BookRepository     // singleton
    {
        private static BookRepository instance;
        private List<BookDto> bookList;
        private int keyValue;

        private DbConnector db;

        private BookRepository()
        {
            db = DbConnector.Instance;

            bookList = new List<BookDto>()
            {
                new BookDto ("1", "패밀리 레스토랑 가자.", "야마",
                        "문학동네", 4, "12900", "2024.04.01",
                        "123456a 1234567890123", "소설"),
                new BookDto ("2", "일류의 조건", "다카시", "필름",
                        3, "18000", "2024.03.01",
                        "654321a 3210987654321", "자기계발"),
                new BookDto ("3", "불변의 법칙", "하우절",
                        "서삼독", 0, "22500",
                        "2000.09.08", "567567a 5675675675675", "자기계발")
            };
            keyValue = 4;
        }

        public static BookRepository Instance
        {
            get
            {
                if (instance == null)
                    instance = new BookRepository();
                return instance;
            }
        }

        public void AddBook(BookDto book)
        {
            string insertQuery = string.Format("INSERT INTO book VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}')",
                  book.Id, book.Title, book.Writer, book.Publisher, book.Count, book.Price, book.ReleaseDate, book.ISBN, book.Info);
            try
            {
                using (MySqlConnection mySql = new MySqlConnection(db.ConnectionAddress))
                {
                    mySql.Open();

                    MySqlCommand command = new MySqlCommand(insertQuery, mySql);
                    if (command.ExecuteNonQuery() == 1)
                        ExplainingScreen.ExplainSuccessScreen();
                }
            }
            catch (Exception exe)
            {
                Console.WriteLine(exe.Message);
            }
        }

        public List<BookDto> GetBookList()
        { return bookList; }

        public int KeyValue
        {
            get { return keyValue; } 
            set { keyValue = value; }
        }

        public void ReduceBookCount(int key)
        { bookList[key].Count -= 1; }

        public void IncreaseBookCount(int key)
        { bookList[key].Count += 1; }

        public void DeleteBook(int key)
        { bookList.RemoveAt(key); }

        public void ModifyBookTitle(int key, string title)
        { bookList[key].Title = title; }

        public void ModifyBookWriter(int key, string writer)
        { bookList[key].Writer = writer; }

        public void ModifyBookPublisher(int key, string publisher)
        { bookList[key].Publisher = publisher; }

        public void ModifyBookCount(int key, int count)
        { bookList[key].Count = count; }

        public void ModifyBookPrice(int key, string price)
        { bookList[key].Price = price; }

        public void ModifyBookReleaseDate(int key, string releaseData)
        { bookList[key].ReleaseDate = releaseData; }
    }
}
