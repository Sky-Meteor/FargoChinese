using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Fargowiltas.Items.Tiles;

namespace FargoChinese.Items
{
    public class EchBeGoneSheet : EchPaintingSheet
    {
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 48, ModContent.ItemType<EchBeGone>());
        }
    }
}