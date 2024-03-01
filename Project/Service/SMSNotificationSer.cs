using Project.Entity;
using System;

using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Project.Service
{
    internal class SMSNotificationSer : INotificationService
    {
        private readonly string twilioPhoneNumber;

        public SMSNotificationSer(string twilioAccountSid, string twilioAuthToken, string twilioPhoneNumber) { 
            this.twilioPhoneNumber = twilioPhoneNumber;
            TwilioClient.Init(twilioAccountSid,twilioAuthToken);
        }

        public void sendNotification(User user, string message) {
            MessageResource.Create(
                body: message,
                from: new Twilio.Types.PhoneNumber(twilioPhoneNumber),
                to: new Twilio.Types.PhoneNumber(user.PhoneNumber)
                );

            Console.WriteLine("SMS successfully sent");
        }
    }
}
