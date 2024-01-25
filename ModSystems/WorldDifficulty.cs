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
        public override void SaveWorldHeader(TagCompound tag)
        {
            base.SaveWorldHeader(tag);
        }

        public override bool IsLoadingEnabled(Mod mod) => ModLoader.TryGetMod("FargowiltasSouls", out _) && ModContent.GetInstance<FCConfig>().EnableWorldDifficultyChange;

        private Preferences _saveWorldDifficulty;
        private static readonly string path = Path.Combine(Main.SavePath, "ModConfigs", "FargoChinese_WorldDifficulty.json");

        /// <summary>
        /// 1 => 永恒；2 => 受虐
        /// </summary>
        private Dictionary<Guid, int> _worldMode;
        private FieldInfo _data;
        private bool _enableWorldDifficultyShader;

        #region Save world difficulty
        public override void SaveWorldData(TagCompound tag)
        {
            if (Main.ActiveWorldFileData.GameMode == 3)
            {
                _worldMode.Remove(Main.ActiveWorldFileData.UniqueId);
                return;
            }

            int difficulty = 0;
            if (WorldSavingSystem.EternityMode)
                difficulty = 1;
            if (WorldSavingSystem.MasochistModeReal)
                difficulty = 2;

            if (difficulty == 0)
            {
                _worldMode.Remove(Main.ActiveWorldFileData.UniqueId);
                return;
            }
            _worldMode[Main.ActiveWorldFileData.UniqueId] = difficulty;

            _saveWorldDifficulty.Put("WorldDifficulty", _worldMode);
            _saveWorldDifficulty.Save();
        }
        public override void LoadWorldData(TagCompound tag)
        {
            base.LoadWorldData(tag);
        }

        private void Main_EraseWorld(Terraria.On_Main.orig_EraseWorld orig, int i)
        {
            _worldMode.Remove(Main.WorldList[i].UniqueId);
            orig.Invoke(i);
            _saveWorldDifficulty.Put("WorldDifficulty", _worldMode);
            _saveWorldDifficulty.Save();
        }
        #endregion
        #region Difficulty names
        private void AWorldListItem_GetDifficulty(On_AWorldListItem.orig_GetDifficulty orig, AWorldListItem self, out string expertText, out Color gameModeColor)
        {
            orig.Invoke(self, out expertText, out gameModeColor);
            WorldFileData data = self.Data;
            if (!_worldMode.ContainsKey(self.Data.UniqueId))
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

            if (_worldMode[self.Data.UniqueId] == 1)
            {
                expertText = "永恒";
            }
            else if (_worldMode[self.Data.UniqueId] == 2)
            {
                if (num != 4)
                {
                    expertText = "受虐";
                    gameModeColor = ModContent.GetInstance<FCConfig>().EnableWorldDifficultyShader ? Color.White : new Color(0, 255, 255);
                }
            }
        }
        #endregion
        #region Shader
        private void UIWorldListItem_DrawSelf_Shader(ILContext il)
        {
            var c = new ILCursor(il);

            if (!c.TryGotoNext(i => i.MatchCall(typeof(Utils).GetMethod("DrawBorderString"))))
                return;
            if (!c.TryGotoNext(i => i.MatchCall(typeof(Utils).GetMethod("DrawBorderString")))) // to the second
                return;
            c.Index -= 12;
            c.Emit(OpCodes.Ldarg_0);
            c.Emit(OpCodes.Ldarg_1);
            c.EmitDelegate<Action<UIWorldListItem, SpriteBatch>>((self, spriteBatch) =>
            {
                if (!_worldMode.TryGetValue(((WorldFileData)_data.GetValue(self))!.UniqueId, out int difficulty) || difficulty < 1)
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

            if (!c.TryGotoNext(i => i.MatchCall(typeof(Utils).GetMethod("DrawBorderString"))))
                return;
            c.Index += 2;
            c.Emit(OpCodes.Ldarg_0);
            c.Emit(OpCodes.Ldarg_1);
            c.EmitDelegate<Action<UIWorldListItem, SpriteBatch>>((self, spriteBatch) =>
            {
                if (_worldMode.TryGetValue(((WorldFileData)_data.GetValue(self))!.UniqueId, out int difficulty) && difficulty >= 1)
                {
                    spriteBatch.End();
                    spriteBatch.Begin(SpriteSortMode.Deferred, spriteBatch.GraphicsDevice.BlendState, spriteBatch.GraphicsDevice.SamplerStates[0],
                        spriteBatch.GraphicsDevice.DepthStencilState, spriteBatch.GraphicsDevice.RasterizerState, null, Main.UIScaleMatrix);
                }
            });
        }
        #endregion
        #region Load & Unload

        public override void Load()
        {
            _saveWorldDifficulty = new Preferences(path);
            _saveWorldDifficulty.Load();
            _worldMode = _saveWorldDifficulty.Get("WorldDifficulty", new Dictionary<Guid, int>());
            _saveWorldDifficulty.Put("WorldDifficulty", _worldMode);
            _saveWorldDifficulty.Save();

            _data = typeof(UIWorldListItem).GetField("_data", BindingFlags.NonPublic | BindingFlags.Instance);
            _enableWorldDifficultyShader = ModContent.GetInstance<FCConfig>().EnableWorldDifficultyShader;

            On_Main.EraseWorld += Main_EraseWorld;
            On_AWorldListItem.GetDifficulty += AWorldListItem_GetDifficulty;
            
            if (ModContent.GetInstance<FCConfig>().EnableWorldDifficultyShader)
                IL_UIWorldListItem.DrawSelf += UIWorldListItem_DrawSelf_Shader;
        }

        public override void Unload()
        {
            _saveWorldDifficulty.Put("WorldDifficulty", _worldMode);
            _saveWorldDifficulty.Save();
            _saveWorldDifficulty = null;
            // _worldMode = null;

            // _data = null;
            On_Main.EraseWorld -= Main_EraseWorld;
            On_AWorldListItem.GetDifficulty -= AWorldListItem_GetDifficulty;
            
            IL_UIWorldListItem.DrawSelf -= UIWorldListItem_DrawSelf_Shader;
        }
        #endregion
    }
}