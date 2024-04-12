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
        public bool CheckUser(string s, int stringType)
        {
            string[] str = s.Split('\0');

            if (stringType == (int)Constants.InputType.Id)
            {
                foreach (AccountDto value in AccountRepository.accountList)
                {
                    if (value.Id == str[0])
                        return true;
                }
            }
            else if (stringType == (int)Constants.InputType.Password)
            {
                foreach (AccountDto value in AccountRepository.accountList)
                {
                    if (value.Password == str[0])
                        return true;
                }
            }
            return false;
        }

        public bool CheckManager(string s, int stringType)
        {
            string[] str = s.Split('\0');

            if (stringType == (int)Constants.InputType.Id)
            {
                if (str[0] == AccountRepository.manager.Id)
                    return true;
            }
            else if (stringType == (int)Constants.InputType.Password)
            {
                if (str[0] == AccountRepository.manager.Password)
                    return true;
            }
            return false;
        }

    }
}
