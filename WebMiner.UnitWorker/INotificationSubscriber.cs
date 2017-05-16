using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMiner.UnitWorker
{
    interface INotificationSubscriber
    {
        void OnNotification(Notification notification);
    }
}
