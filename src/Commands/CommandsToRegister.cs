using GameConsole;
using GameConsole.CommandTree;
using plog;

using weluvsubtitle.Subtitle;
using weluvsubtitle.Relay;

namespace weluvsubtitle.Commands;

public sealed class CommandsToRegister(Console con) : CommandRoot(con), IConsoleLogger
{
    public override string Name => "weluv";
    
    public override string Description => "tons of setting";
    
    public Logger Log { get; } = new("weluv");
    
    public override Branch BuildTree(Console con)
        => Branch(Name,
            Leaf<string>("sb", s => SubtitleDisplay.ShowSubtitle(s)),
            Leaf<string>("sbid", s => SubtitleDispatcher.ProcessSignal(s))
        );
}