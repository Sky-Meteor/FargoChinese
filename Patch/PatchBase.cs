using System;
using System.Collections.Generic;
using System.Reflection;
using MonoMod.RuntimeDetour.HookGen;
using Terraria.ModLoader;

namespace FargoChinese.Patch
{
    public abstract class PatchBase : ModSystem
    {
        /// <summary>
        /// Type: 反射方法所在类的类型；string: 方法名；BindingFlags: 方法的筛选标志；bool: true为OnPatch，false为ILPatch；Delegate: 修改的方法
        /// </summary>
        protected abstract Dictionary<Type, Tuple<string, BindingFlags, bool, Delegate>> MethodInfos { get; }

        private Dictionary<Delegate, MethodBase> _onMethods;
        private Dictionary<Delegate, MethodBase> _ilMethods;
        public override void Load()
        {
            if (MethodInfos == null)
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

            if (_ilMethods.Count != 0)
            {
                foreach (var method in _ilMethods)
                {
                    HookEndpointManager.Modify(method.Value, method.Key);
                }
            }
        }

        public override void Unload()
        {
            if (MethodInfos == null)
                return;

            if (_onMethods.Count != 0)
            {
                foreach (var method in _onMethods)
                {
                    HookEndpointManager.Remove(method.Value, method.Key);
                }
            }

            if (_ilMethods.Count != 0)
            {
                foreach (var method in _ilMethods)
                {
                    HookEndpointManager.Unmodify(method.Value, method.Key);
                }
            }

            _onMethods = null;
            _ilMethods = null;
        }
    }
}