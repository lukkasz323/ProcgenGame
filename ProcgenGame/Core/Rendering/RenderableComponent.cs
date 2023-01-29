namespace ProcgenGame.Core.Rendering;

/// <summary>
/// Represents a component that can be rendered.
/// </summary>
public abstract class RenderableComponent : Component, IUpdatable, IRenderable
{
    public abstract void Render(SpriteBatch spriteBatch);
    public abstract void Update(float deltaTime);
}
