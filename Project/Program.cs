using Project.Entity;
using Project.Handler;
using Project.Sender;
using Project.Service;
using System;
using System.Collections.Generic;
using System.Net.Mail;



namespace Project
{
    internal class Program
    {
        static void Main(string[] args)
        {

            DatabaseHandler handler = new DatabaseHandler();

            List<User> users = handler.GetUsers();

            string emailUsername = "fathi.sahla97@gmail.com";
            string emailPassword = "vwxiknbtxevugelv";

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new System.Net.NetworkCredential(emailUsername,emailPassword),
                EnableSsl = true,
            };

            String twilioAccountSid = "ACd3f5805f297e51800a27f9d67d73987a";
            String twilioAuthToken = "e23778ae0543141a50d0be2d325092f3";
            String twilioPhoneNumber = "+16788905449";

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
          //  smtpClient.Dispose();


        }
    }
}
