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
        public bool FruitTip;
        
        [DefaultValue(true)]
        // ReSharper disable once UnassignedField.Global
        public bool KeyBindTip;

        [DefaultValue(true)]
        // ReSharper disable once UnassignedField.Global
        public bool SoulsKeyBindTip;
        
        [DefaultValue(false)]
        public bool AllTipsOn
        {
            get => FruitTip && KeyBindTip && SoulsKeyBindTip;
            set
            {
                if (value)
                {
                    FruitTip = true;
                    KeyBindTip = true;
                    SoulsKeyBindTip = true;
                    AllTipsOff = false;
                }
            }
        }
        
        [DefaultValue(false)]
        public bool AllTipsOff
        {
            get => !FruitTip && !KeyBindTip && !SoulsKeyBindTip;
            set
            {
                if (value)
                {
                    FruitTip = false;
                    KeyBindTip = false;
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