using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMiner.Core.Actors.Test
{
    public class TestActor : UntypedActor
    {
        public TestActor()
        {
            System.Console.WriteLine($"Created actor [{Self.Path}]");
        }

        protected override void OnReceive(object message)
        {
            System.Console.WriteLine($"Message from [{Sender.Path}] to [{Self.Path}]: {message}");
        }
    }
}
