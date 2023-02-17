using System.Collections.Generic;
using Terraria.ModLoader;

namespace FargoChinese.Patch.FargowiltasSouls
{
    [JITWhenModsEnabled("FargowiltasSouls")]
    public class UITranslate : PatchBase
    {
        protected override bool LoadWithFargoSouls => true;

        public override void Load()
        {
            On.Terraria.UI.Chat.ChatManager.ParseMessage += ChatManager_ParseMessage;
        }

        private static List<Terraria.UI.Chat.TextSnippet> ChatManager_ParseMessage(On.Terraria.UI.Chat.ChatManager.orig_ParseMessage orig, string text, Microsoft.Xna.Framework.Color baseColor)
        {
            if (text == "Custom preset 1 (right click to save)")
                text = "自定义效果配置1（右键点击以保存）";
            if (text == "Custom preset 2 (right click to save)")
                text = "自定义效果配置2（右键点击以保存）";
            if (text == "Custom preset 3 (right click to save)")
                text = "自定义效果配置3（右键点击以保存）";
            return orig.Invoke(text, baseColor);
        }

        public override void Unload()
        {
            On.Terraria.UI.Chat.ChatManager.ParseMessage -= ChatManager_ParseMessage;
        }
    }
}
