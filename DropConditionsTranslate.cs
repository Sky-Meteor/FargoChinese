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
                        if (conditionDescription == "This is a Master/Eternity Mode drop rate")
                            conditionDescription = "这是大师或永恒模式下的掉落率";
                        list.Add(conditionDescription);
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
