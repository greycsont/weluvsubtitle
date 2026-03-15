using HarmonyLib;

using weluvsubtitle.Relay;
using weluvsubtitle.Attributes;

namespace weluvsubtitle.TriggerPatches.Environment;

[PatchOnEntry]
[HarmonyPatch(typeof(Landmine))]
public static class LandMinePatch
{
    [HarmonyPrefix]
    [HarmonyPatch(nameof(Landmine.Activate))]
    public static void ActivatePrefix(Landmine __instance)
        => EventRelay.Emit(Id.Environment.activateLandMine, __instance.transform.position);
}