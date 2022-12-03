using Terraria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using FargowiltasSouls.Items.Accessories.Enchantments;

namespace FargoChinese.Commands
{
    public class FargoCommand : ModCommand
    {
        public override CommandType Type => CommandType.Chat;

        public override string Command => "mutant";

        public override void Action(CommandCaller caller, string input, string[] args)
        {              
            /*foreach (string i in args)
                Main.NewText(i);
            CombatText.NewText(caller.Player.Hitbox, Main.DiscoColor, "yee");*/
        }
    }
}
