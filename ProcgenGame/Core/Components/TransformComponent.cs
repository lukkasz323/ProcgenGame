namespace ProcgenGame.Core.Components;

sealed class TransformComponent : Component
{
    public Vector2 Position { get; set; }
    public int Size { get; set; }
}
