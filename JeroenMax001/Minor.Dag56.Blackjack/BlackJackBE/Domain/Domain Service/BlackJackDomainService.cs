using BlackJackBE.Domain.Entities;
using Domain.Entities;
using Minor.WSA.EventBus.Config;
using Minor.WSA.EventBus.Publisher;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;

namespace BlackJackBE.Domain.Domain_Service
{
    public class BlackJackDomainService
    {
        public Round StartGame(StartGameCommand command)
        {
            Dealer dealer = new Dealer();
            Round round = new Round()
            {
                Dealer = dealer,
                Player = new Player() { Hand = new PlayerHand() { CardsInHand = new List<Card>() { dealer.Hit(), dealer.Hit() } } },
            };
            GameStartedEvent gse = new GameStartedEvent() { round = round, RoutingKey="blabla", GUID = Guid.NewGuid().ToString() , TimeStamp = DateTime.UtcNow };

            // Publish event
            using (var eventPublishService = 
                new EventPublisher(
                    new EventBusConfig()
                    {
                        QueueName = "web-app-listener-queue",
                        Host = "localhost"
                    })
                )
            {
                eventPublishService.Publish(gse);
            }

            return round;
        }

        public Card Hit(HitCommand command)
        {
            return command.Round.Dealer.Hit();
        }
    }
}
