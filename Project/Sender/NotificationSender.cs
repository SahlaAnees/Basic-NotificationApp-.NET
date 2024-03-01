using Project.Entity;
using Project.Service;
using System;
using System.Collections;
using System.Collections.Generic;


namespace Project.Sender
{
    internal class NotificationSender
    {
        private List<INotificationService> notificationServices = new List<INotificationService>();

        public void addNotificationService(INotificationService notificationService) {
            notificationServices.Add(notificationService);
        }

        public void sendNotification(User user, string message) {
            foreach (INotificationService service in notificationServices) {
                service.sendNotification(user, message);
            }
        }
    }
}
