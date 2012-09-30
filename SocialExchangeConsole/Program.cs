using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using SocialExchange;

namespace SocialExchangeConsole
{
    class Program
    {
        public static int trustExchangeRoundCount = 24;
        public static bool logicEngineIsRunning = true;
        public static LogicEngine logicEngine = new LogicEngine(trustExchangeRoundCount);

        static void Main(string[] args)
        {
            RunInteractive();
        }

        private static void RunInteractive()
        {
            while(logicEngineIsRunning)
            {
                OutputCurrentRoundInfo();
                PromptPlayerToGivePoint();
                if(PlayerGivesPoint())
                {
                    logicEngine.TrustExchangeTask.CurrentRound.PlayerGivesPoint();
                }
                TriggerPersonaResponse();
            }
        }

        private static void TriggerPersonaResponse()
        {
            logicEngine.TrustExchangeTask.TriggerPersonaResponse();
        }

        private static void OutputCurrentRoundInfo()
        {
            Console.WriteLine(string.Format("ROUND {0} / {1}:", logicEngine.TrustExchangeTask.CurrentRoundIndex, trustExchangeRoundCount));
            Console.WriteLine(string.Format("PERSONA: {0}", logicEngine.TrustExchangeTask.CurrentRound.Persona.Filename));
        }

        private static void PromptPlayerToGivePoint()
        {
            Console.Write("Give points? (Y/N) ");
        }

        private static bool PlayerGivesPoint()
        {
            return Console.In.ReadToEnd().StartsWith("Y", true, CultureInfo.InvariantCulture);
        }
    }
}
