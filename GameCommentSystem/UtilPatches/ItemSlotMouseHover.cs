using FargoChinese.Patch;
using Terraria;

namespace FargoChinese.GameCommentSystem.UtilPatches
{
    public class ItemSlotMouseHover : PatchBase
    {
        public override void Load()
        {
            On.Terraria.UI.ItemSlot.MouseHover_ItemArray_int_int += ItemSlot_MouseHover_ItemArray_int_int;
        }

        private static void ItemSlot_MouseHover_ItemArray_int_int(On.Terraria.UI.ItemSlot.orig_MouseHover_ItemArray_int_int orig, Item[] inv, int context, int slot)
        {
            orig.Invoke(inv, context, slot);
            FargoMutantItem.MouseHoveringOnInventory41 = slot == 40;
        }

        public override void Unload()
        {
            On.Terraria.UI.ItemSlot.MouseHover_ItemArray_int_int -= ItemSlot_MouseHover_ItemArray_int_int;
        }
    }
}