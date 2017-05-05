using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMiner.Core.Messages.Downloader
{
    public class WebPageDownloaded
    {
        /// <summary>
        /// Url of web page
        /// </summary>
        public string Url { get; protected set; }

        /// <summary>
        /// Downloaded page content
        /// </summary>
        public string Content { get; protected set; }
        
        public WebPageDownloaded(string url, string content)
        {
            Url = url;
            Content = content;
        }
    }
}
