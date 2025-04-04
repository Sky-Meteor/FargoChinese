using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace FargoChinese
{
    public class FCConfig : ModConfig
    {
        public static FCConfig Instance;
        
        public override void OnLoaded()
        {
            Instance = this;
        }

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
        
        [DefaultValue(false)]
        public bool AllTipsOn
        {
            get => FruitTip && KeyBindTip;
            set
            {
                if (value)
                {
                    FruitTip = true;
                    KeyBindTip = true;
                    AllTipsOff = false;
                }
            }
        }
        
        [DefaultValue(false)]
        public bool AllTipsOff
        {
            get => !FruitTip && !KeyBindTip;
            set
            {
                if (value)
                {
                    FruitTip = false;
                    KeyBindTip = false;
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