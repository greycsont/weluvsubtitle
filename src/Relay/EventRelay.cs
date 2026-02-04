using System;

using UnityEngine;

namespace weluvsubtitle.Relay;


public static class EventRelay
{
    public static event Action<string, Vector3> OnIdentifierTriggered;

    public static void Emit(string id, Vector3 pos) => OnIdentifierTriggered?.Invoke(id, pos);
}