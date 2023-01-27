namespace ProcgenGame.Core.Components;

public class DrawComponent : Component
{
    public TextureName TextureName { get; set; } = TextureName.White;
    public Color Color { get; set; } = Color.Red;
}
