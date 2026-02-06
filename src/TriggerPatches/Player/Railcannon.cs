using System.Collections.Generic;
using HarmonyLib;

using weluvsubtitle.Relay;
using weluvsubtitle.TriggerHelper;

namespace weluvsubtitle.TriggerPatches.Player;


[HarmonyPatch(typeof(Railcannon))]
public static class RailcannonPatch
{
    [HarmonyTranspiler]
    [HarmonyPatch(nameof(Railcannon.Shoot))]
    public static IEnumerable<CodeInstruction> ShootTranspiler(IEnumerable<CodeInstruction> instructions)
        => ILHelper.WrapWithAction(instructions, AccessTools.Method(typeof(RailcannonPatch), nameof(ShootPatch)));

    public static void ShootPatch(Railcannon __instance)
    {
        switch (__instance.variation)
        {
            case 0:
                EventRelay.Emit(Id.Player.Railcannon.shootElectric, __instance.transform.position);
                break;
            case 1:
                EventRelay.Emit(Id.Player.Railcannon.shootHarpoon, __instance.transform.position);
                break;
            case 2:
                EventRelay.Emit(Id.Player.Railcannon.shootMaliciousBeam, __instance.transform.position);
                break;
        }
    }
}

[HarmonyPatch(typeof(WeaponCharges))]
public static class WeaponChargesPatch
{
    [HarmonyTranspiler]
    [HarmonyPatch(nameof(WeaponCharges.PlayRailCharge))]
    public static IEnumerable<CodeInstruction> PlayRailChargeTranspiler(IEnumerable<CodeInstruction> instructions)
        => ILHelper.WrapWithPositionEmit(instructions, Id.Player.Railcannon.maxCharge);
}