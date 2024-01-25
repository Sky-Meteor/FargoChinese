using System;

namespace FargoChinese.GameCommentSystem
{
    public static class CommentSystemUtils
    {
        public const string Graveyard = "墓地";
        public const string Crimson = "猩红之地";
        public const string Corruption = "腐化之地";
        public const string Hallow = "神圣之地";
        public const string Jungle = "丛林";
        public const string Snow = "雪原";
        public const string Desert = "沙漠";
        public const string BloodMoon = "血月";
        public const string Space = "太空";
        public const string HardMode = "困难模式";
        public const string Dungeon = "地牢";
        public const string Underground = "地下";
        public const string Underworld = "地狱";
        public const string Forest = "森林";
        public const string Ocean = "海洋";
        public const string EvilBiome = "邪恶生物群落";

        public const string ForestTree = "森林树";
        public const string BorealTree = "针叶树";
        public const string MahoganyTree = "红木树";
        public const string EbonwoodTree = "乌木树";
        public const string ShadewoodTree = "暗影木树";
        public const string PearlwoodTree = "珍珠木树";
        public const string PalmTree = "棕榈树";
        public const string A = "";
        
        public static string Not(string tip) => $"非{tip}";

        public static string And(string tip) => $"且{tip}";

        public static string Or(string tip) => $"或{tip}";

        public static string In(string tip) => $"{tip}中";

        public static string When(string tip) => $"{tip}时";

        public static string Of(string tip) => $"{tip}的";

        public static string Moon(params int[] id)
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

        public static string MoonToName(int id)
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
    }
}