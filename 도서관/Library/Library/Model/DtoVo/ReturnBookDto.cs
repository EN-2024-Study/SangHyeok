using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model.DtoVo
{
    public class ReturnBookDto : BookDto
    {
        private string userId;

        public ReturnBookDto(BookDto book, string userId) : base(book.Id, book.Title, book.Writer, book.Publisher, book.Count, book.Price, book.ReleaseDate, book.ISBN, book.Info)
        {
            this.userId = userId;
        }

        public string UserId
        {
            get { return userId; }
            set { userId = value; }
        }
    }
}
