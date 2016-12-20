using System;
using Microsoft.EntityFrameworkCore;
using Minor.Dag39.SpelbeheerServiceBackend.DAL.DatabaseContexts;
using RawRabbit.vNext;
using Minor.Dag39.SpelbeheerServiceBackend.Domain;
using Minor.Dag39.SpelbeheerServiceBackend.Outgoing;
using RawRabbit.Configuration;
using System.Linq;

namespace Minor.Dag39.SpelbeheerServiceBackend.DAL.DAL
{
    public class SpelRepository
        : BaseRepository<Spel, int, DatabaseContext>
    {
        private DbContextOptions _options;

        private RawRabbitConfiguration _RabbitConfig;

        public SpelRepository(DatabaseContext context, RawRabbitConfiguration rabbitconfig = null) : base(context)
        {

            _RabbitConfig = rabbitconfig ?? new RawRabbitConfiguration() {
                Username = "guest",
                Password = "guest",
                Port = 15672,
                Hostnames = { "localhost" },
                Exchange = new GeneralExchangeConfiguration() { Type = RawRabbit.Configuration.Exchange.ExchangeType.Topic }
                                
            };
        }

        protected override DbSet<Spel> GetDbSet()
        {
        
            return _context.Spellen;
        }

        protected override int GetKeyFrom(Spel spel)
        {
            return spel.SpelId;
        }

        public override async void Insert(Spel item)
        {
            base.Insert(item);
            

            var client = BusClientFactory.CreateDefault();
            await client.PublishAsync(new SpelGestartEvent { SpelerIds = item.SpelerIds.Select(x=>x.SpelerId).ToArray(), SpelId = item.SpelId });

        }
    }
}