using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;

namespace FargoChinese
{
    public class FCPlayer : ModPlayer
    {
        public override void PostUpdateMiscEffects()
        {
            if (ModLoader.TryGetMod("Fargowiltas", out Mod fargo))
            {
                int chinese = (int)GameCulture.CultureName.Chinese;
                if (Main.netMode != NetmodeID.MultiplayerClient)
                    fargo.Find<ModItem>("MapViewer").Tooltip.AddTranslation(chinese, "显示整个地图");
                else
                    fargo.Find<ModItem>("MapViewer").Tooltip.AddTranslation(chinese, "显示你周围的地图区域");
            }
        }
    }
}
