using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Library.View;

namespace Library.Utility
{
    public class DbConnector    // singleton
    {
        private static DbConnector instance;
        private string connectionAddress;
        private MySqlConnection mySql;

        private DbConnector()
        {
            string dbServer = "localhost";
            int dbPort = 3306;
            string dbName = "library";
            string dbId = "root";
            string dbPassword = "0000";
            this.connectionAddress = string.Format("Server={0};Port={1};Database={2};Uid={3};Pwd={4}", dbServer, dbPort, dbName, dbId, dbPassword);
            this.mySql = new MySqlConnection(ConnectionAddress);
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

        public string ConnectionAddress
        { get { return connectionAddress; } }

        public void SetData(string query)
        {
            try
            {
                mySql.Open();

                MySqlCommand command = new MySqlCommand(query, mySql);
                if (command.ExecuteNonQuery() == 1)
                    ExplainingScreen.ExplainSuccessScreen();
                mySql.Close();
            }
            catch (Exception exe)
            {
                Console.WriteLine(exe.Message);
            }
        }

        public MySqlConnection MySql
        { get { return mySql; } }
    }
}
