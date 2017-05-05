using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMiner.Core.Messages.Parser
{
    public class ElementParsed
    {
        public string Path { get; protected set; }
         
        public string Value { get; protected set; }

        public ElementParsed(string path, string value)
        {
            Path = path;
            value = value;
        }
    }
}
