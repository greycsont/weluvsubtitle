using System;

using UnityEngine;
using weluvsubtitle.Subtitle;

namespace weluvsubtitle.Relay;


public static class EventRelay
{
    public static void Emit(string id, Vector3 pos) => SubtitleDispatcher.ProcessSignal(id, pos);
}