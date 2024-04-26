using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class BookDto
    {
        protected string id;
        protected string title;
        protected string writer;
        protected string publisher;
        protected int count;
        protected string price;
        protected string releaseDate;
        protected string iSBN;
        protected string info;

        public BookDto(string id, string title, string writer,
            string publisher, int count, string price,
            string releaseDate, string iSBN, string info)
        {
            this.id = id;
            this.title = title;
            this.writer = writer;
            this.publisher = publisher;
            this.count = count;
            this.price = price;
            this.releaseDate = releaseDate;
            this.iSBN = iSBN;
            this.info = info;
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Writer
        {
            get { return writer; }
            set { writer = value; }
        }
        public string Publisher
        {
            get { return publisher; }
            set { publisher = value; }
        }
        public int Count
        {
            get { return count; }
            set { count = value; }
        }
        public string Price
        {
            get { return price; }
            set { price = value; }
        }
        public string ReleaseDate
        {
            get { return releaseDate; }
            set { releaseDate = value; }
        }
        public string ISBN
        {
            get { return iSBN; }
            set { iSBN = value; }
        }
        public string Info
        {
            get { return info; }
            set { info = value; }
        }
    }
}
