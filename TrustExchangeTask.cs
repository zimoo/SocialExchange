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

        public int RoundCount { get; protected set; }
        public int CurrentRoundIndex { get; protected set; }
        public TrustExchangeRound CurrentRound { get { return Rounds[CurrentRoundIndex] ;} }

        public TrustExchangeTask(
            List<TrustExchangeRound> rounds
            )
        {
            Rounds = rounds;
            Rounds.TrimExcess();

            RoundCount = rounds.Count;

            CurrentRoundIndex = -1;
        }

        public DateTime Begin()
        {
            return BeginTimestamp = DateTime.Now;
        }

        public DateTime End()
        {
            return EndTimestamp = DateTime.Now;
        }

        public TrustExchangeRound Advance()
        {
            CurrentRoundIndex++;

            if (CurrentRoundIndex >= Rounds.Count)
            {
                throw new InvalidOperationException("Cannot advance past last round.");
            }

            return CurrentRound;
        }
    }
}
