using Fargowiltas.NPCs;
using Fargowiltas.UI;
using MonoMod.RuntimeDetour;
using System;
using System.Collections.Generic;
using System.Reflection;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace FargoChinese
{
    public static class ChatButtonsTranslate
    {
        private static List<Hook> chatButton;
        public static void Load()
        {
            MonoModHooks.RequestNativeAccess();
            chatButton = new List<Hook>();
            chatButton.Add(new Hook(typeof(Abominationn).GetMethod("SetChatButtons"), AbomButton));
            chatButton.Add(new Hook(typeof(Deviantt).GetMethod("SetChatButtons"), DeviButton));
            foreach (Hook hook in chatButton)
            {
                if (hook is not null)
                    hook.Apply();
            }
        }
        public static void Unload()
        {
            foreach (Hook hook in chatButton)
            {
                if (hook is not null)
                    hook.Dispose();
            }
            chatButton = null;
        }
        private static void AbomButton(Abominationn orig, ref string button, ref string button2)
        {
            button = Language.GetTextValue("LegacyInterface.28");
            button2 = "取消事件";
        }
        private static void DeviButton(Deviantt orig, ref string button, ref string button2)
        {
            button = Language.GetTextValue("LegacyInterface.28");
            if (ModLoader.TryGetMod("FargowiltasSouls", out _) && (bool)ModLoader.GetMod("FargowiltasSouls").Call("EternityMode"))
            {
                button2 = "帮助";
            }
        }
    }
}