using Library.Constants;
using Library.Controller;
using Library.Model.DtoVo;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mysqlx.Expect.Open.Types.Condition.Types;

namespace Library.Model.Dao
{
    public class LogDao
    {
        private DbConnector db;

        public LogDao()
        {
            this.db = DbConnector.Instance;
        }

        public List<LogDto> GetLogList()
        {
            List<LogDto> logList = new List<LogDto>();
            string selectQuery = QueryStrings.SELECT_LOG;

            db.MySql.Open();
            MySqlDataReader table = db.GetTable(selectQuery);
            
            while(table.Read())
            {
                string[] logInfo = new string[5];
                logInfo[0] = table[QueryStrings.FIELD_NUMBER].ToString();
                logInfo[1] = table[QueryStrings.FIELD_TIME].ToString();
                logInfo[2] = table[QueryStrings.FIELD_USER].ToString();
                logInfo[3] = table[QueryStrings.FIELD_INFO].ToString();
                logInfo[4] = table[QueryStrings.FIELD_PLAY].ToString();

                logList.Add(new LogDto(logInfo[0], logInfo[1], logInfo[2], logInfo[3], logInfo[4]));
            }

            db.MySql.Close();
            return logList;
        }

        public void AddLog(LogDto log)
        {
            string insertQuery = string.Format(QueryStrings.INSERT_LOG, 
                log.Time, log.User, log.Info, log.Play);
            db.SetData(insertQuery);
        }

        public void DeleteLog(string key) 
        {
            string deleteQuery = string.Format(QueryStrings.DELETE_LOG, key);
            db.SetData(deleteQuery);
        }
    }
}
