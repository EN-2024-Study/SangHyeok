using System;
using System.Collections.Generic;

namespace Library.Model
{
    public class PastAccountInfo
    {
        private string id;
        private string password;
        private string name;
        private int age;
        private string phoneNumber;
        private string address;
        private List<PastBookInfo> RentalBooks;


        public PastAccountInfo()
        {
            id = null;
            password = null;
            name = null;
            age = 0;
            phoneNumber = null;
            address = null;
            RentalBooks = new List<PastBookInfo>();
        }

        public PastAccountInfo(string id, string password)
        {
            RentalBooks = new List<PastBookInfo>();
            this.id = id;
            this.password = password;
        }

        public PastAccountInfo(string id, string password, string name, 
            int age, string phoneNumber, string address) : this(id, password)
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
