using Library.Constants;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Controller
{
    public class EnvironmentSetUp
    {
        private static readonly string PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "환경변수.txt");
        public static readonly string LOG_PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "로그.txt");

        public static string[] GetId(int type)
        {
            StreamReader reader = new StreamReader(PATH, Encoding.UTF8);
            string[] results = null;
            string title = null;
            bool isRead = false;

            switch (type)
            {
                case (int)Enums.EnvironmentType.Db:
                    title = "DB Address";
                    break;
                case (int)Enums.EnvironmentType.Naver:
                    title = "NAVER API Client";
                    break;
            }

            string line = reader.ReadLine();
            while (line != null)
            {
                if (title.Equals(line))
                {
                    isRead = true;
                    line = reader.ReadLine();
                    continue;
                }

                if (isRead)
                {
                    results = line.Split(' ');
                    break;
                }
                line = reader.ReadLine();
            }

            return results;
        }
    }
}
