/*using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace FargoChinese.UnmanagedTranslations
{
    public class ModPlayerTranslate : ModPlayer
    {
        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource, ref int cooldownCounter)
        {
            string deathText = damageSource.GetDeathText(Player.name).ToString();
            if (deathText.Contains(" was destroyed by their own magic."))
                damageSource = PlayerDeathReason.ByCustomReason($"{Player.name}被自己的魔法摧毁了。");
            if (deathText.Contains("感到了心碎。"))
                damageSource = PlayerDeathReason.ByCustomReason($"{Player.name}被假心欺骗了。");
            if (deathText.Contains(" was pricked by a Cactus."))
                damageSource = PlayerDeathReason.ByCustomReason($"{Player.name}被仙人掌扎死了。");
            return base.PreHurt(pvp, quiet, ref damage, ref hitDirection, ref crit, ref customDamage, ref playSound, ref genGore, ref damageSource, ref cooldownCounter);
        }
    }
}*/