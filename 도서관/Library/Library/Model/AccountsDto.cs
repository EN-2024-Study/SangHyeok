using System;
using System.Collections.Generic;

namespace Library.Model
{
    public class AccountsDto
    {
        List<AccountInfo> accounts;
        AccountInfo manager;

        public AccountsDto()
        {
            manager = new AccountInfo("sanghyeok", 1234,
                "서상혁", 25, "010-3077-5666",
                "서울시 군자동");
            accounts = new List<AccountInfo>
            {
                new AccountInfo("sanghyeok", 1234,
                "서상혁", 25, "010-3077-5666",
                "서울시 군자동"),
                new AccountInfo("SiWon", 1234, "김시원",
                26, "010-4030-3719",
                "경기도 의정부시")
            };
        }

        public List<AccountInfo> Accounts
        {
            get;
            set;
        }

        public AccountInfo Manager
        {
            get;
            set;
        }
    }
}
