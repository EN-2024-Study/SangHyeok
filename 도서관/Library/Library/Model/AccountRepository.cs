using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Model
{
    public class AccountRepository  // Singleton
    {
        private static AccountRepository instance;
        private AccountDto manager;
        private List<AccountDto> userList;

        private AccountRepository() 
            {
            manager = new AccountDto("sanghyeok", "1234",
                     "서상혁", "25", "010-3077-5666",
                     "서울시 군자동");
            userList = new List<AccountDto>
            {
            new AccountDto("siwon", "1234", "김시원",
                            "26", "010-4030-3719",
                            "경기도 의정부시")
            };
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

        public AccountDto Manager
        { get { return manager; } }

        public List<AccountDto> UserList
        { get { return userList; } }

        public void SetUserList(AccountDto value)
        {
            userList.Add(value);
        }


    }
}
