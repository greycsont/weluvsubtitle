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
        Plugin.log.LogInfo($"Emitting trigger with id: {id}");
        
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

    public static IEnumerable<CodeInstruction> WrapWithActionAtStart(
        IEnumerable<CodeInstruction> instructions, 
        MethodInfo method, 
        params CodeInstruction[] args)
    {
        var codes = new List<CodeInstruction>();
        if (args != null) codes.AddRange(args);
        codes.Add(new CodeInstruction(OpCodes.Ldarg_0));
        codes.Add(new CodeInstruction(OpCodes.Call, method));

        return new CodeMatcher(instructions)
            .Start()
            .Insert(codes)
            .InstructionEnumeration();
    }

    public static IEnumerable<CodeInstruction> WrapWithActionAtEnd(
        IEnumerable<CodeInstruction> instructions, 
        MethodInfo method, 
        params CodeInstruction[] args)
    {
        var codes = new List<CodeInstruction>();
        if (args != null) codes.AddRange(args);
        codes.Add(new CodeInstruction(OpCodes.Ldarg_0));
        codes.Add(new CodeInstruction(OpCodes.Call, method));

        return new CodeMatcher(instructions)
            .End()
            .MatchForward(false, new CodeMatch(OpCodes.Ret))
            .Insert(codes)
            .InstructionEnumeration();
    }
}