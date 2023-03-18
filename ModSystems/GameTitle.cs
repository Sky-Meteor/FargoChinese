using FargoChinese.Patch;
using Terraria.ModLoader;

namespace FargoChinese.ModSystems
{
    public class GameTitle : PatchBase
    {
        public override bool IsLoadingEnabled(Mod mod) => false;// ModContent.GetInstance<FCConfig>().EnableGameTitleChange;

        public override void Load()
        {
            On.Terraria.Lang.GetRandomGameTitle += Lang_GetRandomGameTitle;
        }

        private static string Lang_GetRandomGameTitle(On.Terraria.Lang.orig_GetRandomGameTitle orig)
        {
            return orig.Invoke();
        }

        public override void Unload()
        {
            On.Terraria.Lang.GetRandomGameTitle -= Lang_GetRandomGameTitle;
        }
    }
}