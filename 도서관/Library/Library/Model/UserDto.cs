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
        private Dictionary<int, BookDto> rentalBookDict;
        private List<BookDto> returnBookList;

        public UserDto() { }

        public UserDto(string id, string password, string age, string phoneNumber, string address)
        {
            this.id = id;
            this.password = password;
            this.age = age;
            this.phoneNumber = phoneNumber;
            this.address = address;
            this.rentalBookDict = new Dictionary<int, BookDto>();
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

        public Dictionary<int, BookDto> GetRentalBookDIct()
        { return rentalBookDict; }

        public void AddRentalBook(Tuple<int, BookDto> rentalBook)
        {
            rentalBookDict.Add(rentalBook.Item1, rentalBook.Item2);
        }

        public void SubtractRentalBook(int key)
        {
            returnBookList.Add(rentalBookDict[key]);
            rentalBookDict.Remove(key);
        }

        public List<BookDto> GetReturnBookList()
        {
            return returnBookList;
        }
    }
}
