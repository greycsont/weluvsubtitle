using UnityEngine;


public static class EventPos
{
    /// <summary>
    /// 表示事件由玩家自身触发，不需要显示方向标签。
    /// </summary>
    public static readonly Vector3 Player = Vector3.positiveInfinity;

    public static bool IsPlayer(Vector3 pos)
        => pos == Vector3.positiveInfinity;
}