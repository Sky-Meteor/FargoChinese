using FargoChinese.Patch;
using FargowiltasSouls;
using Terraria;
using Terraria.ModLoader;

namespace FargoChinese.ModSystems
{
    [JITWhenModsEnabled("FargowiltasSouls")]
    public class FargoTitle : PatchBase
    {
        public override bool IsLoadingEnabled(Mod mod) => false;//ModLoader.TryGetMod("FargowiltasSouls", out _);// ModContent.GetInstance<FCConfig>().EnableGameTitleChange;

        public override void Load()
        {
            On.Terraria.Lang.GetRandomGameTitle += Lang_GetRandomGameTitle;
        }

        private static string Lang_GetRandomGameTitle(On.Terraria.Lang.orig_GetRandomGameTitle orig)
        {
            if (FargoSoulsWorld.MasochistModeReal)
            {
                return Main.rand.Next(8) switch
                {
                    1 => "Fargo：可曾感受过受虐之旅？",
                    2 => "Fargo：你不会在家门口召唤邪恶Boss吧？",
                    3 => "Fargo：喜欢我新三王石巨人月总三兄妹吗？",
                    4 => "Fargo：砍树不会刷青苔黄蜂，死亡也不会刷突变体雕像",
                    5 => "Fargo：现已推出乱扔瞎甩模式",
                    6 => "Fargo's Unfiltered Unrated Deviations of Abominable Mutant Souls: Apocalypses Unleashed (REMASTERED)",
                    _ => orig.Invoke()
                };
            }

            if (FargoSoulsWorld.EternityMode)
            {
                return Main.rand.Next(8) switch
                {
                    1 => "Fargo：白邪教徒弓箭手",
                    2 => "Fargo：试试墓碑克星",
                    3 => "Fargo：见过11只红魔鬼吗",
                    4 => "Fargo：现已推出套娃史莱姆",
                    5 => "Fargo：菜就多练练",
                    6 => "Fargo's Unfiltered Unrated Deviations of Abominable Mutant Souls: Apocalypses Unleashed (REMASTERED)",
                    _ => orig.Invoke()
                };
            }

            return Main.rand.Next(7) switch
            {
                1 => "Fargo：现已移除突变体！",
                2 => "Fargo：现已移除永恒之魂！",
                3 => "Fargo：你仔细看过模组配置吗？",
                4 => "Fargo：Fargo汉化垃圾东西！",
                _ => orig.Invoke()
            };
        }

        public override void Unload()
        {
            On.Terraria.Lang.GetRandomGameTitle -= Lang_GetRandomGameTitle;
        }
    }
}