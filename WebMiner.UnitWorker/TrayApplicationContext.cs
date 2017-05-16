using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebMiner.UnitWorker.Forms;
using WebMiner.UnitWorker.Properties;

namespace WebMiner.UnitWorker
{
    class TrayApplicationContext : ApplicationContext
    {
        private NotifyIcon trayIcon;
        private BackgroudUnitWorker unitWorker;
        private NotificationForm notificationForm;

        public TrayApplicationContext()
        {
            // Initialize Tray Icon
            trayIcon = new NotifyIcon()
            {
                Icon = Resources.ApplicationIcon,
                ContextMenu = new ContextMenu(new MenuItem[] 
                {
                    new MenuItem("Show notification", ShowNotification),
                    new MenuItem("Exit", Exit)
                }),
                Visible = true,                
             };

            trayIcon.BalloonTipClosed += (sender, e) =>
            {
                // to force hide icon on close
                var thisIcon = (NotifyIcon)sender;
                thisIcon.Visible = false;
                thisIcon.Dispose();
            };

            unitWorker = new BackgroudUnitWorker();
            unitWorker.Start();
        }

        private void ShowNotification(object sender, EventArgs e)
        {
            if (notificationForm == null)
            {
                notificationForm = new NotificationForm();
                notificationForm.FormClosed += NotificationFormClosed;
            }
            
            notificationForm.Show();
            notificationForm.BringToFront();
        }

        private void NotificationFormClosed(object sender, FormClosedEventArgs e)
        {
            notificationForm.Dispose();
            notificationForm = null;
        }

        void Exit(object sender, EventArgs e)
        {
            unitWorker.Stop();

            // Hide tray icon, otherwise it will remain shown until user mouses over it
            trayIcon.Visible = false;   

            Application.Exit();
        }
    }
}
