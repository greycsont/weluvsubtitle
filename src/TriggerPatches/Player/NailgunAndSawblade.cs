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

    [HarmonyTranspiler]
    [HarmonyPatch(nameof(Nailgun.ShootZapper))]
    public static IEnumerable<CodeInstruction> ShootZapperTranspiler(IEnumerable<CodeInstruction> instructions)
        => ILHelper.WrapWithPositionEmit(instructions, Id.Player.Nailgun.shootZapper);

    [HarmonyTranspiler]
    [HarmonyPatch(nameof(Nailgun.SuperSaw))]
    public static IEnumerable<CodeInstruction> SuperSawTranspiler(IEnumerable<CodeInstruction> instructions)
        => ILHelper.WrapWithPositionEmit(instructions, Id.Player.Nailgun.superSaw);
    
    [HarmonyTranspiler]
    [HarmonyPatch(nameof(Nailgun.BurstFire))]
    public static IEnumerable<CodeInstruction> BurstFireTranspiler(IEnumerable<CodeInstruction> instructions)
        => ILHelper.WrapWithPositionEmit(instructions, Id.Player.Nailgun.burstFire);

    [HarmonyTranspiler]
    [HarmonyPatch(nameof(Nailgun.ShootMagnet))]
    public static IEnumerable<CodeInstruction> ShootMagnetTranspiler(IEnumerable<CodeInstruction> instructions)
        => ILHelper.WrapWithPositionEmit(instructions, Id.Player.Nailgun.shootMagnet);

    public static void ShootPatch(Nailgun __instance)
    {
        if (__instance.altVersion)
            EventRelay.Emit(Id.Player.Nailgun.shootSaw, __instance.transform.position);
        else
            EventRelay.Emit(Id.Player.Nailgun.shootNail, __instance.transform.position);
    }

}