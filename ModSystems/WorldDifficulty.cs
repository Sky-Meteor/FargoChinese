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
        protected override bool LoadWithFargoSouls => true;

        private Preferences _saveWorldDifficulty;
        private static readonly string path = Path.Combine(Main.SavePath, "ModConfigs", "FargoChinese_WorldDifficulty.json");
        private Dictionary<Guid, int> _worldMode;

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
        }

        public override void Load()
        {
            _saveWorldDifficulty = new Preferences(path);
            _saveWorldDifficulty.Load();
            _worldMode = _saveWorldDifficulty.Get("WorldDifficulty", new Dictionary<Guid, int>());
            _saveWorldDifficulty.Put("WorldDifficulty", _worldMode);
            _saveWorldDifficulty.Save();

            On.Terraria.Main.EraseWorld += Main_EraseWorld;
            IL.Terraria.GameContent.UI.Elements.UIWorldListItem.DrawSelf += UIWorldListItem_DrawSelf;
        }

        private void Main_EraseWorld(On.Terraria.Main.orig_EraseWorld orig, int i)
        {
            _worldMode.Remove(Main.WorldList[i].UniqueId);
            orig.Invoke(i);
        }

        private void UIWorldListItem_DrawSelf(ILContext il)
        {
            var c = new ILCursor(il);
            if (!c.TryGotoNext(i => i.MatchLdstr("UI.Expert")))
                return;
            c.Index++;
            c.Emit(OpCodes.Ldarg_0);
            c.EmitDelegate<Func<string, UIWorldListItem, string>>((difficultyKey, self) =>
            {
                FieldInfo data = self.GetType().GetField("_data", BindingFlags.NonPublic | BindingFlags.Instance);
                if (data?.GetValue(self) is WorldFileData worldFileData && _worldMode.TryGetValue(worldFileData.UniqueId, out int difficulty) && difficulty == 1)
                {
                    return "永恒";
                }
                return difficultyKey;
            });

            if (!c.TryGotoNext(i => i.MatchLdstr("UI.Master")))
                return;
            c.Index++;
            c.Emit(OpCodes.Ldarg_0);
            c.EmitDelegate<Func<string, UIWorldListItem, string>>((difficultyKey, self) =>
            {
                FieldInfo data = self.GetType().GetField("_data", BindingFlags.NonPublic | BindingFlags.Instance);
                if (data?.GetValue(self) is WorldFileData worldFileData && _worldMode.TryGetValue(worldFileData.UniqueId, out int difficulty))
                {
                    return difficulty switch
                    {
                        1 => "永恒",
                        2 => "受虐",
                        _ => difficultyKey
                    };
                }
                return difficultyKey;
            });

            if (!c.TryGotoNext(i => i.MatchLdsfld(typeof(Main).GetField(nameof(Main.hcColor), BindingFlags.Static | BindingFlags.Public))))
                return;
            c.Index++;
            c.Emit(OpCodes.Ldarg_0);
            c.EmitDelegate<Func<Color, UIWorldListItem, Color>>((hcColor, self) =>
            {
                FieldInfo data = self.GetType().GetField("_data", BindingFlags.NonPublic | BindingFlags.Instance);
                if (data?.GetValue(self) is WorldFileData worldFileData && _worldMode.TryGetValue(worldFileData.UniqueId, out int difficulty) && difficulty == 2)
                {
                    return Main.MouseTextColorReal;
                }
                return hcColor;
            });

            if (!c.TryGotoNext(i => i.MatchCall(typeof(Utils).GetMethod("DrawBorderString"))))
                return;
            c.Index -= 12;
            c.Emit(OpCodes.Ldarg_0);
            c.Emit(OpCodes.Ldarg_1);
            c.EmitDelegate<Action<UIWorldListItem, SpriteBatch>>((self, spriteBatch) =>
            {
                FieldInfo data = self.GetType().GetField("_data", BindingFlags.NonPublic | BindingFlags.Instance);
                if (data?.GetValue(self) is WorldFileData worldFileData && _worldMode.TryGetValue(worldFileData.UniqueId, out int difficulty))
                {
                    if (difficulty < 1)
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
                }
            });

            if (!c.TryGotoNext(i => i.MatchCall(typeof(Utils).GetMethod("DrawBorderString"))))
                return;
            c.Index += 2;
            c.Emit(OpCodes.Ldarg_0);
            c.Emit(OpCodes.Ldarg_1);
            c.EmitDelegate<Action<UIWorldListItem, SpriteBatch>>((self, spriteBatch) =>
            {
                FieldInfo data = self.GetType().GetField("_data", BindingFlags.NonPublic | BindingFlags.Instance);
                if (data?.GetValue(self) is WorldFileData worldFileData && _worldMode.TryGetValue(worldFileData.UniqueId, out int difficulty) && difficulty >= 1)
                {
                    spriteBatch.End();
                    spriteBatch.Begin(SpriteSortMode.Deferred, spriteBatch.GraphicsDevice.BlendState, spriteBatch.GraphicsDevice.SamplerStates[0],
                        spriteBatch.GraphicsDevice.DepthStencilState, spriteBatch.GraphicsDevice.RasterizerState, null, Main.UIScaleMatrix);
                }
            });
        }

        public override void Unload()
        {
            _saveWorldDifficulty.Put("WorldDifficulty", _worldMode);
            _saveWorldDifficulty.Save();
            _saveWorldDifficulty = null;
            _worldMode = null;

            On.Terraria.Main.EraseWorld -= Main_EraseWorld;
            IL.Terraria.GameContent.UI.Elements.UIWorldListItem.DrawSelf -= UIWorldListItem_DrawSelf;
        }
    }
}