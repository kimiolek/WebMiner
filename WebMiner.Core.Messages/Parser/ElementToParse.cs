using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMiner.Core.Messages.Parser
{
    public class ElementToParse
    {
        public string Path { get; protected set; }

        public ElementToParse(string path)
        {
            Path = path;
        }
    }
}
