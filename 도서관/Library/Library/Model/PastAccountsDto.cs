using System;
using System.Collections.Generic;

namespace Library.Model
{
    public class PastAccountsDto
    {
        List<PastAccountInfo> accounts;
        PastAccountInfo manager;

        public PastAccountsDto()
        {
            manager = new PastAccountInfo("sanghyeok", "1234",
                "서상혁", 25, "010-3077-5666",
                "서울시 군자동");
            accounts = new List<PastAccountInfo>
            {
                new PastAccountInfo("sanghyeok", "1234",
                "서상혁", 25, "010-3077-5666",
                "서울시 군자동"),
                new PastAccountInfo("SiWon", "1234", "김시원",
                26, "010-4030-3719",
                "경기도 의정부시")
            };
        }

        public List<PastAccountInfo> Accounts
        {
            get;
            set;
        }

        public PastAccountInfo Manager
        {
            get;
            set;
        }
    }
}
