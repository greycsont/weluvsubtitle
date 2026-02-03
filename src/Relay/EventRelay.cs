using System;

namespace weluvsubtitle.Relay;


public static class EventRelay
{
    public static event Action<string> OnIdentifierTriggered;

    public static void Emit(string id) => OnIdentifierTriggered?.Invoke(id);
}