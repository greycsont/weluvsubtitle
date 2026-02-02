namespace weluvsubtitle.Relay;

public static class RelayHelper
{
    // 这个方法专门供 IL 指令 Call 调用
    public static void Emit(string id) => EventRelay.Emit(id);
}