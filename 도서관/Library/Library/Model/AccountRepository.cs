using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Model
{
    public class AccountRepository
    {
        public static AccountDto manager = new AccountDto("sanghyeok", "1234",
                 "서상혁", "25", "010-3077-5666",
                 "서울시 군자동");
        public static List<AccountDto> userList = new List<AccountDto>
        {
            new AccountDto("siwon", "1234", "김시원",
                            "26", "010-4030-3719",
                            "경기도 의정부시")
        };
    }
}