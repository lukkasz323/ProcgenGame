namespace ProcgenGame.Core;

public static class GlobalState
{
    static int _autoId = -1;

    public static int Flags { get; set; }

    public static int AutoId() => Interlocked.Increment(ref _autoId);
}