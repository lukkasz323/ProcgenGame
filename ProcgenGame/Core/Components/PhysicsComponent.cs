namespace ProcgenGame.Core.Components;

sealed class PhysicsComponent : Component
{
    public Vector2 Velocity { get; set; }
    public int Speed { get; set; }
}
