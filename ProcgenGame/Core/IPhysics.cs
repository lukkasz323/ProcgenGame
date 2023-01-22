namespace ProcgenGame.Core;

public interface IPhysics : IEntity
{
    public Vector2 Position { get; set; }
    public Vector2 Velocity { get; set; }
    public int Size { get; set; }
    public int Speed { get; set; }
}
