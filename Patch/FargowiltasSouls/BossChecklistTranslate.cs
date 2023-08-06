using FargowiltasSouls.Items.Summons;
using Terraria.Localization;
using Terraria.ModLoader;

namespace FargoChinese.Patch.FargowiltasSouls
{
    [JITWhenModsEnabled("FargowiltasSouls")]
    public class BossChecklistTranslate : PatchBase
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            return false;
        }

        protected override bool LoadWithFargoSouls => true;

        public override void Load()
        {
            //ModTranslation translation = LocalizationLoader.GetOrCreateTranslation("Mods.FargowiltasSouls.BossChecklist.LifeChallengerSpawnInfo");
            //translation.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), $"白天时在神圣之地使用[i:{ModContent.ItemType<FragilePixieLamp>()}]召唤。");
        }

        public override void Unload()
        {

        }
    }
}
