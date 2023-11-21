using System;
using System.Collections.Generic;
using System.Reflection;
using Terraria.ModLoader;

namespace FargoChinese.Patch
{
    public abstract class PatchBase
    {
        /// <summary>
        /// <see cref="Type" />: 反射方法所在类的类型；<see cref="string" />: 方法名；<see cref="BindingFlags" />: 方法的筛选标志；<see cref="bool" />: true为OnPatch，false为ILPatch；<see cref="Delegate" />: 修改的方法
        /// </summary>
        public virtual Dictionary<Type, Tuple<string, BindingFlags, bool, Delegate>> MethodInfos => null;

        protected static bool LoadWithFargoSouls() => ModLoader.TryGetMod("FargowiltasSouls", out _);

        public virtual bool IsLoadingEnabled() => true;

        /// <summary>
        /// 原版On和IL写这里
        /// </summary>
        public virtual void Load()
        {

        }

        /// <summary>
        /// 原版On和IL写这里
        /// </summary>
        public virtual void Unload()
        {

        }
    }
}