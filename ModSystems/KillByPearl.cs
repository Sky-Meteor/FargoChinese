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
using FargowiltasSouls.Content.Items.Accessories.Forces;
using FargowiltasSouls.Content.Items.Accessories.Souls;

namespace FargoChinese.ModSystems
{
    [JITWhenModsEnabled("FargowiltasSouls")]
    public class KillByPearl : ModPlayer
    {
        public bool MakeSureFirst;
        public override void OnEnterWorld()
        {
            if (ModLoader.HasMod("FargowiltasSouls"))
            {
                MakeSureFirst = false;
                Main.NewText("汉化组的提示：可在背包右下角的[i:FargowiltasSouls/TogglerIconItem]饰品效果切换菜单中选择关闭饰品效果。", 255, 255, 51);
            }           
        }
        public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource)
        {
            if (ModLoader.HasMod("FargowiltasSouls") && damageSource.SourceProjectileType == 931 && !MakeSureFirst && Main.projectile[damageSource.SourceProjectileLocalIndex].GetGlobalProjectile<PearlWoodTipProjectile>().IsSpawnByPearl)
            {
                Main.NewText("汉化组的提示：一直扣血是珍珠木魔石的效果，请仔细阅读珍珠木魔石的饰品效果说明。", 255, 204, 204);
                Main.NewText("可在背包右下角的[i:FargowiltasSouls/TogglerIconItem]饰品效果切换菜单中选择关闭饰品效果。", 255, 204, 204);
                MakeSureFirst = true;
            };
        }
    }

    [JITWhenModsEnabled("FargowiltasSouls")]
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
            Mod FargowiltasSouls = ModLoader.GetMod("FargowiltasSouls");
            if (FargowiltasSouls != null && source is IEntitySource_WithStatsFromItem s )
            {
                if(s.Item.type == ModContent.ItemType<PearlwoodEnchant>() || s.Item.type == ModContent.ItemType<TimberForce>() || s.Item.type == ModContent.ItemType<TerrariaSoul>())
                {
                    IsSpawnByPearl = true;
                }               
            };
        }
    }

    public class ItemTranslate : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            foreach (TooltipLine tooltipLine in tooltips)
            {
                tooltipLine.Text = tooltipLine.Text.Replace("Cross-mod Balance:", "多开平衡调整：");
                tooltipLine.Text = tooltipLine.Text.Replace("Damage increased by", "伤害增加");
                if (item.type == ItemID.MagicDagger)
                {
                    tooltipLine.Text = tooltipLine.Text.Replace("Damage decreased by 50% in Pre-Hardmode.", "困难模式前伤害降低50%。");
                }
                tooltipLine.Text = tooltipLine.Text.Replace("Damage decreased by", "伤害降低");
                tooltipLine.Text = tooltipLine.Text.Replace("Massively reduced damage with any minions active", "大幅降低仆从伤害");
                tooltipLine.Text = tooltipLine.Text.Replace("Less effective on true melee weapons", "对真近战武器加成减少");
                tooltipLine.Text = tooltipLine.Text.Replace("Less effective on rogue weapons", "对盗贼武器加成减少");
                tooltipLine.Text = tooltipLine.Text.Replace("Reduced effectiveness", "效果削弱");
                tooltipLine.Text = tooltipLine.Text.Replace("Effect disabled while Tin Enchantment effect is active", "锡魔石生效时失效");
                tooltipLine.Text = tooltipLine.Text.Replace("Does not inflict Oiled", "不会造成涂油减益");
                tooltipLine.Text = tooltipLine.Text.Replace("Accumulated damage capped at 500.000", "累计伤害上限为500");
            }
        }
    }
}








