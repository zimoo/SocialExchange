using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialExchange
{
    public class TrustExchangeTask : ITimestamped
    {
        public List<TrustExchangeRound> Rounds { get; protected set; }

        public DateTime BeginTimestamp { get; protected set; }
        public DateTime EndTimestamp { get; protected set; }

        public TrustExchangeTask()
        {
            Rounds = new List<TrustExchangeRound>();
        }

        public DateTime Begin()
        {
            return BeginTimestamp = DateTime.Now;
        }

        public DateTime End()
        {
            return EndTimestamp = DateTime.Now;
        }
    }
}
