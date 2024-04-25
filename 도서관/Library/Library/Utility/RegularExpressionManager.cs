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

        public static bool IsWriterValid(string writer)
        {
            Regex regex1 = new Regex(@"^[가-힣]{10}$");
            Regex regex2 = new Regex(@"^[a-z]{10}$");
            Regex regex3 = new Regex(@"^[A-Z]{10}$");

            if (regex1.IsMatch(writer) || regex2.IsMatch(writer) ||
                regex3.IsMatch(writer))
                return true; 
            return false;
        }

        public static bool IsPublisherValid(string publisher)
        {
            Regex regex = new Regex(@"^20[0-9]{2}-[0-9]{2}-[0-9]{2}$");
            if (regex.IsMatch(publisher))
                return true;
            return false;
        }

        public static bool IsISBNValid(string ISBN)
        {
            Regex regex1 = new Regex(@"^[0-9]{6}[a-z]{1} [0-9]{13}$");
            Regex regex2 = new Regex(@"^[0-9]{6}[A-Z]{1} [0-9]{13}$");

            if (regex1.IsMatch(ISBN) || regex2.IsMatch(ISBN))
                return true;
            return false;
        }
    }
}
