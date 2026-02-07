using System.Collections.Generic;
using HarmonyLib;

using weluvsubtitle.Relay;
using weluvsubtitle.TriggerHelper;
using weluvsubtitle.Attributes;

namespace weluvsubtitle.TriggerPatches.Player;

[PatchOnEntry]
[HarmonyPatch(typeof(ShotgunHammer))]
public static class ShotgunHammerPatch
{
    [HarmonyPostfix]
    [HarmonyPatch(nameof(ShotgunHammer.Awake))]
    public static void PatchStart(ShotgunHammer __instance)
    {
        InjectHelper.InjectObserver(__instance.hitSound, Id.Player.ShotgunHammer.hit);
    }
    
    [HarmonyTranspiler]
    [HarmonyPatch(nameof(ShotgunHammer.ThrowNade))]
    public static IEnumerable<CodeInstruction> ShootSinkTranspiler(IEnumerable<CodeInstruction> instructions)
        => ILHelper.WrapWithPositionEmit(instructions, Id.Player.ShotgunHammer.throwNade);
    
    [HarmonyTranspiler]
    [HarmonyPatch(nameof(ShotgunHammer.ShootSaw))]
    public static IEnumerable<CodeInstruction> ShootSawTranspiler(IEnumerable<CodeInstruction> instructions)
        => ILHelper.WrapWithPositionEmit(instructions, Id.Player.ShotgunHammer.shootSaw);
    
    [HarmonyTranspiler]
    [HarmonyPatch(nameof(ShotgunHammer.Pump))]
    public static IEnumerable<CodeInstruction> PumpTranspiler(IEnumerable<CodeInstruction> instructions)
        => ILHelper.WrapWithActionAtEnd(instructions, AccessTools.Method(typeof(ShotgunHammerPatch), nameof(PumpPatch)));
    
    //[HarmonyTranspiler]
    //[HarmonyPatch(nameof(ShotgunHammer.DeliverDamage))]

    public static void PumpPatch(ShotgunHammer __instance)
    {
        switch (__instance.primaryCharge)
        {
            case 1:
                EventRelay.Emit(Id.Player.ShotgunHammer.pumpLevel1, __instance.transform.position);
                break;
            case 2:
                EventRelay.Emit(Id.Player.ShotgunHammer.pumpLevel2, __instance.transform.position);
                break;
            case 3:
                EventRelay.Emit(Id.Player.ShotgunHammer.pumpLevel3, __instance.transform.position);
                break;
            default:
                EventRelay.Emit(Id.Player.ShotgunHammer.pumpLevel3, __instance.transform.position);
                break;
        }
    }
    
}