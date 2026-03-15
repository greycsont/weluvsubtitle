using HarmonyLib;

using weluvsubtitle.Relay;
using weluvsubtitle.Attributes;


namespace weluvsubtitle.TriggerPatches.Weapon;

[PatchOnEntry]
[HarmonyPatch(typeof(Nailgun))]
public static class NailgunAndSawblade
{
    [HarmonyPrefix]
    [HarmonyPatch(nameof(Nailgun.Shoot))]
    public static void ShootPrefix(Nailgun __instance)
    {
        if (__instance.altVersion)
            EventRelay.Emit(Id.Player.Nailgun.shootSaw, EventPos.Player);
        else
            EventRelay.Emit(Id.Player.Nailgun.shootNail, EventPos.Player);
    }

    [HarmonyPrefix]
    [HarmonyPatch(nameof(Nailgun.ShootZapper))]
    public static void ShootZapperPrefix(Nailgun __instance)
        => EventRelay.Emit(Id.Player.Nailgun.shootZapper, EventPos.Player);

    [HarmonyPrefix]
    [HarmonyPatch(nameof(Nailgun.SuperSaw))]
    public static void SuperSawPrefix(Nailgun __instance)
        => EventRelay.Emit(Id.Player.Nailgun.superSaw, EventPos.Player);

    // 这个没用？
    [HarmonyPrefix]
    [HarmonyPatch(nameof(Nailgun.BurstFire))]
    public static void BurstFirePrefix(Nailgun __instance)
        => EventRelay.Emit(Id.Player.Nailgun.burstFire, EventPos.Player);

    [HarmonyPrefix]
    [HarmonyPatch(nameof(Nailgun.ShootMagnet))]
    public static void ShootMagnetPrefix(Nailgun __instance)
        => EventRelay.Emit(Id.Player.Nailgun.shootMagnet, EventPos.Player);
}