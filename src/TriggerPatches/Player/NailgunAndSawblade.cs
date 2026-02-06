using System.Collections.Generic;
using HarmonyLib;

using weluvsubtitle.Relay;
using weluvsubtitle.TriggerHelper;


namespace weluvsubtitle.TriggerPatches.Player;

[HarmonyPatch(typeof(Nailgun))]
public static class NailgunAndSawblade
{
    [HarmonyTranspiler]
    [HarmonyPatch(nameof(Nailgun.Shoot))]
    public static IEnumerable<CodeInstruction> ShootTranspiler(IEnumerable<CodeInstruction> instructions)
        => ILHelper.WrapWithAction(instructions, AccessTools.Method(typeof(NailgunAndSawblade), nameof(ShootPatch)));   

    public static void ShootPatch(Nailgun __instance)
    {
        if (__instance.altVersion)
            EventRelay.Emit(Id.Player.Nailgun.shootSaw, __instance.transform.position);
        else
            EventRelay.Emit(Id.Player.Nailgun.shootNail, __instance.transform.position);
    }
}