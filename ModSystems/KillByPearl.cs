using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Achievements;
using Terraria.ModLoader;
using FargowiltasSouls.Content.Items.Accessories.Enchantments;
using Terraria.ID;

namespace FargoChinese.ModSystems
{
    public class KillByPearl : ModPlayer
    {
        public bool MakeSureFirst;
        public override void OnEnterWorld()
        {
            MakeSureFirst = false;
        }
        public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource)
        {
            if (damageSource.SourceProjectileType == 931 && !MakeSureFirst && Main.projectile[damageSource.SourceProjectileLocalIndex].GetGlobalProjectile<PearlWoodTipProjectile>().IsSpawnByPearl)
            {
                Main.NewText("汉化组的提示：一直扣血是珍珠木魔石的效果，请仔细阅读珍珠木魔石的饰品效果说明。");
                Main.NewText("可在背包右下角的[i:FargowiltasSouls/TogglerIconItem]饰品效果切换菜单中选择关闭饰品效果。");
                MakeSureFirst = true;
            };
        }
    }

    public class PearlWoodTipProjectile : GlobalProjectile
    {
        public override bool AppliesToEntity(Projectile entity, bool lateInstantiation)
        {
            return entity.type == ProjectileID.FairyQueenMagicItemShot;
        }
        public override bool InstancePerEntity => true;

        public bool IsSpawnByPearl;
        public override void OnSpawn(Projectile projectile, IEntitySource source)
        {
            if (source is IEntitySource_WithStatsFromItem s && s.Item.type == ModContent.ItemType<PearlwoodEnchant>())
            {
                IsSpawnByPearl = true;
            };
        }
    }
}









