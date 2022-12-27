using Terraria.ModLoader;
using On.Terraria.GameContent.UI.Elements;
using System.Reflection;

namespace FargoChinese.Patch
{
    public static class KeyBindsTranslate
    {
        public static void Load()
        {
            UIKeybindingListItem.GetFriendlyName += UIKeybindingListItem_GetFriendlyName;
        }

        private static string UIKeybindingListItem_GetFriendlyName(UIKeybindingListItem.orig_GetFriendlyName orig, Terraria.GameContent.UI.Elements.UIKeybindingListItem item)
        {
            string keybindName = item.GetType().GetField("_keybind", (BindingFlags)60).GetValue(item) as string;
            if (keybindName == "Fargowiltas: Quick Recall/Mirror")
                return "Fargo突变：快速回家";
            else if (keybindName == "Fargowiltas: Quick Rod of Discord")
                return "Fargo突变：快捷混沌传送杖";
            else if (keybindName == "Fargowiltas: Quick Use Custom (Bottom Left Inventory Slot)")
                return "Fargo突变：快捷使用背包左下角物品";
            else if (keybindName == "Fargowiltas: Open Stat Sheet")
                return "Fargo突变：打开属性统计表";
            else if (keybindName.Contains("FargowiltasSouls: "))
            {
                string retVal = keybindName.Replace("FargowiltasSouls: ", "Fargo魂石：");
                if (retVal == "Fargo魂石：突变炸弹")
                    return "Fargo魂石：炸弹";
                return retVal;
            }
            return orig.Invoke(item);
        }
        public static void Unload()
        {
            UIKeybindingListItem.GetFriendlyName -= UIKeybindingListItem_GetFriendlyName;
        }
    }
}