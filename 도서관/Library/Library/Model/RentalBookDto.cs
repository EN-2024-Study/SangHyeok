using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class RentalBookDto
    {
        private BookDto bookDto;
        private DateTime rentalTime;
        public RentalBookDto(BookDto bookDto, DateTime rentalTime)
        {
            this.bookDto = bookDto;
            this.rentalTime = rentalTime;
        }

        public string Id
        {
            get { return bookDto.Id; }
            set { bookDto.Id = value; }
        }

        public string Title
        {
            get { return bookDto.Title; }
            set { bookDto.Title = value; }
        }

        public string Writer
        {
            get { return bookDto.Writer; }
            set { bookDto.Writer = value; }
        }
        public string Publisher
        {
            get { return bookDto.Publisher; }
            set { bookDto.Publisher = value; }
        }
        public int Count
        {
            get { return bookDto.Count; }
            set { bookDto.Count = value; }
        }
        public string Price
        {
            get { return bookDto.Price; }
            set { bookDto.Price = value; }
        }
        public string ReleaseDate
        {
            get { return bookDto.ReleaseDate; }
            set { bookDto.ReleaseDate = value; }
        }
        public string ISBN
        {
            get { return bookDto.ISBN; }
            set { bookDto.ISBN = value; }
        }
        public string Info
        {
            get { return bookDto.Info; }
            set { bookDto.Info = value; }
        }

        public DateTime RentalTime
        {
            get { return rentalTime; }
            set { rentalTime = value; }
        }
    }
}
