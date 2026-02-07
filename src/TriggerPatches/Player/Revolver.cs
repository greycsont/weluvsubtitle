using System.Collections.Generic;
using System.Reflection.Emit;
using HarmonyLib;

using weluvsubtitle.Relay;
using weluvsubtitle.TriggerHelper;
using weluvsubtitle.Attributes;

namespace weluvsubtitle.TriggerPatches.Player;

[PatchOnEntry]
[HarmonyPatch(typeof(Revolver))]
public static class RevolverPatch
{
    [HarmonyTranspiler]
    [HarmonyPatch(nameof(Revolver.Shoot))]
    public static IEnumerable<CodeInstruction> ShootTranspiler(IEnumerable<CodeInstruction> instructions)
     => ILHelper.WrapWithActionAtStart(instructions, AccessTools.Method(typeof(RevolverPatch), nameof(ShootPatch)), new CodeInstruction(OpCodes.Ldarg_1));
    
    public static void ShootPatch(int shotType, Revolver __instance)
    {
        switch (shotType)
        {
            case 1:
                EventRelay.Emit(Id.Player.Revolver.shootBeam,  __instance.transform.position);
                break;
            case 2:
                if (__instance.gunVariation == 0)
                    EventRelay.Emit(Id.Player.Revolver.shootPiercerBeam,  __instance.transform.position);
                if (__instance.gunVariation == 2)
                    EventRelay.Emit(Id.Player.Revolver.shootSharpShooterBeam, __instance.transform.position);
                break;
        }
    }
}