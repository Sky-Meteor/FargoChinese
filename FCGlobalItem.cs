using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Fargowiltas;
using Fargowiltas.Items.Summons;
using Fargowiltas.NPCs;
using Microsoft.VisualBasic;
using Fargowiltas.Items.CaughtNPCs;
using System.Text.RegularExpressions;

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
                    if (tooltips[i].Text == "Reveals the whole map")
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

            if (GetInstance<FargoConfig>().ExpandedTooltips)
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
                        if (GetInstance<FargoConfig>().Fountains)
                            ModifyFountainTooltip("海洋", "Ocean");
                        break;

                    case ItemID.OasisFountain:
                    case ItemID.DesertWaterFountain:
                        if (GetInstance<FargoConfig>().Fountains)
                            ModifyFountainTooltip("沙漠", "Desert");
                        break;

                    case ItemID.JungleWaterFountain:
                        if (GetInstance<FargoConfig>().Fountains)
                            ModifyFountainTooltip("丛林", "Jungle");
                        break;

                    case ItemID.IcyWaterFountain:
                        if (GetInstance<FargoConfig>().Fountains)
                            ModifyFountainTooltip("雪原", "Snow");
                        break;

                    case ItemID.CorruptWaterFountain:
                        if (GetInstance<FargoConfig>().Fountains)
                            ModifyFountainTooltip("腐化之地", "Corruption");
                        break;

                    case ItemID.CrimsonWaterFountain:
                        if (GetInstance<FargoConfig>().Fountains)
                            ModifyFountainTooltip("猩红之地", "Crimson");
                        break;

                    case ItemID.HallowedWaterFountain:
                        if (GetInstance<FargoConfig>().Fountains)
                            ModifyFountainTooltip("神圣之地（在困难模式中生效）", "Hallow (in hardmode only)");
                        break;

                    case ItemID.BugNet:
                    case ItemID.GoldenBugNet:
                    case ItemID.FireproofBugNet:
                        if (GetInstance<FargoConfig>().CatchNPCs)
                        {
                            ModifyTooltip("[i:1991] [c/AAAAAA:可以抓城镇NPC]", "[i:1991] [c/AAAAAA:Can also catch townsfolk]");
                        }
                        break;
                }

                if (GetInstance<FargoConfig>().ExtraLures)
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

                if (GetInstance<FargoConfig>().UnlimitedPotionBuffsOn120 && item.maxStack > 1)
                {
                    if (item.buffType != 0)
                        ModifyTooltip("[i:87] [c/AAAAAA:物品栏，猪猪存钱罐或保险箱中的此物品堆叠30个时获得无尽增益]", "[i:87] [c/AAAAAA:Unlimited buff at thirty stack in inventory, Piggy Bank, or Safe]");
                    else if (item.type == ItemID.SharpeningStation
                            || item.type == ItemID.AmmoBox
                            || item.type == ItemID.CrystalBall
                            || item.type == ItemID.BewitchingTable
                            || item.type == ItemID.SliceOfCake)
                        ModifyTooltip("[i:87] [c/AAAAAA:物品栏，猪猪存钱罐或保险箱中的此物品堆叠15个时获得无尽增益]", "[i:87] [c/AAAAAA:Unlimited buff at thirty stack in inventory, Piggy Bank, or Safe]");
                }

                if (GetInstance<FargoConfig>().PiggyBankAcc)
                {
                    int[] Informational = { ItemID.CopperWatch, ItemID.TinWatch, ItemID.TungstenWatch, ItemID.SilverWatch, ItemID.GoldWatch, ItemID.PlatinumWatch, ItemID.DepthMeter, ItemID.Compass, ItemID.Radar, ItemID.LifeformAnalyzer, ItemID.TallyCounter, ItemID.MetalDetector, ItemID.Stopwatch, ItemID.Ruler, ItemID.FishermansGuide, ItemID.Sextant, ItemID.WeatherRadio, ItemID.GPS, ItemID.REK, ItemID.GoblinTech, ItemID.FishFinder, ItemID.PDA, ItemID.CellPhone };
                    int[] Construction = { ItemID.Toolbelt, ItemID.Toolbox, ItemID.ExtendoGrip, ItemID.PaintSprayer, ItemID.BrickLayer, ItemID.PortableCementMixer, ItemID.ActuationAccessory, ItemID.ArchitectGizmoPack };

                    if (Informational.Contains(item.type) || Construction.Contains(item.type))
                        ModifyTooltip("[i:87] [c/AAAAAA:在猪猪存钱罐和保险箱中同样生效]", "[i:87] [c/AAAAAA:Works from Piggy Bank and Safe]");
                }

                if (Squirrel.SquirrelSells(item, out Squirrel.SquirrelSellType sellType) != Squirrel.ShopGroup.None)
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
}
