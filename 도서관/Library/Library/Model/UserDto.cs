using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class UserDto
    {
        private string id, password, age, phoneNumber, address;

        public UserDto(string id, string password)
        {
            this.id = id;
            this.password = password;
            this.age = null;
            this.phoneNumber = null;
            this.address = null;
        }

        public string Id
        {
            get { return id; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
    }
}
