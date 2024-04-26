using Library.Utility;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Mysqlx.Expect.Open.Types.Condition.Types;

namespace Library.Model
{
    public class UserRepository    
    {
        private static UserRepository instance;

        private DbConnector db;

        private UserRepository()
        {
            this.db = DbConnector.Instance;
        }

        public static UserRepository Instance
        {
            get
            {
                if (instance == null)
                    instance = new UserRepository();
                return instance;
            }
        }

        public List<UserDto> GetUserList()
        {
            List<UserDto> userList = null;
            string selectQuery = string.Format("SELECT * FROM user");
            try
            {
                using (MySqlConnection mySql = new MySqlConnection(db.ConnectionAddress))
                {
                    mySql.Open();

                    MySqlCommand command = new MySqlCommand(selectQuery, mySql);
                    MySqlDataReader table = command.ExecuteReader();

                    while (table.Read())
                    {
                        string id = table["id"].ToString();
                        string password = table["password"].ToString();
                        string age = table["age"].ToString();
                        string phoneNumber = table["phonenumber"].ToString();
                        string address = table["address"].ToString();
                        userList.Add(new UserDto(id, password, age, phoneNumber, address));
                        break;
                    }
                }
            }
            catch (Exception exe)
            {
                Console.WriteLine(exe.Message);
            }

            return userList;
        }

        public void AddUser(UserDto user)
        {
            string insertQuery = string.Format("INSERT INTO user VALUES('{0}', '{1}', '{2}', '{3}', '{4}')",
              user.Id, user.Password, user.Age, user.PhoneNumber, user.Address);
            db.SetData(insertQuery);
        }

        public void RemoveUser(string key)
        {
            string deleteQuery = string.Format("DELETE FROM user WHERE id = {0}", key);
            db.SetData(deleteQuery);
        }

        public void UpdateUser(string key, string updateString, string value)
        {
            string updateQuery = string.Format("UPDATE user SET {1} = '{2}' WHERE id = {0}", key, updateString, value);
            db.SetData(updateQuery);
        }

        public void AddReturnBook(BookDto bookDto)
        { userDtoList[userIndex].AddReturnBook(bookDto); }

        public List<BookDto> GetReturnBookList()
        { return userDtoList[userIndex].GetReturnBookList(); }
    }
}