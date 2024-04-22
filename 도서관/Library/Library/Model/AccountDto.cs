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

        public AccountDto(string password) : this()
        {
            this.password = password;
        }

        public AccountDto(string id, string password) : this(password)
        {
            this.id = id;
        }

        public AccountDto(string id, string password, string name) : this(id, password)
        {
            this.name = name;
        }

        public AccountDto(string id, string password, string name, string age) : this(id, password, name)
        {
            this.age = age;
        }

        public AccountDto(string id, string password, string name, string age, string phoneNumber) : this(id, password, name, age)
        {
            this.phoneNumber = phoneNumber;
        }

        public AccountDto(string id, string password, string name, 
            string age, string phoneNumber, string address) : this(id, password, name, age, phoneNumber)
        {
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
