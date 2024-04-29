using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Net;
using Library.Constants;

namespace Library.Controller
{
    public class RegularExpressionManager
    {
        public static bool IsAccountIdValid(string id)
        {
            Regex regex = new Regex(RegularStrings.ID);
            if (regex.IsMatch(id))
                return true;
            return false;
        }

        public static bool IsAccountPasswordValid(string password)
        {
            Regex regex = new Regex(RegularStrings.PASSWORD);
            if (regex.IsMatch(password))
                return true;
            return false;
        }

        public static bool IsAgeValid(string age)
        {
            Regex regex = new Regex(RegularStrings.AGE);
            if (regex.IsMatch(age))
                return true;
            return false;
        }

        public static bool IsPhoneNumberValid(string phoneNumber)
        {
            Regex regex = new Regex(RegularStrings.PHONENUMBER);
            if (regex.IsMatch(phoneNumber))
                return true;
            return false;
        }

        public static bool IsAddressValid(string address)
        {
            Regex regex1 = new Regex(RegularStrings.ADDRESS1);
            Regex regex2 = new Regex(RegularStrings.ADDRESS2);
            if (regex1.IsMatch(address) || regex2.IsMatch(address))
                return true;
            return false;
        }

        public static bool IsWriterValid(string writer)
        {
            Regex regex = new Regex(RegularStrings.WRITER);
            if (regex.IsMatch(writer))
                return true;
            return false;
        }

        public static bool IsReleaseDateValid(string releaseDate)
        {
            Regex regex = new Regex(RegularStrings.RELEASEDATE);
            if (regex.IsMatch(releaseDate))
                return true;
            return false;
        }

        public static bool IsISBNValid(string ISBN)
        {
            Regex regex = new Regex(RegularStrings.ISBN);

            if (regex.IsMatch(ISBN))
                return true;
            return false;
        }
    }
}
