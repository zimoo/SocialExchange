using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialExchange
{
    public class TrustExchangeTask /*: ITimestamped*/
    {
        public List<TrustExchangeRound> Rounds { get; protected set; }

        public DateTime BeginTimestamp { get; protected set; }
        public DateTime EndTimestamp { get; protected set; }

        public int RoundCount { get; protected set; }
        public int CurrentRoundIndex { get; protected set; }
        public TrustExchangeRound CurrentRound 
        { 
            get 
            { 
                BeginTimestamp = 
                    BeginTimestamp == default(DateTime) ? 
                    DateTime.Now : 
                    BeginTimestamp; 

                return 
                    Rounds[CurrentRoundIndex];
            } 
        }

        public Func<List<TrustExchangeRound>, TrustExchangeRound, PersonaClassification> PersonaTrustExchangeLogic { get; protected set; }

        public TrustExchangeTask(
            List<TrustExchangeRound> rounds,
            Func<List<TrustExchangeRound>, TrustExchangeRound, PersonaClassification> personaTrustExchangeLogic
            )
        {
            Rounds = rounds;
            Rounds.TrimExcess();
            RoundCount = rounds.Count;
            CurrentRoundIndex = 0;

            PersonaTrustExchangeLogic = personaTrustExchangeLogic;
        }

        protected TrustExchangeRound Advance()
        {
            int nextRountIndex = CurrentRoundIndex + 1;

            if (nextRountIndex >= Rounds.Count)
            {
                throw new InvalidOperationException("Cannot advance past final round.");
            }
            else
            {
                CurrentRoundIndex++;
            }

            return CurrentRound;
        }

        protected PersonaClassification TriggerPersonaResponse()
        {
            EndTimestamp =
                CurrentRoundIndex == Rounds.Count - 1 ?
                DateTime.Now :
                default(DateTime);

            return 
                PersonaTrustExchangeLogic(Rounds, CurrentRound);
        }

        public PersonaClassification PlayerGivesPoint()
        {
            CurrentRound.PlayerGivesPoint();

            return TriggerPersonaResponse();
        }
    }
}
