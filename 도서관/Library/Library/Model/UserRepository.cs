using System;
using System.Collections.Generic;

namespace Library.Model
{
    public class UserRepository // singleton
    {
        private static UserRepository instance;
        private AccountDto user;
        private UserRepository()
        {
            user = new AccountDto();
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

        public AccountDto User
        {
            get { return user; }
            set { user = value; }
        }
    }
}
