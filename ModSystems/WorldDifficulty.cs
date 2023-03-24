using FargowiltasSouls;
using Microsoft.Xna.Framework;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using FargoChinese.Patch;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics.Shaders;

namespace FargoChinese.ModSystems
{
    [JITWhenModsEnabled("FargowiltasSouls")]
    public class WorldDifficulty : PatchBase
    {
        public override bool IsLoadingEnabled(Mod mod) => ModLoader.TryGetMod("FargowiltasSouls", out _) && ModContent.GetInstance<FCConfig>().EnableWorldDifficultyChange;

        private Preferences _saveWorldDifficulty;
        private static readonly string path = Path.Combine(Main.SavePath, "ModConfigs", "FargoChinese_WorldDifficulty.json");

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
            if (FargoSoulsWorld.EternityMode)
                difficulty = 1;
            if (FargoSoulsWorld.MasochistModeReal)
                difficulty = 2;

            if (difficulty == 0)
            {
                _worldMode.Remove(Main.ActiveWorldFileData.UniqueId);
                return;
            }
            if (_worldMode.ContainsKey(Main.ActiveWorldFileData.UniqueId))
                _worldMode[Main.ActiveWorldFileData.UniqueId] = difficulty;
            else
                _worldMode.Add(Main.ActiveWorldFileData.UniqueId, difficulty);
            _saveWorldDifficulty.Put("WorldDifficulty", _worldMode);
            _saveWorldDifficulty.Save();
        }
        private void Main_EraseWorld(On.Terraria.Main.orig_EraseWorld orig, int i)
        {
            _worldMode.Remove(Main.WorldList[i].UniqueId);
            orig.Invoke(i);
            _saveWorldDifficulty.Put("WorldDifficulty", _worldMode);
            _saveWorldDifficulty.Save();
        }
        #endregion
        #region Difficulty names
        private void UIWorldListItem_DrawSelf(ILContext il)
        {
            var c = new ILCursor(il);
            if (!c.TryGotoNext(i => i.MatchLdstr("UI.Expert")))
                return;
            c.Index++;
            c.Emit(OpCodes.Ldarg_0);

            c.EmitDelegate<Func<string, UIWorldListItem, string>>((difficultyKey, self) => _worldMode.TryGetValue(((WorldFileData)_data.GetValue(self))!.UniqueId, out int difficulty) && difficulty == 1 ? "永恒" : difficultyKey);

            if (!c.TryGotoNext(i => i.MatchLdstr("UI.Master")))
                return;
            c.Index++;
            c.Emit(OpCodes.Ldarg_0);
            c.EmitDelegate<Func<string, UIWorldListItem, string>>((difficultyKey, self) =>
            {
                if (!_worldMode.TryGetValue(((WorldFileData)_data.GetValue(self))!.UniqueId, out int difficulty))
                    return difficultyKey;

                return difficulty switch
                {
                    1 => "永恒",
                    2 => "受虐",
                    _ => difficultyKey
                };
            });

            if (!c.TryGotoNext(i => i.MatchLdsfld(typeof(Main).GetField(nameof(Main.hcColor), BindingFlags.Static | BindingFlags.Public))))
                return;
            c.Index++;
            c.Emit(OpCodes.Ldarg_0);
            c.EmitDelegate<Func<Color, UIWorldListItem, Color>>((hcColor, self) => !_enableWorldDifficultyShader && _worldMode.TryGetValue(((WorldFileData)_data.GetValue(self))!.UniqueId, out int difficulty) && difficulty == 2 ? new Color(0, 255, 255) : hcColor);
        }
        #endregion
        #region Shader
        private void UIWorldListItem_DrawSelf_Shader(ILContext il)
        {
            var c = new ILCursor(il);
            if (!c.TryGotoNext(i => i.MatchLdsfld(typeof(Main).GetField(nameof(Main.hcColor), BindingFlags.Static | BindingFlags.Public))))
                return;
            c.Index++;
            c.Emit(OpCodes.Ldarg_0);
            c.EmitDelegate<Func<Color, UIWorldListItem, Color>>((hcColor, self) => _worldMode.TryGetValue(((WorldFileData)_data.GetValue(self))!.UniqueId, out int difficulty) && difficulty == 2 ? Color.White : hcColor);

            if (!c.TryGotoNext(i => i.MatchCall(typeof(Utils).GetMethod("DrawBorderString"))))
                return;
            c.Index -= 12;
            c.Emit(OpCodes.Ldarg_0);
            c.Emit(OpCodes.Ldarg_1);
            c.EmitDelegate<Action<UIWorldListItem, SpriteBatch>>((self, spriteBatch) =>
            {
                if (!_worldMode.TryGetValue(((WorldFileData)_data.GetValue(self))!.UniqueId, out int difficulty) || difficulty < 1)
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

            On.Terraria.Main.EraseWorld += Main_EraseWorld;
            IL.Terraria.GameContent.UI.Elements.UIWorldListItem.DrawSelf += UIWorldListItem_DrawSelf;
            if (ModContent.GetInstance<FCConfig>().EnableWorldDifficultyShader)
                IL.Terraria.GameContent.UI.Elements.UIWorldListItem.DrawSelf += UIWorldListItem_DrawSelf_Shader;
        }

        public override void Unload()
        {
            _saveWorldDifficulty.Put("WorldDifficulty", _worldMode);
            _saveWorldDifficulty.Save();
            _saveWorldDifficulty = null;
            // _worldMode = null;

            // _data = null;
            On.Terraria.Main.EraseWorld -= Main_EraseWorld;
            IL.Terraria.GameContent.UI.Elements.UIWorldListItem.DrawSelf -= UIWorldListItem_DrawSelf;
            IL.Terraria.GameContent.UI.Elements.UIWorldListItem.DrawSelf -= UIWorldListItem_DrawSelf_Shader;
        }
        #endregion
    }
}