using HarmonyLib;

using weluvsubtitle.Relay;
using weluvsubtitle.TriggerHelper;
using weluvsubtitle.Attributes;

namespace weluvsubtitle.TriggerPatches.Weapon;

[PatchOnEntry]
[HarmonyPatch(typeof(ShotgunHammer))]
public static class ShotgunHammerPatch
{
    [HarmonyPostfix]
    [HarmonyPatch(nameof(ShotgunHammer.Awake))]
    public static void AwakePostfix(ShotgunHammer __instance)
        => InjectHelper.InjectObserver(__instance.hitSound, Id.Player.ShotgunHammer.hit, true);

    [HarmonyPrefix]
    [HarmonyPatch(nameof(ShotgunHammer.ThrowNade))]
    public static void ThrowNadePrefix(ShotgunHammer __instance)
        => EventRelay.Emit(Id.Player.ShotgunHammer.throwNade, EventPos.Player);

    [HarmonyPrefix]
    [HarmonyPatch(nameof(ShotgunHammer.ShootSaw))]
    public static void ShootSawPrefix(ShotgunHammer __instance)
        => EventRelay.Emit(Id.Player.ShotgunHammer.shootSaw, EventPos.Player);

    [HarmonyPostfix]
    [HarmonyPatch(nameof(ShotgunHammer.Pump))]
    public static void PumpPostfix(ShotgunHammer __instance)
    {
        var id = __instance.primaryCharge switch
        {
            1 => Id.Player.ShotgunHammer.pumpLevel1,
            2 => Id.Player.ShotgunHammer.pumpLevel2,
            _ => Id.Player.ShotgunHammer.pumpLevel3
        };
        EventRelay.Emit(id, EventPos.Player);
    }

    //[HarmonyPrefix]
    //[HarmonyPatch(nameof(ShotgunHammer.DeliverDamage))]
}