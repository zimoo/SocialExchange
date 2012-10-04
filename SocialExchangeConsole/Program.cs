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
            while(LogicEngine.TrustExchangeTask.EndTimestamp == default(DateTime))
            {
                InTrustExchangeTaskOutputCurrentRoundInfo();
                InTrustExchangeTaskPromptPlayerToGivePoint();
                InTrustExchangeTaskProcessPlayerGivesPointInput();
                //InTrustExchangeTaskTriggerPersonaResponse();
            }
        }

        //private static void InTrustExchangeTaskTriggerPersonaResponse()
        //{
        //    LogicEngine.TrustExchangeTask.TriggerPersonaResponse();
        //}

        private static void InTrustExchangeTaskOutputCurrentRoundInfo()
        {
            Console.WriteLine(string.Format("ROUND {0} / {1}:", LogicEngine.TrustExchangeTask.CurrentRoundIndex, LogicEngine.TrustExchangeTask.Rounds.Count));
            Console.WriteLine(string.Format("PERSONA: {0}", LogicEngine.TrustExchangeTask.CurrentRound.Persona.Filename));
        }

        private static void InTrustExchangeTaskPromptPlayerToGivePoint()
        {
            Console.Write("Give points? (Y/N) ");
        }

        private static void InTrustExchangeTaskProcessPlayerGivesPointInput()
        {
            bool playerGivesPoint = Console.In.ReadToEnd().StartsWith("Y", true, CultureInfo.InvariantCulture);

            if(playerGivesPoint)
            {
                LogicEngine.TrustExchangeTask.PlayerGivesPoint();
            }
        }
    }
}
