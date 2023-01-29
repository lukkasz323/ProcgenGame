namespace ProcgenGame.Core.Rendering;

public sealed class RenderingProcessor : IFrameProcessor
{
    private readonly GraphicsDeviceManager _graphics;
    private readonly RenderingOptions _options;
    private readonly SpriteBatch _spriteBatch;
    public RenderingProcessor(RenderingOptions options, GraphicsDeviceManager graphics, SpriteBatch spriteBatch)
    {
        _options = options;
        _graphics = graphics;
        _spriteBatch = spriteBatch;
    }
    public void Process(GameTime gameTime)
    {
        throw new NotImplementedException();
    }
}