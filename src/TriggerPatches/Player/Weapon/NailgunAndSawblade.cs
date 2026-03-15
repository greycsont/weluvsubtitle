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
            EventRelay.Emit(Id.Player.Nailgun.shootSaw, __instance.transform.position);
        else
            EventRelay.Emit(Id.Player.Nailgun.shootNail, __instance.transform.position);
    }

    [HarmonyPrefix]
    [HarmonyPatch(nameof(Nailgun.ShootZapper))]
    public static void ShootZapperPrefix(Nailgun __instance)
        => EventRelay.Emit(Id.Player.Nailgun.shootZapper, __instance.transform.position);

    [HarmonyPrefix]
    [HarmonyPatch(nameof(Nailgun.SuperSaw))]
    public static void SuperSawPrefix(Nailgun __instance)
        => EventRelay.Emit(Id.Player.Nailgun.superSaw, __instance.transform.position);

    // 这个没用？
    [HarmonyPrefix]
    [HarmonyPatch(nameof(Nailgun.BurstFire))]
    public static void BurstFirePrefix(Nailgun __instance)
        => EventRelay.Emit(Id.Player.Nailgun.burstFire, __instance.transform.position);

    [HarmonyPrefix]
    [HarmonyPatch(nameof(Nailgun.ShootMagnet))]
    public static void ShootMagnetPrefix(Nailgun __instance)
        => EventRelay.Emit(Id.Player.Nailgun.shootMagnet, __instance.transform.position);
}