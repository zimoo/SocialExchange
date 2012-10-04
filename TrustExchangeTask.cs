using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialExchange.Tasks
{
    public partial class TrustExchangeTask
    {
        protected List<Round> _rounds = null;
        public IList<Round> Rounds { get { return _rounds.AsReadOnly(); } }

        public DateTime BeginTimestamp { get; protected set; }
        public DateTime EndTimestamp { get; protected set; }

        public int CurrentRoundIndex { get; protected set; }
        public Round CurrentRound 
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

        public Func<PersonaClassification> PersonaResponseLogic { get { return ExecutePersonaResponse; } }

        public TrustExchangeTask(List<Round> rounds)
        {
            _rounds = rounds;
            CurrentRoundIndex = 0;
        }

        protected Round Advance()
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

        public PersonaClassification PlayerGivesPoint()
        {
            CurrentRound.PlayerGivesPoint();

            PersonaClassification response = ExecutePersonaResponse();

            EndTimestamp =
                CurrentRoundIndex == Rounds.Count - 1 ?
                DateTime.Now :
                default(DateTime);

            return response;
        }

        private PersonaClassification ExecutePersonaResponse()
        {
            int cooperators = Rounds.Where(r => r.TrustExchange.PersonaClassification == PersonaClassifications.COOPERATOR).Count();
            int defectors = Rounds.Where(r => r.TrustExchange.PersonaClassification == PersonaClassifications.DEFECTOR).Count();

            PersonaClassification[] options = 
                new PersonaClassification[] { PersonaClassifications.COOPERATOR, PersonaClassifications.DEFECTOR};

            return
                cooperators > defectors ? PersonaClassifications.DEFECTOR :
                cooperators < defectors ? PersonaClassifications.COOPERATOR :
                options[new Random().Next(1, options.Count())];
        }
    }
}
