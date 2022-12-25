using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace FargoChinese
{
    public class FCPlayer : ModPlayer
    {
        public override void OnEnterWorld(Player player)
        {
            Main.NewText(@"- Fargo突变 V 2.8.6 更新 -
-添加了多功能增益站
-添加了万用平台转化器
-添加了洁晶灵的贴图
-添加了祭坛终结者的贴图
-为吸引人的矿物（不死矿工召唤物）添加了合成表
-为茄子（骷髅博士召唤物）添加了合成表
-添加了几条在憎恶商店解锁南瓜月/霜月敌怪的召唤物时显示的通知
-蜂王在场时强制把周围环境设为丛林，就像世纪之花一样
-城市克星不会滚动了
-炸弹商会以略高于材料售价的价格售卖爆炸手里剑
-巫医在骷髅王后会买施法桌
-更新了爆炸手里剑的物品信息
-更新了半程地狱直通车的物品信息，阐明它在一定深度以下不会生效
-调整了圣杯（蒂姆召唤物）合成表
-调整了伐木工的树木宝藏让其可以提供更多小动物
-丛林神庙炸弹现在在你与祭坛有一定距离时也能使用
-宇宙坩埚包含了金染缸
-修复了即使在配置关闭时无限时长的buff还能生效的bug
-万用增益站的职业站和蛋糕块增益被移除，因为他们可以在背包里堆叠获得无限时长
-无尽职业增益站/蛋糕块增益的数量需求从15减少到3
-把商人做成旅商的合成表变简单了
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
