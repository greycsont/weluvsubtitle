using System.Collections.Generic;
using UnityEngine;

using weluvsubtitle.Relay;


namespace weluvsubtitle.Subtitle;

public static class SubtitleDispatcher
{
    static SubtitleDispatcher()
    {
        EventRelay.OnIdentifierTriggered += ProcessSignal;
    }

    public static void ProcessSignal(string id, Vector3 pos = default)
    {
        SubtitleProvider.GetContent(id, out var text);
        SubtitleDisplay.ShowSubtitle(text ?? id);
    }
}