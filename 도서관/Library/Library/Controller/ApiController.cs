using Library.Constants;
using Library.Model;
using Library.Model.DtoVo;
using Library.View;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Library.Controller
{
    public class ApiController
    {
        private readonly string clientId, clientPassword;
        private List<NaverBookVo> bookList;
        private MenuSelector menuSelector;
        private Screen screen;

        public ApiController(MenuSelector menuSelector) 
        {
            this.clientId = "YZUNzAPoiLUk2je0tW_2";
            this.clientPassword = "JDoqusR1uP";
            this.bookList = new List<NaverBookVo>();
            this.menuSelector = menuSelector;
            this.screen = new Screen(); 
        }

        public void SearchNaver(int type)
        {
            SetWindow();
            string inputString = Console.ReadLine();
            Console.CursorVisible = false;
            ReadBookInfo(inputString);

            Console.SetWindowSize(80, 40);
            screen.DrawNaverBooks(bookList);

            switch(type)
            {
                case (int)Enums.ModeMenu.UserMode:

                    break;
                case (int)Enums.ModeMenu.ManagerMode:
                    menuSelector.WaitForEscKey();
                    break;
            }
        }

        private void ReadBookInfo(string query)
        {
            string url = "https://openapi.naver.com/v1/search/book?query=" + query;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("X-Naver-Client-Id", clientId);
            request.Headers.Add("X-Naver-Client-Secret", clientPassword);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string status = response.StatusCode.ToString();

            if (status == "OK")
                SetBookList(new StreamReader(response.GetResponseStream(), Encoding.UTF8));
        }

        private void SetBookList(StreamReader reader)
        {
            JObject jsonData = JObject.Parse(reader.ReadToEnd());
            bookList = new List<NaverBookVo>();
            for(int i = 0; i < 3; i++)
            {
                var item = jsonData["items"][i] ;
                bookList.Add(new NaverBookVo(item["title"], item["author"], item["discount"], 
                    item["publisher"], item["pubdate"], item["isbn"], item["description"]));
            }

        }

        private void SetWindow()
        {
            Console.Clear();
            Console.SetWindowSize(50, 5);
            ExplainingScreen.ExplainSearchNaver();
            Console.SetCursorPosition(12, 0);
            Console.CursorVisible = true;
        }
    }
}
