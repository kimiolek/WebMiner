using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMiner.Core.Messages.Trucker.WorkflowState
{
    public class ParseFinished
    {
        public string Url { get; protected set; }

        public long ElapsedMilliseconds { get; protected set; }

        public ParseFinished(string url, long elapsedMilliseconds)
        {
            Url = url;
            ElapsedMilliseconds = elapsedMilliseconds;
        }
    }
}
