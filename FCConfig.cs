using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace FargoChinese
{
    public class FCConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [Label("开启永恒与受虐难度在地图选择界面的显示")]
        [DefaultValue(true)]
        [ReloadRequired]
        // ReSharper disable once UnassignedField.Global
        public bool EnableWorldDifficultyChange;

        [Label("开启永恒与受虐难度在地图选择界面的特殊动画（需要开启上一条）")]
        [DefaultValue(true)]
        [ReloadRequired]
        // ReSharper disable once UnassignedField.Global
        public bool EnableWorldDifficultyShader;
    }
}