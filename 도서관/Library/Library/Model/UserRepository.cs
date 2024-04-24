using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class UserRepository     // singleton
    {
        private static UserRepository instance;
        private List<UserDto> userDtoList;
        private int userIndex;

        private UserRepository()
        {
            this.userDtoList = new List<UserDto> 
            {
                new UserDto("12345678", "1234", "25", "010-3077-5666", "광진구"),
                new UserDto("11111111", "1234", "24", "010-1234-5678", "중랑구")
            };
            this.userIndex = -1;
        }

        public static UserRepository Instance
        {
            get
            {
                if (instance == null)
                    instance = new UserRepository();
                return instance;
            }
        }

        public List<UserDto> GetUserList()
        {
            return userDtoList;
        }

        public int UserIndex
        {
            get { return userIndex; }
            set { userIndex = value; }
        }

        public void AddUser(UserDto user)
        {
            userDtoList.Add(user);
        }

        public void RemoveUser()
        {
            userDtoList.Remove(userDtoList[userIndex]);
        }

        public void UpdatePassword(string password)
        {
            userDtoList[userIndex].Password = password;
        }

        public void UpdateAge(string age)
        {
            userDtoList[userIndex].Age = age;
        }

        public void UpdatePhoneNumber(string phoneNumber)
        {
            userDtoList[userIndex].PhoneNumber = phoneNumber;
        }

        public void UpdateAddress(string address)
        {
            userDtoList[userIndex].Address = address;
        }

        public List<RentalBookDto> GetRentalBookList()
        {
            return userDtoList[userIndex].GetRentalBookList();
        }

        public void AddRentalBook(RentalBookDto rentalBook)
        {
            userDtoList[userIndex].AddRentalBook(rentalBook);
        }

        public void SubtractRentalBook(int key)
        {
            userDtoList[userIndex].SubtractRentalBook(key);
        }

        public void AddReturnBook(BookDto bookDto)
        {
            userDtoList[userIndex].AddReturnBook(bookDto);
        }

        public List<BookDto> GetReturnBookList()
        {
            return userDtoList[userIndex].GetReturnBookList();
        }
    }
}
