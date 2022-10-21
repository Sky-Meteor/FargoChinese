using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace FargoChinese
{
    public class FCPlayer : ModPlayer
    {
        public override void OnEnterWorld(Player player)
        {
            if (Main.rand.NextBool(1000))
            {
                Main.NewText("恭喜你中了千分之一几率的大奖，这是你的奖品（", Color.Gold);
                int[] items = { ModContent.ItemType<Items.EchBeGone>(), ModContent.ItemType<Fargowiltas.Items.Tiles.EchPainting>() };
                player.QuickSpawnItem(player.GetSource_Misc("FCEchOnEnterWorld"), Main.rand.Next(items));
            }
            else
                Main.NewText("感谢使用Fargo汉化补丁！因为Fargo那边有点忙鸽了，所以以后需要继续用一段时间汉化补丁（", Color.LightGreen);
        }
    }
}
