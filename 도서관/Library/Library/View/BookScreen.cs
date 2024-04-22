using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.View
{
    public class BookScreen
    {
        public void DrawBooks(List<BookDto> bookList)
        {
            int y = 10;
            for(int i = 0; i < bookList.Count; i++)
            {
                Console.SetCursorPosition(0, y + i);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("=====================================");
                Console.SetCursorPosition(0, y + i + 1);
                Console.Write("책 아이디 :" + (i + 1));
                Console.SetCursorPosition(0, y + i + 2);
                Console.Write("책 제목   :" + bookList[i].Title);
                Console.SetCursorPosition(0, y + i + 3);
                Console.Write("책 제목   :" + bookList[i].Writer);
                Console.SetCursorPosition(0, y + i + 4);
                Console.Write("책 제목   :" + bookList[i].Publisher);
                Console.SetCursorPosition(0, y + i + 5);
                Console.Write("책 제목   :" + bookList[i].Count);
                Console.SetCursorPosition(0, y + i + 6);
                Console.Write("책 제목   :" + bookList[i].Price);
                Console.SetCursorPosition(0, y + i + 7);
                Console.Write("책 제목   :" + bookList[i].ReleaseDate);
                Console.SetCursorPosition(0, y + i + 8);
                Console.Write("책 제목   :" + bookList[i].ISBN);
                Console.SetCursorPosition(0, y + i + 9);
                Console.Write("책 제목   :" + bookList[i].Info);
                Console.ResetColor();
                y += 10;
            }
        }

        public void DrawBookId()
        {
            Console.SetCursorPosition(0, 0);
            Console.Write("책 아이디 입력 :");

        }
    }
}
