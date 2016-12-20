using BlackJackBE.Domain.Domain_Service;
using BlackJackFE.Dispatchers;
using Minor.WSA.EventBus.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJackFE
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var dispatcher = new BlackJackDispatcher(new EventBusConfig()))
            {
                var result = Console.ReadLine();

                if(result=="startgame")
                {
                    var gsc = new StartGameCommand() { };
                    BlackJackDomainService bjds = new BlackJackDomainService();
                    bjds.StartGame(gsc);
                }
                Console.ReadKey();

            }




        }
    }
}
