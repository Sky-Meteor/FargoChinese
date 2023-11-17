using Fargowiltas.Items.Tiles;
using Terraria.ModLoader;

namespace FargoChinese.BuildIgnore.Items
{
    public class EchBeGone : EchPainting
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            return false;
        }
        public override void SetDefaults()
        {
            base.SetDefaults();
            Item.createTile = ModContent.TileType<EchBeGoneSheet>();
        }
    }
}