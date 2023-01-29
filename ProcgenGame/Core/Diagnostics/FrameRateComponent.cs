using ProcgenGame.Core.Rendering;

namespace ProcgenGame.Core.Diagnostics;

public sealed class FrameRateComponent : RenderableComponent
{
    private byte _frameRate;
    private readonly Color _color;
    private readonly Vector2 _position;
    private readonly SpriteFont _font;
    public FrameRateComponent(Vector2 position, Color color, SpriteFont font)
    {
        _font = font;
        _color = color;
        _position = position;
    }
    public override void Render(SpriteBatch spriteBatch) =>
        spriteBatch.DrawString(_font, _frameRate.ToString(), _position, _color);
    public override void Update(float deltaTime) =>
        _frameRate = (byte)(1 / deltaTime);
}