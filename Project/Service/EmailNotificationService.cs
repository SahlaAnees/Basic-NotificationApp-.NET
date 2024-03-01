using Project.Entity;
using System;

using System.Net;
using System.Net.Mail;


namespace Project.Service
{
    internal class EmailNotificationService : INotificationService
    {
        private readonly string emailUsername;
        private readonly string emailPassword;

        private readonly SmtpClient smtpClient;

        public EmailNotificationService(string emailUsername, string emailPassword, SmtpClient smtpClient) {
            this.emailUsername = emailUsername;
            this.emailPassword = emailPassword;
            this.smtpClient = smtpClient ?? throw new ArgumentNullException(nameof(smtpClient));
                
            }



        public void sendNotification(User user, string message)
        {
            try {
                var emailMessage = new MailMessage
                {
                    From = new MailAddress(emailUsername),
                    Body = message,
                    IsBodyHtml = false
                };

                emailMessage.To.Add(user.Email);
                smtpClient.Send(emailMessage);
                Console.WriteLine($"Email successfully sent to {emailMessage.To[0].Address}");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error in sending email: {ex.Message}");
            }
        }

        
    }
}
