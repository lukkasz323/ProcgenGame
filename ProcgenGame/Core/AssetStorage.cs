namespace ProcgenGame.Core;

public class AssetStorage
{
    public Dictionary<FontName, SpriteFont> Fonts { get; } = new();
    public Dictionary<TextureName, Texture2D> Textures { get; } = new();
}


