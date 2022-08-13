/*using Fargowiltas.NPCs;
using Fargowiltas.UI;
using MonoMod.RuntimeDetour;
using System;
using System.Collections.Generic;
using System.Reflection;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;

namespace FargoChinese
{
    public static class StatSheetTranslate
    {
        private static List<Hook> hooks;
        public static void Load()
        {
            MonoModHooks.RequestNativeAccess();
            hooks = new List<Hook>();
            hooks.Add(new Hook(typeof(UIHoverTextImageButton).GetMethod("UIHoverTextImageButton"), HoverTextImageButton));
            hooks.Add(new Hook(typeof(StatSheetUI).GetMethod("RebuildStatList"), RebuildStatList));
            foreach (Hook hook in hooks)
            {
                if (hook is not null)
                    hook.Apply();
            }
        }
        public static void Unload()
        {
            foreach (Hook hook in hooks)
            {
                if (hook is not null)
                    hook.Dispose();
            }
            hooks = null;
        }
        private static void HoverTextImageButton(UIHoverTextImageButton orig, Asset<Texture2D> texture, string text)
        {
            orig.Text = "属性统计表";
        }
        private static void RebuildStatList(StatSheetUI orig)
        {

        }
    }
}*/