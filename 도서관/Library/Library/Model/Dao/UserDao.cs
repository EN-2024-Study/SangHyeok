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
using Library.Constants;
using Library.Controller;

namespace Library.Model
{
    public class UserDao    
    {
        private DbConnector db;

        public UserDao()
        {
            this.db = DbConnector.Instance;
        }

        public List<UserDto> GetUserList()
        {
            List<UserDto> userList = new List<UserDto>();
            string selectQuery = QueryStrings.SELECT_USER;
            
            db.MySql.Open();
            MySqlCommand command = new MySqlCommand(selectQuery, db.MySql);
            MySqlDataReader table = command.ExecuteReader();

            while (table.Read())
            {
                string id = table[QueryStrings.FIELD_ID].ToString();
                string password = table[QueryStrings.FIELD_PASSWORD].ToString();
                string age = table[QueryStrings.FIELD_AGE].ToString();
                string phoneNumber = table[QueryStrings.FIELD_PHONENUMBER].ToString();
                string address = table[QueryStrings.FIELD_ADDRESS].ToString();
                userList.Add(new UserDto(id, password, age, phoneNumber, address));
            }
            db.MySql.Close();
          
            return userList;
        }

        public void AddUser(UserDto user)
        {
            string insertQuery = string.Format(QueryStrings.INSERT_USER,
              user.Id, user.Password, user.Age, user.PhoneNumber, user.Address);
            db.SetData(insertQuery);
        }

        public void RemoveUser(string key)
        {
            string deleteQuery = string.Format(QueryStrings.DELETE_USER, key);
            db.SetData(deleteQuery);
        }

        public void UpdateUser(string key, string updateString, string value)
        {
            string updateQuery = string.Format(QueryStrings.UPDATE_USER, key, updateString, value);
            db.SetData(updateQuery);
        }
    }
}