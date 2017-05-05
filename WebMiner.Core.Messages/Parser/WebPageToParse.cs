using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMiner.Core.Messages.Parser
{
    public class WebPageToParse
    {
        public string Url { get; protected set; }

        public string Content { get; protected set; }

        public ElementToParseCollection Elements { get; protected set; }

        public WebPageToParse(string url, string content, ElementToParseCollection elements)
        {
            Url = url;
            Content = content;
            Elements = elements;
        }
    }
}
