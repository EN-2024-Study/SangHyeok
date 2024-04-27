using Library.Model.DtoVo;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class RentalBookDto : ReturnBookDto
    {
        private string rentalTime, returnTime;

        public RentalBookDto(BookDto book, string userId, string rentalTime, string returnTime) : base(book, userId)
        {
            this.rentalTime = rentalTime;
            this.returnTime = returnTime;
        }

        public string RentalTime
        {
            get { return rentalTime; }
            set { rentalTime = value; }
        }

        public string ReturnTime
        {
            get { return returnTime; }
            set { returnTime = value; }
        }
    }
}