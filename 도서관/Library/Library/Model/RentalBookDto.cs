using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class RentalBookDto : BookDto
    {
        private string rentalTime, userId;

        public RentalBookDto(BookDto book, string rentalTime, string userId) : base(book.Id, book.Title, book.Writer, book.Publisher, book.Count, book.Price, book.ReleaseDate, book.ISBN, book.Info)
        {
            this.rentalTime = rentalTime;
            this.userId = userId;
        }

        public string RentalTime
        {
            get { return rentalTime; }
            set { rentalTime = value; }
        }

        public string UserId
        {
            get { return userId; }
            set { userId = value; }
        }
    }
}