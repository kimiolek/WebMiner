using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMiner.Core.Messages.Trucker.WorkflowState
{
    public class DownloadStarted
    {
        public string Url { get; protected set; }

        public DownloadStarted(string url)
        {
            Url = url;
        }
    }
}
