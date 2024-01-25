using System;
using System.Collections.Generic;
using MonoMod.RuntimeDetour;

namespace FargoChinese.BuildIgnore.Patch;

public static class PatchManager
{
    public static List<Hook> Hooks;
    public static List<ILHook> ILHooks;

    public static void Load()
    {
        Hooks = new List<Hook>();
        ILHooks = new List<ILHook>();

        foreach (var type in FargoChinese.Instance.Code.GetTypes())
        {
            if (type.IsSubclassOf(typeof(PatchBase)))
            {
                var patch = Activator.CreateInstance(type) as PatchBase;
                if (patch == null)
                {
                    FargoChinese.Instance.Logger.Error($"{nameof(patch)} is null!");
                    continue;
                }
                if (patch.IsLoadingEnabled())
                {
                    patch.Load();
                    if (patch.MethodInfos == null)
                        continue;
                    foreach (var methodInfo in patch.MethodInfos)
                    {
                        if (methodInfo.Value.Item3) // is on hook
                        {
                            Hooks.Add(new Hook(
                                methodInfo.Key.GetMethod(methodInfo.Value.Item1, methodInfo.Value.Item2) ??
                                throw new Exception($"{methodInfo.Value.Item1} not found!"),
                                methodInfo.Value.Item4));
                        }
                        else // is il hook
                        {
                            ILHooks.Add(new ILHook(
                                methodInfo.Key.GetMethod(methodInfo.Value.Item1, methodInfo.Value.Item2) ??
                                throw new Exception($"{methodInfo.Value.Item1} not found!"),
                                i => methodInfo.Value.Item4.DynamicInvoke(i)));
                        }
                    }
                }
            }

            foreach (var hook in Hooks)
                hook.Apply();
            foreach (var ilHook in ILHooks)
                ilHook.Apply();
        }
    }
}