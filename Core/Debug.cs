using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using System;

namespace NPC_Traffic.Core
{
    class Debug
    {
        public static bool DEBUG_MODE_ENABLED = true;
        public static void OutputDebugString(string text)
        {
            try
            {
                if (!DEBUG_MODE_ENABLED) { return; }
                Console.WriteLine(DateTime.Now.Hour + " : " + DateTime.Now.Minute + " | : " + text);
            }
            catch { }
        }

        public static void CatchExceptions(string FunctionName, Exception ex)
        {
            if (!DEBUG_MODE_ENABLED) { return; }
            Console.WriteLine("[EXCEPTION " + FunctionName + "] " + ex.Message);
            Console.WriteLine("[EXCEPTION " + FunctionName + "] " + ex.StackTrace);
        }

        [Command("pos")]
        public static void YourPosition(IPlayer player)
        {
            OutputDebugString(player.Name + " position : " + player.Position);
        }
    }
}
