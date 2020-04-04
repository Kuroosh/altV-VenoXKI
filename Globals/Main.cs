using AltV.Net;
using AltV.Net.Elements.Entities;
using NPC_Traffic.Models;
using NPC_Traffic.Settings;
using System;
using System.Threading;

namespace NPC_Traffic.Globals
{
    public class Main : IScript
    {
        public const string VENOX_KI_VERSION = "v.1.0.0";

        public static Timer KI_Update_Timer;


        public static void OnUpdateCall(Object Unused)
        {
            foreach (IPlayer player in Alt.GetAllPlayers())
            {
                StreetModel NearestStreetModel = StreetLines.GetNearestStreetModel(player);
                if (NearestStreetModel == null) return;
                player.Emit("NPC:CreateTraffic", "u_m_m_jesus_01", NearestStreetModel.Start_Position.X, NearestStreetModel.Start_Position.Y, NearestStreetModel.Start_Position.Z, 0, "Infernus");
                Core.Debug.OutputDebugString("Triggered for " + player.Name);
            }
        }


        public static void OnResourceStart()
        {
            KI_Update_Timer = new Timer(OnUpdateCall, null, General.UPDATE_INTERVAL_KI, General.UPDATE_INTERVAL_KI);
            StreetLines.CreateLines();
        }
    }
}
