using Project.Entity;
using Project.Handler;
using Project.Sender;
using Project.Service;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;



namespace Project
{
    internal class Program
    {
        static void Main(string[] args)
        {

            DatabaseHandler handler = new DatabaseHandler();

            List<User> users = handler.GetUsers();

            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            string emailUsername = configuration.GetSection("EmailSettings:Username").Value;
            string emailPassword = configuration.GetSection("EmailSettings:Password").Value;

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new System.Net.NetworkCredential(emailUsername,emailPassword),
                EnableSsl = true,
            };

            String twilioAccountSid = configuration.GetSection("TwilioSettings:AccountSid").Value; 
            String twilioAuthToken = configuration.GetSection("TwilioSettings:AuthToken").Value;
            String twilioPhoneNumber = configuration.GetSection("TwilioSettings:PhoneNumber").Value;

            foreach (User user in users)
            {
                Console.Write("Select notification method (1 for Email, 2 for SMS, 3 for Both): ");
                int.TryParse(Console.ReadLine(), out int choice);

                string emailMessage = "Hi " + user.Username + ", this is an email notification...!";
                string textMessage = "Hi " + user.Username + ", this is an sms notification...!";

                NotificationSender sender = new NotificationSender();

                if (choice == 1 || choice == 3)
                {
                    EmailNotificationService emailNotificationService = new EmailNotificationService(emailUsername, emailPassword, smtpClient);
                    sender.addNotificationService(emailNotificationService);
                    sender.sendNotification(user, emailMessage);
                }
                if (choice == 2 || choice == 3)
                {
                    SMSNotificationSer smsNotificationService = new SMSNotificationSer(twilioAccountSid, twilioAuthToken, twilioPhoneNumber);
                    sender.addNotificationService(smsNotificationService);
                    sender.sendNotification(user, textMessage);

                }
            }
          //smtpClient.Dispose();


        }
    }
}
