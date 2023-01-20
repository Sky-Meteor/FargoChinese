using Fargowiltas;
using Fargowiltas.Items.CaughtNPCs;
using Fargowiltas.Items.Misc;
using Fargowiltas.NPCs;
using FargowiltasSouls.Items.Accessories.Enchantments;
using FargowiltasSouls.Items.Accessories.Forces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace FargoChinese
{
    public class FCGlobalItem : GlobalItem
    {
        TooltipLine FountainTooltip(string biome) => new TooltipLine(Mod, "Tooltip_zh", $"[i:909] [c/AAAAAA:激活时使周围的生物群落变为{biome}]");
        string FountainTooltipEN(string biome) => $"[i:909] [c/AAAAAA:Forces surrounding biome state to {biome} upon activation]";
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (item.type == ItemType<MapViewer>())
            {
                for (int i = 0; i < tooltips.Count; i++)
                {
                    if (tooltips[i].Text == "Reveals the map")
                    {
                        tooltips.Remove(tooltips[i]);
                        if (Main.netMode != NetmodeID.MultiplayerClient)
                        {
                            tooltips.Insert(1, new TooltipLine(Mod, "MapViewerTooltip", "显示整个地图"));
                            break;
                        }
                        else
                        {
                            tooltips.Insert(1, new TooltipLine(Mod, "MapViewerTooltip", "显示你周围的地图区域"));
                            break;
                        }
                    }
                }
            }

            void ModifyTooltip(string zh, string en, bool add = true, int insertline = 3)
            {
                if (add)
                    tooltips.Add(new TooltipLine(Mod, "Tooltip_zh", zh));
                else
                    tooltips.Insert(insertline, new TooltipLine(Mod, "Tooltip_zh", zh));
                for (int i = 0; i < tooltips.Count; i++)
                {
                    if (tooltips[i].Text == en)
                    {
                        tooltips.Remove(tooltips[i]);
                        break;
                    }
                }
            }

            FargoConfig fargoConfig = GetInstance<FargoConfig>();

            if (fargoConfig.ExpandedTooltips)
            {
                void ModifyFountainTooltip(string zhbiome, string enbiome)
                {
                    tooltips.Add(FountainTooltip(zhbiome));
                    for (int i = 0; i < tooltips.Count; i++)
                    {
                        if (tooltips[i].Text == FountainTooltipEN(enbiome))
                        {
                            tooltips.Remove(tooltips[i]);
                            break;
                        }
                    }
                }

                switch (item.type)
                {
                    case ItemID.PureWaterFountain:
                        if (fargoConfig.Fountains)
                            ModifyFountainTooltip("海洋", "Ocean");
                        break;

                    case ItemID.OasisFountain:
                    case ItemID.DesertWaterFountain:
                        if (fargoConfig.Fountains)
                            ModifyFountainTooltip("沙漠", "Desert");
                        break;

                    case ItemID.JungleWaterFountain:
                        if (fargoConfig.Fountains)
                            ModifyFountainTooltip("丛林", "Jungle");
                        break;

                    case ItemID.IcyWaterFountain:
                        if (fargoConfig.Fountains)
                            ModifyFountainTooltip("雪原", "Snow");
                        break;

                    case ItemID.CorruptWaterFountain:
                        if (fargoConfig.Fountains)
                            ModifyFountainTooltip("腐化之地", "Corruption");
                        break;

                    case ItemID.CrimsonWaterFountain:
                        if (fargoConfig.Fountains)
                            ModifyFountainTooltip("猩红之地", "Crimson");
                        break;

                    case ItemID.HallowedWaterFountain:
                        if (fargoConfig.Fountains)
                            ModifyFountainTooltip("神圣之地（在困难模式中生效）", "Hallow (in hardmode only)");
                        break;

                    case ItemID.BugNet:
                    case ItemID.GoldenBugNet:
                    case ItemID.FireproofBugNet:
                        if (fargoConfig.CatchNPCs)
                        {
                            ModifyTooltip("[i:1991] [c/AAAAAA:可以抓城镇NPC]", "[i:1991] [c/AAAAAA:Can also catch townsfolk]");
                        }
                        break;
                }

                if (fargoConfig.ExtraLures)
                {
                    switch (item.type)
                    {
                        case ItemID.FishingPotion:
                            ModifyTooltip("[i:2373] [c/AAAAAA:多抛出一条鱼线]", "[i:2373] [c/AAAAAA:Also grants one extra lure]", false);
                            break;

                        case ItemID.FiberglassFishingPole:
                        case ItemID.FisherofSouls:
                        case ItemID.Fleshcatcher:
                        case ItemID.ScarabFishingRod:
                        case ItemID.BloodFishingRod:
                            ModifyTooltip("[i:2373] [c/AAAAAA:能抛出两条鱼线]", "[i:2373] [c/AAAAAA:This rod fires 2 lures]", false);
                            break;

                        case ItemID.MechanicsRod:
                        case ItemID.SittingDucksFishingRod:
                            ModifyTooltip("[i:2373] [c/AAAAAA:能抛出三条鱼线]", "[i:2373] [c/AAAAAA:This rod fires 3 lures]", false);
                            break;

                        case ItemID.GoldenFishingRod:
                        case ItemID.HotlineFishingHook:
                            ModifyTooltip("[i:2373] [c/AAAAAA:能抛出五条鱼线]", "[i:2373] [c/AAAAAA:This rod fires 5 lures]", false);
                            break;
                    }
                }

                if (fargoConfig.TorchGodEX && item.type == ItemID.TorchGodsFavor)
                {
                    ModifyTooltip("[i:5043] [c/AAAAAA:自动替换已放置的火把来增加运气]", "[i:5043] [c/AAAAAA:Automatically swaps placed torches to boost luck]");
                    ModifyTooltip("[i:5043] [c/AAAAAA:替换火把遵循火把运气，可能会与默认的选择有不同]", "[i:5043] [c/AAAAAA:Obeys true torch luck when replacing torches, which may differ from default choices]");
                }

                if (fargoConfig.UnlimitedPotionBuffsOn120 && item.maxStack > 1)
                {
                    if (item.buffType != 0)
                        ModifyTooltip("[i:87] [c/AAAAAA:物品栏，猪猪存钱罐或保险箱中的此物品堆叠30个时获得无尽增益]", "[i:87] [c/AAAAAA:Unlimited buff at 30 stack in inventory, Piggy Bank, or Safe]");
                    else if (item.type == ItemID.SharpeningStation
                            || item.type == ItemID.AmmoBox
                            || item.type == ItemID.CrystalBall
                            || item.type == ItemID.BewitchingTable
                            || item.type == ItemID.SliceOfCake)
                        ModifyTooltip("[i:87] [c/AAAAAA:物品栏，猪猪存钱罐或保险箱中的此物品堆叠3个时获得无尽增益]", "[i:87] [c/AAAAAA:Unlimited buff at 3 stack in inventory, Piggy Bank, or Safe]");
                }

                if (fargoConfig.PiggyBankAcc)
                {
                    int[] Informational = { ItemID.CopperWatch, ItemID.TinWatch, ItemID.TungstenWatch, ItemID.SilverWatch, ItemID.GoldWatch, ItemID.PlatinumWatch, ItemID.DepthMeter, ItemID.Compass, ItemID.Radar, ItemID.LifeformAnalyzer, ItemID.TallyCounter, ItemID.MetalDetector, ItemID.Stopwatch, ItemID.Ruler, ItemID.FishermansGuide, ItemID.Sextant, ItemID.WeatherRadio, ItemID.GPS, ItemID.REK, ItemID.GoblinTech, ItemID.FishFinder, ItemID.PDA, ItemID.CellPhone };
                    int[] Construction = { ItemID.Toolbelt, ItemID.Toolbox, ItemID.ExtendoGrip, ItemID.PaintSprayer, ItemID.BrickLayer, ItemID.PortableCementMixer, ItemID.ActuationAccessory, ItemID.ArchitectGizmoPack };

                    if (Informational.Contains(item.type) || Construction.Contains(item.type))
                        ModifyTooltip("[i:87] [c/AAAAAA:在猪猪存钱罐和保险箱中同样生效]", "[i:87] [c/AAAAAA:Works from Piggy Bank and Safe]");
                }

                if (Squirrel.SquirrelSells(item, out Squirrel.SquirrelSellType sellType) != Squirrel.ShopGroup.End)
                {
                    string text = Regex.Replace(sellType.ToString(), "([a-z])([A-Z])", "$1 $2");
                    switch(text)
                    {
                        case "Craftable Materials Sold":
                            ModifyTooltip($"[i:{CaughtNPCItem.CaughtTownies[NPCType<Squirrel>()]}] [c/AAAAAA:售卖可合成材料]", $"[i:{CaughtNPCItem.CaughtTownies[NPCType<Squirrel>()]}] [c/AAAAAA:{text}]");
                            break;
                        case "Sold By Squirrel":
                            ModifyTooltip($"[i:{CaughtNPCItem.CaughtTownies[NPCType<Squirrel>()]}] [c/AAAAAA:高帽松鼠售卖]", $"[i:{CaughtNPCItem.CaughtTownies[NPCType<Squirrel>()]}] [c/AAAAAA:{text}]");
                            break;
                        case "Some Materials Sold":
                            ModifyTooltip($"[i:{CaughtNPCItem.CaughtTownies[NPCType<Squirrel>()]}] [c/AAAAAA:售卖部分材料]", $"[i:{CaughtNPCItem.CaughtTownies[NPCType<Squirrel>()]}] [c/AAAAAA:{text}]");
                            break;
                        case "Sold At Thirty Stack":
                            ModifyTooltip($"[i:{CaughtNPCItem.CaughtTownies[NPCType<Squirrel>()]}] [c/AAAAAA:堆叠30个时售卖]", $"[i:{CaughtNPCItem.CaughtTownies[NPCType<Squirrel>()]}] [c/AAAAAA:{text}]");
                            break;
                    }
                }
            }
        }
    }

    [JITWhenModsEnabled("FargowiltasSouls")]
    public class FCSoulsGlobalItem : GlobalItem
    {
        public override bool IsLoadingEnabled(Mod mod) => ModLoader.TryGetMod("FargowiltasSouls", out _);

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (item.type == ItemType<CosmoForce>())
            {
                int startIndex = default;
                for (int i = 0; i < tooltips.Count; i++)
                {
                    if (tooltips[i].Name == "Tooltip1")
                        startIndex = i;
                }
                if (startIndex != default)
                {
                    int wizard = ItemType<WizardEnchant>();
                    int solar = ItemType<SolarEnchant>();
                    int vortex = ItemType<VortexEnchant>();
                    int nebula = ItemType<NebulaEnchant>();
                    int stardust = ItemType<StardustEnchant>();

                    tooltips[startIndex].Replace(wizard, solar);
                    tooltips[startIndex + 1].Replace(wizard, solar);
                    tooltips[startIndex + 2].Replace(solar, vortex);
                    tooltips[startIndex + 3].Replace(vortex, nebula);
                    tooltips[startIndex + 4].Replace(nebula, stardust);
                    tooltips[startIndex + 5].Replace(nebula, stardust);
                }
                return;
            }
            else if (item.type == ItemType<EarthForce>())
            {
                tooltips.FindAndReplace("你发射的所有弹幕都会分裂成三个，造成50%伤害且伤害频率翻倍，弹幕增加与其一半伤害相等的护甲穿透", "你发射的所有弹幕都会分裂成三个，造成33%伤害且伤害频率提升到3倍，增加与其一半伤害相等的护甲穿透");
                return;
            }
            else if (item.type == ItemType<SpiritForce>())
            {
                tooltips.FindAndReplace("召唤栏位用光后你仍可以召唤临时的哨兵和仆从", "鞭打你的召唤物可以让它们更勤奋");
            }
        }

    }

    public static class TooltipsUtil
    {
        public static void InsertAfter(this List<TooltipLine> tooltips, string text, TooltipLine line)
        {
            for (int i = 0; i < tooltips.Count; i++)
            {
                if (tooltips[i].Text.Contains(text))
                    tooltips.Insert(i + 1, line);
            }
        }
        /*public static int Type(this string className)
        {
            ModLoader.TryGetMod("FargowiltasSouls", out Mod fargoSouls);
            fargoSouls.TryFind(className, out ModItem modItem);
            return modItem.Type;
        }*/
        public static void Replace(this TooltipLine tooltip, object Old, object New)
        {
            tooltip.Text = tooltip.Text.Replace(Old.ToString(), New.ToString());
        }
        public static void FindAndReplace(this List<TooltipLine> tooltips, object Old, object New)
        {
            tooltips.Find(l => l.Text.Contains(Old.ToString())).Replace(Old.ToString(), New.ToString());
        }
    }
}
