using System;
using System.Collections.Generic;

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

        //    {
        //        new BookInfo
        //        ("패밀리 레스토랑 가자.", "야마",
        //        "문학동네", 4, 12900, "2024.04.01",
        //        "123a 123", "소설"),
        //        new BookInfo
        //        ("일류의 조건", "다카시", "필름", 
        //        3, 18000, "2024.03.01", 
        //        "321a 321", "자기계발")
        //    };
        //}       

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
