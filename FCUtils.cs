using Mono.Cecil.Cil;
using MonoMod.Cil;

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
            c.Emit(OpCodes.Pop);
            c.Emit(OpCodes.Ldstr, zh);
        }
    }
}