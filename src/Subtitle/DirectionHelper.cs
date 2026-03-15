using UnityEngine;

namespace weluvsubtitle.Subtitle;

public static class DirectionHelper
{
    public enum SoundDirection
    {
        Front,
        FrontLeft,
        FrontRight,
        Back,
        BackLeft,
        BackRight,
        Left,
        Right,
        Above,
        Below,
        Unknown
    }

    public static SoundDirection GetDirection(Vector3 soundPos)
    {
        var tracker = MonoSingleton<PlayerTracker>.Instance;
        if (tracker == null) return SoundDirection.Unknown;

        var playerTransform = tracker.Transform;
        if (playerTransform == null) return SoundDirection.Unknown;

        var dir = soundPos - playerTransform.position;
        var localDir = playerTransform.InverseTransformDirection(dir);

        var verticalAngle = Mathf.Atan2(localDir.y, new Vector2(localDir.x, localDir.z).magnitude) * Mathf.Rad2Deg;
        if (verticalAngle > 45f)  return SoundDirection.Above;
        if (verticalAngle < -45f) return SoundDirection.Below;

        var angle = Mathf.Atan2(localDir.x, localDir.z) * Mathf.Rad2Deg;
        return angle switch
        {
            > 157.5f or <= -157.5f => SoundDirection.Back,
            > 112.5f               => SoundDirection.BackRight,
            > 67.5f                => SoundDirection.Right,
            > 22.5f                => SoundDirection.FrontRight,
            > -22.5f               => SoundDirection.Front,
            > -67.5f               => SoundDirection.FrontLeft,
            > -112.5f              => SoundDirection.Left,
            > -157.5f              => SoundDirection.BackLeft,
            _                      => SoundDirection.Back,
        };
    }

    public static string ToLabel(this SoundDirection direction) => direction switch
    {
        SoundDirection.Front      => "↑",
        SoundDirection.FrontLeft  => "↖",
        SoundDirection.FrontRight => "↗",
        SoundDirection.Back       => "↓",
        SoundDirection.BackLeft   => "↙",
        SoundDirection.BackRight  => "↘",
        SoundDirection.Left       => "←",
        SoundDirection.Right      => "→",
        SoundDirection.Above      => "Above",
        SoundDirection.Below      => "Under",
        _                         => string.Empty
    };
}