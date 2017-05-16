using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMiner.UnitWorker
{
    class BackgroudUnitWorker
    {
        private BackgroundWorker worker;

        public BackgroudUnitWorker()
        {
            worker = new BackgroundWorker();
            worker.DoWork += DoWork;
        }

        private void DoWork(object sender, DoWorkEventArgs e)
        {
            for(int i = 0; i < 1000000; i++)
            {
                NotificationBus.Instance.Publish(new Notification { });
                System.Threading.Thread.Sleep(100);
            }
        }

        public void Start()
        {
            worker.RunWorkerAsync();
            NotificationBus.Instance.Publish(new Notification());
        }

        public void Stop()
        {
            if(worker.IsBusy)
                worker.CancelAsync();

            NotificationBus.Instance.Publish(new Notification());
        }
    }
}
