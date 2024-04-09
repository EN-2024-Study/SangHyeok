using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class BookInfo
    {
        private string title;
        private string writer;
        private string publisher;
        private int count;
        private int price;
        private string releaseDate;
        private string iSBN;
        private string info;

        public BookInfo(string title, string writer,
            string publisher, int count, int price,
            string releaseDate, string iSBN, string info)
        {
            this.title = title;
            this.writer = writer;
            this.publisher = publisher;
            this.count = count;
            this.price = price;
            this.releaseDate = releaseDate;
            this.iSBN = iSBN;
            this.info = info;
        }

        public string Title
        {
            get;
            set;
        }

        public string Writer
        {
            get;
            set;
        }
    }
}
