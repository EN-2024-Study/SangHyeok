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
        private DbConnector db;

        public UserRepository()
        {
            this.db = DbConnector.Instance;
        }

        public List<UserDto> GetUserList()
        {
            List<UserDto> userList = new List<UserDto>();
            string selectQuery = string.Format("SELECT * FROM user");
            try
            {
                db.MySql.Open();

                MySqlCommand command = new MySqlCommand(selectQuery, db.MySql);
                MySqlDataReader table = command.ExecuteReader();

                while (table.Read())
                {
                    string id = table["id"].ToString();
                    string password = table["password"].ToString();
                    string age = table["age"].ToString();
                    string phoneNumber = table["phonenumber"].ToString();
                    string address = table["address"].ToString();
                    userList.Add(new UserDto(id, password, age, phoneNumber, address));
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
    }
}