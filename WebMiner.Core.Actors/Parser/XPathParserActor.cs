using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMiner.Core.Messages.Parser;
using WebMiner.Core.Messages.Trucker.WorkflowState;

namespace WebMiner.Core.Actors.Parser
{
    public class XPathParserActor : ReceiveActor
    {
        protected IActorRef trucker;

        public XPathParserActor()
        {
            Receive<WebPageToParse>(msg => ParseWebPage(msg.Url, msg.Content, msg.Elements));
        }

        protected void ParseWebPage(string url, string content, ElementToParseCollection elements)
        {
            trucker.Tell(new ParseStarted(url));

            System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
            timer.Start();

            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(content);

            var parsedElements = new ElementParsedCollection();
            foreach (var element in elements)
            {
                var node = document.DocumentNode.SelectSingleNode(element.Path);
                parsedElements.Add(new ElementParsed(element.Path, node.InnerText));
            }

            timer.Stop();

            trucker.Tell(new ParseFinished(url, timer.ElapsedMilliseconds));
            Sender.Tell(parsedElements);
        }
    }
}
