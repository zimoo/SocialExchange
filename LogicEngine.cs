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

        public int TrustExchangeRoundCount { get; protected set; }
        public TrustExchangeTask TrustExchangeTask { get; protected set; }
        public Action<List<TrustExchangeRound>, TrustExchangeRound> PersonaTrustExchangeLogic { get; protected set; }

        public LogicEngine(int trustExchangeRoundCount)
        {
            TrustExchangeRoundCount = trustExchangeRoundCount;

            InitializePersonas();

            InitializeTrustExchangeRounds();
            InitializePersonaTrustExchangeLogic();
        }

        private void InitializePersonaTrustExchangeLogic()
        {
            PersonaTrustExchangeLogic =
                (rounds, currentRound) =>
                {
                    int cooperators = 0;
                    int defectors = 0;

                    currentRound.PersonaGivesPoint
                };
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

        private void InitializeTrustExchangeRounds()
        {
            List<TrustExchangeRound> rounds = new List<TrustExchangeRound>();

            Random random = new Random();
            while(rounds.Count < TrustExchangeRoundCount)
            {
                Persona roundPersonaCandidate = Personas[random.Next(0, TrustExchangeRoundCount)];
                if (!rounds.Select(r => r.Persona).Cast<Persona>().ToList().Contains(roundPersonaCandidate))
                {
                    rounds.Add(new TrustExchangeRound(roundPersonaCandidate));
                }
            }

            TrustExchangeTask = new TrustExchangeTask(rounds, PersonaTrustExchangeLogic);
        }

    }
}
