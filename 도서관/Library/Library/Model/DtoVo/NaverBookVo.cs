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
        private JToken title, author, discount, publisher, pubdate, isbn, description;

        public NaverBookVo(JToken title, JToken author, JToken discount,
            JToken publisher, JToken pubdate, JToken isbn, JToken description)
        {
            this.title = title;
            this.author = author;
            this.discount = discount;
            this.publisher = publisher;
            this.pubdate = pubdate;
            this.isbn = isbn;
            this.description = description;
        }

        public JToken Title { get { return title; } }
        public JToken Author { get { return author; } }
        public JToken Discount { get { return discount; } }
        public JToken Publisher { get { return publisher; } }
        public JToken Pubdate { get { return pubdate; } }
        public JToken Isbn { get { return isbn; } }
        public JToken Description { get { return description; } }
    }
}
