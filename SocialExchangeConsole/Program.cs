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
        public static bool logicEngineIsRunning = true;
        public static LogicEngine LogicEngine = new LogicEngine();

        static void Main(string[] args)
        {
            RunTrustExchangeTask();
        }

        private static void RunTrustExchangeTask()
        {
            while (LogicEngine.TrustExchangeTask.CurrentRoundIndex < LogicEngine.TrustExchangeTask.Rounds.Count)
            {
                InTrustExchangeTaskOutputCurrentRoundInfo();
                InTrustExchangeTaskPromptPlayerToGivePoint();
                InTrustExchangeTaskProcessPlayerGivesPointInput();
                InTrustExchangeTaskOutputCurrentRoundPersonaResponse();

                if (LogicEngine.TrustExchangeTask.CurrentRoundIndex < LogicEngine.TrustExchangeTask.Rounds.Count - 1)
                {
                    InTrustExchangeTaskAdvanceToNextRound();
                }
                else
                {
                    break;
                }
            }
        }

        private static void InTrustExchangeTaskOutputCurrentRoundInfo()
        {
            Console.WriteLine(string.Format("ROUND {0} / {1}:", LogicEngine.TrustExchangeTask.CurrentRoundIndex + 1, LogicEngine.TrustExchangeTask.Rounds.Count));
            Console.WriteLine(string.Format("PERSONA: {0}", LogicEngine.TrustExchangeTask.CurrentRound.Persona.Filename));
        }

        private static void InTrustExchangeTaskPromptPlayerToGivePoint()
        {
            Console.Write("Give points? (Y/N) ");
        }

        private static void InTrustExchangeTaskProcessPlayerGivesPointInput()
        {
            bool playerGivesPoint = Console.In.ReadLine().StartsWith("Y", true, CultureInfo.InvariantCulture);

            if(playerGivesPoint)
            {
                LogicEngine.TrustExchangeTask.PlayerGivesPoint();
            }
        }

        private static void InTrustExchangeTaskOutputCurrentRoundPersonaResponse()
        {
            Console.WriteLine(string.Format("RESPONSE: {0}", LogicEngine.TrustExchangeTask.CurrentRound.TrustExchange.PersonaClassification.Value));
            Console.WriteLine();
        }

        private static void InTrustExchangeTaskAdvanceToNextRound()
        {
            LogicEngine.TrustExchangeTask.Advance();
        }
    }
}
