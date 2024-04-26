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
    public class DbConnector
    {
        private static DbConnector instance;
        private string dbServer;
        private int dbPort;
        private string dbName;
        private string dbId;
        private string dbPassword;
        private string connectionAddress;

        private DbConnector()
        {
            dbServer = "localhost";
            dbPort = 3306;
            dbName = "library";
            dbId = "root";
            dbPassword = "0000";
            connectionAddress = string.Format("Server={0};Port={1};Database={2};Uid={3};Pwd={4}", dbServer, dbPort, dbName, dbId, dbPassword);
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
                using (MySqlConnection mySql = new MySqlConnection(ConnectionAddress))
                {
                    mySql.Open();

                    MySqlCommand command = new MySqlCommand(query, mySql);
                    if (command.ExecuteNonQuery() == 1)
                        ExplainingScreen.ExplainSuccessScreen();
                }
            }
            catch (Exception exe)
            {
                Console.WriteLine(exe.Message);
            }
        }
    }
}
