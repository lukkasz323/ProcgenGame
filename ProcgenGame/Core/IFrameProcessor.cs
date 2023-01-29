namespace ProcgenGame.Core;

/// <summary>
/// Defines a basic frame processor.
/// </summary>
public interface IFrameProcessor
{
    /// <summary>
    /// Process the current frame.
    /// </summary>
    /// <param name="gameTime">The current <see cref="GameTime"/>.</param>
    void Process(GameTime gameTime);
}