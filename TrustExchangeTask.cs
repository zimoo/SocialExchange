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

        public TrustExchangeRound Advance()
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

        public void TriggerPersonaResponse()
        {
            PersonaTrustExchangeLogic(Rounds, CurrentRound);

            EndTimestamp =
                CurrentRoundIndex == Rounds.Count - 1 ?
                DateTime.Now :
                default(DateTime);
        }

        public PersonaClassification PlayerGivesPoint()
        {
            throw new NotImplementedException();
        }
    }
}
