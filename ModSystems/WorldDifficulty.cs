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

namespace FargoChinese.ModSystems
{
    [JITWhenModsEnabled("FargowiltasSouls")]
    public class WorldDifficulty : PatchBase
    {
        public override bool IsLoadingEnabled(Mod mod) => ModLoader.TryGetMod("FargowiltasSouls", out _) && ModContent.GetInstance<FCConfig>().EnableWorldDifficultyChange && !ModContent.GetInstance<FCConfig>().EnableWorldDifficultyShader;

        private Preferences _saveWorldDifficulty;
        private static readonly string path = Path.Combine(Main.SavePath, "ModConfigs", "FargoChinese_WorldDifficulty.json");

        protected Dictionary<Guid, int> WorldMode;
        protected FieldInfo Data;
        private bool _enableWorldDifficultyShader;

        public override void SaveWorldData(TagCompound tag)
        {
            if (Main.ActiveWorldFileData.GameMode == 3)
            {
                WorldMode.Remove(Main.ActiveWorldFileData.UniqueId);
                return;
            }

            int difficulty = 0;
            if (FargoSoulsWorld.EternityMode)
                difficulty = 1;
            if (FargoSoulsWorld.MasochistModeReal)
                difficulty = 2;

            if (difficulty == 0)
            {
                WorldMode.Remove(Main.ActiveWorldFileData.UniqueId);
                return;
            }
            if (WorldMode.ContainsKey(Main.ActiveWorldFileData.UniqueId))
                WorldMode[Main.ActiveWorldFileData.UniqueId] = difficulty;
            else
                WorldMode.Add(Main.ActiveWorldFileData.UniqueId, difficulty);
        }

        public override void Load()
        {
            _saveWorldDifficulty = new Preferences(path);
            _saveWorldDifficulty.Load();
            WorldMode = _saveWorldDifficulty.Get("WorldDifficulty", new Dictionary<Guid, int>());
            _saveWorldDifficulty.Put("WorldDifficulty", WorldMode);
            _saveWorldDifficulty.Save();

            Data = typeof(UIWorldListItem).GetField("_data", BindingFlags.NonPublic | BindingFlags.Instance);
            _enableWorldDifficultyShader = ModContent.GetInstance<FCConfig>().EnableWorldDifficultyShader;

            On.Terraria.Main.EraseWorld += Main_EraseWorld;
            IL.Terraria.GameContent.UI.Elements.UIWorldListItem.DrawSelf += UIWorldListItem_DrawSelf;
        }

        private void Main_EraseWorld(On.Terraria.Main.orig_EraseWorld orig, int i)
        {
            WorldMode.Remove(Main.WorldList[i].UniqueId);
            orig.Invoke(i);
        }

        private void UIWorldListItem_DrawSelf(ILContext il)
        {
            var c = new ILCursor(il);
            if (!c.TryGotoNext(i => i.MatchLdstr("UI.Expert")))
                return;
            c.Index++;
            c.Emit(OpCodes.Ldarg_0);

            c.EmitDelegate<Func<string, UIWorldListItem, string>>((difficultyKey, self) => WorldMode.TryGetValue(((WorldFileData)Data.GetValue(self))!.UniqueId, out int difficulty) && difficulty == 1 ? "永恒" : difficultyKey);

            if (!c.TryGotoNext(i => i.MatchLdstr("UI.Master")))
                return;
            c.Index++;
            c.Emit(OpCodes.Ldarg_0);
            c.EmitDelegate<Func<string, UIWorldListItem, string>>((difficultyKey, self) =>
            {
                if (!WorldMode.TryGetValue(((WorldFileData)Data.GetValue(self))!.UniqueId, out int difficulty))
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
            c.EmitDelegate<Func<Color, UIWorldListItem, Color>>((hcColor, self) => !_enableWorldDifficultyShader && WorldMode.TryGetValue(((WorldFileData)Data.GetValue(self))!.UniqueId, out int difficulty) && difficulty == 2 ? new Color(0, 255, 255) : hcColor);
        }

        public override void Unload()
        {
            _saveWorldDifficulty.Put("WorldDifficulty", WorldMode);
            _saveWorldDifficulty.Save();
            _saveWorldDifficulty = null;
            WorldMode = null;

            Data = null;
            On.Terraria.Main.EraseWorld -= Main_EraseWorld;
            IL.Terraria.GameContent.UI.Elements.UIWorldListItem.DrawSelf -= UIWorldListItem_DrawSelf;
        }
    }
}