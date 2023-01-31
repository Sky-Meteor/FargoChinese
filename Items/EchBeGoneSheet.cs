using Fargowiltas.Items.Tiles;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace FargoChinese.Items
{
    public class EchBeGoneSheet : EchPaintingSheet
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            return false;
        }
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 32, 48, ModContent.ItemType<EchBeGone>());
        }
    }
}