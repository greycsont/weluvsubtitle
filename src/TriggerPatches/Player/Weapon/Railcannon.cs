using HarmonyLib;

using weluvsubtitle.Relay;
using weluvsubtitle.Attributes;

namespace weluvsubtitle.TriggerPatches.Weapon;

[PatchOnEntry]
[HarmonyPatch(typeof(Railcannon))]
public static class RailcannonPatch
{
    [HarmonyPrefix]
    [HarmonyPatch(nameof(Railcannon.Shoot))]
    public static void ShootPrefix(Railcannon __instance)
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

[PatchOnEntry]
[HarmonyPatch(typeof(WeaponCharges))]
public static class WeaponChargesPatch
{
    [HarmonyPrefix]
    [HarmonyPatch(nameof(WeaponCharges.PlayRailCharge))]
    public static void PlayRailChargePrefix(WeaponCharges __instance)
        => EventRelay.Emit(Id.Player.Railcannon.maxCharge, __instance.transform.position);
}