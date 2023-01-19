namespace ProcgenGame.Core;

public class Scene
{
    public int TileSize { get; } = 64;
    public Room Room { get; private set; }
    public Player Player { get; private set; }

    public Scene()
    {
        Room = new(this);
        Player = new(new Vector2(0, -3), this);
    }
}