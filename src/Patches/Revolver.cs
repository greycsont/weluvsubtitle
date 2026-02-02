using HarmonyLib;

namespace weluvsubtitle.Patches;

[HarmonyPatch(typeof(Revolver))]
public static class RevolverPatch
{
    [HarmonyPrefix]
    [HarmonyPatch(nameof(Revolver.Shoot))]
    public static void ShootPatch(ref int shotType)
    {
        switch (shotType)
        {
            case 0:
                break;
            case 1 :
                break;
        }
    }
}