namespace ProcgenGame.Core.Components;

sealed class DrawComponent : Component
{
    public TextureName TextureName { get; set; } = TextureName.White;
    public Color Color { get; set; } = Color.White;
}
