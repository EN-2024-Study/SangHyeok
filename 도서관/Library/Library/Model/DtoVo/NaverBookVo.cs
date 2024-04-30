using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model.DtoVo
{
    public class NaverBookVo
    {
        private JToken title, writer, price, publisher, releaseDate, iSBN, info;
        private string userid;

        public NaverBookVo(JToken title, JToken author, JToken discount,
            JToken publisher, JToken pubdate, JToken isbn, JToken description, string userid)
        {
            this.title = title;
            this.writer = author;
            this.price = discount;
            this.publisher = publisher;
            this.releaseDate = pubdate;
            this.iSBN = isbn;
            this.info = description;
            this.userid = userid;
        }

        public JToken Title { get { return title; } }
        public JToken Writer { get { return writer; } }
        public JToken Price { get { return price; } }
        public JToken Publisher { get { return publisher; } }
        public JToken ReleaseDate { get { return releaseDate; } }
        public JToken ISBN { get { return iSBN; } }
        public JToken Info { get { return info; } }
        public JToken Userid { get { return userid; } }

    }
}
