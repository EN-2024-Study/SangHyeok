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
        //private static EnvironmentSetUp instance;
        private static readonly string PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "환경변수.txt");

        public static string[] GetDbAddress(int type)
        {
            string[] reader = File.ReadAllLines(PATH, Encoding.UTF8);
            string[] results = null;
            string title = null;
            bool isRead = false;

            switch (type)
            {
                case (int)Enums.EnvironmentType.Db:
                    title = "DB Address";
                    results = new string[5];
                    break;
                case (int)Enums.EnvironmentType.Naver:
                    title = "NAVER API Client";
                    results = new string[2];
                    break;
            }

            foreach(string item in reader)
            {
                if (item.Equals(title))
                    isRead = true;

                if (isRead)
                {
                    results = item.Split(' ');
                    break;
                }
            }

            return results;
        }


        //private EnvironmentSetUp()
        //{

        //}

        //public static EnvironmentSetUp Instance
        //{
        //    get
        //    {
        //        if (instance == null)
        //            instance = new EnvironmentSetUp();
        //        return instance;
        //    }
        //}
    }
}
