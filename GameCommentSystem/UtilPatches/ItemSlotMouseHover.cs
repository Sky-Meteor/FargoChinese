/*using FargoChinese.Patch;
using Terraria;

namespace FargoChinese.GameCommentSystem.UtilPatches
{
    public class ItemSlotMouseHover : PatchBase
    {
        public override void Load()
        {
            Terraria.UI.On_ItemSlot.MouseHover_ItemArray_int_int += ItemSlot_MouseHover_ItemArray_int_int;
        }

        private static void ItemSlot_MouseHover_ItemArray_int_int(Terraria.UI.On_ItemSlot.orig_MouseHover_ItemArray_int_int orig, Item[] inv, int context, int slot)
        {
            orig.Invoke(inv, context, slot);
            FargoMutantItem.MouseHoveringOnInventory41 = slot == 40;
        }

        public override void Unload()
        {
            Terraria.UI.On_ItemSlot.MouseHover_ItemArray_int_int -= ItemSlot_MouseHover_ItemArray_int_int;
        }
    }
}*/