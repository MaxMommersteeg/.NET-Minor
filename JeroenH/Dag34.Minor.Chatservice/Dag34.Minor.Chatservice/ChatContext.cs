using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MySQL.Data.Entity.Extensions;

namespace Dag34.Minor.Chatservice
{
    public class ChatContext : DbContext
    {
        public DbSet<ChatMessage> Chatmessages { get; set; }

        public ChatContext()
        {
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(@"server=hellodb;userid=root;pwd=Pa$$w0rd;port=3306;database=ShopDB;sslmode=none;");
        }

    }
}
