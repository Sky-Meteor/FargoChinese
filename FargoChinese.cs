using FargoChinese.Patch;
using Terraria.ModLoader;

namespace FargoChinese
{
    public class FargoChinese : Mod
    {
        public static FargoChinese Instance;

        public override void Load()
        {
            Instance = this;
         //   PatchManager.Load();
        }

        public override void Unload()
        {
         //   PatchManager.Unload();
            Instance = null;
        }
    }
}