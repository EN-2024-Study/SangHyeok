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
        DbConnector db;

        public ManagerRepository()
        {
            db = DbConnector.Instance;
        }


        public ManagerVo GetManager()
        {
            ManagerVo manager = null;
            string selectQuery = string.Format("SELECT * FROM manager");
            string id, password;
            try
            {
                using (MySqlConnection mySql = new MySqlConnection(db.ConnectionAddress))
                {
                    mySql.Open();

                    MySqlCommand command = new MySqlCommand(selectQuery, mySql);
                    MySqlDataReader table = command.ExecuteReader();

                    while (table.Read())
                    {
                        id = table["id"].ToString();
                        password = table["password"].ToString();
                        manager = new ManagerVo(id, password);
                        break;
                    }
                }
            }
            catch (Exception exe)
            {
                Console.WriteLine(exe.Message);
            }

            return manager;
        }
    }
}
