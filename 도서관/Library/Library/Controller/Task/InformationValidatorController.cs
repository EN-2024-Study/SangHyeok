using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Library.Utility
{
    public class InformationValidatorController
    {
        private AccountRepository instance;

        public InformationValidatorController()
        {
            instance = AccountRepository.Instance;  // singleton 생성
        }

        public bool CheckUserLogIn(string s, int stringType)
        {
            string[] str = s.Split('\0');
            List<AccountDto> list = instance.UserList;

            if (stringType == (int)Constants.InputType.Id)
            {
                foreach (AccountDto value in list)
                {
                    if (value.Id == str[0])
                        return true;
                }
            }
            else if (stringType == (int)Constants.InputType.Password)
            {
                foreach (AccountDto value in list)
                {
                    if (value.Password == str[0])
                        return true;
                }
            }
            return false;
        }

        public bool CheckManagerLogIn(string s, int stringType)
        {
            string[] str = s.Split('\0');
            AccountDto manager = instance.Manager;

            if (stringType == (int)Constants.InputType.Id)
            {
                if (str[0] == manager.Id)
                    return true;
            }
            else if (stringType == (int)Constants.InputType.Password)
            {
                if (str[0] == manager.Password)
                    return true;
            }
            return false;
        }

        public void SaveUserData(string[] inputString)
        {
            string[][] stringData = new string[7][];
            for(int i = 0; i < 7; i++)
                stringData[i] = inputString[i].Split('\0');

            AccountDto account = new AccountDto(stringData[0][0], stringData[1][0],
                stringData[3][0], stringData[4][0], stringData[5][0], stringData[6][0]);
            instance.SetUserList(account);
        }

    }
}
