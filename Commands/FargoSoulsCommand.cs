using Terraria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using FargowiltasSouls.Items.Accessories.Enchantments;
using FargowiltasSouls.Items.Accessories.Essences;
using FargowiltasSouls.Items.Accessories.Forces;
using FargowiltasSouls.Items.Accessories.Souls;
using FargowiltasSouls.Items.Armor;
using FargowiltasSouls.Items.Summons;
using FargowiltasSouls.Items.Weapons.BossDrops;
using FargowiltasSouls.Items.Weapons.SwarmDrops;
using FargowiltasSouls.Patreon.Catsounds;
using FargowiltasSouls.Patreon.Volknet;
using FargowiltasSouls.Items.Accessories.Masomode;

namespace FargoChinese.Commands
{
    [JITWhenModsEnabled("FargowiltasSouls")]
    public class FargoSoulsCommand : ModCommand
    {
        public override bool IsLoadingEnabled(Mod mod) => ModLoader.TryGetMod("FargowiltasSouls", out _);

        public override CommandType Type => CommandType.Chat;

        public override string Command => "souls";

        public override void Action(CommandCaller caller, string input, string[] args)
        {
            if (args.Length > 0)
            {
                switch (args[0])
                {
                    case "ench":
                    case "enchantment":
                    case "魔石":
                        PrintItem(ItemType<AdamantiteEnchant>(), ItemType<WoodEnchant>());
                        break;
                    case "essence":
                    case "精华":
                        PrintItem(ItemType<ApprenticesEssence>(), ItemType<SharpshootersEssence>());
                        break;
                    case "force":
                    case "力":
                        PrintItem(ItemType<CosmoForce>(), ItemType<WillForce>());
                        break;
                    case "eternity":
                    case "maso":
                    case "masomode":
                    case "永恒":
                    case "永恒饰品":
                        PrintItem(ItemType<AbominableWand>(), ItemType<WyvernFeather>(), ItemType<AeolusBoots>(), ItemType<PuffInABottle>(),ItemType<EurusSock>());
                        break;
                    case "soul":
                    case "魂":
                        PrintItem(ItemType<ArchWizardsSoul>(), ItemType<WorldShaperSoul>(), ItemType<VoidSoul>());
                        break;
                    case "armor":
                    case "盔甲":
                    case "装备":
                        PrintItem(ItemType<EridanusBattleplate>(), ItemType<StyxLeggings>());
                        break;
                    case "summon":
                    case "召唤物":
                        PrintItem(ItemType<AbominationnVoodooDoll>(), ItemType<SquirrelCoatofArms>());
                        break;
                    case "weapon":
                    case "武器":
                        PrintItem(ItemType<BoneZone>(), ItemType<TheBigSting>());
                        break;
                    case "patreon":
                    case "捐赠者物品":
                    case "捐赠者":
                        PrintItem(ItemType<MedallionoftheFallenKing>(), ItemType<NanoCore>());
                        break;
                    case "log":
                    case "changelog":
                    case "日志":
                    case "更新日志":
                        Utils.OpenToURL("https://www.bilibili.com/read/cv20213491");
                        break;
                    default:
                        break;
                }

                static void PrintItem(int start, int end, params int[] ignore)
                {
                    string item = "";
                    for (int i = start; i <= end; i++)
                        item += $"[i:{i}]";
                    foreach (int i in ignore)
                        item = item.Replace($"[i:{i}]", "");
                    Main.NewText(item);
                }
            }
                
            /*foreach (string i in args)
                Main.NewText(i);
            CombatText.NewText(caller.Player.Hitbox, Main.DiscoColor, "yee");*/
        }
    }
}
