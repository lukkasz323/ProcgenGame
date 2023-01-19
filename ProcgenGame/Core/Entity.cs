namespace ProcgenGame.Core;

public abstract class Entity
{
    public int Size { get; } = 32;
    public Vector2 Position { get; private set; }

    public Entity(Vector2 spawnOffset, Scene scene)
    {
        Position = new Vector2(
            spawnOffset.X * scene.TileSize + scene.Room.Center.X - Size / 2,
            spawnOffset.Y * scene.TileSize + scene.Room.Center.Y - Size / 2);
    }
}