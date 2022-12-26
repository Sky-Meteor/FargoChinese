using MonoMod.RuntimeDetour.HookGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;

namespace FargoChinese
{
    [JITWhenModsEnabled("FargowiltasSouls")]
    public static class DropConditionsTranslate
    {
        public static void Load()
        {
            On.Terraria.GameContent.UI.Elements.UIBestiaryInfoItemLine.SetBestiaryNotesOnItemCache += UIBestiaryInfoItemLine_SetBestiaryNotesOnItemCache;
        }

        private static void UIBestiaryInfoItemLine_SetBestiaryNotesOnItemCache(On.Terraria.GameContent.UI.Elements.UIBestiaryInfoItemLine.orig_SetBestiaryNotesOnItemCache orig, Terraria.GameContent.UI.Elements.UIBestiaryInfoItemLine self, DropRateInfo info)
        {
            List<string> list = new List<string>();
            if (info.conditions == null)
            {
                return;
            }

            foreach (IItemDropRuleCondition condition in info.conditions)
            {
                if (condition != null)
                {
                    string conditionDescription = condition.GetConditionDescription();
                    if (!string.IsNullOrWhiteSpace(conditionDescription))
                    {
                        list.Add(conditionDescription
                            .Replace("Hardmode Eternity Mode drop rate", "在困难模式下的永恒模式下的的掉落率")
                            .Replace("Pre-Hardmode Eternity Mode drop rate", "在困难模式之前的永恒模式下的掉落率")
                            .Replace("This is a Master/Eternity Mode drop rate", "这是大师或永恒模式下的掉落率")
                            .Replace("Non-Eternity Mode drop rate", "在非永恒模式下的掉落率")
                            .Replace("Eternity Mode drop rate", "在永恒模式下的掉落率")
                            .Replace("捐赠者掉落 在永恒模式", "在永恒模式下作为捐赠者物品的掉落率")
                            .Replace("捐赠者掉落", "作为捐赠者物品的掉落率")
                            .Replace("在血月的丛林", "（在血月期间的丛林）")
                            .Replace("Tim's Concoction drop rate", "佩戴蒂姆的秘药时的掉落率"));
                    }
                }
            }

            FieldInfo fi = typeof(Terraria.GameContent.UI.Elements.UIBestiaryInfoItemLine).GetField("_infoDisplayItem", BindingFlags.Instance | BindingFlags.NonPublic);
            Item _infoDisplayItem = fi.GetValue(self) as Item;
            _infoDisplayItem.BestiaryNotes = string.Join("\n", list);
        }

        public static void Unload()
        {
            On.Terraria.GameContent.UI.Elements.UIBestiaryInfoItemLine.SetBestiaryNotesOnItemCache -= UIBestiaryInfoItemLine_SetBestiaryNotesOnItemCache;
        }
    }
}
