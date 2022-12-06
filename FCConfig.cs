using Terraria.ModLoader;
using Terraria;
using Terraria.ModLoader.Config;
using System.ComponentModel;

namespace FargoChinese
{
    internal class FCConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [Header("指令相关选项")]
        [Label("开关魂提示每行显示条数")]
        [DefaultValue(10)]
        public int CommandTogglePerLine;
    }
}
