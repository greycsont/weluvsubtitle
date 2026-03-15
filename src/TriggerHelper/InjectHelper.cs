using UnityEngine;
using weluvsubtitle.Relay;

namespace weluvsubtitle.TriggerHelper;

public static class InjectHelper
{
    public static void InjectObserver(Component target, string id, bool isPlayerSource = false)
    {
        if (target == null) return;

        var go = target.gameObject;

        if (go.GetComponent<AudioSource>() == null)
        {
            LogHelper.LogWarning($"「{go.name}」上找不到 AudioSource, 跳过注入 {id}");
            return;
        }

        var observer = go.GetComponent<AudioPlayObserver>()
                    ?? go.AddComponent<AudioPlayObserver>();

        observer.id = id;
        observer.isPlayerSource = isPlayerSource;
        LogHelper.LogInfo($"「{go.name}」已注入 {id}");
    }

    public static void InjectObserver(GameObject go, string id, bool isPlayerSource = false)
        => InjectObserver(go?.transform, id, isPlayerSource);
}