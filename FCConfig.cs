using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace FargoChinese
{
    public class FCConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [Header("地图难度特殊显示效果")]
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

        [Header("额外物品信息")]
        [Label("显示油漆工卖画条件提示")]
        [Tooltip("当提示行变为绿色，表明你满足了条件")]
        [DefaultValue(true)]
        // ReSharper disable once UnassignedField.Global
        public bool PainterTip;

        [Label("显示摇树及伐木工树木宝藏掉落水果提示")]
        [Tooltip("当提示行变为绿色，表明你满足了条件")]
        [DefaultValue(true)]
        // ReSharper disable once UnassignedField.Global
        public bool FruitTip;

        [Label("显示钓鱼装备饰品获取提示")]
        [Tooltip("当提示行变为绿色，表明你满足了条件")]
        [DefaultValue(true)]
        // ReSharper disable once UnassignedField.Global
        public bool FishingTip;

        [Label("显示染料原料获取提示")]
        [Tooltip("当提示行变为绿色，表明你满足了条件")]
        [DefaultValue(true)]
        // ReSharper disable once UnassignedField.Global
        public bool DyeTip;

        [Label("显示Fargo突变键位绑定提示")]
        [DefaultValue(true)]
        // ReSharper disable once UnassignedField.Global
        public bool KeyBindTip;

        [Label("显示“快捷使用背包左下角物品”键位绑定提示")]
        [Tooltip("单独添加了一个配置选项，避免觉得左下角物品总多一行物品信息烦人")]
        [DefaultValue(true)]
        // ReSharper disable once UnassignedField.Global
        public bool CustomKeyBindTip;

        [Label("显示Fargo魂石键位绑定提示")]
        [DefaultValue(true)]
        // ReSharper disable once UnassignedField.Global
        public bool SoulsKeyBindTip;

        [Label("开启全部")]
        [DefaultValue(false)]
        public bool AllTipsOn
        {
            get => PainterTip && FruitTip && FishingTip && DyeTip && KeyBindTip && CustomKeyBindTip && SoulsKeyBindTip;
            set
            {
                if (value)
                {
                    PainterTip = true;
                    FruitTip = true;
                    FishingTip = true;
                    DyeTip = true;
                    KeyBindTip = true;
                    CustomKeyBindTip = true;
                    SoulsKeyBindTip = true;
                    AllTipsOff = false;
                }
            }
        }

        [Label("关闭全部")]
        [DefaultValue(false)]
        public bool AllTipsOff
        {
            get => !PainterTip && !FruitTip && !FishingTip && !DyeTip && !KeyBindTip && !CustomKeyBindTip && !SoulsKeyBindTip;
            set
            {
                if (value)
                {
                    PainterTip = false;
                    FruitTip = false;
                    FishingTip = false;
                    DyeTip = false;
                    KeyBindTip = false;
                    CustomKeyBindTip =false;
                    SoulsKeyBindTip = false;
                    AllTipsOn = false;
                }
            }
        }

        /*[Label("更改游戏标题")]
        [DefaultValue(true)]
        [ReloadRequired]
        // ReSharper disable once UnassignedField.Global
        public bool EnableGameTitleChange;*/
    }
}