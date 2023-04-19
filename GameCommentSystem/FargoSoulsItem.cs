using System;
using System.Collections.Generic;
using System.Reflection;
using Fargowiltas;
using FargowiltasSouls.Items.Accessories.Enchantments;
using FargowiltasSouls.Items.Accessories.Forces;
using FargowiltasSouls.Items.Accessories.Masomode;
using FargowiltasSouls.Items.Accessories.Souls;
using Terraria;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;
using static FargoChinese.GameCommentSystem.CommentSystemUtils;
using static Terraria.ModLoader.ModContent;

namespace FargoChinese.GameCommentSystem
{
    [JITWhenModsEnabled("FargowiltasSouls")]
    public class FargoSoulsItem : GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            Player player = Main.LocalPlayer;
            var fargoPlayer = player.GetModPlayer<FargoPlayer>();
            #region KeyBind
            if (!GetInstance<FCConfig>().SoulsKeyBindTip)
                goto NextTip;
            if (item.type == ItemType<StardustEnchant>() || item.type == ItemType<SnowEnchant>() || item.type == ItemType<FrostEnchant>() || item.type == ItemType<CosmoForce>() || item.type == ItemType<NatureForce>())
                AddKeyBindTip("按下“冻结”键", "FargowiltasSouls: 冻结", "77DEFF");
            else if (item.type == ItemType<GoldEnchant>() || item.type == ItemType<WillForce>())
                AddKeyBindTip("按下“金身”键", "FargowiltasSouls: 金身", "F6EDB9");
            else if (item.type == ItemType<CrystalAssassinEnchant>())
                AddKeyBindTip("按下“投掷烟雾弹”键", "FargowiltasSouls: 投掷烟雾弹", "6F6F6F");
            else if (item.type == ItemType<ShadowForce>())
                AddKeyBindTip("你可以扔出烟雾弹", "FargowiltasSouls: 投掷烟雾弹", "6F6F6F");
            else if (item.type == ItemType<BetsysHeart>() || item.type == ItemType<QueenStinger>())
                AddKeyBindTip("按下“特殊冲刺”键", "FargowiltasSouls: 特殊冲刺", "A93044");
            else if (item.type == ItemType<MutantEye>() || item.type == ItemType<IceQueensCrown>())
                AddKeyBindTip("按下“炸弹”键", "FargowiltasSouls: 突变炸弹", "B5DEE0");
            else if (item.type == ItemType<PrecisionSeal>())
                AddKeyBindTip("按下“精确模式”键", "FargowiltasSouls: 玲珑圣印精确模式", "AF71B6");
            else if (item.type == ItemType<MagicalBulb>() || item.type == ItemType<ChaliceoftheMoon>())
                AddKeyBindTip("按下“魔法净化”键", "FargowiltasSouls: 魔法净化", "EAA8DD");
            else if (item.type == ItemType<FrigidGemstone>() || item.type == ItemType<BionomicCluster>())
                AddKeyBindTip("按下“寒霜咒语”键", "FargowiltasSouls: 寒霜咒语", "5680BA");
            else if (item.type == ItemType<AgitatingLens>() || item.type == ItemType<FusedLens>())
                AddKeyBindTip("按下“减益负载”键", "FargowiltasSouls: 减益负载", "F6664D");
            else if (item.type == ItemType<SaucerControlConsole>())
                AddKeyBindTip("按下“弹药切换”键", "FargowiltasSouls: 弹药切换", "7FB3C6");
            else if (item.type == ItemType<SupremeDeathbringerFairy>())
            {
                AddKeyBindTip("按下“特殊冲刺”键", "FargowiltasSouls: 特殊冲刺", "A93044");
                AddKeyBindTip("按下“减益负载”键", "FargowiltasSouls: 减益负载", "F6664D");
            }
            else if (item.type == ItemType<HeartoftheMasochist>())
            {
                AddKeyBindTip("按下“特殊冲刺”键", "FargowiltasSouls: 特殊冲刺", "A93044");
                AddKeyBindTip("能冻住几乎所有敌怪和射弹的炸弹", "FargowiltasSouls: 突变炸弹", "B5DEE0");
                AddKeyBindTip("按下“精确模式”键", "FargowiltasSouls: 玲珑圣印精确模式", "AF71B6");
                AddKeyBindTip("按下“弹药切换”键", "FargowiltasSouls: 弹药切换", "7FB3C6");
            }
            else if (item.type == ItemType<TerrariaSoul>())
            {
                AddKeyBindTip("按下“冻结”键", "FargowiltasSouls: 冻结", "77DEFF");
                AddKeyBindTip("按下“金身”键", "FargowiltasSouls: 金身", "F6EDB9");
                AddKeyBindTip("扔出烟雾弹", "FargowiltasSouls: 投掷烟雾弹", "6F6F6F");
            }
            else if (item.type == ItemType<MasochistSoul>())
            {
                AddKeyBindTip("按下“特殊冲刺”键", "FargowiltasSouls: 特殊冲刺", "A93044");
                AddKeyBindTip("按下“减益负载”键", "FargowiltasSouls: 减益负载", "F6664D");
                AddKeyBindTip("按下“精确模式”键", "FargowiltasSouls: 玲珑圣印精确模式", "AF71B6");
                AddKeyBindTip("按下“弹药切换”键", "FargowiltasSouls: 弹药切换", "7FB3C6");
            }
            void AddKeyBindTip(string tip, string uniqueName, string color)
            {
                var key = PlayerInput.CurrentProfile.InputModes[InputMode.Keyboard].KeyStatus[uniqueName];
                tooltips.FindAndInsertText(tip, key.Count > 0 ? $"[c/{color}:（{key[0]}）]" : $"[c/{color}:（未绑定）]");
            }
            #endregion
            NextTip: ;
        }

        public override bool IsLoadingEnabled(Mod mod) => ModLoader.TryGetMod("FargowiltasSouls", out _);
    }
}