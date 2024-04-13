using System;
using System.Collections.Generic;
using Library.Model;

namespace Library.View
{
    public class BookScreen
    {
        public void PrintAllBook(List<BookDto> book)
        {
            Console.SetCursorPosition(0, 8);
            for(int i = 0; i < book.Count; i++)
            {
                Console.WriteLine("========================================================================");
                Console.WriteLine("책 아이디  : " + (i + 1));
                Console.WriteLine("책 제목    : " + book[i].Title);
                Console.WriteLine("작가       : " + book[i].Writer);
                Console.WriteLine("출판사     : " + book[i].Publisher);
                Console.WriteLine("수량       : " + book[i].Count);
                Console.WriteLine("가격       : " + book[i].Price);
                Console.WriteLine("출시일     : " + book[i].ReleaseDate);
                Console.WriteLine("ISBN       : " + book[i].ISBN);
                Console.WriteLine("책 정보    : " + book[i].Info);
            }
        }
    }
}
