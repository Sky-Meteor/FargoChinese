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
        public override void OnEnterWorld()
        {
            Color c = Color.Orange;
            Main.NewText("Fargo更新后，鉴于代码内和游戏内的诸多问题，汉化的制作遇到更多困难，Fargo汉化也需要一定时间来修补错误，因此，短时间内，Fargo汉化不会更新\n更多解释查看B站 @FallingLeaf落叶 的动态 https://www.bilibili.com/opus/832914516570275889\n注：Fargo突变内容大体没有错误，但Fargo包括突变和魂对于1.4.4及其新种子适配极差，尤其不推荐在新种子中游玩", c);
            /*Main.NewText("- Fargo突变 V 3.0.0 更新 -", c);
            string text = @"-添加了[i:Fargowiltas/PurityTotem] 纯净图腾
-更新到tModLoader 1.4.4";
            string[] textLines = text.Split("-");
            for (int i = 1; i < textLines.Length; i++)
                Main.NewText("-" + textLines[i].Trim(), c);
            Main.NewText("更详细的消息见Bilibili @小小法师的大决心 & @Furgo_", c);*/
            Main.NewText("感谢使用Fargo汉化补丁！", Color.LightGreen);
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
            // Main.changeTheTitle = true;
        }

        /*public override void UpdateEquips()
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
        }*/
    }
}
