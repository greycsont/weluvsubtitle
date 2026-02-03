using GameConsole;
using GameConsole.CommandTree;
using plog;

using weluvsubtitle.Subtitle;

namespace weluvsubtitle.Commands;

public sealed class CommandsToRegister(Console con) : CommandRoot(con), IConsoleLogger
{
    public override string Name => "weluv";
    
    public override string Description => "tons of setting";
    
    public Logger Log { get; } = new("weluv");
    
    public override Branch BuildTree(Console con)
        => Branch(Name,
            Leaf<string>("sb", SubtitleManager.ShowSubtitle),
            Leaf<string>("sbid", SubtitleDispatcher.ProcessSignal)
        );
}