using Library.Model;
using Library.View;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Library.Controller
{
    public class ApiController
    {
        private readonly string clientId, clientPassword;
        private List<BookDto> bookList;
        private Screen screen;

        public ApiController() 
        {
            this.clientId = "YZUNzAPoiLUk2je0tW_2";
            this.clientPassword = "JDoqusR1uP";
            this.screen = new Screen(); 
        }

        public void SearchNaver()
        {
            SetWindow();
            string inputString = Console.ReadLine();
            Console.CursorVisible = false;
            bookList = new List<BookDto>();
            SetBookList(inputString);

            Console.SetWindowSize(80, 40);
            screen.DrawBookInfo(5, bookList[0]);
            Console.ReadLine();
        }

        private void SetBookList(string query)
        {
            string url = "https://openapi.naver.com/v1/search/book?query=" + query;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("X-Naver-Client-Id", clientId);
            request.Headers.Add("X-Naver-Client-Secret", clientPassword);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string status = response.StatusCode.ToString();

            if (status == "OK")
                ReadBookInfo(new StreamReader(response.GetResponseStream(), Encoding.UTF8));
        }

        private void ReadBookInfo(StreamReader reader)
        {
            List<string> titles = new List<string>();
            List<string> authors = new List<string>();
            List<string> discounts = new List<string>();
            List<string> publishers = new List<string>();
            List<string> pubdates = new List<string>();
            List<string> isbns = new List<string>();
            List<string> descriptions = new List<string>();

            while (reader.ReadLine() != null)
            {
                string line = reader.ReadLine();

                if (titles.Count == 3 && titles.Count == authors.Count && titles.Count == discounts.Count && titles.Count == publishers.Count && titles.Count == pubdates.Count && titles.Count == isbns.Count && titles.Count == descriptions.Count)
                    break;
                else if (line.Contains("title"))
                    titles.Add(SplitString(line));
                else if (line.Contains("author"))
                    authors.Add(SplitString(line));
                else if (line.Contains("discount"))
                    discounts.Add(SplitString(line));
                else if (line.Contains("publisher"))
                    publishers.Add(SplitString(line));
                else if (line.Contains("pubdate"))
                    pubdates.Add(SplitString(line));
                else if (line.Contains("isbn"))
                    isbns.Add(SplitString(line));
                else if (line.Contains("description"))
                    descriptions.Add(SplitString(line));
            }

            for (int i = 0; i < 3; i++)
                bookList.Add(new BookDto("쓰레기값", titles[i], authors[i],
                    publishers[i], 1, discounts[i], pubdates[i], isbns[i], descriptions[i]));
        }

        private string SplitString(string line)
        {
            string[] result = line.Split(new char[] { ':' })[1].Split(new char[] { '"' });
            return result[1];
        }

        private void SetWindow()
        {
            Console.Clear();
            Console.SetWindowSize(40, 5);
            ExplainingScreen.ExplainSearchNaver();
            Console.SetCursorPosition(12, 0);
            Console.CursorVisible = true;
        }
    }
}
