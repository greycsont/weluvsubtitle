using System.Collections.Generic;

namespace weluvsubtitle.Subtitle;

public static class SubtitleProvider
{
    private static Dictionary<string, string> _textDB = new Dictionary<string, string>();

    public static void GetContent(string id, out string text)
    {
        _textDB.TryGetValue(id, out text);
    }
}