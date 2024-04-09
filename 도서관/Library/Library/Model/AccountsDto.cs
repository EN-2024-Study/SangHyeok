using System;
using System.Collections.Generic;

namespace Library.Model
{
    public class AccountsDto
    {
        List<AccountInfo> accounts;

        public AccountsDto()
        {
            accounts = new List<AccountInfo>();
        }

        public List<AccountInfo> Accounts
        {
            get { return accounts; }
            set { accounts = value; }
        }
    }
}
