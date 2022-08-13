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
            if (newText.Contains("Battle Cry") && newText.Contains(Main.player[0].name) && newText.Contains("!") && R == 255 && G == 0 && B == 0)
            {
                if (!newText.Contains("deactivated"))
                    orig.Invoke($"战争号角已对{Main.player[0].name}生效！", R, G, B);
                else
                    orig.Invoke($"战争号角已对{Main.player[0].name}停止生效！", R, G, B);
            }
            else if (newText.Contains("Calming Cry") && newText.Contains(Main.player[0].name) && newText.Contains(".") && R == 0 && G == 255 && B == 255)
            {
                if (!newText.Contains("deactivated"))
                    orig.Invoke($"镇静号角已对{Main.player[0].name}生效！", R, G, B);
                else
                    orig.Invoke($"镇静号角已对{Main.player[0].name}停止生效！", R, G, B);
            }
            else if (newText.Contains("researched ") && newText.Contains(" items"))
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
            #endregion
            #region NPCs
            else if (newText == "Betsy has been defeated!" && R == 175 && G == 75 && B == 0)
                orig.Invoke("双足翼龙已被打败！", R, G, B);
            else if (newText.Contains("Killed: ") && R == 206 && G == 12 && B == 15)
            {
                string text = newText.Replace("Killed: ", "击杀数：");
                orig.Invoke(text, R, G, B);
            }
            else if (newText.Contains("Total: ") && R == 206 && G == 12 && B == 15)
            {
                string text = newText.Replace("Total: ", "总计：");
                orig.Invoke(text, R, G, B);
            }
            else if (newText == "The swarm has been defeated!" && R == 206 && G == 12 && B == 15)
            {
                orig.Invoke("这群怪物已被打败！", R, G, B);
            }
            #endregion
            else if (newText == $"A new item has been unlocked in Deviantt's shop!" && R == Color.HotPink.R && G == Color.HotPink.G && B == Color.HotPink.B)
                orig.Invoke("戴薇安解锁了新商品！", R, G, B);
            else if (newText == $"A new item has been unlocked in Abominationn's shop!" && R == Color.Orange.R && G == Color.Orange.G && B == Color.Orange.B)
                orig.Invoke("憎恶解锁了新商品！", R, G, B);
            else
                orig.Invoke(newText, R, G, B);
        }
        private static void NewTextMultiline(On.Terraria.Main.orig_NewTextMultiline orig, string text, bool force = false, Color c = default(Color), int WidthLimit = -1)
        {
            #region Items
            if (text.Contains("Battle Cry") && text.Contains("!") && c == new Color (255, 0, 0))
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
            else if (text.Contains("researched ") && text.Contains(" items"))
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
            else if (text.Contains("Killed: ") && c == new Color(206, 12, 15))
            {
                string realtext = text.Replace("Killed: ", "击杀数：");
                orig.Invoke(realtext, force, c, WidthLimit);
            }
            else if (text.Contains("Total: ") && c == new Color(206, 12, 15))
            {
                string realtext = text.Replace("Total: ", "总计：");
                orig.Invoke(realtext, force, c, WidthLimit);
            }
            else if (text == "The swarm has been defeated!" && c == new Color(206, 12, 15))
                orig.Invoke("这群怪物已被打败！", force, c, WidthLimit);
            #endregion
            else if (text == $"A new item has been unlocked in Deviantt's shop!" && c == Color.HotPink)
                orig.Invoke("戴薇安解锁了新商品！", force, c, WidthLimit);
            else if (text == $"A new item has been unlocked in Abominationn's shop!" && c == Color.Orange)
                orig.Invoke("憎恶解锁了新商品！", force, c, WidthLimit);
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