using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Project.Entity;


namespace Project.Handler
{
    internal class DatabaseHandler
    {
        private readonly string connectionString = "Server=localhost;Database=notificationapp;User=notifyappuser;Password=userNotify123;";

        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string sql = "SELECT * FROM user";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        User user = new User(
                            reader.GetInt32("UserID"),
                            reader.GetString("UserName"),
                            reader.GetString("UserEmail"),
                            reader.GetString("UserPhoneNo")
                        );

                        users.Add(user);
                    }
                }
            }

            return users;
        }

    }
}
