using System.Collections.Generic;
using Terraria.ModLoader;
using Terraria.UI.Chat;

namespace FargoChinese.Patch.FargowiltasSouls
{
    [JITWhenModsEnabled("FargowiltasSouls")]
    public class UITranslate : PatchBase
    {
        public override bool IsLoadingEnabled() => LoadWithFargoSouls();

        public override void Load()
        {
            On_ChatManager.ParseMessage += ChatManager_ParseMessage;
        }

        private static List<TextSnippet> ChatManager_ParseMessage(Terraria.UI.Chat.On_ChatManager.orig_ParseMessage orig, string text, Microsoft.Xna.Framework.Color baseColor)
        {
            if (text == null)
                return new List<TextSnippet>();
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
            On_ChatManager.ParseMessage -= ChatManager_ParseMessage;
        }
    }
}
