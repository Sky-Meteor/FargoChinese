using Fargowiltas.NPCs;
using MonoMod.RuntimeDetour.HookGen;
using System;
using System.Collections.Generic;
using System.Reflection;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace FargoChinese.Patch.Fargowiltas
{
    public static class ChatButtonsTranslate
    {
        private static List<MethodBase> _methods;
        public static void Load()
        {
            _methods = new List<MethodBase>()
            {
                typeof(Abominationn).GetMethod("SetChatButtons"),
                typeof(Deviantt).GetMethod("SetChatButtons"),
                typeof(LumberJack).GetMethod("SetChatButtons"),
                typeof(Mutant).GetMethod("SetChatButtons"),
                typeof(Squirrel).GetMethod("SetChatButtons")
            };
            static void AddNotNull(MethodBase method, Delegate hookDelegate)
            {
                if (method is not null)
                    HookEndpointManager.Add(method, hookDelegate);
            }
            AddNotNull(_methods[0], AbomButton);
            AddNotNull(_methods[1], DeviButton);
            AddNotNull(_methods[2], LumberButton);
            AddNotNull(_methods[3], MutantButton);
            AddNotNull(_methods[4], SquirrelButton);
        }
        public static void Unload()
        {
            static void RemoveNotNull(MethodBase method, Delegate hookDelegate)
            {
                if (method is not null)
                    HookEndpointManager.Remove(method, hookDelegate);
            }
            RemoveNotNull(_methods[0], AbomButton);
            RemoveNotNull(_methods[1], DeviButton);
            RemoveNotNull(_methods[2], LumberButton);
            RemoveNotNull(_methods[3], MutantButton);
            RemoveNotNull(_methods[4], SquirrelButton);
            _methods = null;
        }

        private static void AbomButton(Abominationn orig, ref string button, ref string button2)
        {
            button = Language.GetTextValue("LegacyInterface.28");
            button2 = "取消事件";
        }
        private static void DeviButton(Deviantt orig, ref string button, ref string button2)
        {
            button = Language.GetTextValue("LegacyInterface.28");
            if (ModLoader.TryGetMod("FargowiltasSouls", out _) && (bool)ModLoader.GetMod("FargowiltasSouls").Call("EternityMode"))
            {
                button2 = "帮助";
            }
        }
        private static void LumberButton(LumberJack orig, ref string button, ref string button2)
        {
            button = Language.GetTextValue("LegacyInterface.28");
            button2 = "树木宝藏";
        }
        private static void MutantButton(Mutant orig, ref string button, ref string button2)
        {
            ModNPC mutant = ModContent.GetModNPC(ModContent.NPCType<Mutant>());
            var shopnum = mutant.GetType().GetField("shopNum", BindingFlags.NonPublic | BindingFlags.Static);
            int shopNum = (int)shopnum.GetValue(shopnum);

            switch (shopNum)
            {
                case 1:
                    button = "困难模式前";
                    break;

                case 2:
                    button = "困难模式";
                    break;

                default:
                    button = "月亮领主后";
                    break;
            }

            if (Main.hardMode)
            {
                button2 = "切换商店";
            }

            if (NPC.downedMoonlord)
            {
                if (shopNum >= 4)
                {
                    shopnum.SetValue(mutant, 1);
                }
            }
            else
            {
                if (shopNum >= 3)
                {
                    shopnum.SetValue(mutant, 1);
                }
            }
        }
        private static void SquirrelButton(Squirrel orig, ref string button, ref string button2)
        {
            ModNPC squirrel = ModContent.GetModNPC(ModContent.NPCType<Squirrel>());
            var showcycleshop = squirrel.GetType().GetField("showCycleShop", BindingFlags.Static | BindingFlags.NonPublic);
            bool showCycleShop = (bool)showcycleshop.GetValue(showcycleshop);
            var shopnum = squirrel.GetType().GetField("shopNum", BindingFlags.NonPublic | BindingFlags.Static);
            int shopNum = (int)shopnum.GetValue(shopnum);

            button = Language.GetTextValue("LegacyInterface.28");
            if (showCycleShop)
            {
                button += $"{shopNum + 1}";
                button2 = "切换商店";
            }
        }
    }
}