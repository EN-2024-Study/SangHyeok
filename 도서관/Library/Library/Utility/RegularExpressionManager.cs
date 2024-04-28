using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Net;

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
            Regex regex = new Regex(@"^[0-9]{1,2}$");
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
            Regex regex1 = new Regex(@"^[가-힣]{1,6}[도시]{1} [가-힣]{1,6}[시구]{1}$");
            Regex regex2 = new Regex(@"^[가-힣]{1,6}[도시]{1} [가-힣]{1,2}[구]{1} [가-힣]{1,6}[동]{1}$");
            if (regex1.IsMatch(address) || regex2.IsMatch(address))
                return true;
            return false;
        }

        public static bool IsWriterValid(string writer)
        {
            Regex regex = new Regex(@"^[a-zA-Z가-힣]{1,10}$");
            if (regex.IsMatch(writer))
                return true;
            return false;
        }

        public static bool IsReleaseDateValid(string releaseDate)
        {
            Regex regex = new Regex(@"^20[0-9]{2}-[0-9]{1,2}-[0-9]{1,2}$");
            if (regex.IsMatch(releaseDate))
                return true;
            return false;
        }

        public static bool IsISBNValid(string ISBN)
        {
            Regex regex = new Regex(@"^[0-9]{6}[a-zA-Z]{1} [0-9]{13}$");

            if (regex.IsMatch(ISBN))
                return true;
            return false;
        }
    }
}
