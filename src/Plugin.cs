using BepInEx;
using BepInEx.Logging;
using UnityEngine;
using HarmonyLib;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System;
using weluvsubtitle.Attributes;
using weluvsubtitle.Subtitle;

namespace weluvsubtitle;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    internal static ManualLogSource log { get; private set; } = null;
        
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
    { 
        var harmony = new Harmony(MyPluginInfo.PLUGIN_GUID);

        foreach (var type in typeof(Plugin).Assembly.GetTypes())
        {
            if (type.GetCustomAttribute<PatchOnEntryAttribute>() != null)
            {
                try
                {
                    harmony.PatchAll(type);
                }
                catch (Exception e)
                {
                    Plugin.log.LogError($"FUCK PATCHING {type.Name}, {e}");
                    throw;
                }
            }
        }
    }
}
