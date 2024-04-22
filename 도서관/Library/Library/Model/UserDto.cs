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

        public UserDto() { }

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
            set { id = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Age
        {
            get { return age; }
            set { age = value; }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }
    }
}
