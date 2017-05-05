using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebMiner.Core.Messages.Downloader;
using WebMiner.Core.Messages.Trucker.WorkflowState;

namespace WebMiner.Core.Actors.Downloader
{
    /// <summary>
    /// Responsible for download web page using standard http client
    /// </summary>
    public class DefaultDownloaderActor : ReceiveActor
    {
        protected IActorRef trucker;

        public DefaultDownloaderActor()
        {
            Receive<DownloadFromUrl>(msg => { DownloadFromUrl(msg.Url); });
        }

        protected void DownloadFromUrl(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                trucker.Tell(new DownloadStarted(url));
                System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();

                timer.Start();
                var content = client.GetStringAsync(url).Result;
                timer.Start();

                trucker.Tell(new DownloadFinished(url, timer.ElapsedMilliseconds));
                Sender.Tell(new WebPageDownloaded(url, content));
            }
        }
    }
}
