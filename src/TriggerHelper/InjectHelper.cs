using UnityEngine;


namespace weluvsubtitle.TriggerPatches;

public static class InjectHelper
{
    public static void InjectObserver(GameObject prefab, string id)
    {
        if (prefab == null) return;

        // 拿到 AudioSource，没这个就没法监控
        var source = prefab.GetComponent<AudioSource>();
        if (source == null) return;

        // 挂载你的监控脚本
        var observer = prefab.GetComponent<AudioPlayObserver>();
        if (observer == null)
        {
            observer = prefab.AddComponent<AudioPlayObserver>();
        }
        observer.signalId = id;
    
        // 强制把这个 AudioSource 设为 3D 声音，否则你的 Vector3 坐标没意义
        // (虽然 ULTRAKILL 默认通常就是 3D 的)
        //source.spatialBlend = 1.0f; 
    }
}