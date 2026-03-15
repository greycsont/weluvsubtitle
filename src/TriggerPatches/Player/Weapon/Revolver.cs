using HarmonyLib;

using weluvsubtitle.Relay;
using weluvsubtitle.Attributes;

namespace weluvsubtitle.TriggerPatches.Weapon;

[PatchOnEntry]
[HarmonyPatch(typeof(Revolver))]
public static class RevolverPatch
{
    [HarmonyPrefix]
    [HarmonyPatch(nameof(Revolver.Shoot))]
    public static void ShootPrefix(int shotType, Revolver __instance)
    {
        switch (shotType)
        {
            case 1:
                EventRelay.Emit(Id.Player.Revolver.shootBeam, __instance.transform.position);
                break;
            case 2:
                if (__instance.gunVariation == 0)
                    EventRelay.Emit(Id.Player.Revolver.shootPiercerBeam, __instance.transform.position);
                if (__instance.gunVariation == 2)
                    EventRelay.Emit(Id.Player.Revolver.shootSharpShooterBeam, __instance.transform.position);
                break;
        }
    }
}