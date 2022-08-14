using Terraria.ModLoader;

namespace FargoChinese
{
    public class PatchManager : ModSystem
    {
        public override void Load()
        {
            ChatButtonsTranslate.Load();
            StatSheetTranslate.Load();
        }
        public override void Unload()
        {
            ChatButtonsTranslate.Unload();
            StatSheetTranslate.Unload();
        }
    }
}