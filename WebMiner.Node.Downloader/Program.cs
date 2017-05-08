using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMiner.Node.Downloader
{
    class Program
    {
        static void Main(string[] args)
        {
            ActorSystem system = ActorSystem.Create("WebMiner");
            
            while (true)
            {
                var msg = Console.ReadLine();
                if (msg == "exit") break;

                //var actor = system.ActorSelection("akka.tcp://WebMiner@localhost:8081/user/TestActor");
                //actor.Tell(msg);
            }
        }
    }
}
