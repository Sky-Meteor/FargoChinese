using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;
using Terraria.Chat;
using Microsoft.Xna.Framework;

namespace FargoChinese
{
    public class FCPlayer : ModPlayer
    {
        public override void OnEnterWorld(Player player)
        {
            Main.NewText(@"Fargo突变 - V 2.8.5 更新 -
-添加了晶塔清洁器
-添加了祭坛根除者
-添加了血亲晶塔
-为圣杯添加了合成表
-添加了新配置效果：火把神的恩宠自动替换放置的火把和已放置的火把
-过载南瓜月勋章更新为闹鬼奖杯
-过载探测器更新为火星通讯卫星
-过载调皮礼物更新为调皮礼物袋
-当穿着冥河套时憎恶对它有特殊对话
-当穿着真突变套时突变体对它有特殊对话
-便携日晷现在可以跳过时间到中午和午夜
-恶魔祭坛/猩红祭坛现在在铁砧处制作
-快速房屋现在放置白火把
-重绘了墓碑克星
Fargo魂内容过多，不便展示，详情见Bilibili@小小法师的大决心&@Furgo_", Color.Orange);
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
