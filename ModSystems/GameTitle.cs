using FargoChinese.Patch;
using FargowiltasSouls;
using Terraria;
using Terraria.ModLoader;

namespace FargoChinese.ModSystems
{
    [JITWhenModsEnabled("FargowiltasSouls")]
    public class GameTitle : PatchBase
    {
        public override bool IsLoadingEnabled(Mod mod) => ModLoader.TryGetMod("FargowiltasSouls", out _);// ModContent.GetInstance<FCConfig>().EnableGameTitleChange;

        public override void Load()
        {
            On.Terraria.Lang.GetRandomGameTitle += Lang_GetRandomGameTitle;
        }

        private static string Lang_GetRandomGameTitle(On.Terraria.Lang.orig_GetRandomGameTitle orig)
        {
            if (FargoSoulsWorld.MasochistModeReal)
            {
                return Main.rand.Next(6) switch
                {
                    1 => "Fargo魂石：可曾感受过受虐之旅？",
                    2 => "",
                    3 => "",
                    4 => "",
                    _ => orig.Invoke()
                };
            }

            if (FargoSoulsWorld.EternityMode)
            {
                return Main.rand.Next(6) switch
                {
                    1 => "",
                    2 => "",
                    3 => "",
                    4 => "",
                    _ => orig.Invoke()
                };
            }

            return Main.rand.Next(6) switch
            {
                1 => "Fargo魂石：现已移除突变体！",
                2 => "Fargo魂石：现已移除突变体！",
                3 => "Fargo魂石：现已移除突变体！",
                4 => "Fargo魂石：Fargo汉化垃圾东西！",
                _ => orig.Invoke()
            };
        }

        public override void Unload()
        {
            On.Terraria.Lang.GetRandomGameTitle -= Lang_GetRandomGameTitle;
        }
    }
}