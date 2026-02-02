using GameConsole;
using HarmonyLib;

namespace weluvsubtitle.Commands;

[HarmonyPatch(typeof(Console))]
public class ConsolePatcher
{
    [HarmonyPrefix]
    [HarmonyPatch(nameof(Console.Awake))]
    public static void AddConsoleCommands(Console __instance)
        => __instance.RegisterCommand(new CommandsToRegister(__instance));
}