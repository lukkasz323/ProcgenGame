namespace ProcgenGame.Core;

public static class Debug
{
    public static dynamic A { get; set; }
    public static dynamic B { get; set; }
    public static dynamic C { get; set; }

    public static void ExpensiveNothing(int operations = 9_000_000) 
    {
        for (int i = 0; i < operations; i++) ;
    }
}
