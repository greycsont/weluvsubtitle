using HarmonyLib;

using weluvsubtitle.TriggerHelper;
using weluvsubtitle.Relay;
using weluvsubtitle.Attributes;

namespace weluvsubtitle.TriggerPatches.Weapon;

[PatchOnEntry]
[HarmonyPatch(typeof(RocketLauncher))]
public static class RocketPatch
{
    // 这里是真屋檐了
    [HarmonyPostfix]
    [HarmonyPatch(nameof(RocketLauncher.Start))]
    public static void PatchStart(RocketLauncher __instance)
        => InjectHelper.InjectObserver(__instance.timerTickSound, Id.Player.Rocket.timeTicking, true);

    [HarmonyPrefix]
    [HarmonyPatch(nameof(RocketLauncher.Shoot))]
    public static void ShootPrefix(RocketLauncher __instance)
        => EventRelay.Emit(Id.Player.Rocket.shoot, EventPos.Player);

    [HarmonyPrefix]
    [HarmonyPatch(nameof(RocketLauncher.ShootCannonball))]
    public static void ShootCannonballPrefix(RocketLauncher __instance)
        => EventRelay.Emit(Id.Player.Rocket.shootCannonball, EventPos.Player);

    [HarmonyPrefix]
    [HarmonyPatch(nameof(RocketLauncher.FreezeRockets))]
    public static void FreezeRocketsPrefix(RocketLauncher __instance)
        => EventRelay.Emit(Id.Player.Rocket.freezeRockets, EventPos.Player);

    [HarmonyPrefix]
    [HarmonyPatch(nameof(RocketLauncher.UnfreezeRockets))]
    public static void UnfreezeRocketsPrefix(RocketLauncher __instance)
        => EventRelay.Emit(Id.Player.Rocket.unfreezeRockets, EventPos.Player);

    [HarmonyPrefix]
    [HarmonyPatch(nameof(RocketLauncher.ShootNapalm))]
    public static void ShootNapalmPrefix(RocketLauncher __instance)
        => EventRelay.Emit(Id.Player.Rocket.shootNapalm, EventPos.Player);
}