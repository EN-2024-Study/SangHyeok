using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class ManagerRepository   // singleton
    {
        private static ManagerRepository instance;
        private AccountDto manager;

        private ManagerRepository()
        {
            manager = new AccountDto("sanghyeok", "1234",
                     "서상혁", "25", "010-3077-5666",
                     "서울시 군자동");
        }

        public static ManagerRepository Instance
        {
            get
            {
                if (instance == null)
                    instance = new ManagerRepository();
                return instance;
            }
        }

        public AccountDto Manager
        { get { return manager; } }
    }
}
