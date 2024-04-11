using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Model
{

    public class AccountRepository
    {
        private List<AccountInfo> accountList;

        private AccountInfo manager;

        public AccountRepository()
        {
            accountList = new List<AccountInfo>
            {
                new AccountInfo("siwon", "1234", "김시원",
                                26, "010-4030-3719",
                                "경기도 의정부시")
            };

            manager = new AccountInfo("sanghyeok", "1234",
                 "서상혁", 25, "010-3077-5666",
                 "서울시 군자동");
        }

        public List<AccountInfo> AccountList
        {
            get { return accountList; }
        }

        public void SetAccountList(AccountInfo value)
        {
            accountList.Add(value);
        }

        public AccountInfo Manager
        {
            get { return manager; }
            set { manager = value; }
        }
    }
}