namespace ProcgenGame.Core.Scene;

sealed class Tile
{
    public Rectangle Rectangle { get; set; }
    public int Type { get; set; }

    public Tile(int type, Rectangle rectangle)
    {
        Type = type;
        Rectangle = rectangle;
    }
}
