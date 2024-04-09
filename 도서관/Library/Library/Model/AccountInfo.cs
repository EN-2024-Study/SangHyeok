using System;
using System.Collections.Generic;

namespace Library.Model
{
    public class AccountInfo
    {
        private int id;
        private int password;
        private string name;
        private int age;
        private string phoneNumber;
        private string address;
        private List<BookInfo> RentalBooks;

        public AccountInfo(int id, int password)
        {
            RentalBooks = new List<BookInfo>();
            this.id = id;
            this.password = password;
        }

        public AccountInfo(int id, int password, string name, 
            int age, string phoneNumber, string address) : this(id, password)
        {
            this.name = name;
            this.age = age;
            this.phoneNumber = phoneNumber;
            this.address = address;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
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
