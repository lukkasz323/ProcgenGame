namespace ProcgenGame.Core.Components;

sealed class PhysicsComponent : Component
{
    public float Speed { get; set; }
    public Vector2 Velocity { get; set; }
    public Vector2 Acceleration { get; set; }
}
