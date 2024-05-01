using Library.Constants;
using Library.Controller.ScreenController;
using Library.Model.DtoVo;
using Library.View;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Library.Controller
{
    public class ApiController
    {
        string[] ids;
        private Account accountController;
        private MenuSelector menuSelector;
        private InputManager inputManager;
        private Book bookController;
        private LogManager logManager;
        private Screen screen;

        public ApiController(MenuSelector menuSelector, Book bookController, Account accountController) 
        {
            this.ids = EnvironmentSetUp.GetId((int)Enums.EnvironmentType.Naver);
            this.accountController = accountController;
            this.menuSelector = menuSelector;
            this.bookController = bookController;
            this.inputManager = new InputManager();
            this.logManager = new LogManager(menuSelector);
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
                        logManager.AddLog(accountController.LoggedInId, LogStrings.BOOK_NAVERSEARCH, LogStrings.BLANK);
                        bookController.RequestBook(bookList);
                        break;
                    case (int)Enums.ModeMenu.ManagerMode:
                        logManager.AddLog(LogStrings.MANAGER, LogStrings.BOOK_NAVERSEARCH, LogStrings.BLANK);
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
            request.Headers.Add("X-Naver-Client-Id", ids[(int)Enums.NaverType.Id]);
            request.Headers.Add("X-Naver-Client-Secret", ids[(int)Enums.NaverType.Password]);
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
