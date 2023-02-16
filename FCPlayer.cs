using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Chat;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace FargoChinese
{
    public class FCPlayer : ModPlayer
    {
        public override void OnEnterWorld(Player player)
        {
            Color c = Color.Orange;
            Main.NewText("- Fargo突变 V 2.8.7 更新 -", c);
            string text = @"-节日和种子配置添加了一个额外的选项。它可以被设定为正常，意味着对其没有任何改动。
-将突变躯体时装配方中的史莱姆王面具替换为猪龙鱼公爵面具
-祭坛终结者现在在任意砧处合成
-在褴褛蜜蜂之翼、火之羽、邪恶三叉戟的配方中添加了一个神圣锭
-在宇宙坩埚的配方中添加了腐变室
-伐木工现在售卖竹子";
            string[] textLines = text.Split("-");
            for (int i = 1; i < textLines.Length; i++)
                Main.NewText("-" + textLines[i].Trim(), c);
            Main.NewText("Fargo魂内容过多，不便展示，详情见Bilibili@小小法师的大决心&@Furgo_", c);
            Main.NewText("感谢使用Fargo汉化补丁！", Color.LightGreen);
            Main.NewText("287.1412.9更新：添加了永恒与受虐难度在地图选择界面的显示的功能，可以在模组配置中开关（默认开启），若遇到bug可考虑关闭此功能", new Color(0, 255, 255));
            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("注意，现在的Fargo汉化是客户端模组，不会参与服务器的自动同步，若需要开启汉化需要在模组列表自行开启！"), Color.LightGreen);
            }
            /*if (Main.rand.NextBool(1000))
            {
                Main.NewText("恭喜你中了千分之一几率的大奖，这是你的奖品（", Color.Gold);
                int[] items = { ModContent.ItemType<Items.EchBeGone>(), ModContent.ItemType<Fargowiltas.Items.Tiles.EchPainting>() };
                player.QuickSpawnItem(player.GetSource_Misc("FCEchOnEnterWorld"), Main.rand.Next(items));
            }*/
        }
    }
}
