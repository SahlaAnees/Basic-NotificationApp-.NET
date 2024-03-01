using System;

namespace Project.Entity
{
    class User
    {
        private int id;
        private string username;
        private string email;
        private string phoneNumber;

        public User(int id,string username, string email, string phoneNumber)
        {
            this.id = id;
            this.username = username;
            this.email = email;
            this.phoneNumber = phoneNumber;
        }

        public int ID
        {
            get { return this.id; }
            set { this.id = value; }
        }
        public string Username
        {
            get { return this.username; }
            set { this.username = value; }
        }

        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }

        public string PhoneNumber
        {
            get { return this.phoneNumber; }
            set { this.phoneNumber = value; }
        }
    }

}


