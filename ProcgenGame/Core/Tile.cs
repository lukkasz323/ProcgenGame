namespace ProcgenGame.Core;

public class Tile
{
    public Rectangle Rectangle { get; private set; }
    public int Type { get; private set; }

    public Tile(int type, Rectangle rectangle)
    {
        Type = type;
        Rectangle = rectangle;
    }
}
