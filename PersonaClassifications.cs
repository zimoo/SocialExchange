using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialExchange
{
    public static class PersonaClassifications
    {
        public static readonly PersonaClassification INDETERMINATE = new PersonaClassification("INDETERMINATE");
        public static readonly PersonaClassification DEFECTOR = new PersonaClassification("DEFECTOR");
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
