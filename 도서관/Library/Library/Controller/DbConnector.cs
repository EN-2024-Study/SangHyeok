using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

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

        //public void test()
        //{
        //    string[] a = new string[] {"4", "C언어 프로그래밍", "서상혁", "출판사",
        //        "4", "10000", "2024.01.01", "111111a 1111111111111", "소설"};


        //    string deleteQuery = string.Format("DELETE FROM book WHERE id={0}", 4);

        //    try
        //    {
        //        using (MySqlConnection mySql = new MySqlConnection(connectionAddress))
        //        {
        //            mySql.Open();

        //            MySqlCommand command = new MySqlCommand(deleteQuery, mySql);
        //            if (command.ExecuteNonQuery() == 1)
        //                Console.WriteLine("성공");
        //            else
        //                Console.WriteLine("실패");
        //        }
        //    }
        //    catch (Exception exe)
        //    {
        //        Console.WriteLine(exe.Message);
        //    }
        //}
    }
}
