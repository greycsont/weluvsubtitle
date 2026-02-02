using HarmonyLib;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace weluvsubtitle.Relay;

public static class PatchUtils
{
    public static void InjectEmit(List<CodeInstruction> codes, int index, string id)
    {
        // 插入：Ldstr "your_id"
        codes.Insert(index, new CodeInstruction(OpCodes.Ldstr, id));
        // 插入：Call RelayHelper.Emit(string)
        codes.Insert(index + 1, new CodeInstruction(
            OpCodes.Call, 
            AccessTools.Method(typeof(RelayHelper), nameof(RelayHelper.Emit))
        ));
    }
}