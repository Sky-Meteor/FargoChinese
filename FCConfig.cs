using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace FargoChinese
{
    public class FCConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [Header("WorldDifficulty")]
        [DefaultValue(true)]
        [ReloadRequired]
        // ReSharper disable once UnassignedField.Global
        public bool EnableWorldDifficultyChange;
        
        [DefaultValue(true)]
        [ReloadRequired]
        // ReSharper disable once UnassignedField.Global
        public bool EnableWorldDifficultyShader;

        [Header("ExtraTooltip")]
        [DefaultValue(true)]
        // ReSharper disable once UnassignedField.Global
        public bool PainterTip;
        
        [DefaultValue(true)]
        // ReSharper disable once UnassignedField.Global
        public bool FruitTip;
        
        [DefaultValue(true)]
        // ReSharper disable once UnassignedField.Global
        public bool FishingTip;
        
        [DefaultValue(true)]
        // ReSharper disable once UnassignedField.Global
        public bool DyeTip;
        
        [DefaultValue(true)]
        // ReSharper disable once UnassignedField.Global
        public bool KeyBindTip;

        [DefaultValue(true)]
        // ReSharper disable once UnassignedField.Global
        public bool CustomKeyBindTip;
        
        [DefaultValue(true)]
        // ReSharper disable once UnassignedField.Global
        public bool SoulsKeyBindTip;
        
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