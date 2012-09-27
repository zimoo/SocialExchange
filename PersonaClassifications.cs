using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialExchange
{
    public static class PersonaClassifications
    {
        public static readonly PersonaClassification UNINITIALIZED = new PersonaClassification("UNINITIALIZED");
        public static readonly PersonaClassification CHEATER = new PersonaClassification("CHEATER");
        public static readonly PersonaClassification COOPERATOR = new PersonaClassification("COOPERATOR");
        public static readonly PersonaClassification NOVEL = new PersonaClassification("NOVEL");
    }

    public class PersonaClassification
    {
        public string Value { get; protected set; }

        public PersonaClassification(string value)
        {
            Value = value;
        }
    }
}
