using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class BookRepository     // singleton
    {
        private static BookRepository instance;
        private Dictionary<int, BookDto> bookDict;
        private int keyValue;

        private BookRepository()
        {
            bookDict = new Dictionary<int, BookDto>()
            {
                { 1, new BookDto ("1", "패밀리 레스토랑 가자.", "야마",
                        "문학동네", 4, "12900", "2024.04.01",
                        "123a 123", "소설") },
                { 2, new BookDto ("2", "일류의 조건", "다카시", "필름",
                        3, "18000", "2024.03.01",
                        "321a 321", "자기계발")},
                { 3,
                    new BookDto ("3", "불변의 법칙", "하우절",
                            "서삼독", 0, "22500",
                            "2000.09.08", "567a 567", "자기계발") }
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

        public Dictionary<int, BookDto> GetBookDict()
        { return bookDict; }

        public int KeyValue
        {
            get { return keyValue; } 
            set { keyValue = value; }
        }

        public void ReduceBookCount(int key)
        {
            bookDict[key].Count -= 1;
        }

        public void IncreaseBookCount(int key)
        {
            bookDict[key].Count += 1;
        }

        public void AddBook(BookDto book)
        {
            bookDict.Add(keyValue, book);
        }

        public void DeleteBook(int key)
        {
            bookDict.Remove(key);
        }

        public void ModifyBookTitle(int key, string title)
        {
            bookDict[key].Title = title;
        }

        public void ModifyBookWriter(int key, string writer)
        {
            bookDict[key].Writer = writer;
        }

        public void ModifyBookPublisher(int key, string publisher)
        {
            bookDict[key].Publisher = publisher;
        }

        public void ModifyBookCount(int key, int count)
        {
            bookDict[key].Count = count;
        }

        public void ModifyBookPrice(int key, string price)
        {
            bookDict[key].Price = price;
        }

        public void ModifyBookReleaseDate(int key, string releaseData)
        {
            bookDict[key].ReleaseDate = releaseData;
        }
    }
}
