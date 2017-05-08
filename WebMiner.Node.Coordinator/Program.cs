using Akka.Actor;
using Akka.Cluster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMiner.Core.Actors.Test;

namespace WebMiner.Node.Coordinator
{
    class Program
    {
        static void Main(string[] args)
        {
            ActorSystem system = ActorSystem.Create("WebMiner");
            var actor = system.ActorOf(Props.Create(typeof(TestActor)), "TestActor");
            
            while (true)
            {
                if (System.Console.ReadKey().KeyChar == 'x')
                    break;
            }

            //System.Console.WriteLine("Nacisnij [Enter] aby wyslać wiadowmosc");

            //IActorRef actor = null;
            //int i = 1;
            //while (System.Console.ReadKey().Key == ConsoleKey.Enter)
            //{
            //    string msg = $"WIADOMOSCI_{i++}";

            //    if (actor == null)
            //        actor = system.ActorOf(Props.Create(typeof(TestActor)));

            //    actor.Tell(msg);
            //}

            System.Console.WriteLine("Koncze");
            system.WhenTerminated.Wait();
            System.Console.WriteLine("Enter aby zamknac");
            System.Console.ReadLine();
        }
    }
}
