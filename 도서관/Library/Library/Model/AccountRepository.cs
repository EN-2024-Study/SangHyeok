using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Model
{

    public class AccountRepository
    {
        private List<AccountDto> accountList;

        private AccountDto manager;

        public AccountRepository()
        {
            accountList = new List<AccountDto>
            {
                new AccountDto("siwon", "1234", "김시원",
                                26, "010-4030-3719",
                                "경기도 의정부시")
            };

            manager = new AccountDto("sanghyeok", "1234",
                 "서상혁", 25, "010-3077-5666",
                 "서울시 군자동");
        }

        public List<AccountDto> AccountList
        {
            get { return accountList; }
        }

        public void SetAccountList(AccountDto value)
        {
            accountList.Add(value);
        }

        public AccountDto Manager
        {
            get { return manager; }
            set { manager = value; }
        }
    }
}