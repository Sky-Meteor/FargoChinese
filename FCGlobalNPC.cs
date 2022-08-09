using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
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
        public static bool IsChinese() => LanguageManager.Instance.ActiveCulture == GameCulture.FromCultureName(GameCulture.CultureName.Chinese);
        public override void GetChat(NPC npc, ref string chat)
        {
            if (IsChinese())
            {
                int mechanic = NPC.FindFirstNPC(NPCID.Mechanic);
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
                if (chat == $"Can you please ask {Main.npc[mechanic].GivenName} to stop touching my laser arm please.")
                    chat = $"你能去找{Main.npc[mechanic].GivenName}吗？请让她别碰我的激光胳膊了。";
                #endregion
            }
        }
        public override void OnChatButtonClicked(NPC npc, bool firstButton)
        {
            if (IsChinese())
            {
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
            }
        }
    }
}
