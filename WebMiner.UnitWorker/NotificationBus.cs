using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMiner.UnitWorker
{
    class NotificationBus
    {
        private static object createBusSync = new object();
        private static object busSync = new object();
        private static NotificationBus instance;
        private NotificationBus()
        {

        }

        public static NotificationBus Instance
        {
            get
            {
                if (instance == null)
                    lock (createBusSync)
                        if (instance == null)
                            instance = new NotificationBus();

                return instance;
            }
        }
        
       

        public void Publish(Notification notification)
        {
            lock (busSync)
            {
                foreach (var subscriber in subscribers)
                    subscriber.OnNotification(notification);
            }
        }

        private List<INotificationSubscriber> subscribers = new List<INotificationSubscriber>();
        public void Subscribe(INotificationSubscriber subscriber)
        {
            lock (busSync)
            {
                if (!subscribers.Contains(subscriber))
                    subscribers.Add(subscriber);
            }
        }

        public void Unsubscribe(INotificationSubscriber subscriber)
        {
            lock (busSync)
            {
                if (subscribers.Contains(subscriber))
                    subscribers.Remove(subscriber);
            }
        }
    }

}
