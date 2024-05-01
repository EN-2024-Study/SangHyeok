using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Constants
{
    public class RegularStrings
    {
        public static readonly string ID = @"^[0-9]{8}$";

        public static readonly string PASSWORD = @"^[0-9]{4}$";

        public static readonly string AGE = @"^[0-9]{1,2}$";

        public static readonly string PHONENUMBER = @"^010-[0-9]{4}-[0-9]{4}$";

        public static readonly string ADDRESS1 = @"^[가-힣]{1,6}[도시]{1} [가-힣]{1,6}[시구]{1}$";

        public static readonly string ADDRESS2 = @"^[가-힣]{1,6}[도시]{1} [가-힣]{1,2}[구]{1} [가-힣]{1,6}[동]{1}$";

        public static readonly string WRITER = @"^[a-zA-Z가-힣]{1,10}$";

        public static readonly string COUNT = @"^[0-9]{1,4}$";

        public static readonly string RELEASEDATE = @"^20[0-9]{2}-[0-9]{1,2}-[0-9]{1,2}$";

        public static readonly string ISBN = @"^[0-9]{13}$";
    }
}
