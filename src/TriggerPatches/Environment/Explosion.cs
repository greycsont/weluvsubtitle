using System.Collections.Generic;
using HarmonyLib;

using weluvsubtitle.TriggerHelper;
using weluvsubtitle.Relay;

namespace weluvsubtitle.TriggerPatches.Environment;

[HarmonyPatch(typeof(Explosion))]
public static class ExplosionPatch
{
    [HarmonyTranspiler]
    [HarmonyPatch(nameof(Explosion.Start))]
    public static IEnumerable<CodeInstruction> StartTranspiler(IEnumerable<CodeInstruction> instructions)
        => ILHelper.WrapWithPositionEmit(instructions, Id.Environment.explosion);
}