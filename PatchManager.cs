using Terraria.ModLoader;

namespace FargoChinese
{
    public class PatchManager : ModSystem
    {
        public override void Load()
        {
            ChatButtonsTranslate.Load();
            StatSheetTranslate.Load();

            if (ModLoader.TryGetMod("FargowiltasSouls", out _))
            {
                DropConditionsTranslate.Load();
            }
        }
        public override void Unload()
        {
            ChatButtonsTranslate.Unload();
            StatSheetTranslate.Unload();

            if (ModLoader.TryGetMod("FargowiltasSouls", out _))
            {
                DropConditionsTranslate.Unload();
            }
        }
    }
}