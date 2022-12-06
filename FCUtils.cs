using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FargoChinese
{
    public static class FCUtils
    {
        public static void Merge<TKey, TValue>(this Dictionary<TKey, TValue> Dic1, Dictionary<TKey, TValue> Dic2)
        {
            if (Dic1 == null || Dic2 == null)
                return;
            foreach (KeyValuePair<TKey, TValue> item in Dic2)
            {
                if (Dic1.ContainsKey(item.Key))
                    Dic1.Remove(item.Key);
                Dic1.Add(item.Key, item.Value);
            }
        }
    }
}
