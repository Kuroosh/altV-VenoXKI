using System;
using System.Numerics;

namespace NPC_Traffic.Models
{
    public class StreetModel
    {
        public string Name { get; set; }
        public Vector3 Start_Position { get; set; }
        public Vector3 Start_Rotation { get; set; }
        public Vector3 End_Position { get; set; }
        public DateTime DateTimeCreated { get; set; }
    }
}
