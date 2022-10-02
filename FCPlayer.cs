using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;
using Terraria.Chat;
using Microsoft.Xna.Framework;

namespace FargoChinese
{
    public class FCPlayer : ModPlayer
    {
        public override void OnEnterWorld(Player player)
        {
            Main.NewText("感谢使用Fargo汉化补丁！不出意外的话，下个月Fargo汉化将会合并到Fargo本体，届时如果没有需要将停止更新汉化补丁！", Color.LightGreen);
        }
    }
}
