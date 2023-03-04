using MonoMod.Cil;
using System;
using Terraria.Localization;

namespace FargoChinese
{
    public static class FCUtils
    {
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