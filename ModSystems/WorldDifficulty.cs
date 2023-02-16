using FargowiltasSouls;
using Microsoft.Xna.Framework;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace FargoChinese.ModSystems
{
    [JITWhenModsEnabled("FargowiltasSouls")]
    public class WorldDifficulty : ModSystem
    {
        public override bool IsLoadingEnabled(Mod mod) => ModLoader.TryGetMod("FargowiltasSouls", out _) && ModContent.GetInstance<FCConfig>().EnableWorldDifficultyChange;

        private Preferences _saveWorldDifficulty;
        private static readonly string path = Path.Combine(Main.SavePath, "ModConfigs", "FargoChinese_WorldDifficulty.json");
        private Dictionary<Guid, int> _worldMode;

        public override void SaveWorldData(TagCompound tag)
        {
            int difficulty = 0;
            if (FargoSoulsWorld.EternityMode)
                difficulty = 1;
            if (FargoSoulsWorld.MasochistModeReal)
                difficulty = 2;
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
            //On.Terraria.GameContent.UI.Elements.UIWorldListItem.DrawSelf += On_UIWorldListItem_DrawSelf;
            IL.Terraria.GameContent.UI.Elements.UIWorldListItem.DrawSelf += UIWorldListItem_DrawSelf;
        }

        /*private void On_UIWorldListItem_DrawSelf(On.Terraria.GameContent.UI.Elements.UIWorldListItem.orig_DrawSelf orig, UIWorldListItem self, SpriteBatch spriteBatch)
        {
            FieldInfo data = self.GetType().GetField("_data", BindingFlags.NonPublic | BindingFlags.Instance);
            if (data.GetValue(self) is WorldFileData worldFileData)
            {
                _worldMode.Add(worldFileData.UniqueId, 0);
            }
            orig.Invoke(self, spriteBatch);
        }*/

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
                    return new Color(0, byte.MaxValue, byte.MaxValue);
                }
                return hcColor;
            });
        }

        public override void Unload()
        {
            _saveWorldDifficulty.Put("WorldDifficulty", _worldMode);
            _saveWorldDifficulty.Save();
            _saveWorldDifficulty = null;
            _worldMode = null;
            IL.Terraria.GameContent.UI.Elements.UIWorldListItem.DrawSelf -= UIWorldListItem_DrawSelf;
        }
    }
}