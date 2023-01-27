namespace ProcgenGame.Core.Entities;

public interface IPhysics
{
    Vector2 Position { get; set; }
    Vector2 Velocity { get; set; }
    int Size { get; set; }
    int Speed { get; set; }
    TextureName TextureName { get; set; }
    Color Color { get; set; }
}
