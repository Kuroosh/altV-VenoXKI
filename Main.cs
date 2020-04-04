using AltV.Net;
using System;

namespace NPC_Traffic
{
    public class Main : IScript
    {
        internal class MyResource : Resource
        {
            public override void OnStart()
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("VenoX KI - Traffic NPC System " + Globals.Main.VENOX_KI_VERSION + " is starting...");
                Console.ResetColor();
                Globals.Main.OnResourceStart();
            }

            public override void OnStop()
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("VenoX KI - Traffic NPC System " + Globals.Main.VENOX_KI_VERSION + " is stopping...");
                Console.ResetColor();
            }



        }

    }
}
