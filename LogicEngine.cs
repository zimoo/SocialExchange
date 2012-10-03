using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SocialExchange
{
    public class LogicEngine
    {
        public List<Persona> Personas { get; protected set; }
        public TrustExchangeTask TrustExchangeTask { get; protected set; }

        public LogicEngine(int trustExchangeRoundCount)
        {
            InitializePersonas();
            InitializeTrustExchange(trustExchangeRoundCount);
        }

        private void InitializeTrustExchangePersonaResponseLogic()
        {
        }

        private void InitializePersonas()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            Personas = 
                assembly
                .GetManifestResourceNames()
                .ToList()
                .Select(
                    s => 
                        new Persona(
                            new Bitmap(assembly.GetManifestResourceStream(s)),
                            s
                        )
                    )
                .Cast<Persona>()
                .ToList();
        }

        private void InitializeTrustExchange(int roundCount)
        {
            List<TrustExchangeRound> trustExchangeRounds = new List<TrustExchangeRound>(roundCount);

            Random random = new Random();
            while (trustExchangeRounds.Count < roundCount)
            {
                Persona roundPersonaCandidate = Personas[random.Next(0, roundCount)];
                if (!trustExchangeRounds.Select(r => r.Persona).Cast<Persona>().ToList().Contains(roundPersonaCandidate))
                {
                    trustExchangeRounds.Add(new TrustExchangeRound(roundPersonaCandidate));
                }
            }

            Func<List<TrustExchangeRound>, TrustExchangeRound, PersonaClassification> responseLogic =
                (rounds, currentRound) =>
                {
                    int cooperators = 0;
                    int defectors = 0;

                    //currentRound.PersonaGivesPoint
                    throw new NotImplementedException();
                };

            TrustExchangeTask = new TrustExchangeTask(trustExchangeRounds, responseLogic);
        }

    }
}
