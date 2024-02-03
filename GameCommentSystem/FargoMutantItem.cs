using System.Collections.Generic;
using Fargowiltas;
using Terraria;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using static FargoChinese.GameCommentSystem.CommentSystemUtils;

namespace FargoChinese.GameCommentSystem
{
    public class FargoMutantItem : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            Player player = Main.LocalPlayer;
            var fargoPlayer = player.GetModPlayer<FargoPlayer>();
            /*#region Painter
            if (!ModContent.GetInstance<FCConfig>().PainterTip)
                goto Fruit;
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
                    AddFargoPaintingTip(In(Dungeon), player.ZoneDungeon);
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
                    AddFargoPaintingTip(Underground, player.ZoneRockLayerHeight || player.ZoneDirtLayerHeight);
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
                    AddFargoPaintingTip(Underworld, player.ZoneUnderworldHeight);
                    break;
                    #endregion
            }

            void AddPaintingTip(string tip, bool condition)
            {
                const string defaultColor = "FF4777";
                const string achievedColor = "0BDA51";
                string color = condition ? achievedColor : defaultColor;
                tooltips.Add(new TooltipLine(Mod, "FCPaintingTip", $"[i:Fargowiltas/Painter] [c/{color}:在{tip}售卖]"));
                if (condition && ModContent.GetInstance<FargoServerConfig>().NPCSales && (player.ZoneDungeon || player.ZoneRockLayerHeight || player.ZoneDirtLayerHeight || player.ZoneUnderworldHeight))
                    tooltips.Add(new TooltipLine(Mod, "FCPaintingTipExtra", $"[i:Fargowiltas/Painter] [c/{defaultColor}:如果没有找到预期的画作，可能是因为Fargo突变的配置（NPC卖额外商品）导致原画作被覆盖]"));
            }
            void AddFargoPaintingTip(string tip, bool condition)
            {
                const string defaultColor = "FF4777";
                const string achievedColor = "0BDA51";
                string color = condition ? achievedColor : defaultColor;
                tooltips.Add(new TooltipLine(Mod, "FCPaintingTip", $"[i:Fargowiltas/Painter] [c/{color}:{EnableFargosNPCSale}在{tip}售卖]"));
                if (condition && ModContent.GetInstance<FargoServerConfig>().NPCSales && (player.ZoneDungeon || player.ZoneRockLayerHeight || player.ZoneDirtLayerHeight || player.ZoneUnderworldHeight))
                    tooltips.Add(new TooltipLine(Mod, "FCPaintingTipExtra", $"[i:Fargowiltas/Painter] [c/{defaultColor}:如果没有找到预期的画作，可能是因为Fargo突变的配置（NPC卖额外商品）导致原画作被覆盖]"));
            }
            #endregion*/
            #region Fruit
            Fruit:
            if (!ModContent.GetInstance<FCConfig>().FruitTip)
                goto KeyBind;
            bool condition;
            switch (item.type)
            {
                case ItemID.Apple:
                    AddFruitTip(ForestTree);
                    break;
                case ItemID.Peach:
                case ItemID.Apricot:
                case ItemID.Grapefruit:
                case ItemID.Lemon:
                    AddFruitTip(ForestTree);
                    condition = !(player.ZoneDesert || player.ZoneJungle || player.ZoneHallow ||
                                  (player.ZoneGlowshroom && Main.hardMode) || player.ZoneCorrupt || player.ZoneCrimson
                                  || player.ZoneSnow || player.ZoneBeach || player.ZoneUnderworldHeight ||
                                  player.ZoneRockLayerHeight || player.ZoneDirtLayerHeight);
                    AddLumberTip(Forest);
                    break;
                case ItemID.Plum:
                case ItemID.Cherry:
                    AddFruitTip(BorealTree);
                    condition = !(player.ZoneDesert || player.ZoneJungle || player.ZoneHallow ||
                                  (player.ZoneGlowshroom && Main.hardMode) || player.ZoneCorrupt ||
                                  player.ZoneCrimson) && player.ZoneSnow;
                    AddLumberTip(Snow);
                    break;
                case ItemID.Mango:
                case ItemID.Pineapple:
                    AddFruitTip(MahoganyTree);
                    condition = !player.ZoneDesert && player.ZoneJungle;
                    AddLumberTip(Jungle);
                    break;
                case ItemID.Coconut:
                case ItemID.Banana:
                    AddFruitTip(Of(Ocean) + PalmTree);
                    condition = !(player.ZoneDesert || player.ZoneJungle || player.ZoneHallow ||
                                  (player.ZoneGlowshroom && Main.hardMode) || player.ZoneCorrupt || player.ZoneCrimson
                                  || player.ZoneSnow) && player.ZoneBeach;
                    AddLumberTip(Ocean);
                    break;
                case ItemID.Elderberry:
                case ItemID.BlackCurrant:
                    AddFruitTip(EbonwoodTree);
                    condition = !(player.ZoneDesert || player.ZoneJungle || player.ZoneHallow ||
                                  (player.ZoneGlowshroom && Main.hardMode)) &&
                                (player.ZoneCorrupt || player.ZoneCrimson);
                    AddLumberTip(EvilBiome);
                    break;
                case ItemID.BloodOrange:
                case ItemID.Rambutan:
                    AddFruitTip(ShadewoodTree);
                    condition = !(player.ZoneDesert || player.ZoneJungle || player.ZoneHallow ||
                                  (player.ZoneGlowshroom && Main.hardMode)) &&
                                (player.ZoneCorrupt || player.ZoneCrimson);
                    AddLumberTip(EvilBiome);
                    break;
                case ItemID.Dragonfruit:
                case ItemID.Starfruit:
                    AddFruitTip(PearlwoodTree);
                    condition = !(player.ZoneDesert || player.ZoneJungle) && player.ZoneHallow;
                    AddLumberTip(Hallow);
                    break;
            }

