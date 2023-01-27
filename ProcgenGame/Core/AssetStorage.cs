namespace ProcgenGame.Core;

public record AssetStorage(
        Dictionary<FontName, SpriteFont> Fonts, 
        Dictionary<TextureName, Texture2D> Textures);
