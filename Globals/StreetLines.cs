using AltV.Net.Elements.Entities;
using NPC_Traffic.Models;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace NPC_Traffic.Globals
{
    public class StreetLines
    {
        public static List<StreetModel> LineList = new List<StreetModel>();
        public static void CreateLines()
        {
            LineList = new List<StreetModel>
            {
                new StreetModel
                {
                    Name = "L.S.P.D",
                    Start_Position = new Vector3(402.7912f,-982.8f,29.364136f),
                    End_Position = new Vector3(0f,0f,0f),
                    Start_Rotation = new Vector3(0f,0f,0f),
                    DateTimeCreated = DateTime.Now
                },
                new StreetModel
                {
                    Name = "L.S.P.D",
                    Start_Position = new Vector3(0f,0f,0f),
                    End_Position = new Vector3(0f,0f,0f),
                    Start_Rotation = new Vector3(0f,0f,0f),
                    DateTimeCreated = DateTime.Now
                },

            };
        }

        public static StreetModel GetNearestStreetModel(IPlayer player)
        {
            foreach (StreetModel lines in LineList)
            {
                if (player.Position.Distance(lines.Start_Position) <= Settings.General.MAX_DISTANCE_TRAFFIC)
                {
                    return lines;
                }
            }
            return null;
        }
    }
}
