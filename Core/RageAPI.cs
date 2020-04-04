using AltV.Net;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using System;
using System.Drawing;

namespace NPC_Traffic.Core
{
    public static class RageAPI
    {
        public static T vnxGetElementData<T>(this IBaseObject element, string key)
        {
            try
            {
                if (element.GetData(key, out T value))
                {
                    return value;
                }
                return default;
            }
            catch { return default; }
        }

        public static T vnxGetSharedData<T>(this IEntity element, string key)
        {
            try
            {
                if (element.GetSyncedMetaData(key, out T value))
                {
                    return value;
                }
                return default;
            }
            catch { return default; }
        }

        public static string GetHexColorcode(int r, int g, int b)
        {
            Color myColor = Color.FromArgb(r, g, b);
            return "{" + myColor.R.ToString("X2") + myColor.G.ToString("X2") + myColor.B.ToString("X2") + "}";
        }

        public static void WarpIntoVehicle<T>(this IPlayer player, IVehicle veh, int seat)
        {
            player.Emit("Player:WarpIntoVehicle", veh, seat);
        }
        public static void WarpOutOfVehicle<T>(this IPlayer player)
        {
            player.Emit("Player:WarpOutOfVehicle");
        }


        public static void GivePlayerWeapon(this IPlayer player, AltV.Net.Enums.WeaponModel weapon, int ammo)
        {
            try
            {
                player.GiveWeapon(weapon, ammo, false);
            }
            catch { }
        }

        public static void SetWeaponAmmo(this IPlayer player, AltV.Net.Enums.WeaponModel weapon, int ammo)
        {
            try
            {
                player.GiveWeapon(weapon, ammo, false);
            }
            catch { }
        }

        public static void SendChatMessageToAll(string text)
        {
            try
            {
                foreach (IPlayer players in Alt.GetAllPlayers())
                {
                    players.SendChatMessage(text);
                }
            }
            catch { }
        }

        public static void SetClothes(IPlayer element, int clothesslot, int clothesdrawable, int clothestexture)
        {
            if (clothesslot < 0 || clothesdrawable < 0) { return; }
            Core.Debug.OutputDebugString("Stuff : " + clothesslot + " | " + clothesdrawable + " | " + clothestexture);
            try { element.Emit("Clothes:Load", clothesslot, clothesdrawable, clothestexture); }
            catch (Exception ex) { Core.Debug.CatchExceptions("SetClothes", ex); }
        }

        public static void SetAccessories(IPlayer element, int clothesslot, int clothesdrawable, int clothestexture)
        {
            try { element.Emit("Accessories:Load", clothesslot, clothesdrawable, clothestexture); }
            catch { }
        }

        public static void SetPlayerVisible(IPlayer element, bool trueOrFalse)
        {
            try { element.Emit("Player:Visible", trueOrFalse); }
            catch { }
        }
    }
}
