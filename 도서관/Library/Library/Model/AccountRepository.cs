using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Model
{
    public class AccountRepository  // Singleton
    {
        private static AccountRepository instance;
        private List<AccountDto> userList;
        private List<BookDto> rentalBookList;
        private List<BookDto> returnBookList;

        private AccountRepository() 
            {
                userList = new List<AccountDto>
                {
                new AccountDto("siwon", "1234", "김시원",
                                "26", "010-4030-3719",
                                "경기도 의정부시")
                };
            rentalBookList = new List<BookDto>();
            returnBookList = new List<BookDto>();
        }

        public static AccountRepository Instance
        {
            get
            {
                if (instance == null)
                    instance = new AccountRepository();
                return instance;
            }
        }

        public List<AccountDto> UserList
        { get { return userList; } }

        public void SetUserList(AccountDto value)
        {
            userList.Add(value);
        }

        public List<BookDto> RentalBookList
        { get { return rentalBookList; } }

        public void SetRentalBookList(BookDto value)
        {
            rentalBookList.Add(value);
        }

        public bool RemoveRentalBook(BookDto value)
        {
            return rentalBookList.Remove(value);
        }

        public List<BookDto> ReturnBookList
        { get { return returnBookList; } }

        public void SetReturnBookList(BookDto value)
        {
            returnBookList.Add(value);
        }

        public void ModifyAccount(AccountDto deleteAccount, AccountDto addAccount)
        {
            DeleteAccount(deleteAccount);
            userList.Add(addAccount);
        }

        public bool DeleteAccount(AccountDto deleteAccount)
        {
            return userList.Remove(deleteAccount);
        }
    }
}
