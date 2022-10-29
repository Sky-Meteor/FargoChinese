using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace FargoChinese
{
    public class FCPlayer : ModPlayer
    {
        public override void OnEnterWorld(Player player)
        {
            Main.NewText(@"- V 2.8.6 更新 -
-添加了多功能增益站
-为不死矿工召唤物（吸引人的矿物）添加了合成表
-修复了即使在配置关闭时无限时长的buff还能生效的bug
-万用增益站的职业站和蛋糕块增益被移除，因为他们可以在背包里堆叠获得无限时长
-把商人做成旅商的合成表变简单了", Color.Orange);
            Main.NewText("感谢使用Fargo汉化补丁！因为Fargo那边有点忙鸽了，所以以后需要继续用一段时间汉化补丁（", Color.LightGreen);
            if (Main.rand.NextBool(1000))
            {
                Main.NewText("恭喜你中了千分之一几率的大奖，这是你的奖品（", Color.Gold);
                int[] items = { ModContent.ItemType<Items.EchBeGone>(), ModContent.ItemType<Fargowiltas.Items.Tiles.EchPainting>() };
                player.QuickSpawnItem(player.GetSource_Misc("FCEchOnEnterWorld"), Main.rand.Next(items));
            }
        }
    }
}
