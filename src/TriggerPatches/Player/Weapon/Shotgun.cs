using HarmonyLib;

using weluvsubtitle.Relay;
using weluvsubtitle.Attributes;

namespace weluvsubtitle.TriggerPatches.Weapon;

[PatchOnEntry]
[HarmonyPatch(typeof(Shotgun))]
public static class ShotgunPatch
{
    [HarmonyPrefix]
    [HarmonyPatch(nameof(Shotgun.Shoot))]
    public static void ShootPrefix(Shotgun __instance)
        => EventRelay.Emit(Id.Player.Shotgun.shoot, __instance.transform.position);

    [HarmonyPrefix]
    [HarmonyPatch(nameof(Shotgun.ShootSinks))]
    public static void ShootSinkPrefix(Shotgun __instance)
        => EventRelay.Emit(Id.Player.Shotgun.shootSink, __instance.transform.position);

    [HarmonyPrefix]
    [HarmonyPatch(nameof(Shotgun.ShootSaw))]
    public static void ShootSawPrefix(Shotgun __instance)
        => EventRelay.Emit(Id.Player.Shotgun.shootSaw, __instance.transform.position);

    [HarmonyPostfix]
    [HarmonyPatch(nameof(Shotgun.Pump))]
    public static void PumpPostfix(Shotgun __instance)
    {
        var pos = __instance.transform.position;
        var id = __instance.primaryCharge switch
        {
            1 => Id.Player.Shotgun.pumpLevel1,
            2 => Id.Player.Shotgun.pumpLevel2,
            _ => Id.Player.Shotgun.pumpLevel3
        };
        EventRelay.Emit(id, pos);
    }
}