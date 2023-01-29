namespace ProcgenGame.Core;

public static class GlobalState
{
    static int _autoId;

    public static int Flags { get; set; }

    public static int AutoId() => Interlocked.Increment(ref _autoId);
}