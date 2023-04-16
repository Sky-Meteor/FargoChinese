using System;
using System.Collections.Generic;
using Fargowiltas;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FargoChinese.GameCommentSystem
{
    public class FargoMutantItem : GlobalItem
    {
        private const string Graveyard = "墓地";
        private const string Crimson = "猩红之地";
        private const string Corruption = "腐化之地";
        private const string Hallow = "神圣之地";
        private const string Jungle = "丛林";
        private const string Snow = "雪原";
        private const string Desert = "沙漠";
        private const string BloodMoon = "血月";
        private const string Space = "太空";
        private const string HardMode = "困难模式";
        private const string Dungeon = "地牢";
        private const string Underground = "地下";
        private const string Underworld = "地狱";

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            Player player = Main.LocalPlayer;

            #region Painter
            switch (item.type)
            {
                #region Vanilla
                case ItemID.Daylight:
                    AddPaintingTip(In(Not(Graveyard)), !player.ZoneGraveyard);
                    break;
                case ItemID.FirstEncounter:
                    AddPaintingTip(In(Not(Graveyard)) + And(Moon(0, 1)), !player.ZoneGraveyard && Main.moonPhase is 0 or 1);
                    break;
                case ItemID.GoodMorning:
                    AddPaintingTip(In(Not(Graveyard)) + And(Moon(2, 3)), !player.ZoneGraveyard && Main.moonPhase is 2 or 3);
                    break;
                case ItemID.UndergroundReward:
                    AddPaintingTip(In(Not(Graveyard)) + And(Moon(4, 5)), !player.ZoneGraveyard && Main.moonPhase is 4 or 5);
                    break;
                case ItemID.ThroughtheWindow:
                    AddPaintingTip(In(Not(Graveyard)) + And(Moon(6, 7)), !player.ZoneGraveyard && Main.moonPhase is 6 or 7);
                    break;
                case ItemID.DeadlandComesAlive:
                    AddPaintingTip(Crimson, player.ZoneCrimson);
                    break;
                case ItemID.LightlessChasms:
                    AddPaintingTip(Corruption, player.ZoneCorrupt);
                    break;
                case ItemID.TheLandofDeceivingLooks:
                    AddPaintingTip(Hallow, player.ZoneHallow);
                    break;
                case ItemID.DoNotStepontheGrass:
                    AddPaintingTip(Jungle, player.ZoneJungle);
                    break;
                case ItemID.ColdWatersintheWhiteLand:
                    AddPaintingTip(Snow, player.ZoneSnow);
                    break;
                case ItemID.SecretoftheSands:
                    AddPaintingTip(Desert, player.ZoneDesert);
                    break;
                case ItemID.EvilPresence:
                    AddPaintingTip(When(BloodMoon), Main.bloodMoon);
                    break;
                case ItemID.PlaceAbovetheClouds:
                    AddPaintingTip(In(Of(Not(Graveyard)) + Space), !player.ZoneGraveyard && player.ZoneSkyHeight);
                    break;
                case ItemID.SkyGuardian:
                    AddPaintingTip(In(HardMode + Of(Not(Graveyard)) + Space), !player.ZoneGraveyard && player.ZoneSkyHeight);
                    break;
                case ItemID.Nevermore:
                case ItemID.Reborn:
                case ItemID.Graveyard:
                case ItemID.GhostManifestation:
                case ItemID.WickedUndead:
                case ItemID.BloodyGoblet:
                case ItemID.StillLife:
                    AddPaintingTip(In(Graveyard), player.ZoneGraveyard);
                    break;
                #endregion
                #region FargosMutant
                case ItemID.BloodMoonRising:
                case ItemID.BoneWarp:
                case ItemID.TheCreationoftheGuide:
                case ItemID.TheCursedMan:
                case ItemID.TheDestroyer:
                case ItemID.Dryadisque:
                case ItemID.TheEyeSeestheEnd:
                case ItemID.FacingtheCerebralMastermind:
                case ItemID.GloryoftheFire:
                case ItemID.GoblinsPlayingPoker:
                case ItemID.GreatWave:
                case ItemID.TheGuardiansGaze:
                case ItemID.TheHangedMan:
                case ItemID.Impact:
                case ItemID.ThePersistencyofEyes:
                case ItemID.PoweredbyBirds:
                case ItemID.TheScreamer:
                case ItemID.SkellingtonJSkellingsworth:
                case ItemID.SparkyPainting:
                case ItemID.SomethingEvilisWatchingYou:
                case ItemID.StarryNight:
                case ItemID.TrioSuperHeroes:
                case ItemID.TheTwinsHaveAwoken:
                case ItemID.UnicornCrossingtheHallows:
                    AddPaintingTip(In(Dungeon), player.ZoneDungeon);
                    break;
                case ItemID.AmericanExplosive:
                case ItemID.CrownoDevoursHisLunch:
                case ItemID.Discover:
                case ItemID.FatherofSomeone:
                case ItemID.FindingGold:
                case ItemID.GloriousNight:
                case ItemID.GuidePicasso:
                case ItemID.Land:
                case ItemID.TheMerchant:
                case ItemID.NurseLisa:
                case ItemID.OldMiner:
                case ItemID.RareEnchantment:
                case ItemID.Sunflowers:
                case ItemID.TerrarianGothic:
                case ItemID.Waldo:
                    AddPaintingTip(Underground, player.ZoneRockLayerHeight || player.ZoneDirtLayerHeight);
                    break;
                case ItemID.DarkSoulReaper:
                case ItemID.Darkness:
                case ItemID.DemonsEye:
                case ItemID.FlowingMagma:
                case ItemID.HandEarth:
                case ItemID.ImpFace:
                case ItemID.LakeofFire:
                case ItemID.LivingGore:
                case ItemID.OminousPresence:
                case ItemID.ShiningMoon:
                case ItemID.Skelehead:
                case ItemID.TrappedGhost:
                    AddPaintingTip(Underworld, player.ZoneUnderworldHeight);
                    break;
                    #endregion
            }

            void AddPaintingTip(string tip, bool condition)
            {
                const string defaultColor = "FF4777";
                const string achievedColor = "0BDA51";
                string color = condition ? achievedColor : defaultColor;
                tooltips.Add(new TooltipLine(Mod, "FCPaintingTip", $"[i:Fargowiltas/Painter] [c/{color}:在{tip}售卖]"));
                if (condition && ModContent.GetInstance<FargoConfig>().NPCSales && (player.ZoneDungeon || player.ZoneRockLayerHeight || player.ZoneDirtLayerHeight || player.ZoneUnderworldHeight))
                    tooltips.Add(new TooltipLine(Mod, "FCPaintingTipExtra", $"[i:Fargowiltas/Painter] [c/{defaultColor}:如果没有找到预期的画作，可能是因为Fargo突变的配置（NPC卖额外商品）导致原画作被覆盖]"));
            }

            string Not(string tip) => $"非{tip}";

            string And(string tip) => $"且{tip}";

            string Or(string tip) => $"或{tip}";

            string In(string tip) => $"{tip}中";

            string When(string tip) => $"{tip}时";

            string Of(string tip) => $"{tip}的";

            string Moon(params int[] id)
            {
                string ret = "";
                foreach (int i in id)
                {
                    if (ret == "")
                        ret += MoonToName(i);
                    else
                        ret += Or(MoonToName(i));
                }
                return $"{When($"月相为{ret}")}";
            }

            string MoonToName(int id)
            {
                return id switch
                {
                    0 => "满月",
                    1 => "亏凸月",
                    2 => "下弦月",
                    3 => "残月",
                    4 => "新月",
                    5 => "娥眉月",
                    6 => "上弦月",
                    7 => "盈凸月",
                    _ => throw new Exception($"不存在id为{id}的月相")
                };
            }
            #endregion
        }
    }
}