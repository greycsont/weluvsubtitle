using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using System.Reflection.Emit;
using HarmonyLib;

using weluvsubtitle.Relay;

namespace weluvsubtitle.TriggerHelper;

public static class ILHelper
{
    private static IEnumerable<CodeInstruction> EmitPositionWithStrId(string id)
    {
        yield return new CodeInstruction(OpCodes.Ldstr, id);

        yield return new CodeInstruction(OpCodes.Ldarg_0);

        yield return new CodeInstruction(OpCodes.Call, 
            AccessTools.PropertyGetter(typeof(Component), nameof(Component.transform)));

        yield return new CodeInstruction(OpCodes.Call, 
            AccessTools.PropertyGetter(typeof(Transform), nameof(Transform.position)));

        yield return new CodeInstruction(OpCodes.Call, 
            AccessTools.Method(typeof(EventRelay), nameof(EventRelay.Emit), new[] { typeof(string), typeof(Vector3) }));
    }

    public static IEnumerable<CodeInstruction> WrapWithPositionEmit(IEnumerable<CodeInstruction> instructions, string id)
    {
        return new CodeMatcher(instructions)
            .Start()
            .Insert(EmitPositionWithStrId(id))
            .InstructionEnumeration();
    }

    public static IEnumerable<CodeInstruction> WrapWithAction(
        IEnumerable<CodeInstruction> instructions, 
        MethodInfo targetMethod)
    {
        return new CodeMatcher(instructions)
            .Start()
            .Insert(
                new CodeInstruction(OpCodes.Ldarg_0),
                new CodeInstruction(OpCodes.Call, targetMethod)
            )
            .InstructionEnumeration();
    }
}