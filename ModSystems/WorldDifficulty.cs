using Terraria.ModLoader;
using Terraria.GameContent.UI.Elements;
using System.Reflection;
using MonoMod.Cil;
using Terraria;
using Microsoft.Xna.Framework;
using System;
using Terraria.IO;
using System.Collections.Generic;
using Terraria.ModLoader.IO;
using MonoMod.Utils;
using Mono.Cecil.Cil;
using FargowiltasSouls;
using System.IO;

namespace FargoChinese.ModSystems
{
    [JITWhenModsEnabled("FargowiltasSouls")]
    public class WorldDifficulty : ModSystem
    {
        public override bool IsLoadingEnabled(Mod mod) => ModLoader.TryGetMod("FargowiltasSouls", out _) && ModContent.GetInstance<FCConfig>().EnableWorldDifficultyChange;

        Preferences SaveWorldDifficulty;
        static string path = Path.Combine(Main.SavePath, "ModConfigs", "FargoChinese_WorldDifficulty.json");
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
            SaveWorldDifficulty = new Preferences(path);
            SaveWorldDifficulty.Load();
            _worldMode = SaveWorldDifficulty.Get<Dictionary<Guid, int>>("WorldDifficulty", new());
            SaveWorldDifficulty.Put("WorldDifficulty", _worldMode);
            SaveWorldDifficulty.Save();
            //On.Terraria.GameContent.UI.Elements.UIWorldListItem.DrawSelf += On_UIWorldListItem_DrawSelf;
            IL.Terraria.GameContent.UI.Elements.UIWorldListItem.DrawSelf += UIWorldListItem_DrawSelf; ;
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
            ILCursor c = new ILCursor(il);
            if (!c.TryGotoNext(i => i.MatchLdstr("UI.Expert")))
                return;
            c.Index++;
            c.Emit(OpCodes.Ldarg_0);
            c.EmitDelegate<Func<string, UIWorldListItem, string>>((difficultyKey, self) =>
            {
                FieldInfo data = self.GetType().GetField("_data", BindingFlags.NonPublic | BindingFlags.Instance);
                if (data.GetValue(self) is WorldFileData worldFileData && _worldMode.TryGetValue(worldFileData.UniqueId, out int difficulty) && difficulty == 1)
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
                if (data.GetValue(self) is WorldFileData worldFileData && _worldMode.TryGetValue(worldFileData.UniqueId, out int difficulty))
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
                if (data.GetValue(self) is WorldFileData worldFileData && _worldMode.TryGetValue(worldFileData.UniqueId, out int difficulty) && difficulty == 2)
                {
                    return new Color(0, byte.MaxValue, byte.MaxValue);
                }
                return hcColor;
            });
        }

        public override void Unload()
        {
            SaveWorldDifficulty.Put("WorldDifficulty", _worldMode);
            SaveWorldDifficulty.Save();
            SaveWorldDifficulty = null;
            _worldMode = null;
            IL.Terraria.GameContent.UI.Elements.UIWorldListItem.DrawSelf -= UIWorldListItem_DrawSelf;
        }
    }
}