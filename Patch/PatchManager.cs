using FargoChinese.Patch.Fargowiltas;
using FargoChinese.Patch.FargowiltasSouls;
using Terraria.ModLoader;

namespace FargoChinese.Patch
{
    public class PatchManager : ModSystem
    {
        public override void Load()
        {
            ChatButtonsTranslate.Load();
            ChatMessagesTranslate.Load();
            KeyBindsTranslate.Load();
            StatSheetTranslate.Load();

            if (ModLoader.TryGetMod("FargowiltasSouls", out _))
            {
                BossChecklistTranslate.Load();
                DropConditionsTranslate.Load();
                UITranslate.Load();
            }
        }
        public override void Unload()
        {
            ChatButtonsTranslate.Unload();
            ChatMessagesTranslate.Load();
            KeyBindsTranslate.Unload();
            StatSheetTranslate.Unload();

            if (ModLoader.TryGetMod("FargowiltasSouls", out _))
            {
                DropConditionsTranslate.Unload();
                UITranslate.Unload();
            }
        }
    }
}