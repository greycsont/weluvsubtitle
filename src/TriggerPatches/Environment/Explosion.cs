using HarmonyLib;

using weluvsubtitle.Relay;
using weluvsubtitle.Attributes;

namespace weluvsubtitle.TriggerPatches.Environment;

[PatchOnEntry]
[HarmonyPatch(typeof(Explosion))]
public static class ExplosionPatch
{
    [HarmonyPrefix]
    [HarmonyPatch(nameof(Explosion.Start))]
    public static void StartPrefix(Explosion __instance)
        => EventRelay.Emit(Id.Environment.explosion, __instance.transform.position);
}