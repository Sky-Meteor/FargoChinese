using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using FargowiltasSouls.Common.Graphics.Shaders;
using FargowiltasSouls.Core.Systems;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace FargoChinese.ModSystems
{
    [JITWhenModsEnabled("FargowiltasSouls")]
    public class WorldDifficulty : ModSystem // TODO: save it in SaveWorldHeader
    {
        public override bool IsLoadingEnabled(Mod mod) => ModLoader.HasMod("FargowiltasSouls") && FCConfig.Instance.EnableWorldDifficultyChange;
        
        private FieldInfo _data;
        private MethodInfo _drawBorderString;

        #region Save world difficulty
        /// <summary>
        /// 1 => 永恒；2 => 受虐
        /// </summary>
        public override void SaveWorldHeader(TagCompound tag)
        {
            if (Main.ActiveWorldFileData.GameMode == 3)
            {
                return;
            }

            int difficulty = 0;
            if (WorldSavingSystem.EternityMode)
                difficulty = 1;
            if (WorldSavingSystem.MasochistModeReal)
                difficulty = 2;

            if (difficulty == 0)
            {
                return;
            }

            tag.Add("FCDifficulty", difficulty);
        }
        #endregion
        #region Difficulty names
        private void AWorldListItem_GetDifficulty(On_AWorldListItem.orig_GetDifficulty orig, AWorldListItem self, out string expertText, out Color gameModeColor)
        {
            orig.Invoke(self, out expertText, out gameModeColor);
            WorldFileData data = self.Data;
            if (!data.TryGetHeaderData<WorldDifficulty>(out var headerData) || !headerData.TryGet("FCDifficulty", out int difficulty))
                return;
            int gameMode = data.GameMode;
            int num = 1;
            if (gameMode != 1)
            {
                if (gameMode == 2) 
                    num = 3;
            }
            else
                num = 2;
            if (data.ForTheWorthy)
                num++;

            if (difficulty == 1)
            {
                expertText = "永恒";
            }
            else if (difficulty == 2)
            {
                if (num != 4)
                {
                    expertText = "受虐";
                    gameModeColor = FCConfig.Instance.EnableWorldDifficultyShader ? Color.White : new Color(0, 255, 255);
                }
            }
        }
        #endregion
        #region Shader
        private void UIWorldListItem_DrawSelf_Shader(ILContext il)
        {
            var c = new ILCursor(il);

            if (!c.TryGotoNext(i => i.MatchCall(_drawBorderString)))
                return;
            if (!c.TryGotoNext(i => i.MatchCall(_drawBorderString))) // to the second
                return;
            c.Index -= 12;
            c.Emit(OpCodes.Ldarg_0);
            c.Emit(OpCodes.Ldarg_1);
            c.EmitDelegate<Action<UIWorldListItem, SpriteBatch>>((self, spriteBatch) =>
            {
                if ((WorldFileData)_data.GetValue(self) is not WorldFileData data || !data.TryGetHeaderData<WorldDifficulty>(out var headerData) || !headerData.TryGet("FCDifficulty", out int difficulty) || difficulty < 1)
                    return;
                
                Shader shader = difficulty switch
                {
                    1 => ShaderManager.GetShaderIfExists("Text").SetMainColor(new Color(255, 170, 12)).SetSecondaryColor(new Color(210, 69, 203)),
                    2 => ShaderManager.GetShaderIfExists("Text").SetMainColor(new Color(28, 222, 152)).SetSecondaryColor(new Color(168, 245, 228)),
                    _ => null
                };
                if (shader == null)
                    return;

                spriteBatch.End();
                spriteBatch.Begin(SpriteSortMode.Immediate, spriteBatch.GraphicsDevice.BlendState, spriteBatch.GraphicsDevice.SamplerStates[0],
                    spriteBatch.GraphicsDevice.DepthStencilState, spriteBatch.GraphicsDevice.RasterizerState, shader.WrappedEffect, Main.UIScaleMatrix);
                shader.Apply(true, difficulty == 1 ? "PulseDiagonal" : "PulseUpwards");
            });

            if (!c.TryGotoNext(i => i.MatchCall(_drawBorderString)))
                return;
            c.Index += 2;
            c.Emit(OpCodes.Ldarg_0);
            c.Emit(OpCodes.Ldarg_1);
            c.EmitDelegate<Action<UIWorldListItem, SpriteBatch>>((self, spriteBatch) =>
            {
                spriteBatch.End();
                spriteBatch.Begin(SpriteSortMode.Deferred, spriteBatch.GraphicsDevice.BlendState, spriteBatch.GraphicsDevice.SamplerStates[0],
                    spriteBatch.GraphicsDevice.DepthStencilState, spriteBatch.GraphicsDevice.RasterizerState, null, Main.UIScaleMatrix);

            });
        }
        #endregion
        #region Load & Unload

        public override void Load()
        {
            _data = typeof(UIWorldListItem).GetField("_data", BindingFlags.NonPublic | BindingFlags.Instance);
            _drawBorderString = typeof(Utils).GetMethod("DrawBorderString");

                On_AWorldListItem.GetDifficulty += AWorldListItem_GetDifficulty;
            
            if (FCConfig.Instance.EnableWorldDifficultyShader)
                IL_UIWorldListItem.DrawSelf += UIWorldListItem_DrawSelf_Shader;
        }

        public override void Unload()
        {
            On_AWorldListItem.GetDifficulty -= AWorldListItem_GetDifficulty;
            
            IL_UIWorldListItem.DrawSelf -= UIWorldListItem_DrawSelf_Shader;
        }
        #endregion
    }
}