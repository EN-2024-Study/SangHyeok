using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class UserDto
    {
        private string id, password, age, phoneNumber, address;
        private List<RentalBookDto> rentalBookList;
        private List<BookDto> returnBookList;

        public UserDto(string id, string password, string age, string phoneNumber, string address)
        {
            this.id = id;
            this.password = password;
            this.age = age;
            this.phoneNumber = phoneNumber;
            this.address = address;
            this.rentalBookList = new List<RentalBookDto>();
            this.returnBookList = new List<BookDto>();
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Age
        {
            get { return age; }
            set { age = value; }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public List<RentalBookDto> GetRentalBookList()
        { return rentalBookList; }

        public void AddRentalBook(RentalBookDto rentalBook)   
        { rentalBookList.Add(rentalBook); }

        public void AddReturnBook(BookDto book)
        { returnBookList.Add(book); }

        public void SubtractRentalBook(RentalBookDto book)
        { rentalBookList.Remove(book); }

        public List<BookDto> GetReturnBookList()
        { return returnBookList; }
    }
}
