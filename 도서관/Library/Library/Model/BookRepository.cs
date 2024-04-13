﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class BookRepository // singleton
    {
        private static BookRepository instance;
        private Dictionary<int, BookDto> bookDict;
        private int keyValue;
        private BookRepository() 
        {
            bookDict = new Dictionary<int, BookDto>
            {
                {
                    0,
                    new BookDto
                        ("패밀리 레스토랑 가자.", "야마",
                        "문학동네", "4", "12900", "2024.04.01",
                        "123a 123", "소설")
                },
                {
                    1,
                    new BookDto
                        ("일류의 조건", "다카시", "필름",
                        "3", "18000", "2024.03.01",
                        "321a 321", "자기계발")
                },
                {
                    2,
                    new BookDto
                        (
                            "불변의 법칙", "하우절",
                            "서삼독", "0", "22500",
                            "2000.09.08", "567a 567", "자기계발"
                        )
                }
            };
            keyValue = 3;
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

        public Dictionary<int, BookDto> BookDict
        { get { return bookDict; } }

        public void SetBookDict(BookDto value)
        {
            bookDict.Add(keyValue++, value);
        }
    }
}