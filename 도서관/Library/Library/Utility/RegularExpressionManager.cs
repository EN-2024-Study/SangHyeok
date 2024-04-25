using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Library.Utility
{
    public class RegularExpressionManager
    {
        public static bool IsAccountIdValid(string id)
        {
            Regex regex = new Regex(@"^[0-9]{8}$");
            if (regex.IsMatch(id))
                return true;
            return false;
        }

        public static bool IsAccountPasswordValid(string password)
        {
            Regex regex = new Regex(@"^[0-9]{4}$");
            if (regex.IsMatch(password))
                return true;
            return false;
        }

        public static bool IsAgeValid(string age)
        {
            Regex regex = new Regex(@"^[0-9]{2}$");
            if (regex.IsMatch(age))
                return true;
            return false;
        }

        public static bool IsPhoneNumberValid(string phoneNumber)
        {
            Regex regex = new Regex(@"^010-[0-9]{4}-[0-9]{4}$");
            if (regex.IsMatch(phoneNumber))
                return true;
            return false;
        }

        public static bool IsAddressValid(string address)
        {
            Regex regex = new Regex(@"^[가-힣]{2}[구]{1}$");
            if (regex.IsMatch(address))
                return true;
            return false;
        }

        
    }
}
