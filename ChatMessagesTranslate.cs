using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Fargowiltas.NPCs;
using Terraria.Chat;
using Microsoft.Xna.Framework;
using Terraria.Audio;
using static System.Net.Mime.MediaTypeNames;

namespace FargoChinese
{
	public class ChatMessagesTranslate : ModSystem
	{
        public override void Load()
        {
            On.Terraria.Main.NewText_string_byte_byte_byte += NewText_string_byte_byte_byte;
            On.Terraria.Main.NewTextMultiline += NewTextMultiline;
        }
        private static void NewText_string_byte_byte_byte(On.Terraria.Main.orig_NewText_string_byte_byte_byte orig, string newText, byte R = byte.MaxValue, byte G = byte.MaxValue, byte B = byte.MaxValue)
        {
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
                    orig.Invoke($"镇静号角已对{Main.player[0].name}生效！", R, G, B);
                else
                    orig.Invoke($"镇静号角已对{Main.player[0].name}停止生效！", R, G, B);
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
            else if (newText == "Rain clouds cover the sky.")
                orig.Invoke("雨云遮住了天空。", R, G, B);
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
            else
                orig.Invoke(newText, R, G, B);
        }
        private static void NewTextMultiline(On.Terraria.Main.orig_NewTextMultiline orig, string text, bool force = false, Color c = default(Color), int WidthLimit = -1)
        {
            #region Items
            if (text.StartsWith("Battle Cry ") && text.EndsWith("!") && c == new Color (255, 0, 0))
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
            else
                orig.Invoke(text, force, c, WidthLimit);
            SoundEngine.PlaySound(SoundID.MenuTick);
        }
        public override void Unload()
        {
            On.Terraria.Main.NewText_string_byte_byte_byte -= NewText_string_byte_byte_byte;
            On.Terraria.Main.NewTextMultiline -= NewTextMultiline;
        }
    }
}