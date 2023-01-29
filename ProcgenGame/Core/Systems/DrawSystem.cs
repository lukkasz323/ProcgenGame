using ProcgenGame.Core.Components;
using ProcgenGame.Core.Scene;

namespace ProcgenGame.Core.Systems;

class DrawSystem : IUpdateSystem
{
    readonly Game1 _game;
    readonly GameScene _scene;
    readonly SpriteBatch _batch;
    readonly Dictionary<FontName, SpriteFont> _fonts;
    readonly Dictionary<TextureName, Texture2D> _textures;
    readonly ComponentRegister _componentRegister;
    readonly List<DrawComponent> _drawComponents;
    readonly List<TransformComponent> _transformComponents;

    public DrawSystem(Game1 game)
    {
        _game = game;
        _scene = game.Scene;
        _batch = game.SpriteBatch;
        _fonts = game.Assets.Fonts;
        _textures = game.Assets.Textures;
        _textures = game.Assets.Textures;
        _componentRegister = game.Scene.ComponentRegister;
        _drawComponents = _componentRegister.GetComponentsOfType<DrawComponent>();
        _transformComponents = _componentRegister.GetComponentsOfType<TransformComponent>();
    }

    public void Process(GameTime gameTime)
    {
        _game.GraphicsDevice.Clear(Color.White * 0.05f);

        _batch.Begin();

        DrawRoom();
        DrawEntities();
        DrawDebugInfo(gameTime);

        _batch.End();
    }

    void DrawDebugInfo(GameTime gameTime)
    {
        Color fontColor = Color.White;
        int fps = (int)(1 / gameTime.ElapsedGameTime.TotalSeconds);

        _batch.DrawString(_fonts[FontName.Default], $"{fps}", new Vector2(4, 0), fontColor);
        //_batch.DrawString(_fonts[FontName.Default], $"P: {_scene.Player.Position}", new Vector2(4, 20), fontColor);
        //_batch.DrawString(_fonts[FontName.Default], $"V: {_scene.Player.Velocity}", new Vector2(4, 40), fontColor);

        _batch.DrawString(_fonts[FontName.Default], $"A: {Debug.A}", new Vector2(4, 640), fontColor);
        _batch.DrawString(_fonts[FontName.Default], $"B: {Debug.B}", new Vector2(4, 660), fontColor);
        _batch.DrawString(_fonts[FontName.Default], $"C: {Debug.C}", new Vector2(4, 680), fontColor);
    }

    void DrawRoom()
    {
        foreach (Tile tile in _scene.Room.Tiles)
        {
            Texture2D texture = _textures[(TextureName)Enum.ToObject(typeof(TextureName), tile.Type)];

            _batch.Draw(texture, tile.Rectangle, Color.White);
        }
    }

    void DrawEntities()
    {
        foreach ((DrawComponent draw, TransformComponent transform) in _drawComponents.Zip(_transformComponents))
        {
            _batch.Draw(
                texture: _textures[draw.TextureName],
                destinationRectangle: new Rectangle(
                    x: (int)transform.Position.X,
                    y: (int)transform.Position.Y,
                    width: transform.Size,
                    height: transform.Size),
                color: draw.Color);
        }
    }
}