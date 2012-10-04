using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using SocialExchange.Tasks;

namespace SocialExchange
{
    public class LogicEngine
    {
        public List<Persona> Personas { get; protected set; }
        public TrustExchangeTask TrustExchangeTask { get; protected set; }
        public Func<PersonaClassification> PersonaResponseLogic { get; protected set; }
        public int TrustExchangeTaskRoundcount = 24;

        public LogicEngine()
        {
            InitializePersonas();
            InitializeTrustExchangeTask();
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

        private void InitializeTrustExchangeTask()
        {
            List<TrustExchangeTask.Round> rounds = new List<TrustExchangeTask.Round>(TrustExchangeTaskRoundcount);

            TrustExchangeTask = new TrustExchangeTask(rounds);

            while (rounds.Count < TrustExchangeTaskRoundcount)
            {
                Persona roundPersonaCandidate = Personas[new Random().Next(0, Personas.Count - 1)];
                if (!rounds.Select(r => r.Persona).Cast<Persona>().ToList().Contains(roundPersonaCandidate))
                {
                    rounds.Add(
                        new TrustExchangeTask.Round(
                            roundPersonaCandidate,
                            () =>
                            {
                                int cooperators = TrustExchangeTask.Rounds.Where(r => r.TrustExchange.PersonaClassification == PersonaClassifications.COOPERATOR).Count();
                                int defectors = TrustExchangeTask.Rounds.Where(r => r.TrustExchange.PersonaClassification == PersonaClassifications.DEFECTOR).Count();

                                PersonaClassification[] options =
                                    new PersonaClassification[] { PersonaClassifications.COOPERATOR, PersonaClassifications.DEFECTOR };

                                return
                                    cooperators > defectors ? PersonaClassifications.DEFECTOR :
                                    cooperators < defectors ? PersonaClassifications.COOPERATOR :
                                    options[new Random().Next(1, options.Count())];
                            }
                        )
                    );
                }
            }
        }

    }
}
