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
        public Action<List<TrustExchangeRound>, TrustExchangeRound> TrustExchangePersonaResponseLogic { get; protected set; }

        public LogicEngine(int trustExchangeRoundCount)
        {
            TrustExchangeRoundCount = trustExchangeRoundCount;

            InitializePersonas();

            InitializeTrustExchange();
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

        private void InitializeTrustExchange()
        {
            List<TrustExchangeRound> trustExchangeRounds = new List<TrustExchangeRound>();

            Random random = new Random();
            while(trustExchangeRounds.Count < TrustExchangeRoundCount)
            {
                Persona roundPersonaCandidate = Personas[random.Next(0, TrustExchangeRoundCount)];
                if (!trustExchangeRounds.Select(r => r.Persona).Cast<Persona>().ToList().Contains(roundPersonaCandidate))
                {
                    trustExchangeRounds.Add(new TrustExchangeRound(roundPersonaCandidate));
                }
            }

            TrustExchangePersonaResponseLogic =
                (rounds, currentRound) =>
                {
                    int cooperators = 0;
                    int defectors = 0;

                    //currentRound.PersonaGivesPoint
                };

            TrustExchangeTask = new TrustExchangeTask(trustExchangeRounds, TrustExchangePersonaResponseLogic);
        }

    }
}
