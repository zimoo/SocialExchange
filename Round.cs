using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialExchange
{
    public abstract class Round
    {
        public Player Player { get; protected set; }
        public DateTime BeginRoundTimestamp { get; protected set; }
        public DateTime EndRoundTimestamp { get; protected set; }

        public Round(Player player)
        {
            Player = player;
        }

        public DateTime BeginRound()
        {
            return BeginRoundTimestamp = DateTime.Now;
        }

        public DateTime EndRound()
        {
            return EndRoundTimestamp = DateTime.Now;
        }
    }
}
