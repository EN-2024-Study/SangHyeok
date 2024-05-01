using Library.Constants;
using Library.Controller;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class ManagerDao 
    {
        private DbConnector db;

        public ManagerDao()
        {
            this.db = DbConnector.Instance;
        }


        public ManagerVo GetManager()
        {
            ManagerVo manager = null;
            string selectQuery = QueryStrings.SELECT_MANAGER;

            if (db.MySql.State == System.Data.ConnectionState.Closed)
                db.MySql.Open();
            MySqlDataReader table = db.GetTable(selectQuery);

            while (table.Read())
            {
                string id = table[QueryStrings.FIELD_ID].ToString();
                string password = table[QueryStrings.FIELD_PASSWORD].ToString();
                manager = new ManagerVo(id, password);
                break;
            }
            db.MySql.Close();

            return manager;
        }
    }
}
