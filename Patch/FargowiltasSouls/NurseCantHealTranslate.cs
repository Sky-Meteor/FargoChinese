using FargowiltasSouls;
using FargowiltasSouls.Buffs.Masomode;
using MonoMod.RuntimeDetour.HookGen;
using System.Reflection;
using Terraria;
using Terraria.ModLoader;

namespace FargoMemeChinese.Patch.FargowiltasSouls
{
    [JITWhenModsEnabled("FargowiltasSouls")]
    public static class NurseCantHealTranslate
    {
        private static MethodBase _nurseHealMethod;
        public static void Load()
        {
            _nurseHealMethod = typeof(EModePlayer).GetMethod("ModifyNurseHeal");
            if (_nurseHealMethod is not null)
                HookEndpointManager.Add(_nurseHealMethod, ModifyNurseHeal);
        }

        public delegate bool ModifyNurseHealDelegate(EModePlayer eModePlayer, NPC nurse, ref int health, ref bool removeDebuffs, ref string chatText);
        private static bool ModifyNurseHeal(ModifyNurseHealDelegate orig, EModePlayer eModePlayer, NPC nurse, ref int health, ref bool removeDebuffs, ref string chatText)
        {
            if (!FargoSoulsWorld.EternityMode)
                return orig.Invoke(eModePlayer, nurse, ref health, ref removeDebuffs, ref chatText);

            if (Main.LocalPlayer.HasBuff(ModContent.BuffType<RushJob>()))
            {
                chatText = "我已经在这有限的时间内尽我所能了！";
                return false;
            }
            return orig.Invoke(eModePlayer, nurse, ref health, ref removeDebuffs, ref chatText);
        }

        public static void Unload()
        {
            if (_nurseHealMethod is not null)
                HookEndpointManager.Remove(_nurseHealMethod, ModifyNurseHeal);
            _nurseHealMethod = null;
        }
    }
}
