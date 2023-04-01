using FargoChinese.UnmanagedTranslations;
using Fargowiltas;
using Fargowiltas.Items.Weapons;
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
            Main.NewText("- Fargo V 1.4.2 -", c);
            string text = @"-在各个方面都极大改进了模组！
-通过一系列极具吸引力的新机制，彻底改革了游戏玩法！
-额外添加了可供游玩200小时的精雕细琢的内容！
-充分丰满了令人感动万分且富有哲思的刺激传说！
-永久性修复了所有漏洞！
-实现了完美的平衡，再也不需要任何平衡调整了！";
            string[] textLines = text.Split("-");
            for (int i = 1; i < textLines.Length; i++)
                Main.NewText("-" + textLines[i].Trim(), c);
            Main.NewText("详细更新见Bilibili @小小法师的大决心 & @Furgo_", c);
            Main.NewText("感谢使用Fargo汉化补丁！", Color.LightGreen);
            Main.NewText($"[i:{ModContent.ItemType<LumberJaxe>()}] 287.1412.11更新：添加了永恒与受虐难度在地图选择界面显示的功能及动画效果，可以分别在模组配置中开关（默认开启），若遇到bug或卡顿可考虑关闭此功能", new Color(0, 255, 255));
            Main.NewText($"[i:{ItemID.ArchitectGizmoPack}] 287.1412.11更新：修复了Fargo突变的配置：建筑饰品在猪猪存钱罐/保险箱中生效开启，但实际无效果的bug", Main.mouseTextColor);
            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("注意，现在的Fargo汉化是客户端模组，不会参与服务器的自动同步，若需要开启汉化需要在模组列表自行开启！！！"), Color.LightGreen);
            }
            /*if (Main.rand.NextBool(1000))
            {
                Main.NewText("恭喜你中了千分之一几率的大奖，这是你的奖品（", Color.Gold);
                int[] items = { ModContent.ItemType<Items.EchBeGone>(), ModContent.ItemType<Fargowiltas.Items.Tiles.EchPainting>() };
                player.QuickSpawnItem(player.GetSource_Misc("FCEchOnEnterWorld"), Main.rand.Next(items));
            }*/
            // april fools
            Main.changeTheTitle = true;
        }

        public override void UpdateEquips()
        {
            if (ModContent.GetInstance<FargoConfig>().PiggyBankAcc)
            {
                foreach (Item item in Player.bank.item)
                {
                    GlobalItemTranslate.TryPiggyBankAcc(item, Player);
                }

                foreach (Item item in Player.bank2.item)
                {
                    GlobalItemTranslate.TryPiggyBankAcc(item, Player);
                }
            }
        }
    }
}
