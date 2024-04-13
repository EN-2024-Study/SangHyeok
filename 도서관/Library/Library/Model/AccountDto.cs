using System;
using System.Collections.Generic;

namespace Library.Model
{
    public class AccountDto
    {
        private string id;
        private string password;
        private string name;
        private string age;
        private string phoneNumber;
        private string address;

        public AccountDto()
        {
            this.id = null;
            this.password = null;
            this.name = null;
            this.age = null;
            this.phoneNumber = null;
            this.address = null;
        }

        public AccountDto(string id, string password) : this()
        {
            this.id = id;
            this.password = password;
        }

        public AccountDto(string id, string password, string name, 
            string age, string phoneNumber, string address) : this(id, password)
        {
            this.name = name;
            this.age = age;
            this.phoneNumber = phoneNumber;
            this.address = address;
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

        public string Name
        {
            get { return name; }
            set { name = value; }
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
