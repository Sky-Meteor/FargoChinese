using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Fargowiltas.NPCs;
using Terraria.Chat;
using Microsoft.Xna.Framework;
using Terraria.Audio;
using static System.Net.Mime.MediaTypeNames;
using Terraria.GameContent.UI.Chat;

namespace FargoChinese
{
	public class ChatMessagesTranslate : ModSystem
	{
        public override void Load()
        {
            On.Terraria.Main.NewText_string_byte_byte_byte += hook_NewText_string_byte_byte_byte;
            On.Terraria.Main.NewTextMultiline += hook_NewTextMultiline;
        }
        private static void hook_NewText_string_byte_byte_byte(On.Terraria.Main.orig_NewText_string_byte_byte_byte orig, string newText, byte R = byte.MaxValue, byte G = byte.MaxValue, byte B = byte.MaxValue)
        {
            if (newText.Contains("Battle") && R == 255 && G == 0 && B == 0)
            {
                if (newText.Contains(""))
            }
            else if (newText == "Betsy has been defeated!" && R == 175 && G == 75 && B == 0)
                Main.chatMonitor.NewText("双足翼龙已被打败！", R, G, B);
            else if (newText.Contains("Killed: ") && R == 206 && G == 12 && B == 15)
            {
                string text = newText.Replace("Killed: ", "击杀数：");
                Main.chatMonitor.NewText(text, R, G, B);
            }
            else if (newText.Contains("Total: ") && R == 206 && G == 12 && B == 15)
            {
                string text = newText.Replace("Total: ", "总计：");
                Main.chatMonitor.NewText(text, R, G, B);
            }
            else if (newText == "The swarm has been defeated!" && R == 206 && G == 12 && B == 15)
            {
                Main.chatMonitor.NewText("这群怪物已被打败！", R, G, B);
            }
            else
            {
                Main.chatMonitor.NewText(newText, R, G, B);
                SoundEngine.PlaySound(SoundID.MenuTick);
            }
        }
        private static void hook_NewTextMultiline(On.Terraria.Main.orig_NewTextMultiline orig, string text, bool force = false, Color c = default(Color), int WidthLimit = -1)
        {
            if (text == "Betsy has been defeated!" && c == new Color(175, 75, 0))
                Main.chatMonitor.NewTextMultiline("双足翼龙已被打败！", force, c, WidthLimit);
            else if (text.Contains("Killed: ") && c == new Color(206, 12, 15))
            {
                string realtext = text.Replace("Killed: ", "击杀数：");
                Main.chatMonitor.NewTextMultiline(realtext, force, c, WidthLimit);
            }
            else if (text.Contains("Total: ") && c == new Color(206, 12, 15))
            {
                string realtext = text.Replace("Total: ", "总计：");
                Main.chatMonitor.NewTextMultiline(realtext, force, c, WidthLimit);
            }
            else if (text == "The swarm has been defeated!" && c == new Color(206, 12, 15))
                Main.chatMonitor.NewTextMultiline("这群怪物已被打败！", force, c, WidthLimit);
            else
            {
                Main.chatMonitor.NewTextMultiline(text, force, c, WidthLimit);
                SoundEngine.PlaySound(SoundID.MenuTick);
            }
        }
        public override void Unload()
        {
            On.Terraria.Main.NewText_string_byte_byte_byte -= hook_NewText_string_byte_byte_byte;
            On.Terraria.Main.NewTextMultiline -= hook_NewTextMultiline;
        }
    }
}