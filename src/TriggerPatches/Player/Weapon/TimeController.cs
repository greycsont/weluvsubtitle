using HarmonyLib;

using weluvsubtitle.Relay;
using weluvsubtitle.Attributes;

namespace weluvsubtitle.TriggerPatches.Weapon;

[PatchOnEntry]
[HarmonyPatch(typeof(TimeController))]
public static class TimeControllerPatch
{
    [HarmonyPrefix]
    [HarmonyPatch(nameof(TimeController.ParryFlash))]
    public static void ParryFlashPrefix(TimeController __instance)
        => EventRelay.Emit(Id.Player.NewMovement.parry, EventPos.Player);
}