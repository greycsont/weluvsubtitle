using BepInEx;
using BepInEx.Logging;
using UnityEngine;
using HarmonyLib;

namespace weluvsubtitle;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    internal static new ManualLogSource log { get; private set; } = null!;

    private static Harmony _harmony = new Harmony(MyPluginInfo.PLUGIN_GUID);
        
    private void Awake()
    {
        // Plugin startup logic
        log = base.Logger;
        log.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
        gameObject.hideFlags = HideFlags.DontSaveInEditor;
        LoadMainModule();
        PatchHarmony();
    }

    private void LoadMainModule()
    {
        
    }

    private void PatchHarmony()
        => _harmony.PatchAll();
}
