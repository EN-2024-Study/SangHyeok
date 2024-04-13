using System;
using Library.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.View
{
    public class UserModifyScreen
    {


        public void PrintAccountInfomation(AccountDto account)
        {
            Console.SetCursorPosition(40, 2);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("개 인 정 보 바 꾸 끼");
            Console.ResetColor();

            Console.SetCursorPosition(0, 6);
            Console.WriteLine("========================================================================");
            Console.SetCursorPosition(0, 8);
            Console.WriteLine("USER ID          : " + account.Id);
            Console.WriteLine("USER NAME        : " + account.Name);
            Console.WriteLine("USER AGE         : " + account.Age);
            Console.WriteLine("USER PHONENUMBER : " + account.PhoneNumber);
            Console.WriteLine("USER ADDRESS     : " + account.Address);
        }
    }
}
