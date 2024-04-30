using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model.DtoVo
{
    public class LogDto
    {
        private string number, time, user, info, play;

        public LogDto(string number, string time, string user, string info, string play)
        {
            this.number = number;
            this.time = time;
            this.user = user;
            this.info = info;
            this.play = play;
        }

        public string Number
        { 
            get { return number; }
            set { number = value; }
        }

        public string Time
        {
            get { return time; }
            set { time = value; }
        }

        public string User
        {
            get { return user; }
            set { user = value; }
        }

        public string Info
        {
            get { return info; }
            set { info = value; }
        }

        public string Play
        {
            get { return play; }
            set { play = value; }
        }
    }
}