            void AddFruitTip(string tree) => tooltips.Add(new TooltipLine(Mod, "FCFruitTip", $"[i:{item.type}] [c/DE7D2C:通过摇晃{tree}获得]"));

            void AddLumberTip(string biome)
            {
                const string defaultColor = "FF4777";
                const string achievedColor = "0BDA51";
                string color = condition ? achievedColor : defaultColor;
                tooltips.Add(new TooltipLine(Mod, "FCLumberTip", $"[i:Fargowiltas/LumberJack] [c/{color}:在{biome}通过树木宝藏概率获得]"));
            }
            #endregion
            /* #region Fishing
            Fishing:
            if (!ModContent.GetInstance<FCConfig>().FishingTip)
                goto Dye;
            switch (item.type)
            {
                #region Clothier
                case ItemID.AnglerHat:
                    AddFishingTip(10, true);
                    break;
                case ItemID.AnglerVest:
                    AddFishingTip(15, true);
                    break;
                case ItemID.AnglerPants:
                    AddFishingTip(20, true);
                    break;
                #endregion
                #region Merchant
                case ItemID.FuzzyCarrot:
                    AddFishingTip(5);
                    break;
                case ItemID.AnglerEarring:
                case ItemID.HighTestFishingLine:
                case ItemID.TackleBox:
                case ItemID.GoldenBugNet:
                case ItemID.FishHook:
                    AddFishingTip(10);
                    break;
                case ItemID.FinWings:
                case ItemID.SuperAbsorbantSponge:
                case ItemID.BottomlessBucket:
                    AddFishingTip(10, hardMode: true);
                    break;
                case ItemID.HotlineFishingHook:
                    AddFishingTip(25, hardMode: true);
                    break;
                case ItemID.GoldenFishingRod:
                    AddFishingTip(30, hardMode: true);
                    break;
                #endregion
            }

            void AddFishingTip(int need, bool clothier = false, bool hardMode = false)
            {
                const string defaultColor = "717D6D";
                const string achievedColor = "0BDA51";
                string color = player.anglerQuestsFinished >= need ? achievedColor : defaultColor;
                tooltips.Add(new TooltipLine(Mod, "FCFishingTip", $"[i:Fargowiltas/{(clothier ? "Clothier" : "Merchant")}] [c/{color}:完成{need}个渔夫任务后由{(clothier ? "服装商" : "商人")}{(hardMode ? "在困难模式中" : "")}售卖]"));
            }
            #endregion
            #region Dye
            Dye:
            if (!ModContent.GetInstance<FCConfig>().DyeTip)
                goto KeyBind;
            switch (item.type)
            {
                case ItemID.RedHusk:
                    AddDyeTip("RedHusk");
                    break;
                case ItemID.OrangeBloodroot:
                    AddDyeTip("OrangeBloodroot");
                    break;
                case ItemID.YellowMarigold:
                    AddDyeTip("YellowMarigold");
                    break;
                case ItemID.LimeKelp:
                    AddDyeTip("LimeKelp");
                    break;
                case ItemID.GreenMushroom:
                    AddDyeTip("GreenMushroom");
                    break;
                case ItemID.TealMushroom:
                    AddDyeTip("TealMushroom");
                    break;
                case ItemID.CyanHusk:
                    AddDyeTip("CyanHusk"); 
                    break;
                case ItemID.SkyBlueFlower:
                    AddDyeTip("SkyBlueFlower");
                    break;
                case ItemID.BlueBerries:
                    AddDyeTip("BlueBerries");
                    break;
                case ItemID.PurpleMucos:
                    AddDyeTip("PurpleMucos");
                    break;
                case ItemID.VioletHusk:
                    AddDyeTip("VioletHusk");
                    break;
                case ItemID.PinkPricklyPear:
                    AddDyeTip("PinkPricklyPear");
                    break;
                case ItemID.BlackInk:
                    AddDyeTip("BlackInk");
                    break; 
            }
            void AddDyeTip(string dye)
            {
                const string defaultColor = "2C3C72";
                const string achievedColor = "0BDA51";
                if (fargoPlayer.GetType().GetField("FirstDyeIngredients", BindingFlags.Instance | BindingFlags.NonPublic)?.GetValue(fargoPlayer) is not Dictionary<string, bool> firstDyeIngredients)
                    return;
                string color = firstDyeIngredients[dye] ? achievedColor : defaultColor;
                tooltips.Add(new TooltipLine(Mod, "FCDyeTip", $"[i:Fargowiltas/DyeTrader] [c/{color}:获得一次后，在染料商处售卖]"));
            }
            #endregion*/
            #region KeyBind
            KeyBind:
            if (!ModContent.GetInstance<FCConfig>().KeyBindTip)
                return;
            switch (item.type)
            {
                case ItemID.PotionOfReturn:
                case ItemID.RecallPotion:
                case ItemID.MagicMirror:
                case ItemID.IceMirror:
                case ItemID.CellPhone:
                    AddKeyBindTip("快速回家", "Fargowiltas/Home", "0CA3C0");
                    break;
            }

            void AddKeyBindTip(string tip, string uniqueName, string color, string tipWhenDisabled = "")
            {
                if (tipWhenDisabled == "")
                    tipWhenDisabled = tip;
                var key = PlayerInput.CurrentProfile.InputModes[InputMode.Keyboard].KeyStatus[uniqueName];
                tooltips.Add(key.Count > 0
                    ? new TooltipLine(Mod, "FCKeyBindTip", $"[i:{item.type}] [c/{color}:按下“{key[0]}”键{tip}]")
                    : new TooltipLine(Mod, "FCKeyBindTip", $"[i:{item.type}] [c/{color}:“{tipWhenDisabled}”键未绑定]"));
            }
            #endregion
        }
    }
}