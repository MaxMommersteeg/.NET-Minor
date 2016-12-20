using Minor.WSA.EventBus.Dispatcher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Minor.WSA.EventBus.Config;

namespace BlackJackFE.Dispatchers
{
    [RoutingKey("#")]
    public class BlackJackDispatcher : EventDispatcher
    {
        public BlackJackDispatcher(EventBusConfig config) : base(config)
        {
        }

        public void GameStartedEvent(GameStartedEvent gse)
        {
            Console.WriteLine(gse.round.Dealer.Hand.CardsInHand.First().ToString());
        }
    }
}
