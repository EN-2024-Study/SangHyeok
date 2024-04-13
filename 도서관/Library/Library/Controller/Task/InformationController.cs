using Library.Model;
using Library.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Library.Utility
{
    public class InformationController
    {
        private AccountRepository accountInstance;
        private BookRepository bookInstance;
        private BookScreen bookScreen;

        public InformationController()
        {
            accountInstance = AccountRepository.Instance;  // singleton 생성
            bookInstance = BookRepository.Instance; // singleton 생성
            bookScreen = new BookScreen();
        }

        public bool CheckUserLogIn(string str, int stringType)
        {
            List<AccountDto> list = accountInstance.UserList;

            if (stringType == (int)Constants.InputType.Id)
            {
                foreach (AccountDto value in list)
                {
                    if (value.Id == str)
                        return true;
                }
            }
            else if (stringType == (int)Constants.InputType.Password)
            {
                foreach (AccountDto value in list)
                {
                    if (value.Password == str)
                        return true;
                }
            }
            return false;
        }

        public bool CheckManagerLogIn(string str, int stringType)
        {
            AccountDto manager = accountInstance.Manager;

            if (stringType == (int)Constants.InputType.Id)
            {
                if (str == manager.Id)
                    return true;
            }
            else if (stringType == (int)Constants.InputType.Password)
            {
                if (str == manager.Password)
                    return true;
            }
            return false;
        }

        public void SaveUserData(string[] inputString)
        {
            string[][] stringData = new string[7][];
            for (int i = 0; i < 7; i++)
                stringData[i] = inputString[i].Split('\0');

            AccountDto account = new AccountDto(stringData[0][0], stringData[1][0],
                stringData[3][0], stringData[4][0], stringData[5][0], stringData[6][0]);
            accountInstance.SetUserList(account);
        }

        public void SaveBookData(string[] inputString)
        {
            string[][] str = new string[8][];
            for (int i = 0; i < 8; i++)
                str[i] = inputString[i].Split('\0');
            inputString = new string[8];
            for (int i = 0; i < 8; i++)
                inputString[i] = str[i][0];

            BookDto book = new BookDto(inputString[0], inputString[1], inputString[2], 
                inputString[3], inputString[4], inputString[5], inputString[6], inputString[7]);
            bookInstance.SetBookDict(book);
        }

        public void ShowAllBookInfo()
        {
            bookScreen.PrintBookInfo(bookInstance.BookDict.Values.ToList<BookDto>());
        }

        public List<BookDto> SearchBooks(string[] inputString)
        {
            List<BookDto> books = bookInstance.BookDict.Values.ToList<BookDto>();
            List<BookDto> searchedBooks = books;

            string[][] str = new string[3][];
            for (int i = 0; i < 3; i++)
                str[i] = inputString[i].Split('\0');
            inputString = new string[3] { str[0][0], str[1][0], str[2][0] };

            for (int i = 0; i < 3; i++)
            {
                if (inputString[i] == "")
                    continue;

                List<BookDto> temp = new List<BookDto>();
                foreach (BookDto book in searchedBooks)
                {
                    switch (i)
                    {
                        case (int)Constants.BookInfo.Title:
                            if (book.Title.Contains(inputString[i]))
                                temp.Add(book);
                            break;
                        case 1:
                            if (book.Writer.Contains(inputString[i]))
                                temp.Add(book);
                            break;
                        case 2:
                            if (book.Publisher.Contains(inputString[i]))
                                temp.Add(book);
                            break;
                    }
                }

                searchedBooks = temp;
            }

            return searchedBooks;
        }

        public string TrimString(string s)
        {
            string[] result = s.Split('\0');
            return result[0];
        }
        
        public BookDto SearchIdBooks(int id)
        {
            if (bookInstance.BookDict.TryGetValue(id, out BookDto book))
                return book;
            return null;
        }

        public void RentalBook(BookDto book)
        {
            accountInstance.SetRentalBookList(book);
        }

        public List<BookDto> GetRentalBook()
        {
            return accountInstance.RentalBookList;
        }

        public bool RemoveReturnBook(BookDto book)
        {
            bool isReturn =  accountInstance.RemoveRentalBook(book);
            if (isReturn)
                accountInstance.SetReturnBookList(book);
            return isReturn;
        }

        public List<BookDto> GetReturnBook()
        {
            return accountInstance.ReturnBookList;
        }

        public AccountDto GetAccount()
        {
            return accountInstance.UserList.Last();
        }

        public void ModifyAccount(AccountDto newAccount, AccountDto oldAccount)
        {
            accountInstance.ModifyAccount(oldAccount, newAccount);
        }
    }
}
