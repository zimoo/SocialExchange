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
        public Action<List<TrustExchangeRound>,TrustExchangeRound> PersonaTrustExchangeLogic { get; protected set; }

        public TrustExchangeTask(
            List<TrustExchangeRound> rounds, 
            Action<List<TrustExchangeRound>, TrustExchangeRound> personaTrustExchangeLogic
            )
        {
            Rounds = rounds;
            Rounds.TrimExcess();
            RoundCount = rounds.Count;
            CurrentRoundIndex = 0;

            PersonaTrustExchangeLogic = personaTrustExchangeLogic;
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

        public void TriggerPersonaResponse()
        {
            PersonaTrustExchangeLogic(Rounds, CurrentRound);
        }
    }
}
