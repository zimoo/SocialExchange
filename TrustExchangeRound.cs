using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialExchange
{
    public class TrustExchangeRound : Round
    {
        public TrustExchange TrustExchange { get; protected set; }

        public TrustExchangeRound(Persona persona, TrustExchange trustExchange) : base(persona)
        {
            TrustExchange = trustExchange;
        }
    }
}
