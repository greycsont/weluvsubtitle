using System.Collections.Generic;
using HarmonyLib;

using weluvsubtitle.Relay;
using weluvsubtitle.TriggerHelper;
using weluvsubtitle.Attributes;

namespace weluvsubtitle.TriggerPatches.Player;

[PatchOnEntry]
[HarmonyPatch(typeof(Shotgun))]
public static class ShotgunPatch
{
    [HarmonyTranspiler]
    [HarmonyPatch(nameof(Shotgun.Shoot))]
    public static IEnumerable<CodeInstruction> ShootTranspiler(IEnumerable<CodeInstruction> instructions)
        => ILHelper.WrapWithPositionEmit(instructions, Id.Player.Shotgun.shoot);
    
    [HarmonyTranspiler]
    [HarmonyPatch(nameof(Shotgun.ShootSinks))]
    public static IEnumerable<CodeInstruction> ShootSinkTranspiler(IEnumerable<CodeInstruction> instructions)
        => ILHelper.WrapWithPositionEmit(instructions, Id.Player.Shotgun.shootSink);
    
    [HarmonyTranspiler]
    [HarmonyPatch(nameof(Shotgun.ShootSaw))]
    public static IEnumerable<CodeInstruction> ShootSawTranspiler(IEnumerable<CodeInstruction> instructions)
        => ILHelper.WrapWithPositionEmit(instructions, Id.Player.Shotgun.shootSaw);

    [HarmonyTranspiler]
    [HarmonyPatch(nameof(Shotgun.Pump))]
    public static IEnumerable<CodeInstruction> PumpTranspiler(IEnumerable<CodeInstruction> instructions)
        => ILHelper.WrapWithActionAtEnd(instructions, AccessTools.Method(typeof(ShotgunPatch), nameof(PumpPatch)));
    
    public static void PumpPatch(Shotgun __instance)
    {
        switch (__instance.primaryCharge)
        {
            case 1:
                EventRelay.Emit(Id.Player.Shotgun.pumpLevel1, __instance.transform.position);
                break;
            case 2:
                EventRelay.Emit(Id.Player.Shotgun.pumpLevel2, __instance.transform.position);
                break;
            case 3:
                EventRelay.Emit(Id.Player.Shotgun.pumpLevel3, __instance.transform.position);
                break;
            default:
                EventRelay.Emit(Id.Player.Shotgun.pumpLevel3, __instance.transform.position);
                break;
        }
    }
}