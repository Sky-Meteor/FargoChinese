using FargowiltasSouls;
using FargowiltasSouls.Buffs.Masomode;
using MonoMod.RuntimeDetour.HookGen;
using System.Reflection;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace FargoChinese.Patch.FargowiltasSouls
{
    [JITWhenModsEnabled("FargowiltasSouls")]
    public static class NurseCantHealTranslate
    {
        private static MethodBase method = typeof(EModePlayer).GetMethod("ModifyNurseHeal");
        public static void Load()
        {
            if (method is null)
                return;
            HookEndpointManager.Add(method, ModifyNurseHeal);
            //HookEndpointManager.Modify(method, Manipulate);
        }
        public delegate bool ModifyNurseHealDelegate(EModePlayer eModePlayer, NPC nurse, ref int health, ref bool removeDebuffs, ref string chatText);
        private static bool ModifyNurseHeal(ModifyNurseHealDelegate orig, EModePlayer eModePlayer, NPC nurse, ref int health, ref bool removeDebuffs, ref string chatText)
        {
            if (Main.LocalPlayer.HasBuff(ModContent.BuffType<RushJob>()))
            {
                chatText = "我已经在这有限的时间内尽我所能了！";
                return false;
            }
            return orig.Invoke(eModePlayer, nurse, ref health, ref removeDebuffs, ref chatText);
        }
        /*private static void Manipulate(ILContext i)
        {
            ILCursor c = new ILCursor(i);
            if (!c.TryGotoNext(il => il.MatchLdstr("I've done all I can in the time I have!")))
                return;
            c.Index++;
            c.Emit(OpCodes.Pop);
            c.Emit(OpCodes.Ldstr, "我已经在这有限的时间内尽我所能了！");
        }*/

        public static void Unload()
        {
            if (method is not null)
                HookEndpointManager.Remove(method, ModifyNurseHeal);
                //HookEndpointManager.Unmodify(method, Manipulate);
            method = null;
        }
    }
}
