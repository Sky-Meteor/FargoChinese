using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Fargowiltas.NPCs;
using Microsoft.Xna.Framework;
using Terraria.Audio;

namespace FargoChinese.Patch
{
    public static class ChatMessagesTranslate
    {
        public static void Load()
        {
            On.Terraria.Main.NewText_string_byte_byte_byte += NewText_string_byte_byte_byte;
            On.Terraria.Main.NewTextMultiline += NewTextMultiline;
        }
        private static void NewText_string_byte_byte_byte(On.Terraria.Main.orig_NewText_string_byte_byte_byte orig, string newText, byte R = byte.MaxValue, byte G = byte.MaxValue, byte B = byte.MaxValue)
        {
            #region Fargowiltas
            #region Items
            if (newText.StartsWith("Battle Cry ") && newText.Contains(Main.player[0].name) && newText.EndsWith("!") && R == 255 && G == 0 && B == 0)
            {
                if (!newText.Contains("deactivated"))
                    orig.Invoke($"战争号角已对{Main.player[0].name}生效！", R, G, B);
                else
                    orig.Invoke($"战争号角已对{Main.player[0].name}停止生效！", R, G, B);
            }
            else if (newText.StartsWith("Calming Cry ") && newText.Contains(Main.player[0].name) && newText.EndsWith(".") && R == 0 && G == 255 && B == 255)
            {
                if (!newText.Contains("deactivated"))
                    orig.Invoke($"镇静号角已对{Main.player[0].name}生效。", R, G, B);
                else
                    orig.Invoke($"镇静号角已对{Main.player[0].name}停止生效。", R, G, B);
            }
            else if (newText.StartsWith("researched ") && newText.EndsWith(" items"))
            {
                for (int i = 0; i < int.MaxValue; i++)
                {
                    if (newText == $"researched {i} items")
                    {
                        orig.Invoke($"已研究{i}个物品", R, G, B);
                        break;
                    }
                }
            }
            else if (newText == "Expert mode is now enabled!" && R == 175 && G == 75 && B == 255)
                orig.Invoke("专家模式已开启！", R, G, B);
            else if (newText == "Master mode is now enabled!" && R == 175 && G == 75 && B == 255)
                orig.Invoke("大师模式已开启！", R, G, B);
            else if (newText == "Journey mode is now enabled!" && R == 175 && G == 75 && B == 255)
                orig.Invoke("旅行模式已开启！", R, G, B);
            else if (newText == "Normal mode is now enabled!" && R == 175 && G == 75 && B == 255)
                orig.Invoke("经典模式已开启！", R, G, B);
            #region Summons
            else if ((newText.EndsWith(" has awoken!") || newText.EndsWith(" have awoken!")) && R == 175 && G == 75 && B == 255)
            {
                string awoken1 = newText.Replace(" has awoken!", "已苏醒！");
                string awoken2 = awoken1.Replace(" have awoken!", "已苏醒！");

                void Replace(string en, string zh) => orig.Invoke(awoken2.Replace(en, zh), R, G, B);

                switch (awoken2.Replace("已苏醒！", ""))
                {
                    #region Abom
                    case "Ogre":
                        Replace("Ogre", "食人魔");
                        break;
                    case "Betsy":
                        Replace("Betsy", "双足翼龙");
                        break;
                    case "Everscream":
                        Replace("Everscream", "常绿尖叫怪");
                        break;
                    case "Dark Mage":
                        Replace("Dark Mage", "黑暗魔法师");
                        break;
                    case "Headless Horseman":
                        Replace("Headless Horseman", "无头骑士");
                        break;
                    case "Ice Queen":
                        Replace("Ice Queen", "冰雪女王");
                        break;
                    case "Martian Saucer":
                        Replace("Martian Saucer", "火星飞碟");
                        break;
                    case "Santa-NK1":
                        Replace("Santa-NK1", "圣诞坦克");
                        break;
                    case "The Celestial Pillars":
                        Replace("The Celestial Pillars", "天界柱");
                        break;
                    case "Mourning Wood":
                        Replace("Mourning Wood", "哀木");
                        break;
                    case "Pumpking":
                        Replace("Pumpking", "南瓜王");
                        break;
                    #endregion
                    #region Devi
                    case "Medusa":
                        Replace("Medusa", "蛇发女妖");
                        break;
                    case "Undead Miner":
                        Replace("Undead Miner", "不死矿工");
                        break;
                    case "Dreadnautilus":
                        Replace("Dreadnautilus", "恐惧鹦鹉螺");
                        break;
                    case "Blood Eel":
                        Replace("Blood Eel", "血鳗鱼");
                        break;
                    case "Wyvern":
                        Replace("Wyvern", "飞龙");
                        break;
                    case "Clown":
                        Replace("Clown", "小丑");
                        break;
                    case "Ice Golem":
                        Replace("Ice Golem", "冰雪巨人");
                        break;
                    case "Corrupt Mimic":
                        Replace("Corrupt Mimic", "腐化宝箱怪");
                        break;
                    case "Crimson Mimic":
                        Replace("Crimson Mimic", "猩红宝箱怪");
                        break;
                    case "Red Devil":
                        Replace("Red Devil", "红魔鬼");
                        break;
                    case "Rainbow Slime":
                        Replace("Rainbow Slime", "彩虹史莱姆");
                        break;
                    case "Doctor Bones":
                        Replace("Doctor Bones", "骷髅博士");
                        break;
                    case "Sand Elemental":
                        Replace("Sand Elemental", "沙尘精");
                        break;
                    case "Gnome":
                        Replace("Gnome", "侏儒");
                        break;
                    case "Goblin Scout":
                        Replace("Goblin Scout", "哥布林侦察兵");
                        break;
                    case "Golden Slime":
                        Replace("Golden Slime", "金史莱姆");
                        break;
                    case "Paladin":
                        Replace("Paladin", "圣骑士");
                        break;
                    case "Hallowed Mimic":
                        Replace("Hallowed Mimic", "神圣宝箱怪");
                        break;
                    case "Nymph":
                        Replace("Nymph", "宁芙");
                        break;
                    case "Hemogoblin Shark":
                        Replace("Hemogoblin Shark", "血浆哥布林鲨鱼");
                        break;
                    case "Tim":
                        Replace("Tim", "蒂姆");
                        break;
                    case "Jungle Mimic":
                        Replace("Jungle Mimic", "丛林宝箱怪");
                        break;
                    case "Bone Lee":
                        Replace("Bone Lee", "骷髅李小龙");
                        break;
                    case "Moth":
                        Replace("Moth", "蛾");
                        break;
                    case "Mothron":
                        Replace("Mothron", "蛾怪");
                        break;
                    case "Nailhead":
                        Replace("Nailhead", "钉头");
                        break;
                    case "Pinky":
                        Replace("Pinky", "粉史莱姆");
                        break;
                    case "Pirate Captain":
                        Replace("Pirate Captain", "海盗船长");
                        break;
                    case "Flying Dutchman":
                        Replace("Flying Dutchman", "荷兰飞盗船");
                        break;
                    case "Rune Wizard":
                        Replace("Rune Wizard", "符文巫师");
                        break;
                    case "Goblin Summoner":
                        Replace("Goblin Summoner", "哥布林召唤师");
                        break;
                    case "Dungeon Slime":
                        Replace("Dungeon Slime", "地牢史莱姆");
                        break;
                    case "Mimic":
                        Replace("Mimic", "宝箱怪");
                        break;
                    case "Digger":
                        Replace("Digger", "挖掘怪");
                        break;
                    case "Giant Worm":
                        Replace("Giant Worm", "巨型蠕虫");
                        break;
                    #endregion
                    #region Mutant
                    case "Every boss":
                        Replace("Every boss", "所有boss");
                        break;
                    case "Lunatic Cultist":
                        Replace("Lunatic Cultist", "拜月教邪教徒");
                        break;
                    case "Several bosses":
                        Replace("Several bosses", "数个boss");
                        break;
                    case "Queen Slime":
                        Replace("Queen Slime", "史莱姆皇后");
                        break;
                    case "Plantera":
                        Replace("Plantera", "世纪之花");
                        break;
                    case "Empress of Light":
                        Replace("Empress of Light", "光之女皇");
                        break;
                    case "Dungeon Guardian":
                        Replace("Dungeon Guardian", "地牢守卫");
                        break;
                    case "Skeletron":
                        Replace("Skeletron", "骷髅王");
                        break;
                    #endregion
                    #region Vanilla
                    case "Queen Bee":
                        Replace("Queen Bee", "蜂王");
                        break;
                    case "Moon Lord":
                        Replace("Moon Lord", "月亮领主");
                        break;
                    case "Deerclops":
                        Replace("Deerclops", "独眼巨鹿");
                        break;
                    case "Brain of Cthulhu":
                        Replace("Brain of Cthulhu", "克苏鲁之脑");
                        break;
                    case "Golem":
                        Replace("Golem", "石巨人");
                        break;
                    case "The Twins":
                        Replace("The Twins", "双子魔眼");
                        break;
                    case "Skeletron Prime":
                        Replace("Skeletron Prime", "机械骷髅王");
                        break;
                    case "The Destroyer":
                        Replace("The Destroyer", "毁灭者");
                        break;
                    case "King Slime":
                        Replace("King Slime", "史莱姆王");
                        break;
                    case "Eye of Cthulhu":
                        Replace("Eye of Cthulhu", "克苏鲁之眼");
                        break;
                    case "Duke Fishron":
                        Replace("Duke Fishron", "猪龙鱼公爵");
                        break;
                    case "Eater of Worlds":
                        Replace("Eater of Worlds", "世界吞噬怪");
                        break;
                    #endregion
                    default:
                        orig.Invoke(awoken2, R, G, B);
                        break;
                }
            }
            else if (newText == "The wind begins howling." && R == 175 && G == 75 && B == 255)
                orig.Invoke("狂风开始怒号。", R, G, B);
            else if (newText == "A sandstorm has begun." && R == 175 && G == 75 && B == 255)
                orig.Invoke("沙尘暴开始了。", R, G, B);
            else if (newText == "Lantern Night rate increased!" && R == 175 && G == 75 && B == 255)
                orig.Invoke("出现灯笼夜的概率提高了！", R, G, B);
            //The Celestial Pillars have awoken!
            else if (newText == "Lantern Night rate restored to default." && R == 175 && G == 75 && B == 255)
                orig.Invoke("出现灯笼夜的概率恢复正常。", R, G, B);
            else if (newText == "Rain clouds cover the sky." && R == 175 && G == 75 && B == 255)
                orig.Invoke("雨云遮住了天空。", R, G, B);
            #region Swarm
            else if (newText == "A deafening buzz pierces through you!" && R == 175 && G == 75 && B == 255)
                orig.Invoke("震耳欲聋的嗡嗡声穿透了你！", R, G, B);
            else if (newText == "The real Old One's Army is attacking!" && R == 175 && G == 75 && B == 255)
                orig.Invoke("真正的撒旦大军来袭！", R, G, B);
            else if (newText == "You feel dumb among so many brains!" && R == 175 && G == 75 && B == 255)
                orig.Invoke("在这么多聪颖的大脑中间，你觉得自己很笨！", R, G, B);
            else if (newText == "Defeaning chants fill your ears!" && R == 175 && G == 75 && B == 255)
                orig.Invoke("反抗的圣歌回响在你的耳畔！", R, G, B);
            else if (newText == "You feel like you're in a library!" && R == 175 && G == 75 && B == 255)
                orig.Invoke("你感觉你身在图书馆！", R, G, B);
            else if (newText == "The Constant takes over!" && R == 175 && G == 75 && B == 255)
                orig.Invoke("永恒领域的生物大肆入侵！", R, G, B);
            else if (newText == "The planet trembles from the core!" && R == 175 && G == 75 && B == 255)
                orig.Invoke("整颗星球从核心开始颤抖！", R, G, B);
            else if (newText == "Bullet heaven is descending!" && R == 175 && G == 75 && B == 255)
                orig.Invoke("弹幕天堂正在降临！", R, G, B);
            else if (newText == "Countless eyes pierce the veil staring in your direction!" && R == 175 && G == 75 && B == 255)
                orig.Invoke("无数眼睛刺破面纱看透了你！", R, G, B);
            else if (newText == "The ocean swells with ferocious pigs!" && R == 175 && G == 75 && B == 255)
                orig.Invoke("海洋被凶猛的猪们搅的天翻地覆！", R, G, B);
            else if (newText == "The Frost Moon is rising..." && R == 175 && G == 75 && B == 255)
                orig.Invoke("霜月正在升起……", R, G, B);
            else if (newText == "The Frost Moon fades away!" && R == 175 && G == 75 && B == 255)
                orig.Invoke("霜月消逝……", R, G, B);
            else if (newText == "Wave: 20: Everything" && R == 175 && G == 75 && B == 255)
                orig.Invoke("波数：20：一切", R, G, B);
            else if (newText == "The goblins have calmed down!" && R == 175 && G == 75 && B == 255)
                orig.Invoke("哥布林们冷静下来了！", R, G, B);
            else if (newText == "Ancient automatons come crashing down!" && R == 175 && G == 75 && B == 255)
                orig.Invoke("古老的机器人接连从天上落下！", R, G, B);
            else if (newText == "The martians have calmed down!" && R == 175 && G == 75 && B == 255)
                orig.Invoke("火星人们冷静下来了！", R, G, B);
            else if (newText == "The wind whispers of death's approach!" && R == 175 && G == 75 && B == 255)
                orig.Invoke("逼近死亡之风呢喃不已……", R, G, B);
            else if (newText == "The pirates have calmed down!" && R == 175 && G == 75 && B == 255)
                orig.Invoke("海盗们冷静下来了！", R, G, B);
            else if (newText == "The jungle beats as one!" && R == 175 && G == 75 && B == 255)
                orig.Invoke("丛林万物的心跳合而为一！", R, G, B);
            else if (newText == "A sickly chill envelops the world!" && R == 175 && G == 75 && B == 255)
                orig.Invoke("一股恶心的寒气笼罩着整个世界！", R, G, B);
            else if (newText == "The Pumpkin Moon is rising..." && R == 175 && G == 75 && B == 255)
                orig.Invoke("南瓜月正在升起……", R, G, B);
            else if (newText == "The Pumpkin Moon fades away!" && R == 175 && G == 75 && B == 255)
                orig.Invoke("南瓜月消逝……", R, G, B);
            else if (newText == "Welcome to the truer slime rain!" && R == 175 && G == 75 && B == 255)
                orig.Invoke("欢迎来到名副其实的史莱姆雨！", R, G, B);
            else if (newText == "A great clammering of bones rises from the dungeon!" && R == 175 && G == 75 && B == 255)
                orig.Invoke("骨头的碰撞声从地牢中升腾而起！", R, G, B);
            else if (newText == "Welcome to the true slime rain!" && R == 175 && G == 75 && B == 255)
                orig.Invoke("欢迎来到真正的史莱姆雨！", R, G, B);
            else if (newText == "A legion of glowing iris sing a dreadful song!" && R == 175 && G == 75 && B == 255)
                orig.Invoke("一群发光的虹膜唱着可怕的歌！", R, G, B);
            else if (newText == "A fortress of flesh arises from the depths!" && R == 175 && G == 75 && B == 255)
                orig.Invoke("一个血肉堡垒从深处升起！", R, G, B);
            else if (newText == "The ground shifts with formulated precision!" && R == 175 && G == 75 && B == 255)
                orig.Invoke("地面以公式化的精度颤动！", R, G, B);
            #endregion
            #endregion
            #endregion
            #region NPCs
            else if (newText == "Betsy has been defeated!" && R == 175 && G == 75 && B == 0)
                orig.Invoke("双足翼龙已被打败！", R, G, B);
            else if (newText.StartsWith("Killed: ") && R == 206 && G == 12 && B == 15)
            {
                string text = newText.Replace("Killed: ", "击杀数：");
                orig.Invoke(text, R, G, B);
            }
            else if (newText.StartsWith("Total: ") && R == 206 && G == 12 && B == 15)
            {
                string text = newText.Replace("Total: ", "总计：");
                orig.Invoke(text, R, G, B);
            }
            else if (newText == "The swarm has been defeated!" && R == 206 && G == 12 && B == 15)
            {
                orig.Invoke("这群怪物已被打败！", R, G, B);
            }
            #endregion
            #region Utils
            else if (newText == $"A new item has been unlocked in Deviantt's shop!" && R == Color.HotPink.R && G == Color.HotPink.G && B == Color.HotPink.B)
                orig.Invoke("戴薇安解锁了新商品！", R, G, B);
            else if (newText == $"A new item has been unlocked in Abominationn's shop!" && R == Color.Orange.R && G == Color.Orange.G && B == Color.Orange.B)
                orig.Invoke("憎恶解锁了新商品！", R, G, B);
            #endregion
            #region Fargowiltas
            else if (newText == "The invaders have left!" && R == 175 && G == 75 && B == 255)
                orig.Invoke("入侵者已离开！", R, G, B);
            else if (newText == "The Pumpkin Moon is lowering..." && R == 175 && G == 75 && B == 255)
                orig.Invoke("南瓜月正在降下……", R, G, B);
            else if (newText == "The Frost Moon is lowering..." && R == 175 && G == 75 && B == 255)
                orig.Invoke("霜月正在降下……", R, G, B);
            else if (newText == "A solar eclipse is not happening!" && R == 175 && G == 75 && B == 255)
                orig.Invoke("日食停止发生！", R, G, B);
            else if (newText == "The blood moon is descending..." && R == 175 && G == 75 && B == 255)
                orig.Invoke("血月正在降下……", R, G, B);
            else if (newText == "The wind has ended!" && R == 175 && G == 75 && B == 255)
                orig.Invoke("狂风已经平息！", R, G, B);
            else if (newText == "The Old One's Army is leaving!" && R == 175 && G == 75 && B == 255)
                orig.Invoke("旧日军团正在离开！", R, G, B);
            else if (newText == "The sandstorm has ended!" && R == 175 && G == 75 && B == 255)
                orig.Invoke("沙尘暴已结束！", R, G, B);
            else if (newText == "Celestial creatures are not invading!" && R == 175 && G == 75 && B == 255)
                orig.Invoke("天界生物停止入侵！", R, G, B);
            else if (newText == "The rain has ended!" && R == 175 && G == 75 && B == 255)
                orig.Invoke("雨停了！", R, G, B);
            #endregion
            #endregion
            #region FargowiltasSouls
            else if (newText == "Toggles saved to custom set 1!")
                orig.Invoke("已将饰品效果设置保存至自定义效果配置1！", R, G, B);
            else if (newText == "Toggles saved to custom set 2!")
                orig.Invoke("已将饰品效果设置保存至自定义效果配置2！", R, G, B);
            else if (newText == "Toggles saved to custom set 3!")
                orig.Invoke("已将饰品效果设置保存至自定义效果配置3！", R, G, B);
            else if (newText == "No toggles found in custom set 1.")
                orig.Invoke("在自定义效果配置1中未找到饰品效果设置。", R, G, B);
            else if (newText == "No toggles found in custom set 2.")
                orig.Invoke("在自定义效果配置2中未找到饰品效果设置。", R, G, B);
            else if (newText == "No toggles found in custom set 3.")
                orig.Invoke("在自定义效果配置3中未找到饰品效果设置。", R, G, B);
            #endregion
            else
                orig.Invoke(newText, R, G, B);
        }
        private static void NewTextMultiline(On.Terraria.Main.orig_NewTextMultiline orig, string text, bool force = false, Color c = default, int WidthLimit = -1)
        {
            #region Fargowiltas
            #region Items
            if (text.StartsWith("Battle Cry ") && text.EndsWith("!") && c == new Color(255, 0, 0))
            {
                if (!text.Contains("deactivated"))
                {
                    string realtext = text.Replace("Battle Cry activated for ", "战争号角已对");
                    string realtext1 = realtext.Replace("!", "生效！");
                    orig.Invoke(realtext1, force, c, WidthLimit);
                }
                else
                {
                    string realtext = text.Replace("Battle Cry deactivated for ", "战争号角已对");
                    string realtext2 = realtext.Replace("!", "停止生效！");
                    orig.Invoke(realtext2, force, c, WidthLimit);
                }
            }
            else if (text.StartsWith("Calming Cry ") && text.EndsWith(".") && c == new Color(0, 255, 255))
            {
                if (!text.Contains("deactivated"))
                {
                    string realtext = text.Replace("Calming Cry activated for ", "镇静号角已对");
                    string realtext1 = realtext.Replace(".", "生效。");
                    orig.Invoke(realtext1, force, c, WidthLimit);
                }
                else
                {
                    string realtext = text.Replace("Calming Cry deactivated for ", "镇静号角已对");
                    string realtext2 = realtext.Replace(".", "停止生效。");
                    orig.Invoke(realtext2, force, c, WidthLimit);
                }
            }
            else if (text.StartsWith("researched ") && text.EndsWith(" items"))
            {
                for (int i = 0; i < int.MaxValue; i++)
                {
                    if (text == $"researched {i} items")
                    {
                        orig.Invoke($"已研究{i}个物品", force, c, WidthLimit);
                        break;
                    }
                }
            }
            else if (text == "Expert mode is now enabled!" && c == new Color(175, 75, 255))
                orig.Invoke("专家模式已开启！", force, c, WidthLimit);
            else if (text == "Master mode is now enabled!" && c == new Color(175, 75, 255))
                orig.Invoke("大师模式已开启！", force, c, WidthLimit);
            else if (text == "Journey mode is now enabled!" && c == new Color(175, 75, 255))
                orig.Invoke("旅行模式已开启！", force, c, WidthLimit);
            else if (text == "Normal mode is now enabled!" && c == new Color(175, 75, 255))
                orig.Invoke("经典模式已开启！", force, c, WidthLimit);
            #region Summons
            else if ((text.EndsWith(" has awoken!") || text.EndsWith(" have awoken!")) && c == new Color(175, 75, 255))
            {
                string awoken1 = text.Replace(" has awoken!", "已苏醒！");
                string awoken2 = awoken1.Replace(" have awoken!", "已苏醒！");

                void Replace(string en, string zh) => orig.Invoke(awoken2.Replace(en, zh), force, c, WidthLimit);

                switch (awoken2.Replace("已苏醒！", ""))
                {
                    #region Abom
                    case "Ogre":
                        Replace("Ogre", "食人魔");
                        break;
                    case "Betsy":
                        Replace("Betsy", "双足翼龙");
                        break;
                    case "Everscream":
                        Replace("Everscream", "常绿尖叫怪");
                        break;
                    case "Dark Mage":
                        Replace("Dark Mage", "黑暗魔法师");
                        break;
                    case "Headless Horseman":
                        Replace("Headless Horseman", "无头骑士");
                        break;
                    case "Ice Queen":
                        Replace("Ice Queen", "冰雪女王");
                        break;
                    case "Martian Saucer":
                        Replace("Martian Saucer", "火星飞碟");
                        break;
                    case "Santa-NK1":
                        Replace("Santa-NK1", "圣诞坦克");
                        break;
                    case "The Celestial Pillars":
                        Replace("The Celestial Pillars", "天界柱");
                        break;
                    case "Mourning Wood":
                        Replace("Mourning Wood", "哀木");
                        break;
                    case "Pumpking":
                        Replace("Pumpking", "南瓜王");
                        break;
                    #endregion
                    #region Devi
                    case "Medusa":
                        Replace("Medusa", "蛇发女妖");
                        break;
                    case "Undead Miner":
                        Replace("Undead Miner", "不死矿工");
                        break;
                    case "Dreadnautilus":
                        Replace("Dreadnautilus", "恐惧鹦鹉螺");
                        break;
                    case "Blood Eel":
                        Replace("Blood Eel", "血鳗鱼");
                        break;
                    case "Wyvern":
                        Replace("Wyvern", "飞龙");
                        break;
                    case "Clown":
                        Replace("Clown", "小丑");
                        break;
                    case "Ice Golem":
                        Replace("Ice Golem", "冰雪巨人");
                        break;
                    case "Corrupt Mimic":
                        Replace("Corrupt Mimic", "腐化宝箱怪");
                        break;
                    case "Crimson Mimic":
                        Replace("Crimson Mimic", "猩红宝箱怪");
                        break;
                    case "Red Devil":
                        Replace("Red Devil", "红魔鬼");
                        break;
                    case "Rainbow Slime":
                        Replace("Rainbow Slime", "彩虹史莱姆");
                        break;
                    case "Doctor Bones":
                        Replace("Doctor Bones", "骷髅博士");
                        break;
                    case "Sand Elemental":
                        Replace("Sand Elemental", "沙尘精");
                        break;
                    case "Gnome":
                        Replace("Gnome", "侏儒");
                        break;
                    case "Goblin Scout":
                        Replace("Goblin Scout", "哥布林侦察兵");
                        break;
                    case "Golden Slime":
                        Replace("Golden Slime", "金史莱姆");
                        break;
                    case "Paladin":
                        Replace("Paladin", "圣骑士");
                        break;
                    case "Hallowed Mimic":
                        Replace("Hallowed Mimic", "神圣宝箱怪");
                        break;
                    case "Nymph":
                        Replace("Nymph", "宁芙");
                        break;
                    case "Hemogoblin Shark":
                        Replace("Hemogoblin Shark", "血浆哥布林鲨鱼");
                        break;
                    case "Tim":
                        Replace("Tim", "蒂姆");
                        break;
                    case "Jungle Mimic":
                        Replace("Jungle Mimic", "丛林宝箱怪");
                        break;
                    case "Bone Lee":
                        Replace("Bone Lee", "骷髅李小龙");
                        break;
                    case "Moth":
                        Replace("Moth", "蛾");
                        break;
                    case "Mothron":
                        Replace("Mothron", "蛾怪");
                        break;
                    case "Nailhead":
                        Replace("Nailhead", "钉头");
                        break;
                    case "Pinky":
                        Replace("Pinky", "粉史莱姆");
                        break;
                    case "Pirate Captain":
                        Replace("Pirate Captain", "海盗船长");
                        break;
                    case "Flying Dutchman":
                        Replace("Flying Dutchman", "荷兰飞盗船");
                        break;
                    case "Rune Wizard":
                        Replace("Rune Wizard", "符文巫师");
                        break;
                    case "Goblin Summoner":
                        Replace("Goblin Summoner", "哥布林召唤师");
                        break;
                    case "Dungeon Slime":
                        Replace("Dungeon Slime", "地牢史莱姆");
                        break;
                    case "Mimic":
                        Replace("Mimic", "宝箱怪");
                        break;
                    case "Digger":
                        Replace("Digger", "挖掘怪");
                        break;
                    case "Giant Worm":
                        Replace("Giant Worm", "巨型蠕虫");
                        break;
                    #endregion
                    #region Mutant
                    case "Every boss":
                        Replace("Every boss", "所有boss");
                        break;
                    case "Lunatic Cultist":
                        Replace("Lunatic Cultist", "拜月教邪教徒");
                        break;
                    case "Several bosses":
                        Replace("Several bosses", "数个boss");
                        break;
                    case "Queen Slime":
                        Replace("Queen Slime", "史莱姆皇后");
                        break;
                    case "Plantera":
                        Replace("Plantera", "世纪之花");
                        break;
                    case "Empress of Light":
                        Replace("Empress of Light", "光之女皇");
                        break;
                    case "Dungeon Guardian":
                        Replace("Dungeon Guardian", "地牢守卫");
                        break;
                    case "Skeletron":
                        Replace("Skeletron", "骷髅王");
                        break;
                    #endregion
                    #region Vanilla
                    case "Queen Bee":
                        Replace("Queen Bee", "蜂王");
                        break;
                    case "Moon Lord":
                        Replace("Moon Lord", "月亮领主");
                        break;
                    case "Deerclops":
                        Replace("Deerclops", "独眼巨鹿");
                        break;
                    case "Brain of Cthulhu":
                        Replace("Brain of Cthulhu", "克苏鲁之脑");
                        break;
                    case "Golem":
                        Replace("Golem", "石巨人");
                        break;
                    case "The Twins":
                        Replace("The Twins", "双子魔眼");
                        break;
                    case "Skeletron Prime":
                        Replace("Skeletron Prime", "机械骷髅王");
                        break;
                    case "The Destroyer":
                        Replace("The Destroyer", "毁灭者");
                        break;
                    case "King Slime":
                        Replace("King Slime", "史莱姆王");
                        break;
                    case "Eye of Cthulhu":
                        Replace("Eye of Cthulhu", "克苏鲁之眼");
                        break;
                    case "Duke Fishron":
                        Replace("Duke Fishron", "猪龙鱼公爵");
                        break;
                    case "Eater of Worlds":
                        Replace("Eater of Worlds", "世界吞噬怪");
                        break;
                    #endregion
                    default:
                        orig.Invoke(awoken2, force, c, WidthLimit);
                        break;
                }
            }
            else if (text == "The wind begins howling." && c == new Color(175, 75, 255))
                orig.Invoke("狂风开始怒号。", force, c, WidthLimit);
            else if (text == "A sandstorm has begun." && c == new Color(175, 75, 255))
                orig.Invoke("沙尘暴开始了。", force, c, WidthLimit);
            else if (text == "Lantern Night rate increased!" && c == new Color(175, 75, 255))
                orig.Invoke("出现灯笼夜的概率提高了！", force, c, WidthLimit);
            //The Celestial Pillars have awoken!
            else if (text == "Lantern Night rate restored to default." && c == new Color(175, 75, 255))
                orig.Invoke("出现灯笼夜的概率恢复正常。", force, c, WidthLimit);
            else if (text == "Rain clouds cover the sky." && c == new Color(175, 75, 255))
                orig.Invoke("雨云遮住了天空。", force, c, WidthLimit);
            #region Swarm
            else if (text == "A deafening buzz pierces through you!" && c == new Color(175, 75, 255))
                orig.Invoke("震耳欲聋的嗡嗡声穿透了你！", force, c, WidthLimit);
            else if (text == "The real Old One's Army is attacking!" && c == new Color(175, 75, 255))
                orig.Invoke("真正的撒旦大军来袭！", force, c, WidthLimit);
            else if (text == "You feel dumb among so many brains!" && c == new Color(175, 75, 255))
                orig.Invoke("在这么多聪颖的大脑中间，你觉得自己很笨！", force, c, WidthLimit);
            else if (text == "Defeaning chants fill your ears!" && c == new Color(175, 75, 255))
                orig.Invoke("反抗的圣歌回响在你的耳畔！", force, c, WidthLimit);
            else if (text == "You feel like you're in a library!" && c == new Color(175, 75, 255))
                orig.Invoke("你感觉你身在图书馆！", force, c, WidthLimit);
            else if (text == "The Constant takes over!" && c == new Color(175, 75, 255))
                orig.Invoke("永恒领域的生物大肆入侵！", force, c, WidthLimit);
            else if (text == "The planet trembles from the core!" && c == new Color(175, 75, 255))
                orig.Invoke("整颗星球从核心开始颤抖！", force, c, WidthLimit);
            else if (text == "Bullet heaven is descending!" && c == new Color(175, 75, 255))
                orig.Invoke("弹幕天堂正在降临！", force, c, WidthLimit);
            else if (text == "Countless eyes pierce the veil staring in your direction!" && c == new Color(175, 75, 255))
                orig.Invoke("无数眼睛刺破面纱看透了你！", force, c, WidthLimit);
            else if (text == "The ocean swells with ferocious pigs!" && c == new Color(175, 75, 255))
                orig.Invoke("海洋被凶猛的猪们搅的天翻地覆！", force, c, WidthLimit);
            else if (text == "The Frost Moon is rising..." && c == new Color(175, 75, 255))
                orig.Invoke("霜月正在升起……", force, c, WidthLimit);
            else if (text == "The Frost Moon fades away!" && c == new Color(175, 75, 255))
                orig.Invoke("霜月消逝……", force, c, WidthLimit);
            else if (text == "Wave: 20: Everything" && c == new Color(175, 75, 255))
                orig.Invoke("波数：20：一切", force, c, WidthLimit);
            else if (text == "The goblins have calmed down!" && c == new Color(175, 75, 255))
                orig.Invoke("哥布林们冷静下来了！", force, c, WidthLimit);
            else if (text == "Ancient automatons come crashing down!" && c == new Color(175, 75, 255))
                orig.Invoke("古老的机器人接连从天上落下！", force, c, WidthLimit);
            else if (text == "The martians have calmed down!" && c == new Color(175, 75, 255))
                orig.Invoke("火星人们冷静下来了！", force, c, WidthLimit);
            else if (text == "The wind whispers of death's approach!" && c == new Color(175, 75, 255))
                orig.Invoke("逼近死亡之风呢喃不已……", force, c, WidthLimit);
            else if (text == "The pirates have calmed down!" && c == new Color(175, 75, 255))
                orig.Invoke("海盗们冷静下来了！", force, c, WidthLimit);
            else if (text == "The jungle beats as one!" && c == new Color(175, 75, 255))
                orig.Invoke("丛林万物的心跳合而为一！", force, c, WidthLimit);
            else if (text == "A sickly chill envelops the world!" && c == new Color(175, 75, 255))
                orig.Invoke("一股恶心的寒气笼罩着整个世界！", force, c, WidthLimit);
            else if (text == "The Pumpkin Moon is rising..." && c == new Color(175, 75, 255))
                orig.Invoke("南瓜月正在升起……", force, c, WidthLimit);
            else if (text == "The Pumpkin Moon fades away!" && c == new Color(175, 75, 255))
                orig.Invoke("南瓜月消逝……", force, c, WidthLimit);
            else if (text == "Welcome to the truer slime rain!" && c == new Color(175, 75, 255))
                orig.Invoke("欢迎来到名副其实的史莱姆雨！", force, c, WidthLimit);
            else if (text == "A great clammering of bones rises from the dungeon!" && c == new Color(175, 75, 255))
                orig.Invoke("骨头的碰撞声从地牢中升腾而起！", force, c, WidthLimit);
            else if (text == "Welcome to the true slime rain!" && c == new Color(175, 75, 255))
                orig.Invoke("欢迎来到真正的史莱姆雨！", force, c, WidthLimit);
            else if (text == "A legion of glowing iris sing a dreadful song!" && c == new Color(175, 75, 255))
                orig.Invoke("一群发光的虹膜唱着可怕的歌！", force, c, WidthLimit);
            else if (text == "A fortress of flesh arises from the depths!" && c == new Color(175, 75, 255))
                orig.Invoke("一个血肉堡垒从深处升起！", force, c, WidthLimit);
            else if (text == "The ground shifts with formulated precision!" && c == new Color(175, 75, 255))
                orig.Invoke("地面以公式化的精度颤动！", force, c, WidthLimit);
            #endregion
            #endregion
            #endregion
            #region NPCs
            else if (text == "Betsy has been defeated!" && c == new Color(175, 75, 0))
                orig.Invoke("双足翼龙已被打败！", force, c, WidthLimit);
            else if (text.StartsWith("Killed: ") && c == new Color(206, 12, 15))
            {
                string realtext = text.Replace("Killed: ", "击杀数：");
                orig.Invoke(realtext, force, c, WidthLimit);
            }
            else if (text.StartsWith("Total: ") && c == new Color(206, 12, 15))
            {
                string realtext = text.Replace("Total: ", "总计：");
                orig.Invoke(realtext, force, c, WidthLimit);
            }
            else if (text == "The swarm has been defeated!" && c == new Color(206, 12, 15))
                orig.Invoke("这群怪物已被打败！", force, c, WidthLimit);
            #endregion
            #region Utils
            else if (text == $"A new item has been unlocked in Deviantt's shop!" && c == Color.HotPink)
                orig.Invoke("戴薇安解锁了新商品！", force, c, WidthLimit);
            else if (text == $"A new item has been unlocked in Abominationn's shop!" && c == Color.Orange)
                orig.Invoke("憎恶解锁了新商品！", force, c, WidthLimit);
            #endregion
            #region Fargowiltas
            else if (text == "The invaders have left!" && c == new Color(175, 75, 255))
                orig.Invoke("入侵者已离开！", force, c, WidthLimit);
            else if (text == "The Pumpkin Moon is lowering..." && c == new Color(175, 75, 255))
                orig.Invoke("南瓜月正在降下……", force, c, WidthLimit);
            else if (text == "The Frost Moon is lowering..." && c == new Color(175, 75, 255))
                orig.Invoke("霜月正在降下……", force, c, WidthLimit);
            else if (text == "A solar eclipse is not happening!" && c == new Color(175, 75, 255))
                orig.Invoke("日食停止发生！", force, c, WidthLimit);
            else if (text == "The blood moon is descending..." && c == new Color(175, 75, 255))
                orig.Invoke("血月正在降下……", force, c, WidthLimit);
            else if (text == "The wind has ended!" && c == new Color(175, 75, 255))
                orig.Invoke("狂风已经平息！", force, c, WidthLimit);
            else if (text == "The Old One's Army is leaving!" && c == new Color(175, 75, 255))
                orig.Invoke("旧日军团正在离开！", force, c, WidthLimit);
            else if (text == "The sandstorm has ended!" && c == new Color(175, 75, 255))
                orig.Invoke("沙尘暴已结束！", force, c, WidthLimit);
            else if (text == "Celestial creatures are not invading!" && c == new Color(175, 75, 255))
                orig.Invoke("天界生物停止入侵！", force, c, WidthLimit);
            else if (text == "The rain has ended!" && c == new Color(175, 75, 255))
                orig.Invoke("雨停了！", force, c, WidthLimit);
            #endregion
            #endregion
            #region FargowiltasSouls
            #endregion
            else
                        orig.Invoke(text, force, c, WidthLimit);
        }
        public static void Unload()
        {
            On.Terraria.Main.NewText_string_byte_byte_byte -= NewText_string_byte_byte_byte;
            On.Terraria.Main.NewTextMultiline -= NewTextMultiline;
        }
    }
}