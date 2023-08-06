using Mono.Cecil.Cil;
using MonoMod.Cil;
using System.Collections.Generic;
using Terraria.ModLoader;

namespace FargoChinese.Patch.FargowiltasSouls
{
    [JITWhenModsEnabled("FargowiltasSouls")]
    public class DropConditionsTranslate : PatchBase
    {
        protected override bool LoadWithFargoSouls => true;

        public override void Load()
        {
            Terraria.GameContent.UI.Elements.IL_UIBestiaryInfoItemLine.SetBestiaryNotesOnItemCache += UIBestiaryInfoItemLine_SetBestiaryNotesOnItemCache;
        }

        private static void UIBestiaryInfoItemLine_SetBestiaryNotesOnItemCache(ILContext il)
        {
            var c = new ILCursor(il);

            if (!c.TryGotoNext(i => i.MatchCallvirt(typeof(List<string>).GetMethod("Add"))))
                return;
            Replace("Pre-Hardmode Eternity Mode drop rate", "在困难模式之前的永恒模式下的掉落率");
            Replace("Hardmode Eternity Mode drop rate", "在困难模式下的永恒模式下的的掉落率");
            Replace("This is a Master/Eternity Mode drop rate", "这是大师或永恒模式下的掉落率");
            Replace("Non-Eternity Mode drop rate", "在非永恒模式下的掉落率");
            Replace("Eternity Mode drop rate", "在永恒模式下的掉落率");
            Replace("捐赠者掉落 在永恒模式", "在永恒模式下作为捐赠者物品的掉落率");
            Replace("捐赠者掉落", "作为捐赠者物品的掉落率");
            Replace("在血月的丛林", "（在血月期间的丛林）");
            Replace("Tim's Concoction drop rate", "佩戴蒂姆的秘药时的掉落率");
            void Replace(string old, string @new)
            {
                c.Emit(OpCodes.Ldstr, old);
                c.Emit(OpCodes.Ldstr, @new);
                c.Emit(OpCodes.Callvirt, typeof(string).GetMethod("Replace", new[] { typeof(string), typeof(string) }));
            }
        }

        public override void Unload()
        {
            Terraria.GameContent.UI.Elements.IL_UIBestiaryInfoItemLine.SetBestiaryNotesOnItemCache += UIBestiaryInfoItemLine_SetBestiaryNotesOnItemCache;
        }
    }
}
