using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Net;
using Library.Constants;
using Library.Model;
using Library.Model.DtoVo;
using Library.View;

namespace Library.Controller
{
    public class ExceptionManager
    {
        public bool IsExoressionValid(int type, string str)
        {
            Regex regex = GetRegex(type);
            if (regex.IsMatch(str))
                return true;
            return false;
        }

        public bool IsAddressValid(string address)
        {
            Regex regex1 = new Regex(RegularStrings.ADDRESS1);
            Regex regex2 = new Regex(RegularStrings.ADDRESS2);
            if (regex1.IsMatch(address) || regex2.IsMatch(address))
                return true;
            return false;
        }

        public bool IsRequestValid(int type, List<NaverBookVo> bookList, NaverBookVo book)
        {
            if (book == null)
            {
                ExplainingScreen.ExplainFailScreen();
                ExplainingScreen.ExplainInvalidInput("도서 제목");
                return false;
            }

            bool isDuplication = false;
            if (type == (int)Enums.ModeMenu.UserMode)
            {
                foreach (NaverBookVo item in bookList)
                {
                    if (item.Equals(book))  // 이미 요청한 책이라면 false
                    {
                        isDuplication = true;
                        break;
                    }
                }
            }
            else if (type == (int)Enums.ModeMenu.ManagerMode)
            {
                foreach (NaverBookVo item in bookList)
                    if (item.Equals(book))  // user가 요청한 책 이름과 같다면 true
                        return true;

                isDuplication = true;
            }

            if (isDuplication)
            {
                ExplainingScreen.ExplainFailScreen();
                ExplainingScreen.ExplainDuplicationExist("요청 도서");
                return false;
            }
            return true;
        }

        private Regex GetRegex(int type)
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
