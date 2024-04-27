using Library.Utility;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class ManagerRepository 
    {
        private DbConnector db;

        public ManagerRepository()
        {
            this.db = DbConnector.Instance;
        }


        public ManagerVo GetManager()
        {
            ManagerVo manager = null;
            string selectQuery = string.Format("SELECT * FROM manager");
            try
            {
                db.MySql.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, db.MySql);
                MySqlDataReader table = command.ExecuteReader();

                while (table.Read())
                {
                    string id = table["id"].ToString();
                    string password = table["password"].ToString();
                    manager = new ManagerVo(id, password);
                    break;
                }
                db.MySql.Close();
            }
            catch (Exception exe)
            {
                Console.WriteLine(exe.Message);
            }

            return manager;
        }
    }
}
