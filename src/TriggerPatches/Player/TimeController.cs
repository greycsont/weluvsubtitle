using System.Collections.Generic;
using HarmonyLib;

using weluvsubtitle.TriggerHelper;
using weluvsubtitle.Relay;  


namespace weluvsubtitle.TriggerPatches.Player;

[HarmonyPatch(typeof(TimeController))]
public static class TimeControllerPatch
{
    [HarmonyTranspiler]
    [HarmonyPatch(nameof(TimeController.ParryFlash))]
    public static IEnumerable<CodeInstruction> ParryFlashTranspiler(IEnumerable<CodeInstruction> instructions)
        => ILHelper.WrapWithPositionEmit(instructions, Id.Player.NewMovement.parry);
}