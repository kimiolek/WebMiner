using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMiner.Core.Messages.Downloader
{
    /// <summary>
    /// Message for downloader actors to start download web page form given url address
    /// </summary>
    public class DownloadFromUrl
    {
        public string Url { get; protected set; }

        public DownloadFromUrl(string url)
        {
            Url = url;
        }
    }
}
