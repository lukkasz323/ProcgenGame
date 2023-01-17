namespace ProcgenGame;

public class Player
{
    public int Size { get; } = 32;
    public Rectangle Rectangle { get; private set; }

    public Player(Level level)
    {
        Rectangle = new Rectangle(level.Center.x - (Size / 2), -3 * level.TileSize + level.Center.y - (Size / 2), Size, Size);
    }
}
