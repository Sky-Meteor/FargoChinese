using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using System;
using System.Reflection;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.Graphics.Shaders;
using Terraria.IO;
using Terraria.ModLoader;

namespace FargoChinese.ModSystems
{
    [JITWhenModsEnabled("FargowiltasSouls")]
    public class WorldDifficultyShader : WorldDifficulty
    {
        public override bool IsLoadingEnabled(Mod mod) => ModLoader.TryGetMod("FargowiltasSouls", out _) && ModContent.GetInstance<FCConfig>().EnableWorldDifficultyChange && ModContent.GetInstance<FCConfig>().EnableWorldDifficultyShader;

        public override void Load()
        {
            base.Load();
            IL.Terraria.GameContent.UI.Elements.UIWorldListItem.DrawSelf += UIWorldListItem_DrawSelf;
        }

        private void UIWorldListItem_DrawSelf(ILContext il)
        {
            var c = new ILCursor(il);
            if (!c.TryGotoNext(i => i.MatchLdsfld(typeof(Main).GetField(nameof(Main.hcColor), BindingFlags.Static | BindingFlags.Public))))
                return;
            c.Index++;
            c.Emit(OpCodes.Ldarg_0);
            c.EmitDelegate<Func<Color, UIWorldListItem, Color>>((hcColor, self) => WorldMode.TryGetValue(((WorldFileData)Data.GetValue(self))!.UniqueId, out int difficulty) && difficulty == 2 ? Main.MouseTextColorReal : hcColor);

            if (!c.TryGotoNext(i => i.MatchCall(typeof(Utils).GetMethod("DrawBorderString"))))
                return;
            c.Index -= 12;
            c.Emit(OpCodes.Ldarg_0);
            c.Emit(OpCodes.Ldarg_1);
            c.EmitDelegate<Action<UIWorldListItem, SpriteBatch>>((self, spriteBatch) =>
            {
                if (!WorldMode.TryGetValue(((WorldFileData)Data.GetValue(self))!.UniqueId, out int difficulty) || difficulty < 1)
                    return;

                MiscShaderData shader = difficulty switch
                {
                    1 => GameShaders.Misc["PulseDiagonal"].UseColor(new Color(255, 170, 12)).UseSecondaryColor(new Color(210, 69, 203)),
                    2 => GameShaders.Misc["PulseUpwards"].UseColor(new Color(28, 222, 152)).UseSecondaryColor(new Color(168, 245, 228)),
                    _ => null
                };
                if (shader == null)
                    return;

                spriteBatch.End();
                spriteBatch.Begin(SpriteSortMode.Immediate, spriteBatch.GraphicsDevice.BlendState, spriteBatch.GraphicsDevice.SamplerStates[0],
                    spriteBatch.GraphicsDevice.DepthStencilState, spriteBatch.GraphicsDevice.RasterizerState, shader.Shader, Main.UIScaleMatrix);
                shader.Apply();
            });

            if (!c.TryGotoNext(i => i.MatchCall(typeof(Utils).GetMethod("DrawBorderString"))))
                return;
            c.Index += 2;
            c.Emit(OpCodes.Ldarg_0);
            c.Emit(OpCodes.Ldarg_1);
            c.EmitDelegate<Action<UIWorldListItem, SpriteBatch>>((self, spriteBatch) =>
            {
                if (WorldMode.TryGetValue(((WorldFileData)Data.GetValue(self))!.UniqueId, out int difficulty) && difficulty >= 1)
                {
                    spriteBatch.End();
                    spriteBatch.Begin(SpriteSortMode.Deferred, spriteBatch.GraphicsDevice.BlendState, spriteBatch.GraphicsDevice.SamplerStates[0],
                        spriteBatch.GraphicsDevice.DepthStencilState, spriteBatch.GraphicsDevice.RasterizerState, null, Main.UIScaleMatrix);
                }
            });
        }

        public override void Unload()
        {
            base.Unload();
            IL.Terraria.GameContent.UI.Elements.UIWorldListItem.DrawSelf -= UIWorldListItem_DrawSelf;
        }
    }
}