using Terraria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Xna.Framework;
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
using FargowiltasSouls.Toggler;
using Terraria.Localization;

namespace FargoChinese.Commands
{
    [JITWhenModsEnabled("FargowiltasSouls")]
    public class FargoSoulsCommand : ModCommand
    {
        public override bool IsLoadingEnabled(Mod mod) => ModLoader.TryGetMod("FargowiltasSouls", out _);

        public override CommandType Type => CommandType.Chat;

        public override string Command => "souls";

        public override string Usage =>
@"用法：/souls [关键词]
关键词列表：
ench, enchantment, 魔石 -> 查看所有魔石
essence, 精华 -> 查看所有精华
force, 力 -> 查看所有力
eternity, maso, masomode, 永恒, 永恒饰品 -> 查看所有永恒饰品
soul, 魂 -> 查看所有魂
armor, 盔甲, 装备 -> 查看所有盔甲
summon, summoner, 召唤物 -> 查看所有Fargo魂添加的召唤物
weapon, 武器 -> 查看所有武器
patreon, 捐赠者物品, 捐赠者 -> 查看所有捐赠者物品
log, changelog, 日志, 更新日志 -> 查看最新的更新日志（自动打开网页）
t -> 使用预设饰品效果（用法：/souls t [关键词1] [关键词2]）";

        public override string Description => "这是与Fargo魂有关的一些实用指令";

        Dictionary<string, bool> Toggles;

        public override void Load()
        {
            Toggles = new Dictionary<string, bool>();
        }

        public override void Action(CommandCaller caller, string input, string[] args)
        {
            Player player = caller.Player;

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
                    case "summoner":
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
                    case "t":
                        if (args.Length > 1)
                        {
                            string[] _args = input[9..].Split(" ");
                            foreach (string arg in _args)
                            {
                                switch (arg)
                                {
                                    case "nodash":
                                        NoDash:
                                        Toggles.Merge(new Dictionary<string, bool>() 
                                        {
                                            { "JungleDash", false },
                                            { "Monk", false },
                                            { "ShinobiDash", false },
                                            { "Shinobi", false },
                                            { "CrystalDash", false },
                                            { "Solar", false },
                                            { "SupersonicTabi", false },
                                            { "CthulhuShield", false },
                                            { "DeerSinewDash", false },
                                            { "MasoSkeleSpin", false },
                                        });
                                        continue;
                                    case "[i:58]Furgo[i:58]力[i:58]荐[i:58]":
                                        for (int i = 0; i < 200; i++)
                                            CombatText.NewText(new Rectangle((int)player.position.X + Main.rand.Next(-1000, 1000), (int)player.position.Y + Main.rand.Next(-500, 500), 1, 1), Color.Red, Main.rand.Next(new string[] { "¿", "?", "¡", "!" }));
                                        goto NoDash;
                                    default:
                                        Main.NewText($"参数{arg}输入错误", Color.Red);
                                        continue;
                                }
                            }
                            string nameCollectionT = default;
                            string nameCollectionF = default;
                            int numT = 0;
                            int numF = 0;
                            foreach (KeyValuePair<string, bool> pair in Toggles)
                            {
                                if (numT > 9)
                                {
                                    numT = 0;
                                    Main.NewText($"{nameCollectionT[..(nameCollectionT.Length - 1)]} 已开启");
                                    nameCollectionT = default;
                                }
                                if (numF > 9)
                                {
                                    numF = 0;
                                    Main.NewText($"{nameCollectionF[..(nameCollectionF.Length - 1)]} 已关闭");
                                    nameCollectionF = default;
                                }

                                string name = Language.GetTextValue($"Mods.FargowiltasSouls.Toggler.{pair.Key}Config");
                                foreach (KeyValuePair<string, string> enchColor in FCGlobalItem.enchColors)
                                {
                                    if ($"{pair.Key}Config" == enchColor.Key)
                                    {
                                        name = $"[c/{enchColor.Value}:{name}]";
                                        break;
                                    }
                                }
                                if (pair.Value == true)
                                {
                                    numT += 1;
                                    nameCollectionT += name + "，";
                                }
                                else
                                {
                                    numF += 1;
                                    nameCollectionF += name + "，";
                                }
                                player.SetToggleValue(pair.Key, pair.Value);
                            }
                            if (!string.IsNullOrEmpty(nameCollectionT))
                                Main.NewText($"{nameCollectionT[..(nameCollectionT.Length - 1)]} 已开启");
                            if (!string.IsNullOrEmpty(nameCollectionF))
                                Main.NewText($"{nameCollectionF[..(nameCollectionF.Length - 1)]} 已关闭");
                        }
                        break;
                    case "test":
                        break;
                    default:
                        Main.NewText($"参数{args[0]}输入错误", Color.Red);
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

        public override void Unload()
        {
            Toggles = null;
        }
    }
}
