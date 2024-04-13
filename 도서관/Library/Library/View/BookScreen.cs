using System;
using System.Collections.Generic;
using Library.Model;
using Library.Utility;

namespace Library.View
{
    public class BookScreen
    {
        public void PrintBookInfo(List<BookDto> bookList)
        {
            Console.SetCursorPosition(0, 8);
            for(int i = 0; i < bookList.Count; i++)
            {
                Console.WriteLine("========================================================================");
                Console.WriteLine("책 아이디  : " + (i + 1));
                Console.WriteLine("책 제목    : " + bookList[i].Title);
                Console.WriteLine("작가       : " + bookList[i].Writer);
                Console.WriteLine("출판사     : " + bookList[i].Publisher);
                Console.WriteLine("수량       : " + bookList[i].Count);
                Console.WriteLine("가격       : " + bookList[i].Price);
                Console.WriteLine("출시일     : " + bookList[i].ReleaseDate);
                Console.WriteLine("ISBN       : " + bookList[i].ISBN);
                Console.WriteLine("책 정보    : " + bookList[i].Info);
            }
        }

        public void PrintIdSearch(string str)
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(str);
            Console.WriteLine("ID 값은 1부터 999 사이의 값입니다.");
            Console.WriteLine("입력 : ");
        }

 
    }
}
