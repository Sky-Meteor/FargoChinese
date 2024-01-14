using FargoChinese.UnmanagedTranslations;
using Fargowiltas;
using Fargowiltas.Common.Configs;
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
            Main.NewText("- Fargo突变 V 3.0.0 更新 -", c);
            string text = @"-v321.1622.2更新：爆裂者更名为爆裂噬魂者
-v321.1622.8更新：尝试解决卸载模组报错的问题";
            string[] textLines = text.Split("-");
            for (int i = 1; i < textLines.Length; i++)
                Main.NewText("-" + textLines[i].Trim(), c);

            Main.NewText("感谢使用Fargo汉化补丁！", Color.LightGreen);
            Main.NewText("", Color.LightGreen);
            Main.NewText($"[i:{ItemID.UndergroundReward}] 查看模组配置（FCConfig）以调整部分内容！", new Color(255, 51, 51));
            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("注意，现在的Fargo汉化是客户端模组，不会参与服务器的自动同步，若需要开启汉化请提醒你的朋友订阅并在模组列表自行开启！！！"), Color.LightGreen);
            }

            Main.NewText("有意向参与汉化工作的玩家可以进灾厄维基汉化组QQ群：660392953（进群需要汉化考核，工作范围包括但不限于灾厄及各附属，Fargo，救赎，星海等等）", Color.OrangeRed);

            // april fools
            // Main.changeTheTitle = true;
        }

        public override void UpdateEquips()
        {
            if (ModContent.GetInstance<FargoServerConfig>().PiggyBankAcc)
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
