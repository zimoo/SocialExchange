using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialExchange
{
    public class TrustExchange
    {
        public int RawPointsGiven { get; set; }
        public int RawPointsReceived { get; set; }
        public PersonaClassification PersonaClassification { get; set; }

        public TrustExchange()
        {
            RawPointsGiven = 0;
            RawPointsReceived = 0;
            PersonaClassification = PersonaClassifications.UNINITIALIZED;
        }
    }
}
