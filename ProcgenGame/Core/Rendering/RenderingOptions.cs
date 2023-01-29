namespace ProcgenGame.Core.Rendering;

/// <summary>
/// Defines the options for rendering.
/// </summary>
public sealed class RenderingOptions
{
    /// <summary>
    /// The color of the font utilized for rendering text.
    /// </summary>
    public Color FontColor { get; set; }
    /// <summary>
    /// Creates a new <see cref="RenderingOptions"/> instance.
    /// </summary>
    public RenderingOptions() =>
        FontColor = Color.White;
}