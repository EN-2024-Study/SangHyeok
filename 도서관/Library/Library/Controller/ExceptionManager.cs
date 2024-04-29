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
    public class ExceptionManager
    {
        public static bool IsExoressionValid(int type, string str)
        {
            Regex regex = GetRegex(type);
            if (regex.IsMatch(str))
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

        private static Regex GetRegex(int type)
        {
            switch (type)
            {
                case (int)Enums.InputType.SignUpId:
                    return new Regex(RegularStrings.ID);
                case (int)Enums.InputType.SignUpPassword:
                    return new Regex(RegularStrings.PASSWORD);
                case (int)Enums.InputType.SignUpAge:
                    return new Regex(RegularStrings.AGE);
                case (int)Enums.InputType.SignUpPhoneNumber:
                    return new Regex(RegularStrings.PHONENUMBER);
                case (int)Enums.InputType.Writer:
                    return new Regex(RegularStrings.WRITER);
                case (int)Enums.InputType.Count:
                    return new Regex(RegularStrings.COUNT);
                case (int)Enums.InputType.ReleaseDate:
                    return new Regex(RegularStrings.RELEASEDATE);
                case (int)Enums.InputType.ISBN:
                    return new Regex(RegularStrings.ISBN);
            }
            return null;
        }
    }
}
