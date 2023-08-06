using MonoMod.RuntimeDetour.HookGen;
using System;
using System.Collections.Generic;
using System.Reflection;
using Terraria.ModLoader;

namespace FargoChinese.Patch
{
    public abstract class PatchBase : ModSystem
    {
        /// <summary>
        /// <see cref="Type" />: 反射方法所在类的类型；<see cref="string" />: 方法名；<see cref="BindingFlags" />: 方法的筛选标志；<see cref="bool" />: true为OnPatch，false为ILPatch；<see cref="Delegate" />: 修改的方法
        /// </summary>
        protected virtual Dictionary<Type, Tuple<string, BindingFlags, bool, Delegate>> MethodInfos => null;

        protected virtual bool LoadWithFargoSouls => false;

        public override bool IsLoadingEnabled(Mod mod) =>
            LoadWithFargoSouls ? ModLoader.TryGetMod("FargowiltasSouls", out _) : base.IsLoadingEnabled(mod);

        private Dictionary<Delegate, MethodBase> _onMethods;
        private Dictionary<Delegate, MethodBase> _ilMethods;

        /// <summary>
        /// 使用时若不希望覆盖记得 <see cref="Load()"/>
        /// </summary>
        public override void Load()
        {
            /*if (MethodInfos == null)
                return;
            _onMethods = new Dictionary<Delegate, MethodBase>();
            _ilMethods = new Dictionary<Delegate, MethodBase>();

            foreach (var methodInfo in MethodInfos)
            {
                if (methodInfo.Value.Item3)
                {
                    _onMethods.Add(methodInfo.Value.Item4, methodInfo.Key.GetMethod(methodInfo.Value.Item1, methodInfo.Value.Item2));
                }
                else
                {
                    _ilMethods.Add(methodInfo.Value.Item4, methodInfo.Key.GetMethod(methodInfo.Value.Item1, methodInfo.Value.Item2));
                }
            }

            if (_onMethods.Count != 0)
            {
                foreach (var method in _onMethods)
                {
                    HookEndpointManager.Add(method.Value, method.Key);
                }
            }
            else
            {
                _onMethods = null;
            }

            if (_ilMethods.Count != 0)
            {
                foreach (var method in _ilMethods)
                {
                    HookEndpointManager.Modify(method.Value, method.Key);
                }
            }
            else
            {
                _ilMethods = null;
            }*/
        }

        /// <summary>
        /// 使用时若不希望覆盖记得 <see cref="Unload()"/>
        /// </summary>
        public override void Unload()
        {
            /*if (MethodInfos == null)
                return;

            if (_onMethods != null)
            {
                foreach (var method in _onMethods)
                {
                    HookEndpointManager.Remove(method.Value, method.Key);
                }
                _onMethods = null;
            }

            if (_ilMethods != null)
            {
                foreach (var method in _ilMethods)
                {
                    HookEndpointManager.Unmodify(method.Value, method.Key);
                }
                _ilMethods = null;
            }*/
        }
    }
}