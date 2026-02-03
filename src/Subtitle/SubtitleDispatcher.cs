using UnityEngine.EventSystems;
using weluvsubtitle.Relay;


namespace weluvsubtitle.Subtitle;

public static class SubtitleDispatcher
{
    static SubtitleDispatcher()
    {
        EventRelay.OnIdentifierTriggered += ProcessSignal;
    }

    public static void ProcessSignal(string identifier)
    {
        SubtitleManager.ShowSubtitle(identifier);
    }
}