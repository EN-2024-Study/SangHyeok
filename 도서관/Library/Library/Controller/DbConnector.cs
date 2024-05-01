using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Library.View;
using System.Management;
using Library.Constants;

namespace Library.Controller
{
    public class DbConnector    // singleton
    {
        private static DbConnector instance;
        private MySqlConnection mySql;

        private DbConnector()
        {
            string[] ids = EnvironmentSetUp.GetId((int)Enums.EnvironmentType.Db);
            string connectionAddress = string.Format("Server={0};Port={1};Database={2};Uid={3};Pwd={4}", 
                ids[(int)Enums.DbType.Server], ids[(int)Enums.DbType.Port], ids[(int)Enums.DbType.Name], ids[(int)Enums.DbType.Id], ids[(int)Enums.DbType.Password]);
            
            this.mySql = new MySqlConnection(connectionAddress);
        }

        public static DbConnector Instance
        {
            get
            {
                if (instance == null)
                    instance = new DbConnector();
                return instance;
            }
        }

        public void SetData(string query)
        {
            try
            {
                mySql.Open();

                MySqlCommand command = new MySqlCommand(query, mySql);
                if (command.ExecuteNonQuery() == 1) 
                {
                    //ExplainingScreen.ExplainSuccessScreen();
                }
                mySql.Close();
            }
            catch (Exception exe)
            {
                Console.WriteLine(exe.Message);
            }
        }

        public MySqlDataReader GetTable(string query)
        {
            MySqlCommand command = new MySqlCommand(query, mySql);
            MySqlDataReader table = command.ExecuteReader();
            return table;
        }

        public MySqlConnection MySql
        { get { return mySql; } }
    }
}
