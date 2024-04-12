using System;
using System.Collections.Generic;

namespace Library.Model
{
    public class BookDto
    {
        private string title;
        private string writer;
        private string publisher;
        private string count;
        private string price;
        private string releaseDate;
        private string iSBN;
        private string info;

        public BookDto(string title, string writer,
            string publisher, string count, string price,
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
