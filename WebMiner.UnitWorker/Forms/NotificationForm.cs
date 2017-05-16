using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebMiner.UnitWorker.Forms
{
    partial class NotificationForm : Form, INotificationSubscriber
    {
        public NotificationForm()
        {
            InitializeComponent();
            NotificationBus.Instance.Subscribe(this);
        }

        public void OnNotification(Notification notification)
        {
            MethodInvoker method = (MethodInvoker)delegate
            {
                textBox1.AppendText("notification" + Environment.NewLine);
            };

            
            textBox1.Invoke(method);
          
        }

        private void NotificationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            NotificationBus.Instance.Unsubscribe(this);
        }
    }
}
