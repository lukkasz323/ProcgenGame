namespace ProcgenGame.Core;

public static class Utils
{
    public static IReadOnlyDictionary<Direction, Point> DirectionToPosition { get; } = new Dictionary<Direction, Point>()
    {
        { Direction.North, new Point(0, -1) },
        { Direction.South, new Point(0, 1) },
        { Direction.West, new Point(-1, 0) },
        { Direction.East, new Point(1, 0) },
    };

    public static Vector2 Abs(Vector2 v) => new(Math.Abs(v.X), Math.Abs(v.Y));
}