using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialExchange
{
    public class TrustExchangeRound : Round
    {
        protected TrustExchange TrustExchange { get; set; }

        public TrustExchangeRound(Persona persona) : base(persona)
        {
            TrustExchange = new TrustExchange();
        }

        public int PlayerGivesPoint()
        {
            return TrustExchange.PlayerGivesPoint();
        }

        public int PersonaGivesPoint()
        {
            return TrustExchange.PersonaGivesPoint();
        }

        public void SetOutcome(PersonaClassification personaClassification)
        {
            TrustExchange.PersonaClassification = personaClassification;
        }
    }
}
