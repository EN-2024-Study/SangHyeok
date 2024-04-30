using Library.Constants;
using Library.Model;
using Library.Model.DtoVo;
using Library.View;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
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
        private AccountController accountController;
        private MenuSelector menuSelector;
        private InputManager inputManager;
        private BookController bookController;
        private Screen screen;

        public ApiController(MenuSelector menuSelector, BookController bookController, AccountController accountController) 
        {
            this.clientId = "YZUNzAPoiLUk2je0tW_2";
            this.clientPassword = "JDoqusR1uP";
            this.accountController = accountController;
            this.menuSelector = menuSelector;
            this.bookController = bookController;
            this.inputManager = new InputManager();
            this.screen = new Screen(); 
        }

        public void SearchNaver(int type)
        {
            bool isContinue = true;
            while(isContinue)
            {
                Console.Clear();
                Console.SetWindowSize(50, 5);
                ExplainingScreen.ExplainSearchNaver();

                string inputString = inputManager.LimitInputLength((int)Enums.InputType.NaverSearch, false);
                if (inputString == null || inputString == "")
                    return;
                StreamReader reader = ReadBookInfo(inputString);
                List<NaverBookVo> bookList = GetBookList(reader);
                screen.DrawNaverBooks(bookList);

                switch (type)
                {
                    case (int)Enums.ModeMenu.UserMode:
                        bookController.RequestBook(bookList);
                        break;
                    case (int)Enums.ModeMenu.ManagerMode:
                        ExplainingScreen.ExplainEcsKey(0);
                        menuSelector.WaitForEscKey();
                        break;
                }
            }
        }

        private StreamReader ReadBookInfo(string query)
        {
            string url = "https://openapi.naver.com/v1/search/book?query=" + query;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("X-Naver-Client-Id", clientId);
            request.Headers.Add("X-Naver-Client-Secret", clientPassword);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string status = response.StatusCode.ToString();

            if (status == "OK")
                return new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            return null;
        }

        private List<NaverBookVo> GetBookList(StreamReader reader)
        {
            JObject jsonData = JObject.Parse(reader.ReadToEnd());
            List<NaverBookVo> bookList = new List<NaverBookVo>();
            for(int i = 0; i < 3; i++)
            {
                var item = jsonData["items"][i];
                bookList.Add(new NaverBookVo(item["title"], item["author"], item["discount"], 
                    item["publisher"], item["pubdate"], item["isbn"], item["description"], accountController.LoggedInId));
            }
            return bookList;
        }
    }
}
