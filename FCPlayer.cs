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
            Main.NewText("- Fargo突变 V 2.8.8 更新 -", c);
            string text = @"-调整了Boss权重，再次使其适配Boss列表
-修复了环境领域在多人模式未加载的区块中使用有时会删除方块
-修复了使用物品热键相关问题，例如混沌传送杖在不应当能使用的时候可以使用
-添加了多功能平台转化器
-修复了用蠕虫食物召唤世界吞噬者、用某种金属蠕虫召唤毁灭者时的体节丢失问题
-修复了敌怪召唤物多人模式不同步的问题
-告死精灵和古代符章注明只能在晚上使用";
            string[] textLines = text.Split("-");
            for (int i = 1; i < textLines.Length; i++)
                Main.NewText("-" + textLines[i].Trim(), c);
            Main.NewText("Fargo魂石的内容以及更详细的更新见Bilibili @小小法师的大决心 & @Furgo_", c);
            Main.NewText("感谢使用Fargo汉化补丁！", Color.LightGreen);
            Main.NewText($"[i:Fargowiltas/Deviantt] 288.1425.1更新：调整了三条死亡消息的汉化（Nycro无伤模组会使这些失效）", new Color(255, 102, 255));
            Main.NewText($"[i:{ItemID.UndergroundReward}] 查看模组配置（FCConfig）以调整部分内容！", new Color(255, 51, 51));
            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("注意，现在的Fargo汉化是客户端模组，不会参与服务器的自动同步，若需要开启汉化请提醒你的朋友订阅并在模组列表自行开启！！！"), Color.LightGreen);
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
