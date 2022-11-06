using Fargowiltas.Items.Tiles;
using Terraria.ID;
using Terraria.ModLoader;

namespace FargoChinese.Items
{
    public class EchBeGone : EchPainting
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.createTile = ModContent.TileType<EchBeGoneSheet>();
        }
    }
}