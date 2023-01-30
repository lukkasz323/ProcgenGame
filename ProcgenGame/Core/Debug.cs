namespace ProcgenGame.Core;

public static class Debug
{
    public static dynamic? A { get; set; }
    public static dynamic? B { get; set; }
    public static dynamic? C { get; set; }

    public static void ExpensiveNothing(int operations = 9_000_000)
    {
        for (int i = 0; i < operations; i++) ;
    }
}

//var keyToState = new Dictionary<Keys, StateFlags>
//{
//    { Keys.W, StateFlags.Up },
//    { Keys.S, StateFlags.Down },
//    { Keys.A, StateFlags.Left },
//    { Keys.D, StateFlags.Right },
//};

//StateFlags state = StateFlags.None;
//foreach(var (k, v) in keyToState)
//{
//    if (keyboard.IsKeyDown(k)) state |= v;
//}