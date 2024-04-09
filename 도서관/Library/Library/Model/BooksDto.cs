﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class BooksDto
    {
        List<BookInfo> books;

        public BooksDto()
        {
            books = new List<BookInfo>
            {
                new BookInfo
                ("패밀리 레스토랑 가자.", "야마",
                "문학동네", 4, 12900, "2024.04.01",
                "123a 123", "소설"),
                new BookInfo
                ("일류의 조건", "다카시", "필름", 
                3, 18000, "2024.03.01", 
                "321a 321", "자기계발")
            };
        }       

        public List<BookInfo> Books
        {
            get { return books; }
            set { books = value; }
        }
    }
}
