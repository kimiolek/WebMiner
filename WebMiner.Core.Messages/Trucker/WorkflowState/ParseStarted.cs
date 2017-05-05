using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMiner.Core.Messages.Trucker.WorkflowState
{
    public class ParseStarted
    {
        public string Url { get; protected set; }

        public ParseStarted(string url)
        {
            Url = url;
        }
    }
}
