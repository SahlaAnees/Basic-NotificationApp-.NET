using Project.Entity;
using System;

namespace Project.Service
{
    internal interface INotificationService
    {
        void sendNotification(User username, String message);
    }
}
