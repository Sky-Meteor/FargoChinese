using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Text.RegularExpressions;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Fargowiltas;
using Fargowiltas.NPCs;

namespace FargoChinese
{
    public class FCGlobalNPC : GlobalNPC
    {
        public override void GetChat(NPC npc, ref string chat)
        {
            int mechanic = NPC.FindFirstNPC(NPCID.Mechanic);
            int mutant = NPC.FindFirstNPC(ModContent.NPCType<Mutant>());
            int lumberjack = NPC.FindFirstNPC(ModContent.NPCType<LumberJack>());
            #region abominationn
            if (chat == "You really defeated me... not bad. Now do it again without getting hit. Oh, and Copper Shortsword only.")
                chat = "你真的打败了我……不错。现在来试试无伤我吧。哦对了，只能用铜短剑。";
            if (chat == "Where'd I get my scythe from? Ask me later.")
                chat = "我的镰刀是从哪里弄来的？稍后问我吧。";
            if (chat == "Where'd I get my scythe from? You'll figure it out.")
                chat = "我的镰刀是从哪里弄来的？你会明白的。";
            if (chat == "I have defeated everything in this land... nothing can beat me.")
                chat = "我已经打败了这片土地上的一切……没有什么能打败我。";
            if (chat == "Have you ever had a weapon stuck to your hand? It's not very handy.")
                chat = "你可曾有一把粘在你手上的武器？它不是很方便。";
            if (chat == "What happened to Yoramur? No idea who you're talking about.")
                chat = "Yoramur怎么了？不知道你在说谁。";
            if (chat == "You wish you could dress like me? Ha! Actually yea.. you can.")
                chat = "你想穿得像我一样吗？哈！实际上……你可以。";
            if (chat == "You ever read the ancient classics, I love all the fighting in them.")
                chat = "你曾经读过古代经典，我喜欢里面所有的战斗。";
            if (chat == "I'm a world class poet, ever read my piece about impending doom?")
                chat = "我是世界级的诗人，有没有读过我关于即将到来的末日的诗作？";
            if (chat == "You want swarm summons? Maybe next year.")
                chat = "你想要集群召唤物？也许明年吧。";
            if (chat == "Like my wings? Thanks, the thing I got them from didn't like it much.")
                chat = "喜欢我的翅膀？谢谢，我从一个不太喜欢它的人那得到的。";
            if (chat == "Heroism has no place in this world, instead let's just play ping pong.")
                chat = "这个世界没有英雄主义的容身之处，不如打乒乓球吧。";
            if (chat == "Why are you looking at me like that? Your fashion sense isn't going to be winning you any awards either.")
                chat = "你为什么那样看着我？你的时尚感也不会为你赢得任何奖项。";
            if (chat == "No, you can't have my hat.")
                chat = "不，你不能有我的帽子。";
            if (chat == "Embrace suffering... Wait what do you mean that's already taken?")
                chat = "拥抱痛苦……等等，你的意思是已经被占用了？";
            if (chat == "Your attempt to exploit my anger is admirable, but I cannot be angered.")
                chat = "你利用我的愤怒的企图令人钦佩，但我不会被激怒。";
            if (chat == "Is it really a crime if everyone else does it.")
                chat = "如果其他人都这样做，这真的是犯罪吗？";
            if (chat == "Inflicting suffering upon others is the most amusing thing there is.")
                chat = "让别人受苦是最有趣的事情。";
            if (chat == "Irony is the best kind of humor, isn't that ironic?")
                chat = "讽刺是最好的幽默，这不是讽刺吗？";
            if (chat == "I like Cat... What do you mean who's Cat?")
                chat = "我喜欢猫……什么？你问我谁是猫？";
            if (chat == "Check the wiki if you need anything, the kirb is slowly getting it up to par.")
                chat = "如果您需要任何指导，请查看wiki，kirb正在慢慢达到标准。";
            if (chat == "I've heard tales of a legendary Diver... Anyway what was that about a giant jellyfish?")
                chat = "我听说过一位传奇潜水员的故事……但无论如何，巨型水母是什么？？";
            if (chat == "Overloaded events...? Yeah, they're pretty cool.")
                chat = "过载事件？那可太酷了。";
            if (chat == "It's not like I don't enjoy your company, but can you buy something?")
                chat = "我不是不喜欢你的陪伴，但你能买点东西吗！？";
            if (chat == "I have slain one thousand humans! Huh? You're a human? There's so much blood on your hands..")
                chat = "我已经杀了一千人了……卧槽？你还是人？你手上的鲜血有那么多……";
            if (chat == "I hope all these graves lying around don't belong to you.")
                chat = "我希望周围所有的这些墓碑不是你的。";
            if (mechanic != -1)
            {
                if (chat == $"Can you please ask {Main.npc[mechanic].GivenName} to stop touching my laser arm please.")
                    chat = $"你能去找{Main.npc[mechanic].GivenName}吗？请让她别碰我的激光胳膊了。";
            }
            #endregion
            #region deviantt
            if (chat == "This world looks tougher than usual, so you can have these on the house just this once! Talk to me if you need any tips, yeah?")
                chat = "这个世界看起来比平时更艰难，所以我免费给你提供这些，仅此一次！如果你需要任何提示，请告诉我，好吗？";
            if (npc.type == ModContent.NPCType<Deviantt>() && chat.Contains("HA"))
            {
                string c1 = chat.Replace("HA", "哈");
                string c2 = c1.Replace("HEE", "嘻");
                string c3 = c2.Replace("HOO", "呼");
                string c4 = c3.Replace("HEH", "嘿");
                string c5 = c4.Replace(" ", "");//去空格
                chat = c5.Replace("!", "！");
            }
            if (chat == "UWAH! Please don't hurt... wait, it's just you. Don't scare me like that! And why is that THING following you?!")
                chat = "呜哇！别伤害我……等等，是你啊……不要这样吓我！还有，为什么那东西在跟着你？！";
            if (chat == "Good work getting one over on me! Hope I didn't make you sweat too much. Keep at the grind - I wanna see how far you can go!")
                chat = "不错，你战胜了我！希望我没有让你太辛苦。坚持到底吧——我想要看看你能前行多远！";
            if (chat == "The blood moon's effects? I'm not human anymore, so nope!")
                chat = "血月的影响？我不再是人类了，所以没有！";
            if (chat == "Did you know? The only real music genres are death metal and artcore.")
                chat = "你知道吗？唯一真正的音乐类型是死亡金属和艺术核心。";
            if (chat == "I'll have you know I'm over a hundred Fargo years old! Don't ask me how long a Fargo year is.")
                chat = "我要让你知道我已经度过了一百多Fargo年了！别问我一Fargo年有多长。";
            if (chat == "I might be able to afford a taller body if you keep buying!")
                chat = "如果你继续买，我可能承担得起更高的身体！";
            if (chat == "Where's that screm cat?")
                chat = "那只尖叫猫呢？";
            if (chat == $"{Main.LocalPlayer.name}!I saw something rodent - y just now!You don't have a hamster infestation, right? Right!?")
                chat = $"{Main.LocalPlayer.name}！我刚才看到了一些啮齿类动物！你没有感染仓鼠吧？对吧！？";
            if (chat == "You're the Terrarian? Honestly, I was expecting someone a little... taller.")
                chat = "你就是泰拉瑞亚人？老实说，我在期待一个稍微……高一点的人。";
            if (chat == "Don't look at me like that! The only thing I've deviated from is my humanity.")
                chat = "别用那种眼神看我！我唯一背离的就是我的人性。";
            if (chat == "Rip and tear and buy from me for more things to rip and tear!")
                chat = "撕裂并流下眼泪，再从我这买点东西，再流下眼泪，这是个轮回。";
            if (chat == "What's a chee-bee doe-goe?")
                chat = "什么是 chee-bee doe-goe？";
            if (chat == "Wait a second. Are you sure this house isn't what they call 'prison?'")
                chat = "等一下。你确定这房子不是他们所说的“监狱”？";
            if (chat == "Deviantt has awoken! Quick, give her all your money to defeat her!")
                chat = "戴薇安已苏醒！快，把你所有的钱给她来打败她！";
            if (chat == "One day, I'll sell a summon for myself! ...Just kidding.")
                chat = "总有一天我会卖自己的召唤物！……开玩笑的。";
            if (chat == "Hmm, I can tell! You've killed a lot, but you haven't killed enough!")
                chat = "嗯，我看得出来！你杀了很多，但你杀的还不够！";
            if (chat == "Why the extra letter, you ask? Only the strongest sibling is allowed to remove their own!")
                chat = "你问我为什么要多出一个字母？只有我们中的最强者才被允许删除他们多出来的字母！";
            if (chat == "The more rare things you kill, the more stuff I sell! Simple, right?")
                chat = "你杀的稀有的东西越多，我卖的东西就越多！很简单吧？";
            if (mutant != -1)
            {
                if (chat == $"Can you tell {Main.npc[mutant].GivenName} to put some clothes on?")
                    chat = $"你能让{Main.npc[mutant].GivenName}穿上衣服吗？";
                if (chat == $"One day, I'll sell a summon for myself! ...Just kidding. That's {Main.npc[mutant].GivenName}'s job.")
                    chat = $"总有一天，我会卖自己的召唤物！……开玩笑的。那是{Main.npc[mutant].GivenName}的工作。";
            }
            if (lumberjack != -1)
            {
                if (chat == $"What's that? You want to fight {Main.npc[lumberjack].GivenName}? ...even I know better than to try.")
                    chat = $"啥？你想和{Main.npc[lumberjack].GivenName}打？……最好不要尝试。";
            }
            if (chat == "Embrace suffering... and while you're at it, embrace another purchase!")
                chat = "拥抱痛苦吧……受虐时别忘了来我这买新东西！";
            #endregion
            #region lumberjack
            if (chat == "")
                chat = "";
            if (chat == "")
                chat = "";
            if (chat == "")
                chat = "";
            if (chat == "")
                chat = "";
            if (chat == "")
                chat = "";
            if (chat == "")
                chat = "";
            if (chat == "")
                chat = "";
            if (chat == "")
                chat = "";
            if (chat == "")
                chat = "";
            if (chat == "")
                chat = "";
            if (chat == "")
                chat = "";
            if (chat == "")
                chat = "";
            #endregion
        }
        public override void OnChatButtonClicked(NPC npc, bool firstButton)
        {
            #region abominationn
                if (npc.type == ModContent.NPCType<Abominationn>())
                {
                    if (Main.npcChatText == "Hocus pocus, the event is over")
                        Main.npcChatText = "吼吼嘿哈，事件结束了！";
                    for (int abomclearcd = 120; abomclearcd >= 0; abomclearcd--)
                    {
                        if (Main.npcChatText == $"I'm not feeling it right now, come back in {abomclearcd} seconds.")
                        {
                            Main.npcChatText = $"我现在感觉不到，{abomclearcd}秒之后再来吧。";
                            break;
                        }
                    }
                    if (Main.npcChatText == "I don't think there's an event right now.")
                        Main.npcChatText = "我认为现在没有事件。";
                }
                #endregion
            #region deviantt
                if (npc.type == ModContent.NPCType<Deviantt>())
                {
                    if (Main.npcChatText == "What's that? You want to fight me for real? ...nah, I can't put up a good fight on my own.")
                        Main.npcChatText = "啥？你想和我来真的？……啊这，我自己一个人不太会打架。";
                    if (Main.npcChatText == "Hey, you've almost made it to the end! Got all your Soul accessories ready? What's that? You want to fight my big brother? ...maybe if he had a reason to.")
                        Main.npcChatText = "嘿，你已经快到最后了！准备好所有的魂饰品了吗？啥，你想和我大哥打？……应该能吧，如果他有理由这么做。";
                    if (Main.npcChatText == "Ready to fight my big brother? Remember how you've learned to learn. Stay focused, look for patterns, and don't panic. Good luck!")
                        Main.npcChatText = "准备打我大哥了？回想你是如何学会洞察战斗的。保持专注，寻找规律，不要惊慌。祝好运！";
                    if (Main.npcChatText == "Wanna craft Forces, but missing Enchantments? Craft the Sigil of Champions and they'll give you what you want, so long as you earn it.")
                        Main.npcChatText = "想合成九大力，但是缺少魔石？去做一个唤灵魔符。你想要的东西，只要你证明了自己的实力，他们就会给你。";
                    if (Main.npcChatText == "Only a specific type of weapon will work against each specific pillar. As for that moon guy, his weakness will keep changing.")
                        Main.npcChatText = "只有特定类型的武器能够有效对付每根特定的天界柱。至于那个没腿的大章鱼，他的弱点会不断变化。";
                    if (Main.npcChatText == "Some powerful enemies like that dungeon guy can create their own arenas. You won't be able to escape, so make full use of the room you do have.")
                        Main.npcChatText = "一些强大的敌人——例如那个地牢门口的家伙——可以创造自己的战斗区域。你无法逃出来，所以充分利用你掌握的空间。";
                    if (Main.npcChatText == "Did you beat that fish pig dragon yet? He reduces your maximum life a little on every hit. He's also strong enough to break defenses in one hit. Too bad you don't have any reinforced plating to prevent that, right?")
                        Main.npcChatText = "你打过那个猪龙鱼了吗？你每次被击中，他都会降低你的最大生命值。他的力量强到足以一下破除你的防御。要是你没有强化钢板来防止这种事情发生，这可太坏了，对吧？";
                    if (Main.npcChatText == "Now's a good time to go for Betsy! Don't worry. If you reach the last wave and lose, you won't have to retry the event for more attempts at her. Careful not to slip up before then, and mind her debuffs!")
                        Main.npcChatText = "现在是去打双足翼龙的好时机！别担心。如果你撑到了最后一波但输掉了，你不需要从头来过。注意不要在最后一波前失误，并注意她的减益！";
                    if (Main.npcChatText == "That temple? Reach the altar to regain wire control! The golem gets upset when you leave, so fighting in there is best. Platforms won't work, but a Lihzahrd Instactuation Bomb can help clear space!")
                        Main.npcChatText = "那座神庙？碰一下祭坛来重新控制电线！石巨人会在你离开神庙时狂暴，所以最好在那里战斗。平台在这场战斗中不起作用，但丛林神庙炸弹可以帮助清理空间！";
                    if (Main.npcChatText == "That overgrown plant inflicts a special venom that works her into an enraged frenzy if she stacks enough hits on you. She also has a ring of crystal leaves, but minions go through it.")
                        Main.npcChatText = "那株长得飞快的植物会造成一种特殊的毒液，如果你被她击中得够多，她就会进入狂暴状态。她还有一圈叶状水晶，但召唤物能穿过它们。";
                    if (Main.npcChatText == "That metal worm has a few upgrades, but its probes were downgraded to compensate. It'll start shooting homing dark stars and flying. When it coils around you, don't try to escape!")
                        Main.npcChatText = "那条金属蠕虫经过了一些升级，但它的探针被削弱了以维持平衡。它会开始射出追踪的暗星并飞行。当它盘旋在你身边时，不要试图逃跑！";
                    if (Main.npcChatText == "I saw that metal eye spinning while firing a huge laser the other day. Also, even if you kill them, they won't die until they're both killed!")
                        Main.npcChatText = "前几天我看到了那个金属眼球一边旋转一边射出一道巨大的激光。而且，即使你杀了它们，它们也不会立即死亡，直到它们都被杀死！";
                    if (Main.npcChatText == "Focus on taking down that metal skull, not its limbs. Don't try to outrun its spinning limbs! Keep your eyes open and learn to recognize what's doing what.")
                        Main.npcChatText = "专注于拿下那个大铁骷髅头，而不是它的四肢。不要试图跑出它旋转的四肢！睁大你的眼睛，学会分析它的行动。";
                    if (Main.npcChatText == "That thing's mouth is as good as immune to damage, so you'll have to aim for the eye. Only one of them is vulnerable at a time, though. What thing? You know, that thing!")
                        Main.npcChatText = "那东西的嘴几乎免疫伤害，所以你必须瞄准它们的眼睛。虽然同一时间内，它们之间只有一个能受到伤害。哪个东西？你知道的，那个东西！";
                    if (Main.npcChatText == "Next up is me! Make sure you can recognize whatever attack I'll throw at you. Blocks and turning away can nullify petrification!")
                        Main.npcChatText = "下一个是我！确保你能回避我向你丢出的任何攻击。方块和转身可以使石化无效！";
                    if (Main.npcChatText == "The master of the dungeon can use its babies to attack! Which attack it uses depends on whether or not it's spinning. It'll also take a last stand, so be ready to run when you make the kill!")
                        Main.npcChatText = "地牢之主可以操纵它的宝宝来攻击！它使用哪种攻击取决于它的头是否在旋转。它也会在最后再坚持一会，所以当你杀死它时准备好开跑！";
                    if (Main.npcChatText == "The queen bee will summon her progeny for backup. She's harder to hurt while they're there, so take them out first. Oh, and her swarm can't hit right above or below her!")
                        Main.npcChatText = "蜂后会召唤它的后代作为后援。它们存在时她更难被伤害，所以先灭了它们。对了，它的蜂群不能打到她的正上方和下方！";
                    if (Main.npcChatText == "Focus on how the ichor moves and don't get overwhelmed! When the brain gets mad, it'll confuse you every few seconds. Four rings to confuse you, one ring when it wears off!")
                        Main.npcChatText = "注意灵液如何移动，不要惊慌失措！当大脑变得疯狂时，它每几秒钟就会让你感到困惑。四个环出现时你会感到困惑，一个环出现后它会消失并冲刺！";
                    if (Main.npcChatText == "The more the world eater splits, the more worms can rush you at once. The head is extra sturdy now, but don't let them pile up too much!")
                        Main.npcChatText = "世界吞噬怪吐出越多魔唾液，一次就有更多虫子会向你冲来。它的头部现在非常结实，但不要让它们堆积太多！";
                    if (Main.npcChatText == "Watch out when you break your second Crimson Heart! It might attract the goblins, so prepare before you do it.")
                        Main.npcChatText = "当你打破第二颗猩红心脏时要小心！这也许会引来哥布林，所以在你做这桩事前做好准备。";
                    if (Main.npcChatText == "Watch out when you break your second Shadow Orb! It might attract the goblins, so prepare before you do it.")
                        Main.npcChatText = "当你打破第二颗暗影珠时要小心！这也许会引来哥布林，所以在你做这桩事前做好准备。";
                    if (Main.npcChatText == "That big eyeball has the power of the moon, but it's too flashy for its own good! Learn to notice and focus only on the bits that threaten to hurt you.")
                        Main.npcChatText = "那个大眼珠子有着月亮之力，但是全都是花里胡哨！学会注意并只关注那些可能会打到你的部分。";
                    if (Main.npcChatText == "Gonna fight that slime king soon? Crafting a Mini Instabridge or two might help, and mind the spike rain. Don't stay up and out of his range or he'll get mad, though!")
                        Main.npcChatText = "马上要和史莱姆王打一架了吗？造一两个速建平台也许会有帮助，并且注意从天而降的刺。不要待在它的上方，也不要离它太远，不然它会狂暴的！";
                    if (Main.npcChatText == "Seems like everyone's learning to project auras these days. If you look at the particles, you can see whether it'll affect you at close range or a distance!")
                        Main.npcChatText = "看起来每个人这几天都在学习如何发出光环。如果你细看那些粒子，你可以看出它会在圈内还是圈外生效！";
                    if (Main.npcChatText == "There's probably a thousand items to protect against all these debuffs. It's a shame you don't have a thousand hands to carry them all at once!")
                        Main.npcChatText = "可能有上千件物品来免疫这些减益。可惜你并没有一千只手来把它们一次全带上！";
                    if (Main.npcChatText == "Don't forget you can turn off your soul toggles! They're all in that little wrench button right below your inventory. Those small buttons at the very bottom of the list include a recommended low-lag preset!")
                        Main.npcChatText = "不要忘记你可以关闭你的魂石开关！它们都在你物品栏右下角的小扳手里。列表最底部的那些小按钮包含了一套推荐的低卡顿预设！";
                    if (Main.npcChatText == "I don't have any more Life Crystals for you, but I think my big brother left some in the fat slime king. Maybe he'll share if you beat it up!")
                        Main.npcChatText = "我没有更多的生命水晶给你了，但我想我大哥在那只肥胖的史莱姆王里留了一些。如果你击败了它，它也许会分享这些水晶！";
                    if (Main.npcChatText == "Watch out for those fish! Sharks will leave you alone if you leave them alone, but piranhas go wild when they smell blood. They can jump out of water to get you!")
                        Main.npcChatText = "小心那些鱼！鲨鱼会在你离开它们时离开你，但食人鱼一旦闻到血腥味就会立刻变得狂野。它们可以跳出水面来抓你！";
                    if (Main.npcChatText == "The water is bogging you down? Never had an issue with it, personally... Have you tried breathing water instead of air?")
                        Main.npcChatText = "水让你陷入了困境？就我而言，从来没遇到过这个问题……你试过在水里呼吸而不是在空气里吗？";
                    if (Main.npcChatText == "The underworld has gotten a lot hotter since the last time I visited. I hear an obsidian skull is a good luck charm against burning alive, though!")
                        Main.npcChatText = "较我上次参观，地狱变得更热了。不过，我听说黑曜石骷髅头是个防止被活活烧死的好运符！";
                    if (Main.npcChatText == "Want to have a breath-holding contest? The empty vacuum of space would be perfect. No, I won't cheat by breathing water instead of air!")
                        Main.npcChatText = "想来一场憋气大赛吗？太空的真空环境会是个完美的场地。不，我不会通过呼吸水而非空气来作弊！";
                    if (Main.npcChatText == "That's a funny face you're making... Is the underground Hallow too disorienting? Try controlling gravity on your own and maybe it can't flip you by force!")
                        Main.npcChatText = "你这脸真滑稽……地下神圣让你搞不清东南西北？试试自己控制重力，也许它不能强行翻转你！";
                    if (Main.npcChatText == "If you ask me, Plantera is really letting herself go. A diet of Chlorophyte Ore and Life Fruit isn't THAT healthy! Why don't you help her slim down?")
                        Main.npcChatText = "你要是问我的话，世纪之花实在是太放纵自己了。叶绿矿和生命果并不是一套那么好的饮食！为什么你不帮帮她减肥？";
                }
                #endregion
        }
    }
}
