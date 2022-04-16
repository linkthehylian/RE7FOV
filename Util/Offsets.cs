using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace iSukv2.Util
{
    public static class Offsets
    {
        public static int clientState = 0x588D9C;
        public static int LocalPlayer = 0xD28B1C;
        public static int ActiveWeapon = 0x2EF8;
        public static int MyWeapons = 0x2DF8;
        public static int ItemDefinitionIndex = 0x2FAA;
        public static int ViewModelIndex = 0x3220;
        public static int WorldModelIndex = 0x3224;
        public static int ModelIndex = 0x258;
        public static int ItemIDHigh = 0x2FC0;
        public static int FallbackStatTrak = 0x31C4;
        public static int FallbackPaintKit = 0x31B8;
        public static int FallbackWear = 0x31C0;
        public static int Flags = 0x104;
        public static int ForceJump = 0x51DFEAC;
        public static int EntityList = 0x4D3C68C;
        public static int Team = 0xF4;
        public static int CrossHairID = 0xB3D4;
        public static int Health = 0x100;
        public static int ForceAttack = 0x316DD4C;
        public static int GlowIndex = 0xA428;
        public static int GlowObjectManager = 0x527DF60;
        public static int Dormant = 0xED;
        public static int FlashMaxAlpha = 0xA40C;
        public static int defaultFOV = 0x332C;
        public static int FOV = 0x31E4;
        public static int IsScoped = 0x3914;
        public static int ZoomLevel = 0x33B0;
        public static int OriginalOwnerXuidLow = 0x31B0;
        public static int Spotted = 0x93D;
        public static int VecPunch = 0x302C;
        public static int ShotsFired = 0xA380;
        public static int ViewAngles = 0x4D88;
        public static int VecOrigin = 0x138;
        public static int VecViewOffset = 0x108;
        public static int ViewMatrix = 0x4D2E0A4;
        public static int BoneMatrix = 0x26A8;
        public static int Client { get; set; }
        public static int Engine { get; set; }

        public static bool GetClient()
        {
            try
            {
                Process[] ps = Process.GetProcessesByName("csgo");
                if (ps.Length > 0)
                {
                    foreach (ProcessModule module in ps[0].Modules)
                    {
                        if (module.ModuleName == "client_panorama.dll")
                        {
                            Client = (int)module.BaseAddress;
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show($"Failed to grab client_panorama.dll. Make sure CSGO is open!\nException: {ex}"); }
            return false;
        }

        public static bool GetEngine()
        {
            try
            {
                Process[] ps = Process.GetProcessesByName("csgo");
                if (ps.Length > 0)
                {
                    foreach (ProcessModule module in ps[0].Modules)
                    {
                        if (module.ModuleName == "engine.dll")
                        {
                            Engine = (int)module.BaseAddress;
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show($"Failed to grab engine.dll. Make sure CSGO is open!\nException: {ex.Message}"); }
            return false;
        }
    }
}
