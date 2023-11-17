using System;
using System.Collections.Generic;
using System.Reflection;
using FargowiltasSouls.Content.Buffs.Masomode;
using FargowiltasSouls.Core.ModPlayers;
using FargowiltasSouls.Core.Systems;
using Terraria;
using Terraria.ModLoader;

namespace FargoChinese.Patch.FargowiltasSouls
{
    [JITWhenModsEnabled("FargowiltasSouls")]
    public class NurseCantHealTranslate : PatchBase
    {
        public override bool IsLoadingEnabled() => LoadWithFargoSouls();

        public override Dictionary<Type, Tuple<string, BindingFlags, bool, Delegate>> MethodInfos =>
            new()
            {
                {typeof(EModePlayer), new Tuple<string, BindingFlags, bool, Delegate>("ModifyNurseHeal", BindingFlags.Public | BindingFlags.Instance, true, ModifyNurseHeal)}
            };

        private delegate bool ModifyNurseHealDelegate(EModePlayer eModePlayer, NPC nurse, ref int health, ref bool removeDebuffs, ref string chatText);
        private static bool ModifyNurseHeal(ModifyNurseHealDelegate orig, EModePlayer eModePlayer, NPC nurse, ref int health, ref bool removeDebuffs, ref string chatText)
        {
            if (!WorldSavingSystem.EternityMode)
                return orig.Invoke(eModePlayer, nurse, ref health, ref removeDebuffs, ref chatText);

            if (Main.LocalPlayer.HasBuff(ModContent.BuffType<RushJobBuff>()))
            {
                chatText = "我已经在这有限的时间内尽我所能了！";
                return false;
            }

            return orig.Invoke(eModePlayer, nurse, ref health, ref removeDebuffs, ref chatText);
        }
    }
}
