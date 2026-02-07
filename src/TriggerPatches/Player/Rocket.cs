using System.Collections.Generic;

using HarmonyLib;

using weluvsubtitle.TriggerHelper;
using weluvsubtitle.Relay;
using weluvsubtitle.Attributes;

namespace weluvsubtitle.TriggerPatches.Player;

[PatchOnEntry]
[HarmonyPatch(typeof(RocketLauncher))]
public static class RocketPatch
{
    // 这里是真屋檐了
    [HarmonyPostfix]
    [HarmonyPatch(nameof(RocketLauncher.Start))]
    public static void PatchStart(RocketLauncher __instance)
    {
        InjectHelper.InjectObserver(__instance.timerTickSound, Id.Player.Rocket.timeTicking);
    }
    
    [HarmonyTranspiler]
    [HarmonyPatch(nameof(RocketLauncher.Shoot))]
    public static IEnumerable<CodeInstruction> ShootTranspiler(IEnumerable<CodeInstruction> instructions)
        => ILHelper.WrapWithPositionEmit(instructions, Id.Player.Rocket.shoot);

    [HarmonyTranspiler]
    [HarmonyPatch(nameof(RocketLauncher.ShootCannonball))]
    public static IEnumerable<CodeInstruction> ShootCannonballTranspiler(IEnumerable<CodeInstruction> instructions)
        => ILHelper.WrapWithPositionEmit(instructions, Id.Player.Rocket.shootCannonball);

    [HarmonyTranspiler]
    [HarmonyPatch(nameof(RocketLauncher.FreezeRockets))]
    public static IEnumerable<CodeInstruction> FreezeRocketsTranspiler(IEnumerable<CodeInstruction> instructions)
        => ILHelper.WrapWithPositionEmit(instructions, Id.Player.Rocket.freezeRockets);

    [HarmonyTranspiler]
    [HarmonyPatch(nameof(RocketLauncher.UnfreezeRockets))]
    public static IEnumerable<CodeInstruction> UnfreezeRocketsTranspiler(IEnumerable<CodeInstruction> instructions)
        => ILHelper.WrapWithPositionEmit(instructions, Id.Player.Rocket.unfreezeRockets);

    [HarmonyTranspiler]
    [HarmonyPatch(nameof(RocketLauncher.ShootNapalm))]
    public static IEnumerable<CodeInstruction> ShootNapalmTranspiler(IEnumerable<CodeInstruction> instructions)
        => ILHelper.WrapWithPositionEmit(instructions, Id.Player.Rocket.shootNapalm);
}