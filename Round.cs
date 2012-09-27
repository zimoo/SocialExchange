﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialExchange
{
    public abstract class Round : ITimestamped
    {
        public Persona Persona { get; protected set; }
        public DateTime BeginTimestamp { get; protected set; }
        public DateTime EndTimestamp { get; protected set; }

        public Round(Persona persona)
        {
            Persona = persona;
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
