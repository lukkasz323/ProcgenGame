namespace ProcgenGame.Core;

sealed class AssetStorage
{
    public Dictionary<FontName, SpriteFont> Fonts { get; } = new();
    public Dictionary<TextureName, Texture2D> Textures { get; } = new();
}


