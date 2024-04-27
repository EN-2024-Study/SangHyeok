using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class ManagerVo
    {
        private string id, password;

        public ManagerVo(string id, string password)
        {
            this.id = id;
            this.password = password;
        }

        public string Id
        {get { return id; }}

        public string Password
        {get { return password; }}
    }
}
