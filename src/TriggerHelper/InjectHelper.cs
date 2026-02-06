using UnityEngine;


namespace weluvsubtitle.TriggerHelper;

public static class InjectHelper
{
    public static void InjectObserver(GameObject prefab, string id)
    {
        Plugin.log.LogInfo($"给{prefab.name}挂{id}");
        if (prefab == null) return;

        var source = prefab.GetComponent<AudioSource>();
        if (source == null) return;

        var observer = prefab.GetComponent<AudioPlayObserver>();
        if (observer == null)
        {
            observer = prefab.AddComponent<AudioPlayObserver>();
        }
        observer.id = id;
        
        Plugin.log.LogInfo("挂好了");

    }
    
    public static void InjectObserver(Component target, string id)
    {
        if (target == null) return;
        
        GameObject prefabObj = target.gameObject;
    
        Plugin.log.LogInfo($"给{prefabObj.name}挂{id}");

        var source = prefabObj.GetComponent<AudioSource>();
        if (source == null) 
        {
            Plugin.log.LogWarning($"{prefabObj.name} 上找不到 AudioSource");
            return;
        }

        var observer = prefabObj.GetComponent<AudioPlayObserver>() 
                       ?? prefabObj.AddComponent<AudioPlayObserver>();
    
        observer.id = id;
        Plugin.log.LogInfo("挂好了");
    }
}