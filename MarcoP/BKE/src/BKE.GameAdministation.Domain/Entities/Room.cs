using BKE.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BKE.GameAdministation.Domain
{
    public class Room
    {
        private List<Player> _players;

        public long ID { get; set; }
        public string Name { get; set; }
        public long GameID { get; set; }
        public IEnumerable<Player> Players { get { return _players; } }

        public Room()
        {
            _players = new List<Player>();
        }

        public void Create(string name, long gameID)
        {
            Name = name;
            GameID = gameID;
        }

        public void Join(long playerID, string colour)
        {
            if (_players.Any(p => p.Colour == colour))
            {
                var error = new FunctionalError("US013.2.a", $"The colour '{colour}' has already been taken");
                throw new FunctionalException(error);
            }
            var player = new Player { ID = playerID, Colour = colour };
            _players.Add(player);
        }
    }
}
