using Fargowiltas.NPCs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FargoChinese.UnmanagedTranslations
{
    public class GlobalNPCTranslation : GlobalNPC
    {
        public override void GetChat(NPC npc, ref string chat)
        {
            int nurse = NPC.FindFirstNPC(NPCID.Nurse);
            int mechanic = NPC.FindFirstNPC(NPCID.Mechanic);
            int partyGirl = NPC.FindFirstNPC(NPCID.PartyGirl);
            int witchDoctor = NPC.FindFirstNPC(NPCID.WitchDoctor);
            int dryad = NPC.FindFirstNPC(NPCID.Dryad);
            int stylist = NPC.FindFirstNPC(NPCID.Stylist);
            int truffle = NPC.FindFirstNPC(NPCID.Truffle);
            int tax = NPC.FindFirstNPC(NPCID.TaxCollector);
            int guide = NPC.FindFirstNPC(NPCID.Guide);
            int cyborg = NPC.FindFirstNPC(NPCID.Cyborg);
            int demoman = NPC.FindFirstNPC(NPCID.Demolitionist);
            int tavernkeep = NPC.FindFirstNPC(NPCID.DD2Bartender);
            int dyeTrader = NPC.FindFirstNPC(NPCID.DyeTrader);
            int mutant = NPC.FindFirstNPC(ModContent.NPCType<Mutant>());
            int lumberjack = NPC.FindFirstNPC(ModContent.NPCType<LumberJack>());
            #region abominationn
            if (npc.type == ModContent.NPCType<Abominationn>())
            {
                if (chat == "You really defeated me... not bad. Now do it again without getting hit. Oh, and Copper Shortsword only.")
                    chat = "你真的打败了我……不错。现在来试试无伤我吧。哦对了，只能用铜短剑。";
                else if (chat == "What nostalgic armor you're wearing... No, it doesn't fit on me anymore. And its battery takes too long to charge.")
                    chat = "你穿的这套盔甲可真是怀旧……不，它不再合我身了。而且充满它的电池需要太长时间。";
                else if (chat == "Where'd I get my scythe from? Ask me later.")
                    chat = "我的镰刀是从哪里弄来的？稍后问我吧。";
                else if (chat == "Where'd I get my scythe from? You'll figure it out.")
                    chat = "我的镰刀是从哪里弄来的？你会明白的。";
                else if (chat == "I have defeated everything in this land... nothing can beat me.")
                    chat = "我已经打败了这片土地上的一切……没有什么能打败我。";
                else if (chat == "Have you ever had a weapon stuck to your hand? It's not very handy.")
                    chat = "你可曾有一把粘在你手上的武器？它不是很方便。";
                else if (chat == "What happened to Yoramur? No idea who you're talking about.")
                    chat = "Yoramur怎么了？不知道你在说谁。";
                else if (chat == "You wish you could dress like me? Ha! Actually yea.. you can.")
                    chat = "你想穿得像我一样吗？哈！实际上……你可以。";
                else if (chat == "You ever read the ancient classics, I love all the fighting in them.")
                    chat = "你曾经读过古代经典，我喜欢里面所有的战斗。";
                else if (chat == "I'm a world class poet, ever read my piece about impending doom?")
                    chat = "我是世界级的诗人，有没有读过我关于即将到来的末日的诗作？";
                else if (chat == "You want swarm summons? Maybe next year.")
                    chat = "你想要集群召唤物？也许明年吧。";
                else if (chat == "Like my wings? Thanks, the thing I got them from didn't like it much.")
                    chat = "喜欢我的翅膀？谢谢，我从一个不太喜欢它的人那得到的。";
                else if (chat == "Heroism has no place in this world, instead let's just play ping pong.")
                    chat = "这个世界没有英雄主义的容身之处，不如打乒乓球吧。";
                else if (chat == "Why are you looking at me like that? Your fashion sense isn't going to be winning you any awards either.")
                    chat = "你为什么那样看着我？你的时尚感也不会为你赢得任何奖项。";
                else if (chat == "No, you can't have my hat.")
                    chat = "不，你不能有我的帽子。";
                else if (chat == "Embrace suffering... Wait what do you mean that's already taken?")
                    chat = "拥抱痛苦……等等，你说这句话已经被占用了是什么意思？";
                else if (chat == "Your attempt to exploit my anger is admirable, but I cannot be angered.")
                    chat = "你利用我的愤怒的企图令人钦佩，但我不会被激怒。";
                else if (chat == "Is it really a crime if everyone else does it.")
                    chat = "如果每个人都这样做，这真的是犯罪吗？";
                else if (chat == "Inflicting suffering upon others is the most amusing thing there is.")
                    chat = "让别人受苦是最有趣的事情。";
                else if (chat == "Irony is the best kind of humor, isn't that ironic?")
                    chat = "讽刺是最好的幽默，这不是讽刺吗？";
                else if (chat == "I like Cat... What do you mean who's Cat?")
                    chat = "我喜欢猫……什么？你问我谁是猫？";
                else if (chat == "Check the wiki if you need anything, the kirb is slowly getting it up to par.")
                    chat = "如果您需要任何指导，请查看wiki，kirb正在慢慢达到标准。";
                else if (chat == "I've heard tales of a legendary Diver... Anyway what was that about a giant jellyfish?")
                    chat = "我听说过一位传奇潜水员的故事……但无论如何，巨型水母是什么？？";
                else if (chat == "Overloaded events...? Yeah, they're pretty cool.")
                    chat = "过载事件？那可太酷了。";
                else if (chat == "It's not like I don't enjoy your company, but can you buy something?")
                    chat = "我不是不喜欢你的陪伴，但你能买点东西吗！？";
                else if (chat == "I have slain one thousand humans! Huh? You're a human? There's so much blood on your hands..")
                    chat = "我已经杀了一千人了……什么？？你还是人？你手上的鲜血有那么多……";
                else if (chat == "I hope all these graves lying around don't belong to you.")
                    chat = "我希望周围所有的这些墓碑不是你的。";
                else if (mechanic != -1)
                {
                    if (chat == $"Can you please ask {Main.npc[mechanic].GivenName} to stop touching my laser arm please.")
                        chat = $"你能去找{Main.npc[mechanic].GivenName}吗？请让她别碰我的激光胳膊了。";
                }
            }
            #endregion
            #region deviantt
            else if (npc.type == ModContent.NPCType<Deviantt>())
            {
                if (chat == "This world looks tougher than usual, so you can have these on the house just this once! Talk to me if you need any tips, yeah?")
                    chat = "这个世界看起来比平时更艰难，所以我免费给你提供这些，仅此一次！如果你需要任何提示，请告诉我，好吗？";
                else if (chat.StartsWith("IT'S THE FUNNY BEE WORLD!"))
                {
                    chat = chat.Replace("IT'S THE FUNNY BEE WORLD!", "这里是有趣的蜜蜂世界！").Replace("HA", "哈").Replace("HEE", "嘻").Replace("HOO", "呼").Replace("HEH", "嘿").Replace("HAH", "哈").Replace(" ", "").Replace("!", "！");
                }
                else if (chat == "UWAH! Please don't hurt... wait, it's just you. Don't scare me like that! And why is that THING following you?!")
                    chat = "呜哇！别伤害我……等等，是你啊……不要这样吓我！还有，为什么那东西在跟着你？！";
                else if (chat == "Ooh, that's my hoodie! So how is it? Comfy and great for gaming, right? Maybe you'll even go beat a boss without taking damage!")
                    chat = "哦，那是我的连帽衫！所以感觉如何？舒适、很适合打游戏，对吧？也许你甚至能无伤打败一个Boss！";
                else if (chat == "Good work getting one over on me! Hope I didn't make you sweat too much. Keep at the grind - I wanna see how far you can go!")
                    chat = "不错，你战胜了我！希望我没有让你太辛苦。坚持到底吧——我想要看看你能前行多远！";
                else if (chat == "Wow, you smell rancid. When's the last time you took a shower, stinky?")
                    chat = "哇，你闻起来像是变质了。你上次洗澡是什么时候？你身上太臭了。";
                else if (chat.StartsWith("You're making too many hearts at me! Sorry, we're only at bond level ") && chat.EndsWith(" right now!"))
                    chat = chat.Replace("You're making too many hearts at me! Sorry, we're only at bond level ", "你对我冒出太多爱心了！对不起，我们现在的亲密等级只有").Replace(" right now!", "！");
                else if (chat == "The blood moon's effects? I'm not human anymore, so nope!")
                    chat = "血月的影响？我不再是人类了，所以没有！";
                else if (chat == "Did you know? The only real music genres are death metal and artcore.")
                    chat = "你知道吗？唯一真正的音乐类型是死亡金属和艺术核心。";
                else if (chat == "I'll have you know I'm over a hundred Fargo years old! Don't ask me how long a Fargo year is.")
                    chat = "我要让你知道我已经度过了一百多Fargo年了！别问我一Fargo年有多长。";
                else if (chat == "I might be able to afford a taller body if you keep buying!")
                    chat = "如果你继续买，我可能承担得起更高的身体！";
                else if (chat == "Where's that screm cat?")
                    chat = "那只尖叫猫呢？";
                else if (chat.EndsWith("! I saw something rodent-y just now! You don't have a hamster infestation, right? Right!?"))
                    chat = chat.Replace("! I saw something rodent-y just now! You don't have a hamster infestation, right? Right!?", "！我刚才看到了一些啮齿类动物！你没有被仓鼠感染吧？对吧！？");
                else if (chat == "You're the Terrarian? Honestly, I was expecting someone a little... taller.")
                    chat = "你就是泰拉瑞亚人？老实说，我在期待一个稍微……高一点的人。";
                else if (chat == "Don't look at me like that! The only thing I've deviated from is my humanity.")
                    chat = "别用那种眼神看我！我唯一背离的就是我的人性。";
                else if (chat == "Rip and tear and buy from me for more things to rip and tear!")
                    chat = "撕裂并流下眼泪，再从我这买点东西，再流下眼泪，这是个轮回。";
                else if (chat == "What's a chee-bee doe-goe?")
                    chat = "什么是 chee-bee doe-goe？";
                else if (chat == "Wait a second. Are you sure this house isn't what they call 'prison?'")
                    chat = "等一下，你确定这房子不是他们所说的“监狱”？";
                else if (chat == "Deviantt has awoken! Quick, give her all your money to defeat her!")
                    chat = "戴薇安已苏醒！快，把你所有的钱给她来打败她！";
                else if (chat == "One day, I'll sell a summon for myself! ...Just kidding.")
                    chat = "总有一天我会卖自己的召唤物！……开玩笑的。";
                else if (chat == "Hmm, I can tell! You've killed a lot, but you haven't killed enough!")
                    chat = "嗯，我看得出来！你杀了很多，但你杀的还不够！";
                else if (chat == "Why the extra letter, you ask? Only the strongest sibling is allowed to remove their own!")
                    chat = "你问我为什么要多出一个字母？只有我们中的最强者才被允许删除他们多出来的字母！";
                else if (chat == "The more rare things you kill, the more stuff I sell! Simple, right?")
                    chat = "你杀的稀有的东西越多，我卖的东西就越多！很简单吧？";
                else if (chat == "Oh, hi! I, uh, definitely don't have any Stink Potions on me right now! Not that I normally would!")
                    chat = "哦，嗨！我……呃，千万不要现在给我丢臭味药水！我一般不会那样！";
                else if (chat == "No, I'm totally not throwing Love Potions while you're not looking! Um, I mean... oh, just buy something!")
                    chat = "哦，嗨！我……呃，千万不要现在给我丢臭味药水！我一般不会那样！";
                else if (chat == "Shower thought. If I put you in a meat grinder and all that's left is two Dye... I'd probably be rich! Not that I would, not to you, specifically, I mean... never mind!")
                    chat = "我突然有个想法。如果我把你放进绞肉机，做到只剩下两个染料……我一定会发财！我不会那样做的，确切地说，不会对你……我的意思是……别管它了。";
                else if (mutant != -1)
                {
                    if (chat == $"Can you tell {Main.npc[mutant].GivenName} to put some clothes on?")
                        chat = $"你能让{Main.npc[mutant].GivenName}穿上衣服吗？";
                    else if (chat == $"One day, I'll sell a summon for myself! ...Just kidding. That's {Main.npc[mutant].GivenName}'s job.")
                        chat = $"总有一天，我会卖自己的召唤物！……开玩笑的。那是{Main.npc[mutant].GivenName}的工作。";
                }
                else if (lumberjack != -1)
                {
                    if (chat == $"What's that? You want to fight {Main.npc[lumberjack].GivenName}? ...even I know better than to try.")
                        chat = $"啥？你想和{Main.npc[lumberjack].GivenName}打？……最好不要尝试。";
                }
                else if (chat == "Embrace suffering... and while you're at it, embrace another purchase!")
                    chat = "拥抱痛苦吧……受虐时别忘了来我这买新东西！";
            }
            #endregion
            #region lumberjack
            else if (npc.type == ModContent.NPCType<LumberJack>())
            {
                if (chat == "Dynasty wood? Between you and me, that stuff ain't real wood!")
                    chat = "王朝木？这话我就跟你说，那东西不是真木头！";
                else if (chat == "Sure cactus isn't wood, but I can still chop it with me trusty axe.")
                    chat = "仙人掌当然不是木头，但我仍然可以用我可靠的斧头砍了它。";
                else if (chat == "You wouldn't by chance have any fantasies about me... right?")
                    chat = "你对我不会有任何幻想……对吧？";
                else if (chat == "I eat a bowl of woodchips for breakfast... without any milk.")
                    chat = "我早餐吃了一碗木片……不带牛奶。";
                else if (chat == "TIIIIIIIIIMMMBEEEEEEEERRR!")
                    chat = "砍木木木木木木木木木木木木木木木木木木木头！";
                else if (chat == "I'm a lumberjack and I'm okay, I sleep all night and I work all day!")
                    chat = "我是伐木工，我没事，我整夜睡觉，整天工作！";
                else if (chat == "You won't ever need an axe again with me around.")
                    chat = "有我在，你再也不需要斧头了。";
                else if (chat == "I have heard of people cutting trees with fish, who does that?")
                    chat = "我听说有人用鱼砍树，那是谁干的？";
                else if (chat == "You wanna see me work without my shirt on? Maybe in 2030.")
                    chat = "你想看我不穿衬衫工作吗？也许在2030年可以。";
                else if (chat == "You ever seen the world tree?")
                    chat = "你见过世界树吗？";
                else if (chat == "You want what? ...Sorry that's not the kind of wood I'm selling.")
                    chat = "你想要什么？……对不起，那种木材不是我卖的。";
                else if (chat == "Why don't I sell acorns? ...I replant all the trees I chop, don't you?")
                    chat = "我为什么不卖橡实？……我每次都重新种植所有我砍的树，难道你不是吗？";
                else if (chat == "What's the best kind of tree? ... Any if I can chop it.")
                    chat = "最好的树是什么树？……任何我砍得掉的树。";
                else if (chat == "Can I axe you a question?")
                    chat = "能让你砍砍我的问题吗？";
                else if (chat == "Might take a nap under a tree later, care to join me?")
                    chat = "我待会儿也许会在树下小睡一会儿，愿意和我一起吗？";
                else if (chat == "I'm an expert in all wood types.")
                    chat = "我是所有木材类型的专家。";
                else if (chat == "I'm glad there's more trees to chop here at journey's end.")
                    chat = "我很高兴在旅途的终点，又有更多树可以砍了。";
                else if (chat == "Red is one of my favourite colors, right after wood.")
                    chat = "红色是我最喜欢的颜色之一，仅次于木材色。";
                else if (chat == "It's always flannel season.")
                    chat = "这儿一直是法兰绒的季节。";
                else if (chat == "I'm glad my wood put such a big smile on your face.")
                    chat = "我很高兴我的木头让你脸上露出如此灿烂的笑容。";
                else if (nurse != -1)
                {
                    if (chat == $"I always see {Main.npc[nurse].GivenName} looking at my biceps when I'm working. Wonder if she wants some of my wood.")
                        chat = $"我总是看见{Main.npc[nurse].GivenName}在我工作的时候看着我的二头肌。不知道她想不想要一些我的木头。";
                }
                else if (chat == "Lucy from that universe.. Interesting things await you.")
                    chat = "来自那个宇宙的露西……有趣的东西正等着你呢。";
            }
            #endregion
            #region mutant
            else if (npc.type == ModContent.NPCType<Mutant>())
            {
                if (chat == "Congratulations. You truly embraced eternity... at least, I think you did? So what happens next? Ascend from this plane of existence? Fight a transcendant cat-like entity? Destroy the world? All the power's in your hands now.")
                    chat = "恭喜。你真正地拥抱了永恒……至少，我认为你做到过？那么之后会发生什么？从这种无聊的境界飞升？与一只超凡的猫形生物战斗？毁灭世界？所有力量现在都掌握在你的手里。";
                else if (chat == "Good work beating me, I guess. I still feel like stretching my wings... Why don't we go at it for real next time?")
                    chat = "我想，打得不错。我仍然想要伸展我的翅膀……我们下次认真战斗吧？";
                else if (chat == "Nice armor you have, very realistic skin. As a matter of fact, mind if I borrow it? Your skin, that is.")
                    chat = "你这套盔甲很好，有非常逼真的皮肤。事实上，你介意我借用一下吗？我说的是你的皮肤。";
                else if (chat == "Savagery, barbarism, bloodthirst, that's what I like seeing in people.")
                    chat = "残暴、野蛮、嗜血，这就是我喜欢在人们身上看到的。";
                else if (chat == "The stronger you get, the more stuff I sell. Makes sense, right?")
                    chat = "你越强大，我卖的东西就越多。不难理解，对吧？";
                else if (chat == "There's something all of you have that I don't... Death perception, I think it's called?")
                    chat = "你们所有人都有一些我没有的东西……死亡感知，是叫这个来着吧？";
                else if (chat == "It would be pretty cool if I sold a summon for myself...")
                    chat = "我觉得卖个自己的召唤物是个挺酷的事儿……";
                else if (chat == "The only way to get stronger is to keep buying from me and in bulk too!")
                    chat = "变得更强大的唯一方法是继续从我这里购买东西，大量地购买东西！";
                else if (chat == "Why are you looking at me like that, all I did was eat an apple.")
                    chat = "你为什么那样看着我，我只是吃了一个苹果。";
                else if (chat == "Don't bother with anyone else, all you'll ever need is right here.")
                    chat = "不要打扰其他人，你所需要的就在这里。";
                else if (chat == "You're lucky I'm on your side.")
                    chat = "你很幸运，我站在你这边。";
                else if (chat == "Why yes I would love a ham and swiss sandwich.")
                    chat = "我在想为什么我会喜欢火腿和瑞士三明治。";
                else if (chat == "Should I start wearing clothes? ...Nah.")
                    chat = "我应该开始穿衣服吗？啊这……";
                else if (chat == "It's not like I can actually use all the gold you're spending.")
                    chat = "你花的所有金币我其实用不完。";
                else if (chat == "Violence for violence is the law of the beast.")
                    chat = "以暴制暴是野兽的法则。";
                else if (chat == "Those guys really need to get more creative. All of their first bosses are desert themed!")
                    chat = "那些家伙真的需要变得更有创意。他们所有的第一个Boss都是沙漠主题！";
                else if (chat == "You say you want to know how a Mutant and Abominationn are brothers? You're better off not knowing.")
                    chat = "你说你想知道突变体和憎恶是怎样的兄弟关系？你最好别问。";
                else if (chat == "I'm all you need for a calamity.")
                    chat = "我是你在灾难中所需要的一切。";
                else if (chat == "Everything shall bow before me! ...after you make this purchase.")
                    chat = "我将拥有整个世界！……在你购买我东西之后。";
                else if (chat == "It's clear that I'm helping you out, but uh.. what's in this for me? A house you say? I eat zombies for breakfast.")
                    chat = "很明显我是在帮助你，但是呃……这对我有什么好处？你认为是房子？我早餐吃僵尸。";
                else if (chat == "Can I jump? No, I don't have something called a 'spacebar'.")
                    chat = "我可以跳吗？不，我没有叫做“空格键”的东西。";
                else if (chat == "Got your nose, I needed one to replace mine.")
                    chat = "摸到你的鼻子了，我需要一个东西把我的鼻子换掉。";
                else if (chat == "What's a Terry?")
                    chat = "什么是Terry？";
                else if (chat == "Why do so many creatures carry around a weird looking blue doll? The world may never know.")
                    chat = "为什么这么多生物带着一个看起来很奇怪的蓝色娃娃？这个问题的答案可能永远不会被知晓。";
                else if (chat == "Impending doom approaches. ...If you don't buy anything of course.")
                    chat = "末日即将来临……如果你不买我东西的话。";
                else if (chat == "I've heard of a '3rd dimension', I wonder what that looks like.")
                    chat = "我听说过“三维”，我想知道它是什么样子的。";
                else if (chat == "Boy don't I look fabulous today.")
                    chat = "小子，我今天看起来不是很好。";
                else if (chat == "You have fewer friends than I do eyes.")
                    chat = "你的朋友比我的眼睛还少。";
                else if (chat == "The ocean is a dangerous place, I wonder where Diver is?")
                    chat = "海洋是一个危险的地方，我想知道潜水员在哪里？";
                else if (chat == "Do you know what an Ee-arth is?")
                    chat = "你知道Ee-arth是什么吗？";
                else if (chat == "I can't even spell 'apotheosis', do you expect me to know what it is?")
                    chat = "我连“巅峰”都不会拼写，你希望我知道它是什么吗？";
                else if (chat == "Where do monsters get their gold from? ...I don't have pockets you know.")
                    chat = "怪物从哪里得到的金币？……你知道我没有口袋。";
                else if (chat == "Dogs are cool and all, but cats don't try to bite my brain.")
                    chat = "狗很酷，但猫不会试图咬我的大脑。";
                else if (chat == "Beware the green dragon... What's that face mean?")
                    chat = "小心绿龙……你这张脸是什么意思？";
                else if (chat == "Where is this O-hi-o I keep hearing about.")
                    chat = "我一直听说的O-hi-o在哪？";
                else if (chat == "I've told you 56 times already, I'm busy... Oh wait you want to buy something, I suppose I have time.")
                    chat = "我已经跟你说过56次了，我很忙……哦，等等你想买东西？我想我有时间。";
                else if (chat == "I've heard of a 'Soul of Souls' that only exists in 2015.")
                    chat = "我听说过一个只存在于2015年的“灵魂之魂”。";
                else if (chat == "Adding EX after everything makes it way more difficult.")
                    chat = "在事物之后添加EX会让它变得更加困难。";
                else if (chat == "I think that all modern art looks great, especially the bloody stuff.")
                    chat = "我认为所有现代艺术看起来都很棒，尤其是血腥的东西。";
                else if (chat == "How many guides does it take to change a lightbulb? ... I don't know, how about you ask him.")
                    chat = "换一个灯泡需要几个向导？……我不知道，你问问他怎么样。";
                else if (chat == "Good thing I don't have a bed, I'd probably never leave it.")
                    chat = "还好我没有床，有的话我可能永远不会离开它。";
                else if (chat == "What's this about an update? Sounds rare.")
                    chat = "这更新的是什么？听起来很罕见。";
                else if (chat == "If you need me I'll be slacking off somewhere.")
                    chat = "如果你需要我，我会在某个地方偷懒。";
                else if (chat == "What do you mean who is Fargo!")
                    chat = "你是什么意思，谁是Fargo！";
                else if (chat == "Have you seen the ech cat?")
                    chat = "你见过Ech猫吗？";
                else if (chat == "I don't understand music nowadays, I prefer some smooth jazz... or the dying screams of monsters.")
                    chat = "我不懂现在的音乐，我更喜欢一些流畅的爵士乐……或者怪物垂死的尖叫声。";
                else if (chat == "Cthulhu's got nothing on me!")
                    chat = "克苏鲁在我身上得不到任何东西！";
                else if (chat == "I heard of a rumor of infinite use boss summons. Makes me sick..")
                    chat = "我听到一个关于无限召唤物的传言。这让我很难受……";
                else if (chat == "Now that you've defeated the big guy, I'd say it's time to start collecting those materials!")
                    chat = "既然打败了那个大家伙，是时候开始收集那些材料了！";
                else if (chat == "What's that? You want to fight me? ...sure, I guess.")
                    chat = "啥？你想和我战斗？……好吧。";
                else if (chat == "What's that? You want to fight me? ...maybe if I had a reason.")
                    chat = "啥？你想和我战斗？……我得有足够的理由。";
                else if (chat == "What's that? You want to fight me? ...you're not worthy you rat.")
                    chat = "啥？你想和我战斗？……你这个老鼠不配。";
                else if (chat == "A bit spooky tonight, isn't it.")
                    chat = "今晚有点吓人，不是吗？";
                else if (chat == "I'd ask for a coat, but I don't think you have any my size.")
                    chat = "我想要一件外套，但我认为你没有我的尺码。";
                else if (chat == "Weather seems odd today, wouldn't you agree?")
                    chat = "今天的天气似乎很奇怪，你同意吗？";
                else if (chat == "Lovely night, isn't it?")
                    chat = "美好的夜晚，不是吗？";
                else if (chat == "I hope the constant arguing I'm hearing isn't my fault.")
                    chat = "我希望我听到的不断争论不是我的错。";
                else if (chat == "I'd follow and help, but I'd much rather sit around right now.")
                    chat = "我会跟随并提供帮助，但我现在更愿意坐在那里。";
                else if (partyGirl != -1)
                {
                    if (chat == $"{Main.npc[partyGirl].GivenName} is the one who invited me, I don't understand why though.")
                        chat = $"{Main.npc[partyGirl].GivenName}邀请了我，但我不明白为什么。";
                    else if (chat == $"Man, {Main.npc[partyGirl].GivenName}'s confetti keeps getting stuck to my wings.")
                        chat = $"兄弟，{Main.npc[partyGirl].GivenName}的五彩纸屑总是粘在我的翅膀上。";
                }
                else if (nurse != -1)
                {
                    if (chat == $"Whenever we're alone, {Main.npc[nurse].GivenName} keeps throwing syringes at me, no matter how many times I tell her to stop!")
                        chat = $"每当我们独自一人时，{Main.npc[nurse].GivenName}都一直向我扔注射器！无论我叫她停下多少次！";
                }
                else if (witchDoctor != -1)
                {
                    if (chat == $"Please go tell {Main.npc[witchDoctor].GivenName} to drop the 'mystical' shtick, I mean, come on! I get it, you make tainted water or something.")
                        chat = $"请让{Main.npc[witchDoctor].GivenName}放弃“神秘”的技巧，我的意思是，哦！我明白了，你也制造了被污染的水什么的。";
                }
                else if (dryad != -1)
                {
                    if (chat == $"Why does {Main.npc[dryad].GivenName}'s outfit make my wings flutter?")
                        chat = $"为什么{Main.npc[dryad].GivenName}的装扮让我的翅膀颤动？";
                }
                else if (stylist != -1)
                {
                    if (chat == $"{Main.npc[stylist].GivenName} once gave me a wig... I look hideous with long hair.")
                        chat = $"{Main.npc[stylist].GivenName}曾经给了我一顶假发……我戴长发看起来很丑。";
                }
                else if (chat == $"That mutated mushroom seems like my type of fella.")
                    chat = $"那个变异蘑菇似乎是我喜欢的类型。";
                else if (tax != -1)
                {
                    if (chat == $"{Main.npc[tax].GivenName} keeps asking me for money, but he won't accept my spawners!")
                        chat = $"{Main.npc[tax].GivenName}一直向我要钱，但他不接受我用召唤物！";
                }
                else if (guide != -1)
                {
                    if (chat == $"Any idea why {Main.npc[guide].GivenName} is always cowering in fear when I get near him?")
                        chat = $"为什么当我靠近{Main.npc[guide].GivenName}时他总是害怕？";
                }
                else if (truffle != -1 && witchDoctor != -1 && cyborg != -1)
                {
                    if (chat == $"If any of us could play instruments, I'd totally start a band with {Main.npc[witchDoctor].GivenName}, {Main.npc[truffle].GivenName}, and {Main.npc[cyborg].GivenName}.")
                        chat = $"如果我们中有人会演奏乐器，我会叫上{Main.npc[witchDoctor].GivenName}，{Main.npc[truffle].GivenName}和{Main.npc[cyborg].GivenName}来组建一支乐队。";
                }
                else if (demoman != -1)
                {
                    if (chat == $"I'm surprised {Main.npc[demoman].GivenName} hasn't blown a hole in the floor yet, on second thought that sounds fun.")
                        chat = $"我很惊讶{Main.npc[demoman].GivenName}还没有在地板上炸个洞，不过仔细想想这听起来很有趣。";
                }
                else if (tavernkeep != -1)
                {
                    if (chat == $"{Main.npc[tavernkeep].GivenName} keeps suggesting I drink some beer, something tells me he wouldn't like me when I'm drunk though.")
                        chat = $"{Main.npc[tavernkeep].GivenName}一直建议我喝啤酒，但我喝醉了他也不会喜欢我。";
                }
                else if (dyeTrader != -1)
                {
                    if (chat == $"{Main.npc[dyeTrader].GivenName} wants to see what I would look like in blue... I don't know how to feel.")
                        chat = $"{Main.npc[dyeTrader].GivenName}想看看我穿蓝色衣服会是什么样子……我不知道什么感觉。";
                }
            }

            #endregion
            #region squirrel
            else if (npc.type == ModContent.NPCType<Squirrel>())
            {
                if (chat == "*squeak*")
                    chat = "*吱吱*";
                else if (chat == "*chitter*")
                    chat = "*啾啾*";
                else if (chat == "*crunch crunch*")
                    chat = "*嘎吱嘎吱*";
                else if (chat == "[c/FF0000:You will suffer.]")
                    chat = "[c/FF0000:你会受苦的。]";
            }
            #endregion
        }
        public override void OnChatButtonClicked(NPC npc, bool firstButton)
        {
            #region abominationn
            if (npc.type == ModContent.NPCType<Abominationn>())
            {
                if (Main.npcChatText == "Hocus pocus, the event is over")
                {
                    Main.npcChatText = "天灵灵地灵灵，事件结束了！";
                    return;
                }

                for (int abomclearcd = 120; abomclearcd >= 0; abomclearcd--)
                {
                    if (Main.npcChatText == $"I'm not feeling it right now, come back in {abomclearcd} seconds.")
                    {
                        Main.npcChatText = $"我现在没有力气，{abomclearcd}秒之后再来吧。";
                        return;
                    }
                }
                if (Main.npcChatText == "I don't think there's an event right now.")
                {
                    Main.npcChatText = "我认为现在没有事件。";
                    return;
                }
            }
            #endregion
            #region deviantt
            else if (npc.type == ModContent.NPCType<Deviantt>())
            {
                if (Main.npcChatText == "What's that? You want to fight me for real? ...nah, I can't put up a good fight on my own.")
                    Main.npcChatText = "啥？你想和我来真的？……啊这，我自己一个人不太会打架。";
                else if (Main.npcChatText == "Hey, you've almost made it to the end! Got all your Soul accessories ready? What's that? You want to fight my big brother? ...maybe if he had a reason to.")
                    Main.npcChatText = "嘿，你已经快到最后了！准备好所有的魂饰品了吗？啥，你想和我大哥打？……应该能吧，如果他有理由这么做。";
                else if (Main.npcChatText == "Ready to fight my big brother? Remember how you've learned to learn. Stay focused, look for patterns, and don't panic. Good luck!")
                    Main.npcChatText = "准备打我大哥了？回想你是如何学会洞察战斗的。保持专注，寻找规律，不要惊慌。祝好运！";
                else if (Main.npcChatText == "Wanna craft Forces, but missing Enchantments? Craft the Sigil of Champions and they'll give you what you want, so long as you earn it.")
                    Main.npcChatText = "想合成九大力，但是缺少魔石？去做一个唤灵魔符。你想要的东西，只要你证明了自己的实力，他们就会给你。";
                else if (Main.npcChatText == "Only a specific type of weapon will work against each specific pillar. As for that moon guy, his weakness will keep changing.")
                    Main.npcChatText = "只有特定类型的武器能够有效对付每根特定的天界柱。至于那个没腿的大章鱼，他的弱点会不断变化。";
                else if (Main.npcChatText == "Some powerful enemies like that dungeon guy can create their own arenas. You won't be able to escape, so make full use of the room you do have.")
                    Main.npcChatText = "一些强大的敌人——例如那个地牢门口的家伙——可以创造自己的战斗区域。你无法逃出来，所以充分利用你掌握的空间。";
                else if (Main.npcChatText == "Did you beat that fish pig dragon yet? He reduces your maximum life a little on every hit. He's also strong enough to break defenses in one hit. Too bad you don't have any reinforced plating to prevent that, right?")
                    Main.npcChatText = "你打过那个猪龙鱼了吗？你每次被击中，他都会降低你的最大生命值。他的力量强到足以一下破除你的防御。要是你没有强化钢板来防止这种事情发生，这可太坏了，对吧？";
                else if (Main.npcChatText == "Now's a good time to go for Betsy! Don't worry. If you reach the last wave and lose, you won't have to retry the event for more attempts at her. Careful not to slip up before then, and mind her debuffs!")
                    Main.npcChatText = "现在是去打双足翼龙的好时机！别担心。如果你撑到了最后一波但输掉了，你不需要从头来过。注意不要在最后一波前失误，并注意她的减益！";
                else if (Main.npcChatText == "That temple? Reach the altar to regain wire control! The golem gets upset when you leave, so fighting in there is best. Platforms won't work, but a Lihzahrd Instactuation Bomb can help clear space!")
                    Main.npcChatText = "那座神庙？碰一下祭坛来重新控制电线！石巨人会在你离开神庙时狂暴，所以最好在那里战斗。平台在这场战斗中不起作用，但丛林神庙炸弹可以帮助清理空间！";
                else if (Main.npcChatText == "That overgrown plant inflicts a special venom that works her into an enraged frenzy if she stacks enough hits on you. She also has a ring of crystal leaves, but minions go through it.")
                    Main.npcChatText = "那株长得飞快的植物会造成一种特殊的毒液，如果你被她击中得够多，她就会进入狂暴状态。她还有一圈叶状水晶，但召唤物能穿过它们。";
                else if (Main.npcChatText == "That metal worm has a few upgrades, but its probes were downgraded to compensate. It'll start shooting homing dark stars and flying. When it coils around you, don't try to escape!")
                    Main.npcChatText = "那条金属蠕虫经过了一些升级，但它的探针被削弱了以维持平衡。它会开始射出追踪的暗星并飞行。当它盘旋在你身边时，不要试图逃跑！";
                else if (Main.npcChatText == "I saw that metal eye spinning while firing a huge laser the other day. Also, even if you kill them, they won't die until they're both killed!")
                    Main.npcChatText = "前几天我看到了那个金属眼球一边旋转一边射出一道巨大的激光。而且，即使你杀了它们，它们也不会立即死亡，直到它们都被杀死！";
                else if (Main.npcChatText == "Focus on taking down that metal skull, not its limbs. Don't try to outrun its spinning limbs! Keep your eyes open and learn to recognize what's doing what.")
                    Main.npcChatText = "专注于拿下那个大铁骷髅头，而不是它的四肢。不要试图跑出它旋转的四肢！睁大你的眼睛，学会分析它的行动。";
                else if (Main.npcChatText == "That thing's mouth is as good as immune to damage, so you'll have to aim for the eye. Only one of them is vulnerable at a time, though. What thing? You know, that thing!")
                    Main.npcChatText = "那东西的嘴几乎免疫伤害，所以你必须瞄准它们的眼睛。虽然同一时间内，它们之间只有一个能受到伤害。哪个东西？你知道的，那个东西！";
                else if (Main.npcChatText == "Next up is me! Make sure you can recognize whatever attack I'll throw at you. Blocks and turning away can nullify petrification!")
                    Main.npcChatText = "下一个是我！确保你能回避我向你丢出的任何攻击。方块和转身可以使石化无效！";
                else if (Main.npcChatText == "The master of the dungeon can use its babies to attack! Which attack it uses depends on whether or not it's spinning. It'll also take a last stand, so be ready to run when you make the kill!")
                    Main.npcChatText = "地牢之主可以操纵它的宝宝来攻击！它使用哪种攻击取决于它的头是否在旋转。它也会在最后再坚持一会，所以当你杀死它时准备好开跑！";
                else if (Main.npcChatText == "The queen bee will summon her progeny for backup. She's harder to hurt while they're there, so take them out first. Oh, and her swarm can't hit right above or below her!")
                    Main.npcChatText = "蜂后会召唤它的后代作为后援。它们存在时她更难被伤害，所以先灭了它们。对了，它的蜂群不能打到她的正上方和下方！";
                else if (Main.npcChatText == "Focus on how the ichor moves and don't get overwhelmed! When the brain gets mad, it'll confuse you every few seconds. Four rings to confuse you, one ring when it wears off!")
                    Main.npcChatText = "注意灵液如何移动，不要惊慌失措！当大脑变得疯狂时，它每几秒钟就会让你感到困惑。四个环出现时你会感到困惑，一个环出现后它会消失并冲刺！";
                else if (Main.npcChatText == "The more the world eater splits, the more worms can rush you at once. The head is extra sturdy now, but don't let them pile up too much!")
                    Main.npcChatText = "世界吞噬怪吐出越多魔唾液，一次就有更多虫子会向你冲来。它的头部现在非常结实，但不要让它们堆积太多！";
                else if (Main.npcChatText == "Watch out when you break your second Crimson Heart! It might attract the goblins, so prepare before you do it.")
                    Main.npcChatText = "当你打破第二颗猩红心脏时要小心！这也许会引来哥布林，所以在你做这桩事前做好准备。";
                else if (Main.npcChatText == "Watch out when you break your second Shadow Orb! It might attract the goblins, so prepare before you do it.")
                    Main.npcChatText = "当你打破第二颗暗影珠时要小心！这也许会引来哥布林，所以在你做这桩事前做好准备。";
                else if (Main.npcChatText == "That big eyeball has the power of the moon, but it's too flashy for its own good! Learn to notice and focus only on the bits that threaten to hurt you.")
                    Main.npcChatText = "那个大眼珠子有着月亮之力，但是全都是花里胡哨！学会注意并只关注那些可能会打到你的部分。";
                else if (Main.npcChatText == "Gonna fight that slime king soon? Crafting a Mini Instabridge or two might help, and mind the spike rain. Don't stay up and out of his range or he'll get mad, though!")
                    Main.npcChatText = "马上要和史莱姆王打一架了吗？造一两个速建平台也许会有帮助，并且注意从天而降的刺。不要待在它的上方，也不要离它太远，不然它会狂暴的！";
                else if (Main.npcChatText == "Seems like everyone's learning to project auras these days. If you look at the particles, you can see whether it'll affect you at close range or a distance!")
                    Main.npcChatText = "看起来每个人这几天都在学习如何发出光环。如果你细看那些粒子，你可以看出它会在圈内还是圈外生效！";
                else if (Main.npcChatText == "There's probably a thousand items to protect against all these debuffs. It's a shame you don't have a thousand hands to carry them all at once!")
                    Main.npcChatText = "可能有上千件物品来免疫这些减益。可惜你并没有一千只手来把它们一次全带上！";
                else if (Main.npcChatText == "Don't forget you can turn off your soul toggles! They're all in that little wrench button right below your inventory. Those small buttons at the very bottom of the list include a recommended low-lag preset!")
                    Main.npcChatText = "不要忘记你可以关闭你的魂石开关！它们都在你物品栏右下角的小扳手里。列表最底部的那些小按钮包含了一套推荐的低卡顿预设！";
                else if (Main.npcChatText == "I don't have any more Life Crystals for you, but I think my big brother left some in the fat slime king. Maybe he'll share if you beat it up!")
                    Main.npcChatText = "我没有更多的生命水晶给你了，但我想我大哥在那只肥胖的史莱姆王里留了一些。如果你击败了它，他也许会分享这些水晶！";
                else if (Main.npcChatText == "Watch out for those fish! Sharks will leave you alone if you leave them alone, but piranhas go wild when they smell blood. They can jump out of water to get you!")
                    Main.npcChatText = "小心那些鱼！鲨鱼会在你离开它们时离开你，但食人鱼一旦闻到血腥味就会立刻变得狂野。它们可以跳出水面来抓你！";
                else if (Main.npcChatText == "The water is bogging you down? Never had an issue with it, personally... Have you tried breathing water instead of air?")
                    Main.npcChatText = "水让你陷入了困境？就我而言，从来没遇到过这个问题……你试过在水里呼吸而不是在空气里吗？";
                else if (Main.npcChatText == "The underworld has gotten a lot hotter since the last time I visited. I hear an obsidian skull is a good luck charm against burning alive, though!")
                    Main.npcChatText = "较我上次参观，地狱变得更热了。不过，我听说黑曜石骷髅头是个防止被活活烧死的好运符！";
                else if (Main.npcChatText == "Want to have a breath-holding contest? The empty vacuum of space would be perfect. No, I won't cheat by breathing water instead of air!")
                    Main.npcChatText = "想来一场憋气大赛吗？太空的真空环境会是个完美的场地。不，我不会通过呼吸水而非空气来作弊！";
                else if (Main.npcChatText == "That's a funny face you're making... Is the underground Hallow too disorienting? Try controlling gravity on your own and maybe it can't flip you by force!")
                    Main.npcChatText = "你这脸真滑稽……地下神圣让你搞不清东南西北？试试自己控制重力，也许它不能强行翻转你！";
                else if (Main.npcChatText == "If you ask me, Plantera is really letting herself go. A diet of Chlorophyte Ore and Life Fruit isn't THAT healthy! Why don't you help her slim down?")
                    Main.npcChatText = "你要是问我的话，世纪之花实在是太放纵自己了。叶绿矿和生命果并不是一套那么好的饮食！为什么你不帮帮她减肥？";
            }
            #endregion
            #region lumberjack
            else if (npc.type == ModContent.NPCType<LumberJack>())
            {
                if (Main.npcChatText == "While I was chopping down a cactus these things leaped at me, why don't you take care of them?")
                    Main.npcChatText = "我在砍仙人掌的时候，这些东西向我扑过来，你为什么不好好处理它们？";
                else if (Main.npcChatText == "These mahogany trees are full of life, but a tree only has one purpose: to be chopped. Oh yea these fell out of the last one.")
                    Main.npcChatText = "这些红木树充满了生机，但一棵树只有一个意义：被砍掉。哦，是的，这些是从上一棵树上掉下来的。";
                else if (Main.npcChatText == "This place is a bit fanciful for my tastes, but the wood's as choppable as any. Nighttime has these cool bugs though, take a few.")
                    Main.npcChatText = "这个地方对我的口味来说有点异想天开，但这里的木头和其他任何地方一样砍得动。 不过，夜间有这些很酷的虫子，拿一点吧。";
                else if (Main.npcChatText == "Whatever causes these to glow is beyond me, you're probably gonna eat them anyway so have this while you're at it.")
                    Main.npcChatText = "无论是什么使这些东西发光，我都无法理解，反正你可能会吃掉它们，所以你要吃的时候就吃这个吧。";
                else if (Main.npcChatText == "The trees here are probably the toughest in this branch of reality.. Sorry, just tree puns. I found these for you here.")
                    Main.npcChatText = "这里的树可能是这个现实分支中最坚固的……抱歉，只是些树的双关语。我在这里找到了这些东西给你。";
                else if (Main.npcChatText == "This neck of the woods is pretty eh? Here I've got some of my favorite wood for you.")
                    Main.npcChatText = "这个树林的脖子很漂亮吧？在这里，我给你搞了些我最喜欢的木头。";
                else if (Main.npcChatText == "Even on vacation, I always fit in a little chopping. A couple annoying birds fell out of a palm tree. Take them off my hands.. maybe cook them up?")
                    Main.npcChatText = "即使在度假，我也总会抽出时间来砍一小点树。几对恼人的鸟从一棵棕榈树上掉了下来，把它们从我手中拿走……也许可以把它们煮了吃？";
                else if (Main.npcChatText == "I looked around here for a while and didn't find any trees. I did find these little guys though. Maybe you'll want them?")
                    Main.npcChatText = "我在这里看了一会儿，什么树都没找到。不过我确实找到了这些小家伙。也许你会想要它们？";
                else if (Main.npcChatText == "I certainly didn't expect to find such wonderful trees down here. Check this out.")
                    Main.npcChatText = "我真没想到我能在这里找到这么牛x的树。看看这个。";
                else if (Main.npcChatText == "Went for a long haul today, but there were only so many of those strange trees to go around. I did find a lot of these, why don't you give some of them a new home?")
                    Main.npcChatText = "今天我走了很远，但周围只有许多那种奇怪的树。我找到了这些，为什么不给他们一个新家呢？";
                else if (Main.npcChatText == "Seems like the wind brought a bunch of these out of hiding. Some people say they're good luck. All I know is, the only luck I need is a sharp axe!")
                    Main.npcChatText = "看上去风把这些虫子从藏身地带了出来。有些人说他们代表着好运。我只知道，我需要的所有好运就是一把锋利的斧头！";
                else if (Main.npcChatText == "Back in the day, people used to forge butterflies into powerful gear. We try to forget those days... but here have one.")
                    Main.npcChatText = "过去的日子里，人们常常将蝴蝶锻造成强大的装备。我们试图忘记那些日子……但这里有一只。";
                else if (Main.npcChatText == "I found this, but I'm not a sappy person. You can have it instead.")
                    Main.npcChatText = "我找到了这玩意儿，但我一点也不“美汁汁”的，还是给你吧。";
                else if (Main.npcChatText == "These little critters are always falling out of the trees I cut down. Maybe you can find a use for them?")
                    Main.npcChatText = "这些小动物总是从我砍倒的树上掉下来。也许你可以找到它们的用途？";
                else if (Main.npcChatText == "Chopping trees at night is always relaxing... well except for the flying eyeballs. Have one of these little guys to keep you company.")
                    Main.npcChatText = "晚上砍树总是很放松的……好吧，除了这些飞来飞去的眼球。让这些小家伙中的一个陪陪你。";
                else if (Main.npcChatText == "I'm resting after a good day of chopping, come back tomorrow and maybe I'll have something else for you.")
                    Main.npcChatText = "我砍了一天的好东西，现在正在休息呢。明天再来，也许我会给你点别的东西。";
            }
            #endregion
        }
    }
}
