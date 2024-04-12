using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Utility
{
    public class CheckInformation
    {

        public bool Check(string[] s, int type)
        {
            bool isCheck = false;
            string[] str = s[0].Split('\0');
            string id = str[0];
            str = new string[1];
            str = s[1].Split('\0');
            string password = str[0];
            //switch(type)  
            //{
            //    case (int)Constants.MenuType.LogInSignUp:
            //        str[0]
            //}

            

            if (type == (int)Constants.MenuType.LogInSignUp)
            {
                foreach (AccountDto value in AccountRepository.accountList)
                {
                    if (value.Id == id && value.Password == password)
                        return true;
                }
                if (AccountRepository.manager.Id == id && AccountRepository.manager.Password == password)
                    return true;
            }
           
            return false;
        }
    }
}
