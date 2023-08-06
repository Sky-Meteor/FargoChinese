using Terraria.GameContent.UI.Elements;
using System.Reflection;

namespace FargoChinese.Patch
{
    public class KeyBindsTranslate : PatchBase
    {
        public override void Load()
        {
            On_UIKeybindingListItem.GetFriendlyName += UIKeybindingListItem_GetFriendlyName;
        }

        private static string UIKeybindingListItem_GetFriendlyName(On_UIKeybindingListItem.orig_GetFriendlyName orig, Terraria.GameContent.UI.Elements.UIKeybindingListItem item)
        {
            if (item.GetType().GetField("_keybind", (BindingFlags)60)?.GetValue(item) is not string keybindName)
                return orig.Invoke(item);
            switch (keybindName)
            {
                case "Fargowiltas: Quick Recall/Mirror":
                    return "Fargo突变：快速回家";
                case "Fargowiltas: Quick Rod of Discord":
                    return "Fargo突变：快捷混沌传送杖";
                case "Fargowiltas: Quick Use Custom (Bottom Left Inventory Slot)":
                    return "Fargo突变：快捷使用背包左下角物品";
                case "Fargowiltas: Open Stat Sheet":
                    return "Fargo突变：打开属性统计表";
                default:
                    if (keybindName.Contains("FargowiltasSouls: "))
                    {
                        string retVal = keybindName.Replace("FargowiltasSouls: ", "Fargo魂石：");
                        return retVal == "Fargo魂石：突变炸弹" ? "Fargo魂石：炸弹" : retVal;
                    }

                    return orig.Invoke(item);
            }
        }
        public override void Unload()
        {
            On_UIKeybindingListItem.GetFriendlyName -= UIKeybindingListItem_GetFriendlyName;
        }
    }
}