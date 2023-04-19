using MonoMod.Cil;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Terraria.Localization;
using Terraria.ModLoader;

namespace FargoChinese
{
    public static class FCUtils
    {
        public static void InsertAfter(this List<TooltipLine> tooltips, string text, TooltipLine line)
        {
            for (int i = 0; i < tooltips.Count; i++)
            {
                if (tooltips[i].Text.Contains(text))
                    tooltips.Insert(i + 1, line);
            }
        }
        /*public static int Type(this string className)
        {
            ModLoader.TryGetMod("FargowiltasSouls", out Mod fargoSouls);
            fargoSouls.TryFind(className, out ModItem modItem);
            return modItem.Type;
        }*/
        public static void Replace(this TooltipLine tooltip, object old, object @new)
        {
            if (tooltip is null || old.ToString() is null)
                return;
            tooltip.Text = tooltip.Text.Replace(old.ToString()!, @new.ToString());
        }
        public static void FindAndReplace(this List<TooltipLine> tooltips, object old, object @new)
        {
            tooltips.Find(l => l.Text.Contains(old.ToString()!))?.Replace(old, @new);
        }
        public static void FindAndInsertText(this List<TooltipLine> tooltips, object beforeText, object textToAdd)
        {
            tooltips.Find(l => l.Text.Contains(beforeText.ToString()!))?.Replace(beforeText, beforeText + textToAdd.ToString());
        }

        public static void ILTranslate(this ILContext il, string en, string zh)
        {
            var c = new ILCursor(il);
            if (!c.TryGotoNext(i => i.MatchLdstr(en)))
                return;
            c.Index++;
            c.EmitDelegate<Func<string, string>>(_ => zh);
        }

        public static bool IsChinese => Language.ActiveCulture.LegacyId == (int)GameCulture.CultureName.Chinese;
    }
}