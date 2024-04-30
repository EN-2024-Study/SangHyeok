using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Constants
{
    public class QueryStrings
    {
        public static readonly string SELECT_BOOK = "SELECT * FROM book";

        public static readonly string SELECT_RENTALBOOK = "SELECT * FROM rentalbook";

        public static readonly string SELECT_RETURNBOOK = "SELECT * FROM returnbook";

        public static readonly string SELECT_MANAGER = "SELECT * FROM manager";

        public static readonly string SELECT_USER = "SELECT * FROM user";

        public static readonly string SELECT_REQUESTBOOK = "SELECT * FROM request_book";

        public static readonly string INSERT_USER = "INSERT INTO user VALUES('{0}', '{1}', '{2}', '{3}', '{4}')";

        public static readonly string INSERT_BOOK = "INSERT INTO book VALUES( null, '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')";

        public static readonly string INSERT_RENTALBOOK = "INSERT INTO rentalbook VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}')";

        public static readonly string INSERT_RETURNBOOK = "INSERT INTO returnbook VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}')";

        public static readonly string INSERT_REQUESTBOOK = "INSERT INTO request_book VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')";

        public static readonly string UPDATE_USER = "UPDATE user SET {1} = '{2}' WHERE id = {0}";

        public static readonly string UPDATE_BOOK = "UPDATE book SET {1} = '{2}' WHERE id = {0}";

        public static readonly string UPDATE_BOOKCOUNT = "UPDATE book SET count = {1} WHERE id = {0}";

        public static readonly string UPDATE_BOOKCOUNT_INCREASE = "UPDATE book SET count = count + 1 WHERE id = {0}";

        public static readonly string UPDATE_BOOKCOUNT_DESCEND = "UPDATE book SET count = count - 1 WHERE id = {0}";

        public static readonly string DELETE_USER = "DELETE FROM user WHERE id = {0}";

        public static readonly string DELETE_BOOK = "DELETE FROM book WHERE id = {0}";

        public static readonly string DELETE_RENTALBOOK = "DELETE FROM rentalbook WHERE id = {0}";

        public static readonly string FIELD_RENTALTIME = "rentaltime";

        public static readonly string FIELD_RETURNTIME = "returntime";

        public static readonly string FIELD_USERID = "userid";

        public static readonly string FIELD_ID = "id";

        public static readonly string FIELD_PASSWORD = "password";

        public static readonly string FIELD_AGE = "age";

        public static readonly string FIELD_PHONENUMBER = "phonenumber";

        public static readonly string FIELD_ADDRESS = "address";

        public static readonly string FIELD_TITLE = "title";

        public static readonly string FIELD_WRITER = "writer";

        public static readonly string FIELD_PUBLISHER = "publisher";

        public static readonly string FIELD_COUNT = "count";

        public static readonly string FIELD_PRICE = "price";

        public static readonly string FIELD_RELEASEDATE = "releasedate";

        public static readonly string FIELD_ISBN = "iSBN";

        public static readonly string FIELD_INFO = "info";

    }
}
