using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialExchange
{
    public class TrustExchange
    {
        public int PlayerToPersonaRawPoints { get; protected set; }
        public int PersonaToPlayerRawPoints { get; protected set; }
        public PersonaClassification PersonaClassification { get; set; }

        public TrustExchange()
        {
            PlayerToPersonaRawPoints = 0;
            PersonaToPlayerRawPoints = 0;
            PersonaClassification = PersonaClassifications.UNINITIALIZED;
        }

        public int PlayerGivesPoint()
        {
            return (PlayerToPersonaRawPoints++);
        }

        public int PersonaGivesPoint()
        {
            return (PersonaToPlayerRawPoints++);
        }
    }
}
